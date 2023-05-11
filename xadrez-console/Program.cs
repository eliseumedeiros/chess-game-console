﻿// See https://aka.ms/new-console-template for more information
using board;
using chess;
using xadrez_console.board;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            try {
                ChessGame game = new ChessGame();

                while(!game.finished) {
                    Console.Clear();
                    Screen.printBoard(game.board);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadCressPosition().ToPosition();

                    bool[,] possiblePosistions = game.board.piece(origin).possibleMoviments();

                    Console.Clear();
                    Screen.printBoard(game.board, possiblePosistions);

                    Console.WriteLine();
                    Console.Write("Destination: ");
                    Position destination = Screen.ReadCressPosition().ToPosition();

                    game.executeMoviment(origin, destination);

                }
                
            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}