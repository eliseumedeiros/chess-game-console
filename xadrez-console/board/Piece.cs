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
        public abstract bool[,] possibleMoviments();
    }
}
