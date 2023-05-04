using System;
using board;

namespace xadrez_console {
    internal class Screen {

        public static void printBoard(Board board) {

            for (int i = 0; i < board.line; i++) {
                for (int j = 0; j < board.column; j++) {
                    if (board.piece(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        Console.Write(board.piece(i, j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
