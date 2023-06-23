using System.Numerics;

namespace Connect4_Jozel_surro;

//Class for the Game Implementation VS Human.
//This inherits the Game class and gets the interface of the IGameProcess
public class GameVsHuman : Game, IGameProcess
{
    public HumanPlayer Player2;

    public GameVsHuman()
    {
        Player2 = new HumanPlayer();
    }


    //Gets both players information and assigns the symbol for the game
    public void GetPlayers()
    {
        Console.WriteLine("Please enter name for Player 1");
        Player1.Playername = Console.ReadLine();
        Player1.PlayerSymbol = 'X';
        Console.WriteLine("Please enter name for Player 2");
        Player2.Playername = Console.ReadLine();
        Player2.PlayerSymbol = 'O';
    }

    //Starts the Game 
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

            gameover = PlayGame(Player2);
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

}
