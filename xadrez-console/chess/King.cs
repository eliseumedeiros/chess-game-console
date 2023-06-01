using board;

namespace chess {
    internal class King : Piece {
        private ChessGame game;

        public King(Board board, Color color, ChessGame game) : base(color, board) {
            this.game = game;
        }

        public override string ToString() {
            return "K";
        }
        private bool canMove(Position pos) {
            Piece p = board.piece(pos);
            return p == null || p.color != color;
        }

        private bool testRookToCastle(Position pos) {
            Piece p = board.piece(pos);
            return p != null && p is Rook && p.color == color && p.amountOfMovies == 0;
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

            // #specialgame Castle (roque)
            if (amountOfMovies == 0 && !game.check) {
                // #specialgame "Castle Kingside" (roque pequeno)
                Position posRook1 = new Position(position.row, position.column + 3);
                if (testRookToCastle(posRook1)) {
                    Position p1 = new Position(position.row, position.column + 1);
                    Position p2 = new Position(position.row, position.column + 2);
                    if (board.piece(p1) == null && board.piece(p2) == null) {
                        mat[position.row, position.column + 2] = true;
                    }
                }
                // #specialgame "Castle Queenside" (roque pequeno)
                Position posRook2 = new Position(position.row, position.column - 4);
                if (testRookToCastle(posRook2)) {
                    Position p1 = new Position(position.row, position.column - 1);
                    Position p2 = new Position(position.row, position.column - 2);
                    Position p3 = new Position(position.row, position.column - 3);
                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null) {
                        mat[position.row, position.column - 2] = true;
                    }
                }
            }


            return mat;
        }
    }
}
