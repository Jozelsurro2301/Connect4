using System.Numerics;

namespace Connect4_Jozel_surro;

//Class for the Basic Implementation of the Game
public class Game
{
    ////Creates 2 players
    public HumanPlayer Player1;

    public Game()
    {
        Player1 = new HumanPlayer();
    }

    public static int GetInput()
    {
        int input = 0;
        do
        {
            try
            {
                input = Convert.ToInt32(Console.ReadLine());

                if (input < 1 || input > 2)
                {
                    throw new GettingValidMove("Invalid Input");
                }
                return input;
            }
            catch (FormatException Fe)
            {
                Console.WriteLine(Fe.Message);
            }
            catch (GettingValidMove Gvm)
            {
                Gvm.EnterVAlidOption();
            }
        } while (true);
        
    }

   
    //Every Game has 1 human playing
    //This is the method that gets the move of Human
    public static bool PlayGame(HumanPlayer player)
    {
        int move;

        do
        {
            Connect4Board.DisplayBoard();
            Console.WriteLine($"{player.Playername}, Enter a number from 1-7: ");
            move = player.GetMove();
        } while (Connect4Board.IsColumnFull(move));


        PlacePiece(move, player.PlayerSymbol);
        Console.Clear();

        if (IsWinner(player.PlayerSymbol))
        {
            Connect4Board.DisplayBoard();
            return true;
        }
        else if (Connect4Board.CheckIfFull())
        {
            Connect4Board.DisplayBoard();
            Restart();
        }
        return false;
    }


    //Places the players piece to the board
    public static void PlacePiece(int piece, char Player_Symbol)
    {
        for (int i = Connect4Board.Rows - 1; i >= 0; i--)
        {
            if (Connect4Board.Board[i, piece] == '#')
            {
                Connect4Board.Board[i, piece] = Player_Symbol;
                return;
            }
        }
    }


    //Check for winning patters
    public static bool IsWinner(char Player_Symbol)
    {
        for (int i = 5; i >= 0; i--)
        {
            for (int j = 0; j <= 3; j++)
            {
                //Horizontal Win
                if (Connect4Board.Board[i, j] == Player_Symbol &&
                    Connect4Board.Board[i, j + 1] == Player_Symbol &&
                    Connect4Board.Board[i, j + 2] == Player_Symbol &&
                    Connect4Board.Board[i, j + 3] == Player_Symbol)
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
                if (Connect4Board.Board[i, j] == Player_Symbol &&
                    Connect4Board.Board[i - 1, j] == Player_Symbol &&
                    Connect4Board.Board[i - 2, j] == Player_Symbol &&
                    Connect4Board.Board[i - 3, j] == Player_Symbol)
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
                if (Connect4Board.Board[i, j] == Player_Symbol &&
                Connect4Board.Board[i - 1, j + 1] == Player_Symbol &&
                Connect4Board.Board[i - 2, j + 2] == Player_Symbol &&
                Connect4Board.Board[i - 3, j + 3] == Player_Symbol)
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
                if (Connect4Board.Board[i, j] == Player_Symbol &&
                    Connect4Board.Board[i - 1, j - 1] == Player_Symbol &&
                    Connect4Board.Board[i - 2, j - 2] == Player_Symbol &&
                    Connect4Board.Board[i - 3, j - 3] == Player_Symbol)
                {
                    //Return Win
                    return true;
                }
            }
        }

        //return fase if there is not winning pattern
        return false;

    }

  
    public static bool Restart()
    {
        int restart;
        do
        {
            Console.WriteLine("Play Again? [1] = Yes, [2] = No");
            restart = GetInput();
            if (restart == 2)
            {
                Environment.Exit(0);
            }
            else
            {
                return true;
            }
        } while (true);
    }


    //Prints the winner of the game
    public static void PrintWinner(string Playername)
    {
        Console.WriteLine($"It is a Connect 4!, {Playername} Wins!");
    }
}
