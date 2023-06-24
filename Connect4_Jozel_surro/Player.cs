namespace Connect4_Jozel_surro;

//Interface of a Player. A player has a name, symbol and a method called GetMove();
interface IPlayer
{

    string Playername { get; set; }
    char PlayerSymbol { get; set; }

    int GetMove();
}


//A class that inherits the interface of the IPlayer
public class HumanPlayer : IPlayer
{
    public string Playername { get; set; }
    public char PlayerSymbol { get; set; }


    //This method gets user input for a move on the game. This is also an exception free since all possible exception has a catch.
    public int GetMove()
    {
        int move;
        do
        {
            try
            {
                move = Convert.ToInt32(Console.ReadLine()) - 1;
                if (move > 6 || move < 0)
                {
                    throw new GettingValidMove("Invalid Move!");
                }
                return move;
            }
            catch (FormatException Fe)
            {
                Console.WriteLine(Fe.Message);
            }
            catch (GettingValidMove Gvm)
            {
                Gvm.EnterValidMove();
            }
        } while (true);
    }
}



//A class for EasyAI player that inherits the interface of the IPlayer
public class AIPlayerEasy : IPlayer
{

    private Random rnd = new();
    public string Playername { get; set; }
    public char PlayerSymbol { get; set; }

    //This class will choose a random number from 1-6
    public int GetMove()
    {

        int move;

        do
        {
            Connect4Board.DisplayBoard();
            move = rnd.Next(7);

        } while (Connect4Board.IsColumnFull(move));

        return move;
    }
}


//A class for HardAI player that inherits the interface of the IPlayer
public class AIPlayerHard : IPlayer
{
    private Random rnd = new();
    public string Playername { get; set; }
    public char PlayerSymbol { get; set; }


    //Check sthe move of the Human Player if there is a possible winning pattern
    public int GetMove()
    {
        int move;
        move = rnd.Next(7);

        do
        {
            Connect4Board.DisplayBoard();
            //Check if players got connect4
            for (int i = 5; i >= 0; i--)
            {
                for (int j = 0; j <= 3; j++)
                {
                    //Horizontal Win
                    if (Connect4Board.Board[i, j] == 'X' &&
                        Connect4Board.Board[i, j + 1] == 'X' &&
                        Connect4Board.Board[i, j + 2] == 'X' &&
                        Connect4Board.Board[i, j + 3] == '#')
                    {
                        //Return Win
                        move = j + 3;
                    }
                    else if (Connect4Board.Board[i, j] == 'X' &&
                        Connect4Board.Board[i, j + 1] == 'X' &&
                        Connect4Board.Board[i, j + 2] == '#' &&
                        Connect4Board.Board[i, j + 3] == 'X')
                    {
                        //Return Win
                        move = j + 2;
                    }
                    else if (Connect4Board.Board[i, j] == 'X' &&
                        Connect4Board.Board[i, j + 1] == '#' &&
                        Connect4Board.Board[i, j + 2] == 'X' &&
                        Connect4Board.Board[i, j + 3] == 'X')
                    {
                        //Return Win
                        move = j + 1;
                    }
                }
            }

            for (int i = 5; i >= 3; i--)
            {
                for (int j = 0; j <= 6; j++)
                {
                    //Vertical Win
                    if (Connect4Board.Board[i, j] == 'X' &&
                        Connect4Board.Board[i - 1, j] == 'X' &&
                        Connect4Board.Board[i - 2, j] == 'X' &&
                        Connect4Board.Board[i - 3, j] == '#')
                    {
                        //Return Win
                        move = j;

                    }
                }
            }


            for (int i = 5; i >= 3; i--)
            {
                for (int j = 0; j <= 3; j++)
                {

                    //Diagonal Going Right Up
                    if (Connect4Board.Board[i, j] == 'X' &&
                    Connect4Board.Board[i - 1, j + 1] == 'X' &&
                    Connect4Board.Board[i - 2, j + 2] == 'X' &&
                    Connect4Board.Board[i - 3, j + 3] == '#')
                    {
                        //Return Win
                        move = j + 3;
                    }
                    else if (Connect4Board.Board[i, j] == 'X' &&
                    Connect4Board.Board[i - 1, j + 1] == 'X' &&
                    Connect4Board.Board[i - 2, j + 2] == '#' &&
                    Connect4Board.Board[i - 3, j + 3] == 'X')
                    {
                        //Return Win
                        move = j + 2;
                    }
                    else if (Connect4Board.Board[i, j] == 'X' &&
                    Connect4Board.Board[i - 1, j + 1] == '#' &&
                    Connect4Board.Board[i - 2, j + 2] == 'X' &&
                    Connect4Board.Board[i - 3, j + 3] == 'X')
                    {
                        //Return Win
                        move = j + 1;
                    }

                }
            }


            for (int i = 5; i >= 3; i--)
            {
                for (int j = 3; j <= 6; j++)
                {
                    //Diagonal Going Left Up

                    if (Connect4Board.Board[i, j] == 'X' &&
                        Connect4Board.Board[i - 1, j - 1] == 'X' &&
                        Connect4Board.Board[i - 2, j - 2] == 'X' &&
                        Connect4Board.Board[i - 3, j - 3] == '#')
                    {
                        //Return Win
                        move = j - 3;
                    }
                    else if (Connect4Board.Board[i, j] == 'X' &&
                        Connect4Board.Board[i - 1, j - 1] == 'X' &&
                        Connect4Board.Board[i - 2, j - 2] == '#' &&
                        Connect4Board.Board[i - 3, j - 3] == 'X')
                    {
                        //Return Win
                        move = j - 2;
                    }
                    else if (Connect4Board.Board[i, j] == 'X' &&
                        Connect4Board.Board[i - 1, j - 1] == '#' &&
                        Connect4Board.Board[i - 2, j - 2] == 'X' &&
                        Connect4Board.Board[i - 3, j - 3] == 'X')
                    {
                        //Return Win
                        move = j - 1;
                    }
                }
            }

            //Checks if the the column if full. If the Column is full then generate a Random number from 0-6
            if (Connect4Board.IsColumnFull(move))
            {
                do
                {
                    move = rnd.Next(7);
                } while (Connect4Board.IsColumnFull(move));
            }

        } while (Connect4Board.IsColumnFull(move));

        return move;
    }
}

