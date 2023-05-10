namespace board {
    internal class Position {

        public int row { get; set; }
        public int column { get; set; }

        public Position(int line, int column) {
            this.row = line;
            this.column = column;
        }

        public override string ToString() {
            return row
                + ", " 
                + column;
        }
    }
}
