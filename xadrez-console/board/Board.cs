using xadrez_console.board;

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

        public Piece piece(int line, int column) {
            return pieces[line, column];
        }
        public Piece piece(Position pos) {
            return pieces[pos.line, pos.column];
        }

        public bool existPiece(Position pos) {
            validatePositicion(pos);
            return piece(pos) != null;
        }

        public void putPiece(Piece p, Position pos) {
            if (existPiece(pos)) {
                throw new BoardException("There is already a piece in that position!");
            }
            pieces[pos.line, pos.column] = p;
            p.position = pos;
        }

        public bool validPosition(Position pos) {
            if (pos.line<0 || pos.line>=line || pos.column<0 || pos.column>=column) { 
                return false;
            }
                return true;
        }

        public void validatePositicion(Position pos) {
            if (!validPosition(pos)) {
                throw new BoardException("Ivalid Position!");
            }
        }
    }
}
