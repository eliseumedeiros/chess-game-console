using board;

namespace chess {
    class Pawn : Piece {
        private ChessGame game;
        public Pawn(Board board, Color color, ChessGame game) : base(color, board) {
            this.game = game;
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
                // #specialmoviment En Passant
                if (position.row == 3) {
                    Position left = new Position(position.row, position.column - 1);
                    if (board.validPosition(left) && existisEnemy(left) && board.piece(left) == game.vulnerableEnPassant) {
                        mat[left.row - 1, left.column] = true;
                    }
                    Position right = new Position(position.row, position.column + 1);
                    if (board.validPosition(right) && existisEnemy(right) && board.piece(right) == game.vulnerableEnPassant) {
                        mat[right.row - 1, pos.column] = true;
                    }
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
                // #specialmoviment En Passant
                if (position.row == 4) {
                    Position left = new Position(position.row, position.column - 1);
                    if (board.validPosition(left) && existisEnemy(left) && board.piece(left) == game.vulnerableEnPassant) {
                        mat[left.row + 1, left.column] = true;
                    }
                    Position right = new Position(position.row, position.column + 1);
                    if (board.validPosition(right) && existisEnemy(right) && board.piece(right) == game.vulnerableEnPassant) {
                        mat[right.row + 1, right.column] = true;
                    }
                }

            }
            return mat;
        }
    }
}
