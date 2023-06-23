namespace Connect4_Jozel_surro;

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

    //Create a new blank board
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

}
