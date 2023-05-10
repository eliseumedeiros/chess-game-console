using System;
using board;
using chess;

namespace xadrez_console {
    internal class Screen {

        public static void printBoard(Board board) {

            for (int i = 0; i < board.row; i++) {
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
            Console.WriteLine("  a b c d e f g h");
            //Console.WriteLine("Rook - R; King - K");
        }

        public static ChessPosition ReadCressPosition() {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessPosition(column, row);
        }

        public static void printPiece(Piece piece) {
            if (piece.color == Color.White) {
                Console.Write(piece + " ");
            }
            else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece + " ");
                Console.ForegroundColor = aux;
            }
        }
    }
}
