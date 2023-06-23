namespace Connect4_Jozel_surro;

//Class for Players
public interface IPlayer
{

    public string Playername { get; set; }
    public char PlayerSymbol { get; set; }

    int GetMove();
}




public class HumanPlayer : IPlayer
{
    public string Playername { get; set; }
    public char PlayerSymbol { get; set; }


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



public class AIPlayerEasy : IPlayer
{
    protected Random rnd = new();

    //public AIPlayerEasy()
    //{
    //    PlayerInfo player = new PlayerInfo();
    //}

    public string Playername { get; set; }
    public char PlayerSymbol { get; set; }

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


public class AIPlayerHard : IPlayer
{
    protected Random rnd = new();
    public string Playername { get; set; }
    public char PlayerSymbol { get; set; }

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

            //Condition
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

