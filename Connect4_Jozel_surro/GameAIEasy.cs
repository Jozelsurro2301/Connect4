using System.Numerics;

namespace Connect4_Jozel_surro;

//A class for a the game implementation of the the Game vs an easy AI
//This will inherit the Game class and will get the interface of both IGameProcess and IGameAI
public class GameAIEasy : Game, IGameProcess
{
    public AIPlayerEasy Player2;

    public GameAIEasy()
    {
        Player2 = new AIPlayerEasy();
    }

    protected Random rnd = new();

    //Promts the human for the Name
    public void GetPlayers()
    {
        Console.WriteLine("Please enter name for Player 1");
        Player1.Playername = Console.ReadLine();
        Player1.PlayerSymbol = 'X';
        Player2.Playername = "Computer";
        Player2.PlayerSymbol = 'O';
    }

    //Starts a game with player 2 as the computer
    public void StartGame()
    {
        bool gameover;
        Console.WriteLine("Welcome to Connect 4 Game!");
        GetPlayers();
        Console.Clear();
        Connect4Board.CreateBoard();

        do
        {
            gameover = PlayGame(Player1);
            if (gameover)
            {
                PrintWinner(Player1.Playername);
                break;
            }

            gameover = PlayGameAI(Player2);
            if (gameover)
            {
                PrintWinner(Player2.Playername);
                break;
            }

        } while (!gameover);

        if (Restart() == true)
        {
            Console.Clear();
            StartGame();
        }

    }

    //Generates the move of the AI
    //For the easy AI- It will just generate a random number from 1-7 without checking move of the human
    public bool PlayGameAI(AIPlayerEasy player)
    {
        int move;

       move = player.GetMove();

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

    //Prompts for a restart
    //public void Restart()
    //{
    //    int restart;
    //    do
    //    {
    //        Console.WriteLine("Play Again? [1] = Yes, [2] = No");
    //        restart = GetInput();
    //        if (restart == 1)
    //        {
    //            Console.Clear();
    //            StartGame();


    //        }
    //        else if (restart == 2)
    //        {
    //            Environment.Exit(0);
    //        }
    //    } while (restart != 1 || restart != 2);
    //}
}
