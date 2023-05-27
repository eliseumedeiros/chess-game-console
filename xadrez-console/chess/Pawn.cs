using board;

namespace chess {
    class Pawn : Piece {
        public Pawn(Board board, Color color) : base(color, board) {
        }

        public override string ToString() {
            return "P";
        }

        private bool existisEnemy(Position pos) {
            Piece p = board.piece(pos);
            return p != null && p.color != color;
        }

        private bool free(Position pos) {
            return board.piece(pos) == null;
        }

        public override bool[,] possibleMoviments() {
            bool[,] mat = new bool[board.row, board.column];

            Position pos = new Position(0, 0);

            if (color == Color.White) {
                pos.defineValues(position.row - 1, position.column);
                if (board.validPosition(pos) && free(pos)) {
                    mat[pos.row, pos.column] = true;
                }
                pos.defineValues(position.row - 2, position.column);
                if (board.validPosition(pos) && free(pos) && amountOfMovies == 0) {
                    mat[pos.row, pos.column] = true;
                }
                pos.defineValues(position.row - 1, position.column - 1);
                if (board.validPosition(pos) && existisEnemy(pos)) {
                    mat[pos.row, pos.column] = true;
                }
                pos.defineValues(position.row - 1, position.column + 1);
                if (board.validPosition(pos) && existisEnemy(pos)) {
                    mat[pos.row, pos.column] = true;
                }
            }
            else {
                pos.defineValues(position.row + 1, position.column);
                if (board.validPosition(pos) && free(pos)) {
                    mat[pos.row, pos.column] = true;
                }
                pos.defineValues(position.row + 2, position.column);
                if (board.validPosition(pos) && free(pos) && amountOfMovies == 0) {
                    mat[pos.row, pos.column] = true;
                }
                pos.defineValues(position.row + 1, position.column - 1);
                if (board.validPosition(pos) && existisEnemy(pos)) {
                    mat[pos.row, pos.column] = true;
                }
                pos.defineValues(position.row + 1, position.column + 1);
                if (board.validPosition(pos) && existisEnemy(pos)) {
                    mat[pos.row, pos.column] = true;
                }
            }
            return mat;
        }
    }
}
