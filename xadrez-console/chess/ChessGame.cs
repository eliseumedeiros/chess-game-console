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

        public ChessGame() {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;

            putPieces();
        }

        public void executeMoviment(Position origin, Position destination) {
            Piece p = board.removePiece(origin);
            p.IncreaseAmountOfMovies();
            Piece capturedPiece = board.removePiece(destination);
            board.putPiece(p, destination);
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
            if(currentPlayer != board.piece(pos).color) {
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

        private void putPieces() {
            board.putPiece(new Rook(board, Color.White), new ChessPosition('c', 1).ToPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('c', 2).ToPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('d', 2).ToPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('e', 2).ToPosition());
            board.putPiece(new Rook(board, Color.White), new ChessPosition('e', 1).ToPosition());
            board.putPiece(new King(board, Color.White), new ChessPosition('d', 1).ToPosition());

            board.putPiece(new Rook(board, Color.Black), new ChessPosition('c', 7).ToPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('c', 8).ToPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('d', 7).ToPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('e', 7).ToPosition());
            board.putPiece(new Rook(board, Color.Black), new ChessPosition('e', 8).ToPosition());
            board.putPiece(new King(board, Color.Black), new ChessPosition('d', 8).ToPosition());

        }
    }
}
