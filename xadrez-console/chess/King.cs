using board;

namespace chess {
    internal class King : Piece {

        public King(Board board, Color color) : base(color, board) {

        }

        public override string ToString() {
            return "K";
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
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            //ne
            pos.defineValues(position.row - 1, position.column + 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            //direita
            pos.defineValues(position.row, position.column + 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            //se
            pos.defineValues(position.row + 1, position.column + 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            //abaixo
            pos.defineValues(position.row + 1, position.column);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            //so
            pos.defineValues(position.row + 1, position.column - 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            //esquerda
            pos.defineValues(position.row, position.column - 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            //no
            pos.defineValues(position.row - 1, position.column - 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            return mat;
        }
    }
}
