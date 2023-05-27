using board;

namespace chess {
    internal class Knight : Piece {
        public Knight(Board board, Color color) : base(color, board) {
        }

        public override string ToString() {
            return "N";
        }
        private bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMoviments() {
            bool[,] mat = new bool[board.row, board.column];

            Position pos = new Position(0, 0);

            pos.defineValues(position.row - 1, position.column - 2);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.defineValues(position.row - 2, position.column - 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.defineValues(position.row - 2, position.column + 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.defineValues(position.row - 1, position.column + 2);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.defineValues(position.row + 1, position.column + 2);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.defineValues(position.row + 2, position.column + 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.defineValues(position.row + 2, position.column - 1);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }
            pos.defineValues(position.row + 1, position.column - 2);
            if (board.validPosition(pos) && canMove(pos)) {
                mat[pos.row, pos.column] = true;
            }

            return mat;
        }
    }
}