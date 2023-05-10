using xadrez_console.board;

namespace board {
    internal class Board {
        public int row { get; set; }
        public int column { get; set; }
        public Piece[,] pieces;

        public Board(int row, int column) {
            this.row = row;
            this.column = column;
            this.pieces = new Piece[row, column];
        }

        public Piece piece(int row, int column) {
            return pieces[row, column];
        }
        public Piece piece(Position pos) {
            return pieces[pos.row, pos.column];
        }

        public bool existPiece(Position pos) {
            validatePositicion(pos);
            return piece(pos) != null;
        }

        public void putPiece(Piece p, Position pos) {
            if (existPiece(pos)) {
                throw new BoardException("There is already a piece in that position!");
            }
            pieces[pos.row, pos.column] = p;
            p.position = pos;
        }

        public Piece removePiece(Position pos) {
            if(piece(pos) == null) {
                return null;
            }
            Piece aux = piece(pos);
            aux.position = null;
            pieces[pos.row, pos.column] = null;
            return aux;
        }

        public bool validPosition(Position pos) {
            if (pos.row<0 || pos.row>=row || pos.column<0 || pos.column>=column) { 
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
