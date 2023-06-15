using static Connect4_Jozel_surro.Program;

namespace Connect4_Jozel_surro;

class Program
{
    //Class for Players
    public class Player
    {
        //Properties
        public string Playername { get; set; }
        private char _PlayerSymbol;

        public char PlayerSymbol
        {
            get { return _PlayerSymbol; }
            set { _PlayerSymbol = value; }
        }

    }


    //Class for the Board 
    public static class Connect4Board
    {
        private static char[,] _Board;
        private static int _Rows;
        private static int _Columns;


        public static char[,] Board
        {
            get { return _Board; }
            set { _Board = value; }
        }

        public static int Rows
        {
            get { return _Rows; }
            set { _Rows = value; }
        }

        public static int Columns
        {
            get { return _Columns; }
            set { _Columns = value; }
        }

        static Connect4Board()
        {
            _Columns = 7;
            _Rows = 6;
            _Board = new char[_Rows, _Columns];
        }


        public static void CreateBoard()
        {
            //Creates a New Blank Board
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++){

                    Board[i, j] = '#';
                }
            }
        }

        public static void DisplayBoard()
        {
            //Display the Updated Board After every move
            Console.WriteLine(" - - - - - - - -");

            for (int i = 0; i < Rows; i++)
            {
                Console.Write("| ");

                for (int j = 0; j < Columns; j++)
                {
                    if (Board[i,j] == '#'){
                        Console.Write("# ");
                    }
                    else
                    {
                        Console.Write($"{Board[i,j]} ");
                        
                    }
                }

                Console.WriteLine("|\n");
            }
            Console.WriteLine(" - - - - - - - -");
            Console.WriteLine("| 1 2 3 4 5 6 7 |");
            Console.WriteLine(" - - - - - - - -");
        }

    }

    public class Game
    {
        private Player Player1;
        private Player Player2;

        public Game()
        {
            Player1 = new Player();
            Player2 = new Player();
        }


        public void GetPlayers()
        {
            //Gets player informations
            Console.WriteLine("Please enter name for Player 1");
            Player1.Playername = Console.ReadLine();
            Player1.PlayerSymbol = 'X';
            Console.WriteLine("Please enter name for Player 2");
            Player2.Playername = Console.ReadLine();
            Player2.PlayerSymbol = 'O';
        }

        public void StartGame()
        {
            //Start the Game
            bool gameover = false;
            Console.WriteLine("Welcome to Connect 4 Game!");
            GetPlayers();
            Console.Clear();
            Connect4Board.CreateBoard();

            do
            {

                gameover = PlayGame(Player1);
                if( gameover == true)
                {
                    PrintWinner(Player1);
                    Restart();
                }

                gameover = PlayGame(Player2);
                if (gameover == true)
                {
                    PrintWinner(Player2);
                    Restart();
                }

            } while (gameover == false);
           

        }

        public bool PlayGame(Player player)
        {
            //Plays the game
            bool winner = false;
            bool FullColumn = false;
            int move;
            do
            {
                Connect4Board.DisplayBoard();
                Console.WriteLine($"{player.Playername}, Enter a number from 1-7: ");
                move = Convert.ToInt32(Console.ReadLine()) - 1;
                FullColumn = CheckPiece(move);
                if(FullColumn == true)
                {
                    move = 10;
                }

            } while (move > 6 || move < 0);

            PlacePiece(move , player);
            winner = CheckWin(player);
            CheckIfFull();
            Console.Clear();
            if(winner == true)
            {
                Connect4Board.DisplayBoard();
                return true;
            }

            return false;

        }

        public void Restart()
        {
            //Checks for A new game after every game
            int restart;
            do
            {
                Console.WriteLine("Play Again? [1] = Yes, [2] = No");
                restart = Convert.ToInt32(Console.ReadLine());
                if (restart == 1)
                {
                    Console.Clear();
                    StartGame();
                }
                else if (restart == 2)
                {
                    Environment.Exit(0);
                }
            } while (restart != 1 || restart != 2);
        }

        public bool CheckPiece(int piece)
        {
            //Check if piece can be placed to the column
            for (int i = Connect4Board.Rows - 1; i >= 0; i--)
            {
                if (Connect4Board.Board[i, piece] == '#')
                {
                    return false;
                }
            }
            Console.Clear();
            Console.WriteLine("That Column is Full! Enter a Number Again!");

            return true;
        }

        public void PlacePiece(int piece, Player player)
        {
            //Places the Players piece in the board

                for (int i = Connect4Board.Rows - 1; i >= 0; i--)
                {
                    if (Connect4Board.Board[i, piece] == '#')
                    {
                        Connect4Board.Board[i, piece] = player.PlayerSymbol;
                    return;
                    }
                }
        }

        public bool CheckWin(Player player)
        {
            //Check if players got connect4
            for (int i = 5; i >= 0; i--)
            {
                for (int j = 0; j <= 3; j++)
                {
                    //Horizontal Win
                    if (Connect4Board.Board[i, j] == player.PlayerSymbol &&
                        Connect4Board.Board[i, j + 1] == player.PlayerSymbol &&
                        Connect4Board.Board[i, j + 2] == player.PlayerSymbol &&
                        Connect4Board.Board[i, j + 3] == player.PlayerSymbol)
                    {
                        //Return Win
                        return true;
                    }
                }
            }



            for (int i = 5; i >= 3; i--)
            {
                for (int j = 0; j <= 6; j++)
                {
                    //Vertical Win
                    if (Connect4Board.Board[i, j] == player.PlayerSymbol &&
                        Connect4Board.Board[i - 1, j] == player.PlayerSymbol &&
                        Connect4Board.Board[i - 2, j] == player.PlayerSymbol &&
                        Connect4Board.Board[i - 3, j] == player.PlayerSymbol)
                    {
                        //Return Win
                        return true;

                    }
                }
            }


            for (int i = 5; i >= 3; i--)
            {
                for (int j = 0; j <= 3; j++)
                {

                    //Diagonal Going Right Up
                    if (Connect4Board.Board[i, j] == player.PlayerSymbol &&
                    Connect4Board.Board[i - 1, j + 1] == player.PlayerSymbol &&
                    Connect4Board.Board[i - 2, j + 2] == player.PlayerSymbol &&
                    Connect4Board.Board[i - 3, j + 3] == player.PlayerSymbol)
                    {
                        //Return Win
                        return true;
                    }

                }
            }


            for (int i = 5; i >= 3; i--)
            {
                for (int j = 3; j <= 6; j++)
                {
                    //Diagonal Going Left Up

                    if (Connect4Board.Board[i, j] == player.PlayerSymbol &&
                        Connect4Board.Board[i - 1, j - 1] == player.PlayerSymbol &&
                        Connect4Board.Board[i - 2, j - 2] == player.PlayerSymbol &&
                        Connect4Board.Board[i - 3, j - 3] == player.PlayerSymbol)
                    {
                        //Return Win
                        return true;
                    }
                }
            }

            return false;

        }

        public void PrintWinner(Player player)
        {
            //Returns the Winner
            Console.WriteLine($"It is a Connect 4!, {player.Playername} Wins!");
        }

        public void CheckIfFull()
        {
            //Checks the board if the it is full (Draw)
            for (int i = 5; i >= 0; i--)
            {
                for ( int j = 0; j < 7; j++)
                {
                    if (Connect4Board.Board[i,j] == '#')
                    {
                        return;
                    }
                }
            }
            Console.WriteLine("It's a Draw!");
            Restart();
        }
    }




    static void Main(string[] args)
    {
        var NewGame = new Game();
        NewGame.StartGame();
    }
}

