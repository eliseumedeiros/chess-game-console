using board;

namespace chess {
    internal class Rook : Piece {

        public Rook(Board board, Color color) : base(color, board) {

        }
        private bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMoviments() {
            bool[,] mat = new bool[board.row, board.column];

            Position pos = new Position(0, 0);

            //acima
            pos.defineValues(position.row - 1, position.column);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.row = pos.row - 1;
            }

            //abaixo
            pos.defineValues(position.row + 1, position.column);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.row = pos.row + 1;
            }

            //direita
            pos.defineValues(position.row, position.column + 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.column = pos.column + 1;
            }

            //equerda
            pos.defineValues(position.row, position.column - 1);
            while (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).color != color) {
                    break;
                }
                pos.column = pos.column - 1;
            }

            return mat;
        }

        public override string ToString() {
            return "R";
        }
    }
}
