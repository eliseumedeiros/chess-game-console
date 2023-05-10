﻿using System;
using board;
using xadrez_console.board;
using xadrez_console;

namespace chess {
    internal class ChessGame {

        public Board board { get; private set; }
        private int turn;
        private Color currentPlayer;
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