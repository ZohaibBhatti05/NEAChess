﻿using Prototype5.Boards;
using Prototype5.Pieces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Prototype5.Boards
{
    class AI : Player
    {
        private string[][] openingMoves = new string[261487][]; // table contains 261487 opening lines
        private bool useOpening = true; // disable after move 16 or if no longer found

        private Move[][] killerMoves;
        private const int KILLER_MOVE_COUNT = 2;

        private int nodes;
        private int qNodes;
        private int ttWrites;
        private int ttReads;
        private int ttReadSuccess;

        private int plyDepth;
        private PlayerColour colour;
        private Move bestMove;

        bool useTransposition = true;
        private Zobrist hasher;
        private TranspositionTable transpositionTable;

        public AI(int plyDepth, PlayerColour colour) : base()
        {
            this.plyDepth = plyDepth;
            this.colour = colour;

            killerMoves = new Move[plyDepth][];
            for (int i = 0; i < plyDepth; i++)
            {
                killerMoves[i] = new Move[KILLER_MOVE_COUNT];
            }

            InitialiseTables();

            if (useTransposition)
            {
                transpositionTable = new TranspositionTable();
                hasher = new Zobrist();
            }
        }

        // method sets up the opening/ending tablebases
        private void InitialiseTables()
        {
            // open file
            string opPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + "/Tablebases/Openings.pgn";
            StreamReader reader = new StreamReader(opPath);

            for (int index = 0; index < 261487; index++)
            {
                openingMoves[index] = (reader.ReadLine()).Split(" "); // format array
            }

            reader.Close();
        }

        // method run by board when computer needs to make a move
        public Move MakeMove(ChessBoard board)
        {
            nodes = 0; qNodes = 0; ttReads = 0; ttWrites = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            bestMove = null;

            // Search opening table
            if (useOpening)
            {
                bool moveFound = SearchOpeningTable(board); // try to find the best move
                Console.WriteLine($"{stopwatch.Elapsed.ToString()} seconds spent on opening table");
                if (moveFound)
                {
                    return bestMove; // return move if found
                }
            }

            // intital Minimax call
            AlphaBeta(board, plyDepth, (colour == PlayerColour.White), int.MinValue, int.MaxValue, 0);

            Console.WriteLine($"Ply {plyDepth} + {QUIESCENCE_MAX_DEPTH} :: {nodes} nodes :: {qNodes} Q-Nodes in {stopwatch.Elapsed.ToString()} seconds");
            Console.WriteLine($"{ttReadSuccess} Successful TT Reads :: {ttReads} Total TT Reads :: {ttWrites} TT Writes");

            if (bestMove == null)
            {
                bestMove = board.AllPossibleMoves(colour)[0];
            }

            return bestMove;
        }

        // function attempts to make a move from the opening table
        private bool SearchOpeningTable(ChessBoard board)
        {
            string moveName = null;
            bool found = false; // bool for early termination

            // iterate through the opening table
            Parallel.ForEach(openingMoves, (moveString, loopState) =>
            {
                for (int i = 0; i < board.moveHistory.Count; i++)
                {
                    if (board.moveNameHistory[i] != moveString[i]) // if string doesnt match the game, ignore
                    {
                        break;
                    }
                    else if (i == board.moveNameHistory.Count - 1) // if all moves match
                    {
                        moveName = moveString[i + 1]; // get next move
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    loopState.Break(); // terminate loop early
                }
            });

            if (moveName != null) // if a move was found
            {
                List<Move> allMoves = board.AllPossibleMoves(colour); // get all possible moves
                foreach (Move move in allMoves)
                {
                    if (move.GetMoveName(board) == moveName)
                    {
                        bestMove = move; // match name to move, set move as best move
                        return true;
                    }
                }
            }
            else // no move found
            {
                useOpening = false;
                return false;
            }

            return false;
        }

        // minimax algorithm
        private int AlphaBeta(ChessBoard board, int currentDepth, bool max, int alpha, int beta, long hash)
        {
            int value;
            // return board value at final depth
            if (currentDepth == 0)
            {
                return Quiescence(board, max, 0, -beta, -alpha);
                //return board.BoardValue(max, plyDepth - currentDepth);
            }


            // check for entry in tt
            if (useTransposition && hash != 0)
            {
                if (transpositionTable.ContainsHash(hash)) // if hash exists in table, return its value
                {
                    ttReads++;
                    Transposition transposition = transpositionTable.GetTransposition(hash);
                    if (transposition.depth >= currentDepth) // only read if higher/equal depth
                    {
                        switch (transposition.type)
                        {
                            case TranspositionType.Exact:
                                ttReadSuccess++;
                                return transposition.value;
                            case TranspositionType.Beta:
                                alpha = Math.Max(alpha, transposition.value);
                                break;
                            case TranspositionType.Alpha:
                                beta = Math.Min(beta, transposition.value);
                                break;

                        }

                        if (alpha >= beta)
                        {
                            ttReadSuccess++;
                            return transposition.value;
                        }
                    }
                }
            }

            // null move
            if (currentDepth == plyDepth - 1) // root node
            {
                if (useTransposition)
                {
                    hash = hasher.HashFromBoard(board.board, max); // get hash
                }

                if (!(board.winStatus == WinStatus.WhiteCheck || board.winStatus == WinStatus.BlackCheck) && plyDepth > 3) // if not in check and on base nodes
                {
                    value = Quiescence(board, max, 0, -beta, -alpha);

                    if (value >= beta) // beta cutoff => return early
                    {
                        return value;
                    }
                }
            }

            nodes++;

            // generate moves
            List<Move> possibleMoves = ((max) ? board.AllPossibleMoves(PlayerColour.White) : board.AllPossibleMoves(PlayerColour.Black));
            if (possibleMoves.Count == 0)
            {
                return board.BoardValue(max, plyDepth - currentDepth);
            }

            OrderMoves(possibleMoves, currentDepth);

            currentDepth--;

            // white
            if (max)
            {
                Move bestMoveNode = null;
                value = int.MinValue;
                // for every possible move
                foreach (Move move in possibleMoves)
                {
                    board.MakeMove(move); // make the move
                    if (move.movingPiece is Pawn && move.positionTo.row == 7)
                    {
                        //continue;
                        board.AddPiece(new Queen(PlayerColour.White), move.positionTo);
                    }

                    board.UpdateWinStatus(PlayerColour.Black);

                    int newValue = AlphaBeta(board, currentDepth, false, alpha, beta, hasher.HashFromMove(hash, move, max));

                    if (newValue > value) // if better move found
                    {
                        value = newValue;
                        if (currentDepth == plyDepth - 1)
                        {
                            bestMove = move; // update best move
                        }
                        bestMoveNode = move;
                    }

                    // beta cutoff
                    if (value >= beta)
                    {
                        board.UndoMove(move);
                        AddKillerMove(currentDepth, move);
                        if (useTransposition) { transpositionTable.AddValue(hash, bestMoveNode, value, currentDepth, TranspositionType.Beta); ttWrites++; }
                        break;
                    }
                    alpha = Math.Max(value, alpha);
                    board.UndoMove(move); // undo the move
                }
                // add value to tt
                if (useTransposition) { transpositionTable.AddValue(hash, bestMoveNode, value, currentDepth, TranspositionType.Exact); ttWrites++; }

                return value;
            }
            // black
            else
            {
                Move bestMoveNode = null;
                value = int.MaxValue;
                // for every possible move
                foreach (Move move in possibleMoves)
                {
                    board.MakeMove(move); // make the move
                    if (move.movingPiece is Pawn && move.positionTo.row == 0)
                    {
                        board.AddPiece(new Queen(PlayerColour.Black), move.positionTo);
                        //continue;
                    }

                    board.UpdateWinStatus(PlayerColour.White);
                    int newValue = AlphaBeta(board, currentDepth, true, alpha, beta, hasher.HashFromMove(hash, move, max));
                    if (newValue < value) // if better move found
                    {
                        value = newValue;
                        if (currentDepth == plyDepth - 1)
                        {
                            bestMove = move; // update best move
                        }
                        bestMoveNode = move; // update best move at node
                    }

                    // alpha cutoff
                    if (value <= alpha)
                    {
                        board.UndoMove(move);
                        AddKillerMove(currentDepth, move);
                        if (useTransposition) { transpositionTable.AddValue(hash, bestMoveNode, value, currentDepth, TranspositionType.Alpha); ttWrites++; }
                        break;
                    }

                    beta = Math.Min(value, beta);
                    board.UndoMove(move); // undo the move
                }

                // add value to tt
                if (useTransposition) { transpositionTable.AddValue(hash, bestMoveNode, value, currentDepth, TranspositionType.Exact); ttWrites++; }

                return value;
            }
        }

        private const int QUIESCENCE_MAX_DEPTH = 5;

        // quiescence search
        private int Quiescence(ChessBoard board, bool max, int qDepth, int alpha, int beta)
        {
            // "stand pat" state
            int value = board.BoardValue(max, qDepth);
            if (value >= beta || qDepth == QUIESCENCE_MAX_DEPTH) // beta cutoff or depth cutoff
            {
                return value;
            }

            //delta pruning
            if (value < alpha - board.PIECE_MATERIAL_VALUES_END[4])
            {
                return alpha;
            }

            if (value > alpha) // increase alpha => ignore lower values
            {
                alpha = value;
            }

            //
            // recursion

            qNodes++; // debug

            List<Move> possibleMoves = ((max) ? board.AllPossibleMoves(PlayerColour.White) : board.AllPossibleMoves(PlayerColour.Black));

            if (possibleMoves.Count == 0) // terminate at mate
            {
                return board.BoardValue(max, qDepth);
            }

            // sort list
            possibleMoves = possibleMoves.OrderByDescending(move => ((move.takenPiece is null ? -100 : move.takenPiece.value) - move.movingPiece.value)).ToList();

            // iterate list
            foreach (Move move in possibleMoves)
            {
                if ((move.takenPiece is null && !(board.winStatus == WinStatus.WhiteCheck || board.winStatus == WinStatus.BlackCheck)) || move.takenPiece is King)
                {
                    continue; // ignore quiescent moves
                }
                else if (move.takenPiece is not null)
                {
                    if (move.takenPiece.value - move.movingPiece.value < -4)
                    {
                        continue; // avoid obviously poor takes
                    }
                }

                board.MakeMove(move);

                if (move.movingPiece is Pawn && move.positionTo.row == 7) // promote white
                {
                    board.AddPiece(new Queen(PlayerColour.White), move.positionTo);
                }
                else if (move.movingPiece is Pawn && move.positionTo.row == 0) // promote black
                {
                    board.AddPiece(new Queen(PlayerColour.Black), move.positionTo);
                }

                board.UpdateWinStatus((max ? PlayerColour.Black : PlayerColour.White)); // update check/mate

                value = -Quiescence(board, !max, qDepth + 1, -beta, -alpha); // recursion call
                board.UndoMove(move);

                if (value >= beta) // beta cutoff
                {
                    return beta;
                }
                else if (value > alpha) // update alpha
                {
                    alpha = value;
                }
            }

            return alpha;
        }

        // inserts a new killer move at the specified depth
        private void AddKillerMove(int depth, Move move)
        {
            for (int i = killerMoves[depth].Length - 2; i >=0; i--)
            {
                killerMoves[depth][i + 1] = killerMoves[depth][i]; // move all moves over to the right, insert new move at the start
            }
            killerMoves[depth][0] = move;
        }

        // orders the move list before recursion starts
        private void OrderMoves(List<Move> moves, int depth)
        {
            // killer heuristic

            int foundKiller = 0;
            // sort killer moves to be evaluated first
            for (int i = 0; i < moves.Count - 1; i++)
            {
                if (killerMoves[depth - 1].Contains(moves[i])) // if move is killer move, insert at front
                {
                    moves.Insert(0, moves[i]); // put move at front, remove duplicate
                    moves.RemoveAt(i + 1);
                    foundKiller++;
                    if (foundKiller == KILLER_MOVE_COUNT) // if all killer moves found, ignore the rest of the list
                    {
                        break;
                    }
                }
            }
        }

    }

    #region Transposition Table

    public enum TranspositionType
    {
        Exact, Alpha, Beta
    }

    public class TranspositionTable
    {
        private int tableSize = 2 << 20;
        public Transposition[] table { get; private set; }

        public TranspositionTable()
        {
            table = new Transposition[tableSize];
        }

        public bool ContainsHash(long hash)
        {
            long index = hash % tableSize;
            if (table[index] != null)
            {
                if (table[index].hash == hash)
                {
                    return true; // if contains *matching* hash entry, return true
                }
            }
            return false;
        }

        public void AddValue(long hash, Move move, int value, int depth, TranspositionType type)
        {
            long index = hash % tableSize;
            Transposition old = table[index];
            if (old != null) // if replacing
            {
                if (depth < old.depth) // if better than old evaluation
                {
                    table[hash % tableSize] = new Transposition(hash, move, value, depth, type);
                }
            }
            else
            {
                table[hash % tableSize] = new Transposition(hash, move, value, depth, type);
            }
        }

        public Transposition GetTransposition(long hash)
        {
            return table[hash % tableSize];
        }

    }

    public class Transposition
    {
        public long hash;
        public Move move;
        public int value;
        public int depth;
        public TranspositionType type;

        public Transposition(long hash, Move move, int value, int depth, TranspositionType type)
        {
            this.hash = hash;
            this.move = move;
            this.value = value;
            this.depth = depth;
            this.type = type;
        }
    }

    public class Zobrist
    {
        private long[] hashTable;
        private long blackMove;

        public Zobrist()
        {
            // initialise hash table
            Random random = new Random();
            hashTable = new long[12 * 64];
            for (int i = 0; i < (12 * 64); i++)
            {
                hashTable[i] = random.NextInt64();
            }
            blackMove = random.NextInt64(); // positions should be considered different depending on whose turn it is
        }

        // function returns the zobrist hash of a board
        public long HashFromBoard(Piece[][] board, bool max)
        {
            long hash = 0;

            // iterate across board, get hashes
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    // get piece hash value
                    if (board[i][j] is not null)
                    {
                        int pos = (i * 8) + j;
                        int val = board[i][j].type + (6 * ((board[i][j].colour == PlayerColour.White) ? 0 : 1));

                        hash ^= hashTable[(12 * val) + pos];
                    }
                }
            }

            if (!max) // unique for black
            {
                hash ^= blackMove;
            }

            return hash;
        }

        // function returns the zobrist hash from a hash and a move
        public long HashFromMove(long hash, Move move, bool max)
        {
            hash ^= blackMove;

            int posF = (8 * move.positionFrom.column) + move.positionFrom.row; // 0-63 val for positions 
            int posT = (8 * move.positionTo.column) + move.positionTo.row;
            int valM = move.movingPiece.type + (6 * ((max) ? 0 : 1));

            // special cases
            // en passant
            if (move is EnPassant)
            {
                int valT = move.takenPiece.type + (6 * ((!max) ? 0 : 1)); // get taken piece
                int posTaken = (8 * (move as EnPassant).takenPosition.column) + (move as EnPassant).takenPosition.row; // get pos of taken pawn
                hash ^= hashTable[(12 * valT) + posTaken]; // remove taken piece
                hash ^= hashTable[(12 * valM) + posF]; // remove old pos
                hash ^= hashTable[(12 * valM) + posT]; // add new piece to
            }
            // castling
            else if (move is Castle)
            {
                int valRook = 1 + (6 * ((max) ? 0 : 1)); // value of rook
                // king
                hash ^= hashTable[(12 * valM) + posF]; // old king pos
                hash ^= hashTable[(12 * valM) + posT]; // new king pos
                // rook
                int posRF = (8 * (move as Castle).rookFrom.column) + (move as Castle).rookFrom.row; // old rook pos
                int posRT = (8 * (move as Castle).rookTo.column) + (move as Castle).rookTo.row; // new rook pos

                hash ^= hashTable[(12 * valRook) + posRF]; // old king pos
                hash ^= hashTable[(12 * valRook) + posRT]; // new king pos
            }
            else if (move.movingPiece is Pawn && (move.positionTo.row == 0 || move.positionTo.row == 7)) // promotion
            {
                // taking
                int valT = (move.takenPiece == null) ? 0 : move.takenPiece.type + (6 * ((!max) ? 0 : 1));
                hash ^= hashTable[(12 * valM) + posF]; // remove old pos

                if (valT > 0)
                {
                    hash ^= hashTable[(12 * valT) + posT]; // remove taken piece
                }

                hash ^= hashTable[(12 * (4 + (6 * ((max) ? 0 : 1)))) + posT]; // add queen to
            }
            // taking move
            else if (move.takenPiece is not null)
            {
                int valT = move.takenPiece.type + (6 * ((!max) ? 0 : 1)); // get taken piece

                hash ^= hashTable[(12 * valM) + posF]; // remove old pos
                hash ^= hashTable[(12 * valT) + posT]; // remove taken piece
                hash ^= hashTable[(12 * valM) + posT]; // add new piece to
            }
            else
            {
                hash ^= hashTable[(12 * valM) + posF]; // remove old pos
                hash ^= hashTable[(12 * valM) + posT]; // add new pos to
            }

            return hash;
        }
    }

    #endregion
}
