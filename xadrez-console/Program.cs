// See https://aka.ms/new-console-template for more information
using board;
using chess;
using xadrez_console.board;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            try {
                ChessGame game = new ChessGame();

                while(!game.finished) {
                    try {
                        Console.Clear();
                        Screen.printBoard(game.board);

                        Console.WriteLine();
                        Console.WriteLine("Turn: " + game.turn);
                        Console.WriteLine("Waiting for move: " + game.currentPlayer);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.ReadCressPosition().ToPosition();
                        game.validateOriginPosition(origin);

                        bool[,] possiblePosistions = game.board.piece(origin).possibleMoviments();

                        Console.Clear();
                        Screen.printBoard(game.board, possiblePosistions);

                        Console.WriteLine();
                        Console.Write("Destination: ");
                        Position destination = Screen.ReadCressPosition().ToPosition();
                        game.validateDestinationPosition(origin, destination);

                        game.doMoviment(origin, destination);
                    }
                    catch (BoardException e) {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                   

                }
                
            }
            catch (BoardException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}