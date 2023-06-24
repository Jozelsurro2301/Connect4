namespace Connect4_Jozel_surro;

//Class for the Board 
public static class Connect4Board
{
    //Create the Fields of the Connect 4 Board
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

    //Defines the Size of the Board
    static Connect4Board()
    {
        _Columns = 7;
        _Rows = 6;
        _Board = new char[_Rows, _Columns];
    }

    //Creates a New Blank Board
    public static void CreateBoard()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {

                Board[i, j] = '#';
            }
        }
    }

    //Displays the Game Board After Every Move
    public static void DisplayBoard()
    {
        Console.WriteLine(" - - - - - - - -");

        for (int i = 0; i < Rows; i++)
        {
            Console.Write("| ");

            for (int j = 0; j < Columns; j++)
            {
                if (Board[i, j] == '#')
                {
                    Console.Write("# ");
                }
                else
                {
                    Console.Write($"{Board[i, j]} ");
                }
            }

            Console.WriteLine("|\n");
        }
        Console.WriteLine(" - - - - - - - -");
        Console.WriteLine("| 1 2 3 4 5 6 7 |");
        Console.WriteLine(" - - - - - - - -");
    }

    //Checks if a Column is Full
    public static bool IsColumnFull(int piece)
    {
        for (int i = Rows - 1; i >= 0; i--)
        {
            if (Board[i, piece] == '#')
            {
                return false;
            }
        }
        Console.Clear();
        Console.WriteLine("That Column is Full! Enter a Number Again!");

        return true;
    }

    //Check if the board is full. If the board si Full the it is a draw!
    public static bool CheckIfFull()
    {
        for (int i = 5; i >= 0; i--)
        {
            for (int j = 0; j < 7; j++)
            {
                if (Board[i, j] == '#')
                {
                    return false;
                }
            }
        }
        Console.WriteLine("It's a Draw!");
        return true;
    }


    //Checks for any winning patters
    public static bool IsWinner(char Player_Symbol)
    {
        for (int i = 5; i >= 0; i--)
        {
            for (int j = 0; j <= 3; j++)
            {
                //Horizontal Win
                if (Board[i, j] == Player_Symbol &&
                    Board[i, j + 1] == Player_Symbol &&
                    Board[i, j + 2] == Player_Symbol &&
                    Board[i, j + 3] == Player_Symbol)
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
                if (Board[i, j] == Player_Symbol &&
                    Board[i - 1, j] == Player_Symbol &&
                    Board[i - 2, j] == Player_Symbol &&
                    Board[i - 3, j] == Player_Symbol)
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
                if (Board[i, j] == Player_Symbol &&
                Board[i - 1, j + 1] == Player_Symbol &&
                Board[i - 2, j + 2] == Player_Symbol &&
                Board[i - 3, j + 3] == Player_Symbol)
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
                if (Board[i, j] == Player_Symbol &&
                    Board[i - 1, j - 1] == Player_Symbol &&
                    Board[i - 2, j - 2] == Player_Symbol &&
                    Board[i - 3, j - 3] == Player_Symbol)
                {
                    //Return Win
                    return true;
                }
            }
        }

        //return fase if there is not winning pattern
        return false;

    }

}
