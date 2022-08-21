using Prototype4.Boards;
using Prototype4.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype4.Players
{

    enum TranspositionState
    {
        Exact,
        Alpha,
        Beta
    }

    internal class TranspositionTable
    {
        private long tableSize = 2 << 20;
        public Transposition[] table { get; private set; }

        public TranspositionTable()
        {
            table = new Transposition[tableSize];
        }

        public void AddValue(long hash, Move move, TranspositionState state, int depth, int value)
        {
            long index = hash % tableSize;

            if (table[index] != null) // same hash
            {
                if (depth > table[index].depth) // if better than stored, replace
                {
                    table[index] = new Transposition(hash, move, state, depth, value);
                }
            }
            else
            {
                table[index] = new Transposition(hash, move, state, depth, value);
            }
        }

        public bool ContainsHash(long hash)
        {
            return (table[hash % tableSize] != null);
        }


        public Transposition GetEntry(long hash)
        {
            return (table[hash % tableSize]);
        }
    }

    internal class Transposition
    {
        public long zobristHash;
        public int value;
        public Move bestMove;
        public TranspositionState state;
        public int depth;

        public Transposition(long zobristHash, Move bestMove, TranspositionState state, int depth, int value)
        {
            this.zobristHash = zobristHash;
            this.bestMove = bestMove;
            this.state = state;
            this.depth = depth;
            this.value = value;
        }
    }

    internal class Zobrist
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
            blackMove = random.NextInt64();
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

            int posF = (8 * move.positionFrom.column) + move.positionFrom.row;
            int posT = (8 * move.positionTo.column) + move.positionTo.row;
            int valM = move.movingPiece.type + (6 * ((max) ? 0 : 1));
            
            // taking move
            if (move.takenPiece is not null)
            {
                int valT = move.movingPiece.type + (6 * ((!max) ? 0 : 1)); // get taken piece

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
}
