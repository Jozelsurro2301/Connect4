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
                Console.Write("| ");

                for (int j = 0; j < Columns; j++){

                    Console.Write("#");
                    Console.Write(" ");
                    Board[i, j] = '#';
                }

                Console.WriteLine("\n");
            }
        }

        public static void DisplayBoard(Player Player)
        {
            //Display the Updated Board After every move
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
                        Console.Write($"{Player.PlayerSymbol} ");
                    }
                }

                Console.WriteLine("\n");
            }
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
        }

        public void StartGame()
        {
            //Start the Game
        }

        public void PlayGame()
        {
            //Plays the game
        }

        public void Restart()
        {
            //Checks for A new game after every game
        }

        public void PlacePiece()
        {
            //Places the Players piece in the board
        }

        public void CheckPiece()
        {
            //Check if a pieace can be place on the board
        }

        public void CheckWin()
        {
            //Check if players got connect4
        }

        public void PrintWinner()
        {
            //Returns the Winner
        }

        public void CheckIfFull()
        {
            //Checks the board if the it is full (Draw)
        }
    }




    static void Main(string[] args)
    {

        var NewGame = new Game();
        NewGame.StartGame();
    }
}

