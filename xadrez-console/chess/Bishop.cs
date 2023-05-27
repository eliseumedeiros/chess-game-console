using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xadrez_console.chess {
    internal class Bishop : Piece {
        public Bishop(Board board, Color color) : base(color, board) {
        }

        public override string ToString() {
            return "B";
        }
        private bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMoviments() {
            bool[,] mat = new bool[board.row, board.column];

            Position pos = new Position(0, 0);

            // NO
            pos.defineValues(position.row - 1, position.column - 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.row - 1, pos.column - 1);
            }

            // NE
            pos.defineValues(position.row - 1, position.column + 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.row - 1, pos.column + -1);
            }

            // SE
            pos.defineValues(position.row + 1, position.column + 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.row + 1, pos.column + 1);
            }

            // SO
            pos.defineValues(position.row + 1, position.column - 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.defineValues(pos.row + 1, pos.column - 1);
            }

            return mat;
        }
    }
}
