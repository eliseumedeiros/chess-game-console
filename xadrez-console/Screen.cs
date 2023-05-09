using System;
using board;

namespace xadrez_console {
    internal class Screen {

        public static void printBoard(Board board) {

            for (int i = 0; i < board.line; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.column; j++) {
                    if (board.piece(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        Screen.printPiece(board.piece(i, j));
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(" a b c d e f g h");
        }

        public static void printPiece(Piece piece) {
            if (piece.color == Color.White) {
                Console.Write(piece);
            }
            else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}
