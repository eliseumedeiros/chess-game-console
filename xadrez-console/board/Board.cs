namespace board {
    internal class Board {
        public int line { get; set; }
        public int column { get; set; }
        public Piece[,] pieces;

        public Board(int line, int column) {
            this.line = line;
            this.column = column;
            this.pieces = new Piece[line, column];
        }
    }
}
