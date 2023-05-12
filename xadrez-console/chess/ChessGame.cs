using System;
using board;
using xadrez_console.board;
using xadrez_console;

namespace chess {
    internal class ChessGame {

        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;

        public ChessGame() {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();

            putPieces();
        }

        public void executeMoviment(Position origin, Position destination) {
            Piece p = board.removePiece(origin);
            p.IncreaseAmountOfMovies();
            Piece capturedPiece = board.removePiece(destination);
            board.putPiece(p, destination);
            if (capturedPiece != null) {
                captured.Add(capturedPiece);
            }
        }
        public HashSet<Piece> capturedPieces(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece x in captured) {
                if(x.color == color) {
                    aux.Add(x);
                }
            }
            return aux;
        }
        public HashSet<Piece> piecesInGame(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces) {
                if (x.color == color) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(color));
            return aux;
        }
        public void doMoviment(Position origin, Position destination) {
            executeMoviment(origin, destination);
            turn++;
            changePlayer();
        }

        public void validateOriginPosition(Position pos) {
            if (board.piece(pos) == null) {
                throw new BoardException("There is no piece in the chosen position!");
            }
            if (currentPlayer != board.piece(pos).color) {
                throw new BoardException("The chosen origin piece is not yours!");
            }
            if (!board.piece(pos).thereArePossivelMoves()) {
                throw new BoardException("There are no possible moves for the chosen origin piece!");
            }
        }
        public void validateDestinationPosition(Position origin, Position destination) {
            if (!board.piece(origin).canMoveTo(destination)) {
                throw new BoardException("Ivalid destination position!");
            }
        }
        private void changePlayer() {
            if (currentPlayer == Color.White) {
                currentPlayer = Color.Black;
            }
            else {
                currentPlayer = Color.White;
            }
        }
        public void putNewPiece(char column, int row, Piece piece) {
            board.putPiece(piece, new ChessPosition(column, row).ToPosition());
            pieces.Add(piece);
        }
        private void putPieces() {
            putNewPiece('c', 1, new Rook(board, Color.White));
            putNewPiece('c', 2, new Rook(board, Color.White));
            putNewPiece('d', 2, new Rook(board, Color.White));
            putNewPiece('e', 2, new Rook(board, Color.White));
            putNewPiece('e', 1, new Rook(board, Color.White));
            putNewPiece('d', 1, new King(board, Color.White));

            putNewPiece('c', 7, new Rook(board, Color.Black));
            putNewPiece('c', 8, new Rook(board, Color.Black));
            putNewPiece('d', 7, new Rook(board, Color.Black));
            putNewPiece('e', 7, new Rook(board, Color.Black));
            putNewPiece('e', 8, new Rook(board, Color.Black));
            putNewPiece('d', 8, new King(board, Color.Black));

        }
    }
}
