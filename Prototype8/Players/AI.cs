using Prototype8.Pieces;
using Prototype8.Players;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Prototype8.Boards
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

        private int maxPlyDepth;
        private int plyDepth;
        private PlayerColour colour;
        private Move bestMove;

        bool useTransposition = true;
        private Zobrist hasher;
        private TranspositionTable transpositionTable;

        private readonly TimeSpan MAX_ITERATIVE_TIME = new TimeSpan(0, 0, 10);

        private List<Move> initialMoves;

        private int quiescentDepth = 3;

        public AI(int plyDepth, int qDepth, PlayerColour colour, bool tt, bool opTable) : base()
        {
            this.useOpening = opTable;
            this.useTransposition = tt;
            this.maxPlyDepth = plyDepth;
            this.quiescentDepth = qDepth;
            this.colour = colour;

            killerMoves = new Move[maxPlyDepth][];
            for (int i = 0; i < maxPlyDepth; i++)
            {
                killerMoves[i] = new Move[KILLER_MOVE_COUNT];
            }

            if (useOpening)
            {
                InitialiseTables();
            }

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
            //string opPath = "C:\\Users\\Zohaib\\source\\repos\\NEAChess\\Tablebases\\Openings.pgn";
            string opPath = "C:\\Users\\Zobear\\source\\repos\\NEAChess\\Tablebases\\Openings.pgn";
            StreamReader reader = new StreamReader(opPath);

            for (int index = 0; index < 261487; index++)
            {
                openingMoves[index] = (reader.ReadLine()).Split(' '); // format array
            }

            reader.Close();
        }

        // run by board
        public Move MakeMove(ChessBoard board)
        {
            return MakeMove(board, this.colour);
        }

        // method run by board when computer needs to make a move
        public Move MakeMove(ChessBoard board, PlayerColour colour)
        {
            nodes = 0; qNodes = 0; ttReads = 0; ttWrites = 0; ttReadSuccess = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // debug

            initialMoves = board.AllPossibleMoves(colour);
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

            // iterative deepening
            plyDepth = 1;
            while (stopwatch.Elapsed < MAX_ITERATIVE_TIME && plyDepth <= maxPlyDepth)
            {
                // intital Minimax call
                int value = AlphaBeta(board, plyDepth, (colour == PlayerColour.White), int.MinValue + 1, int.MaxValue, 0);

                Console.WriteLine($"Ply {plyDepth} + {quiescentDepth} :: {nodes} nodes :: {qNodes} Q-Nodes in {stopwatch.Elapsed.ToString()} seconds");

                // iterative deepening
                initialMoves.Remove(bestMove); // place best move from previous search at front of list
                initialMoves.Insert(0, bestMove);

                plyDepth++;

                if (value >= (int.MaxValue - plyDepth - 50))
                {
                    break;
                }
            }

            Console.WriteLine($"{ttReadSuccess} Successful out of {ttReads} TT-Reads :: {ttWrites} TT-Writes\n"); // debug

            if (bestMove == null) // handle error in search
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

            if (board.moveNameHistory.Count > 15)
            {
                useOpening = false;
                return false;
            }

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

            // read from transposition table
            if (useTransposition)
            {
                if (currentDepth == plyDepth) // get hash at shallowest node
                {
                    hash = hasher.HashFromBoard(board.board, max);
                }

                if (transpositionTable.ContainsHash(hash)) // if hash found in table
                {
                    ttReads++;
                    Transposition transposition = transpositionTable.GetTransposition(hash);
                    if (transposition.depth >= currentDepth) // if depth stored better than or equal to current depth
                    {
                        ttReadSuccess++;
                        switch (transposition.type)
                        {
                            case TranspositionType.Exact: // exhausted evaluation
                                if (currentDepth == plyDepth) // shallowest node
                                {
                                    bestMove = transposition.move;
                                }
                                return transposition.value;

                            case TranspositionType.UpperBound: // cutoff : update alpha or beta
                                beta = Math.Min(beta, transposition.value);
                                break;
                            case TranspositionType.LowerBound:
                                alpha = Math.Max(alpha, transposition.value);
                                break;
                        }

                        if (alpha >= beta) // cutoff
                        {
                            return transposition.value;
                        }
                    }
                }
            }
            long hashBeforeMove = hash;
            //

            // return board value at final depth
            if (currentDepth == 0)
            {
                return Quiescence(board, max, 0, alpha, beta);
                //return board.BoardValue(max, plyDepth - currentDepth);
            }


            // null move heuristic
            if (plyDepth > 3 && !(board.winStatus == WinStatus.WhiteCheck || board.winStatus == WinStatus.BlackCheck))
            {
                // make null move
                value = -Quiescence(board, !max, quiescentDepth - 2, -beta, -alpha);
                // undo null move
                if (value >= beta) // if position strong enough to produce cutoff, return
                {
                    return beta;
                }
            }

            // get all possible moves
            List<Move> possibleMoves;
            if (currentDepth == plyDepth) // shallowest node
            {
                possibleMoves = initialMoves;
            }
            else // need to generate moves
            {
                possibleMoves = board.AllPossibleMoves(((max) ? PlayerColour.White : PlayerColour.Black));
            }
            //

            if (possibleMoves.Count == 0) // early termination node
            {
                nodes++;
                return (max ? 1 : -1) * board.BoardValue(max, plyDepth - currentDepth);
                // if black, return negative score (score from black players perspective)
            }

            // order moves before iterating through them
            OrderMoves(possibleMoves, currentDepth);

            value = int.MinValue;
            Move bestMoveNode = null;
            foreach (Move move in possibleMoves)
            {
                nodes++;
                board.MakeMove(move);
                if (move.movingPiece is Pawn && (move.positionTo.row == 7 || move.positionTo.row == 0)) // promotion
                {
                    board.AddPiece(new Queen(((max) ? PlayerColour.White : PlayerColour.Black)), move.positionTo);
                }
                board.UpdateWinStatus((max) ? PlayerColour.Black : PlayerColour.White); // make move, update check/mate

                if (useTransposition) // update hash from the move
                {
                    hash = hasher.HashFromMove(hashBeforeMove, move, max);
                    //long hashBoard = hasher.HashFromBoard(board.board, !max);
                    //Console.WriteLine($"ply {currentDepth}:: old {hashBeforeMove} :: {hash} :: {hashBoard} :: Difference {hash - hashBoard}");
                }

                int newValue = -AlphaBeta(board, currentDepth - 1, !max, -beta, -alpha, hash); //recursion call
                board.UndoMove(move);

                if (newValue > value) // if better move found
                {
                    value = newValue; // update value
                    if (currentDepth == plyDepth) // update best move at shallowest node
                    {
                        bestMove = move;
                    }
                    bestMoveNode = move; // update best move at current depth
                }

                alpha = Math.Max(value, alpha); // update alpha
                if (alpha >= beta) // cutoff
                {
                    AddKillerMove(currentDepth, move); // add cutoff move to killer moves
                    break;
                }
            }

            // write to tt
            if (useTransposition)
            {
                ttWrites++;
                if (value <= alpha)
                {
                    transpositionTable.AddValue(hashBeforeMove, bestMoveNode, value, currentDepth, TranspositionType.UpperBound);
                }
                else if (value >= beta)
                {
                    transpositionTable.AddValue(hashBeforeMove, bestMoveNode, value, currentDepth, TranspositionType.LowerBound);
                }
                else
                {
                    transpositionTable.AddValue(hashBeforeMove, bestMoveNode, value, currentDepth, TranspositionType.Exact);
                }
            }
            //

            return value;
        }

        // quiescence search
        private int Quiescence(ChessBoard board, bool max, int qDepth, int alpha, int beta)
        {
            // "standpat" score
            int value = (max ? 1 : -1) * board.BoardValue(max, qDepth);

            if (qDepth == quiescentDepth) // depth cutoff
            {
                return value;
            }
            if (value >= beta) // beta cutoff
            {
                return beta;
            }
            if (value > alpha) // update alpha
            {
                alpha = value;
            }

            // get all possible moves
            List<Move> possibleMoves = board.AllPossibleMoves((max ? PlayerColour.White : PlayerColour.Black));
            if (possibleMoves.Count == 0) // early termination
            {
                qNodes++;
                return (max ? 1 : -1) * board.BoardValue(max, qDepth);
            }

            // sort list by value of taken piece - value of taking piece
            possibleMoves = possibleMoves.OrderByDescending(move => move.captureValue).ToList();

            foreach (Move move in possibleMoves)
            {
                if (move.takenPiece is null && !(board.winStatus == WinStatus.WhiteCheck || board.winStatus == WinStatus.BlackCheck) || move.takenPiece is King)
                {
                    continue; // ignore quiescent moves
                }

                qNodes++;

                board.MakeMove(move); // make move, update win state

                if (move.movingPiece is Pawn && (move.positionTo.row == 7 || move.positionTo.row == 0)) // promotion
                {
                    board.AddPiece(new Queen(((max) ? PlayerColour.White : PlayerColour.Black)), move.positionTo);
                }

                board.UpdateWinStatus((max ? PlayerColour.Black : PlayerColour.White));
                value = -Quiescence(board, !max, qDepth + 1, -beta, -alpha); // recursive call
                board.UndoMove(move);

                if (value >= beta) // beta cutoff
                {
                    return beta;
                }
                if (value > alpha) // update alpha
                {
                    alpha = value;
                }
            }
            return alpha;
        }

        // inserts a new killer move at the specified depth
        private void AddKillerMove(int depth, Move move)
        {
            depth--; // decrement depth to account for 0-based array indexes
            for (int i = killerMoves[depth].Length - 2; i >= 0; i--)
            {
                killerMoves[depth][i + 1] = killerMoves[depth][i]; // move all moves over to the right, insert new move at the start
            }
            killerMoves[depth][0] = move;
        }

        // orders the move list before recursion starts
        private void OrderMoves(List<Move> moves, int depth)
        {
            // order moves by value of taking pieces
            moves = moves.OrderByDescending(move => move.captureValue).ToList();

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
        Exact, UpperBound, LowerBound,
    }

    public class TranspositionTable
    {
        private int tableSize = 1 << 20;
        public Transposition[] table { get; private set; }

        public TranspositionTable()
        {
            table = new Transposition[tableSize];
        }

        // returns true if the hash exists and matches
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

        // adds value to tt :: doesnt replace if depth lower than existing entry
        public void AddValue(long hash, Move move, int value, int depth, TranspositionType type)
        {
            long index = hash % tableSize;

            Transposition old = table[index];
            if (old != null) // if replacing
            {
                if (depth < old.depth) // if better than old evaluation or empty, replace
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
                hashTable[i] = (random.Next() << 32) | random.Next();
            }
            blackMove = (random.Next() << 32) | random.Next(); // positions should be considered different depending on whose turn it is
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
                    if (!(board[i][j] is null))
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
            // regular non-taking move
            else if (move.takenPiece is null)
            {
                hash ^= hashTable[(12 * valM) + posF]; // remove old pos
                hash ^= hashTable[(12 * valM) + posT]; // add new pos to
            }
            // regular taking move
            else
            {
                int valT = move.takenPiece.type + (6 * ((!max) ? 0 : 1)); // get taken piece

                hash ^= hashTable[(12 * valM) + posF]; // remove old pos
                hash ^= hashTable[(12 * valT) + posT]; // remove taken piece
                hash ^= hashTable[(12 * valM) + posT]; // add new piece to
            }

            return hash;
        }
    }

    #endregion
}