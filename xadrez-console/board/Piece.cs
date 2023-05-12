using board;

namespace board {
    abstract class Piece {
        public Position position { get; set; }
        public Color color { get; set; }
        public int amountOfMovies { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Color color, Board board) {
            this.position = null;
            this.color = color;
            this.amountOfMovies = 0;
            this.board = board;
        }

        public void IncreaseAmountOfMovies() {
            amountOfMovies++;
        }
        public bool thereArePossivelMoves() {
            bool[,] mat = possibleMoviments();
            for(int i=0; i<board.row; i++) {
                for(int j=0; j<board.column; j++) {
                    if (mat[i, j]) {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool canMoveTo(Position pos) {
            return possibleMoviments()[pos.row, pos.column];
        }
        public abstract bool[,] possibleMoviments();
    }
}
