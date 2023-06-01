using System;
using board;
using xadrez_console.board;
using xadrez_console;
using xadrez_console.chess;

namespace chess {
    internal class ChessGame {

        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool check { get; private set; }
        public Piece vulnerableEnPassant { get; private set; }
        public ChessGame() {
            board = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.White;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            check = false;
            vulnerableEnPassant = null;

            putPieces();
        }

        public Piece executeMoviment(Position origin, Position destination) {
            Piece p = board.removePiece(origin);
            p.IncreaseAmountOfMovies();
            Piece capturedPiece = board.removePiece(destination);
            board.putPiece(p, destination);
            if (capturedPiece != null) {
                captured.Add(capturedPiece);
            }

            // #specialgame Castle Kingside
            if (p is King && destination.column == origin.column + 2) {
                Position originRook = new Position(origin.row, origin.column + 3);
                Position destinationRook = new Position(origin.row, origin.column + 1);
                Piece Rk = board.removePiece(originRook);
                Rk.IncreaseAmountOfMovies();
                board.putPiece(Rk, destinationRook);
            }

            // #specialgame Castle Queenside
            if (p is King && destination.column == origin.column - 2) {
                Position originRook = new Position(origin.row, origin.column - 4);
                Position destinationRook = new Position(origin.row, origin.column - 1);
                Piece Rk = board.removePiece(originRook);
                Rk.IncreaseAmountOfMovies();
                board.putPiece(Rk, destinationRook);
            }

            // #sprecialgame En Passant
            if (p is Pawn) {
                if (origin.column != destination.column && capturedPiece == null) {
                    Position posP;
                    if (p.color == Color.White) {
                        posP = new Position(destination.row + 1, destination.column);
                    }
                    else {
                        posP = new Position(destination.row - 1, destination.column);
                    }
                    capturedPiece = board.removePiece(posP);
                    captured.Add(capturedPiece);
                }
            }

            return capturedPiece;
        }
        public HashSet<Piece> capturedPieces(Color color) {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured) {
                if (x.color == color) {
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
        public void undoMoviment(Position origin, Position destination, Piece capturedPiece) {
            Piece p = board.removePiece(destination);
            p.decreaseAmountOfMoves();
            if (capturedPiece != null) {
                board.putPiece(capturedPiece, destination);
                captured.Remove(capturedPiece);
            }
            board.putPiece(p, origin);

            // #specialgame Castle Kingside
            if (p is King && destination.column == origin.column + 2) {
                Position originRook = new Position(origin.row, origin.column + 3);
                Position destinationRook = new Position(origin.row, origin.column + 1);
                Piece Rk = board.removePiece(originRook);
                Rk.IncreaseAmountOfMovies();
                board.putPiece(Rk, destinationRook);
            }

            // #specialgame Castle Queenside
            if (p is King && destination.column == origin.column - 2) {
                Position originRook = new Position(origin.row, origin.column - 4);
                Position destinationRook = new Position(origin.row, origin.column - 1);
                Piece Rk = board.removePiece(originRook);
                Rk.IncreaseAmountOfMovies();
                board.putPiece(Rk, destinationRook);
            }

            // #specialgame En Passant
            if (p is Pawn && destination.column == origin.column - 2) {
                if (origin.column != destination.column && capturedPiece == vulnerableEnPassant) {
                    Piece pawn = board.removePiece(destination);
                    Position posP;
                    if (p.color == Color.White) {
                        posP = new Position(3, destination.column);
                    }
                    else {
                        posP = new Position(4, destination.column);
                    }
                    board.putPiece(pawn, posP);
                }
            }

        }
        public void doMoviment(Position origin, Position destination) {
            Piece capturedPiece = executeMoviment(origin, destination);

            if (isItInCheck(currentPlayer)) {
                undoMoviment(origin, destination, capturedPiece);
                throw new BoardException("You cannot put yourself in check!");
            }

            if (isItInCheck(adversary(currentPlayer))) {
                check = true;
            }
            else {
                check = false;
            }

            if (checkMateTest(adversary(currentPlayer))) {
                finished = true;
            }
            else {
                turn++;
                changePlayer();
            }

            Piece p = board.piece(destination);

            // #specialmoviment En Passant
            if (p is Pawn && (destination.row == origin.row - 2 || destination.row == origin.row + 2)) {
                vulnerableEnPassant = p;
            }
            else {
                vulnerableEnPassant = null;
            }
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
            if (!board.piece(origin).isItAPossibleMoviment(destination)) {
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
        private Color adversary(Color color) {
            if (color == Color.White) {
                return Color.Black;
            }
            else {
                return Color.White;
            }
        }
        private Piece king(Color color) {
            foreach (Piece x in piecesInGame(color)) {
                if (x is King) {
                    return x;
                }
            }
            return null;
        }
        public bool isItInCheck(Color color) {
            Piece K = king(color);
            if (K == null) {
                throw new BoardException("There is no " + color + " King on the board!");
            }
            foreach (Piece x in piecesInGame(adversary(color))) {
                bool[,] mat = x.possibleMoviments();
                if (mat[K.position.row, K.position.column]) {
                    return true;
                }
            }
            return false;
        }

        public bool checkMateTest(Color color) {
            if (!isItInCheck(color)) {
                return false;
            }
            foreach (Piece x in piecesInGame(color)) {
                bool[,] mat = x.possibleMoviments();
                for (int i = 0; i < board.row; i++) {
                    for (int j = 0; j < board.column; j++) {
                        if (mat[i, j]) {
                            Position origin = x.position;
                            Position destination = new Position(i, j);
                            Piece capturedPiece = executeMoviment(origin, destination);
                            bool checkTest = isItInCheck(color);
                            undoMoviment(origin, destination, capturedPiece);
                            if (!checkTest) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public void putNewPiece(char column, int row, Piece piece) {
            board.putPiece(piece, new ChessPosition(column, row).ToPosition());
            pieces.Add(piece);
        }
        private void putPieces() {
            putNewPiece('a', 1, new Rook(board, Color.White));
            putNewPiece('b', 1, new Knight(board, Color.White));
            putNewPiece('c', 1, new Bishop(board, Color.White));
            putNewPiece('d', 1, new Queen(board, Color.White));
            putNewPiece('e', 1, new King(board, Color.White, this));
            putNewPiece('f', 1, new Bishop(board, Color.White));
            putNewPiece('g', 1, new Knight(board, Color.White));
            putNewPiece('h', 1, new Rook(board, Color.White));
            putNewPiece('a', 2, new Pawn(board, Color.White, this));
            putNewPiece('b', 2, new Pawn(board, Color.White, this));
            putNewPiece('c', 2, new Pawn(board, Color.White, this));
            putNewPiece('d', 2, new Pawn(board, Color.White, this));
            putNewPiece('e', 2, new Pawn(board, Color.White, this));
            putNewPiece('f', 2, new Pawn(board, Color.White, this));
            putNewPiece('g', 2, new Pawn(board, Color.White, this));
            putNewPiece('h', 2, new Pawn(board, Color.White, this));

            putNewPiece('a', 8, new Rook(board, Color.Black));
            putNewPiece('b', 8, new Knight(board, Color.Black));
            putNewPiece('c', 8, new Bishop(board, Color.Black));
            putNewPiece('d', 8, new Queen(board, Color.Black));
            putNewPiece('e', 8, new King(board, Color.Black, this));
            putNewPiece('f', 8, new Bishop(board, Color.Black));
            putNewPiece('g', 8, new Knight(board, Color.Black));
            putNewPiece('h', 8, new Rook(board, Color.Black));
            putNewPiece('a', 7, new Pawn(board, Color.Black, this));
            putNewPiece('b', 7, new Pawn(board, Color.Black, this));
            putNewPiece('c', 7, new Pawn(board, Color.Black, this));
            putNewPiece('d', 7, new Pawn(board, Color.Black, this));
            putNewPiece('e', 7, new Pawn(board, Color.Black, this));
            putNewPiece('f', 7, new Pawn(board, Color.Black, this));
            putNewPiece('g', 7, new Pawn(board, Color.Black, this));
            putNewPiece('h', 7, new Pawn(board, Color.Black, this));

        }
    }
}
