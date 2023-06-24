using System.Numerics;

namespace Connect4_Jozel_surro;

//Class for the Game Implementation VS Human.
//This inherits the Game class and gets the interface of the IGameProcess
public class GameVsHuman : Game
{
    //This create another HumanPlayer for the 2 player Mode
    private HumanPlayer _Player2;

    public HumanPlayer Player2
    {
        get { return _Player2; }
        set { _Player2 = value; }
    }

    public GameVsHuman()
    {
        Player2 = new HumanPlayer();
    }


    //Gets both players information and assigns the symbol for the game
    public override void GetPlayers()
    {
        Console.WriteLine("Please enter name for Player 1");
        Player1.Playername = Console.ReadLine();
        Player1.PlayerSymbol = 'X';
        Console.WriteLine("Please enter name for Player 2");
        Player2.Playername = Console.ReadLine();
        Player2.PlayerSymbol = 'O';
    }


    //Starts the Game. This loops to both players until one player wins or ther is a draw
    public override void StartGame()
    {
        bool gameover;
        Console.WriteLine("Connect 4! 2 Player Mode!");
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
