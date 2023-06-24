namespace Connect4_Jozel_surro;

public class GameAIHard : Game
{
    //Creates a Hard AI Player;
    private AIPlayerHard _Player2;

    public AIPlayerHard Player2
    {
        get { return _Player2; }
        set { _Player2 = value; }
    }

    public GameAIHard()
    {
        Player2 = new AIPlayerHard();
    }



    //Promts the human Player to input a name and assigns a symbol for oth human and AI Player
    public override void GetPlayers()
    {
        Console.WriteLine("Please enter name for Player 1");
        Player1.Playername = Console.ReadLine();
        Player1.PlayerSymbol = 'X';
        Player2.Playername = "Computer";
        Player2.PlayerSymbol = 'O';
    }

    //Starts a game with player 2 as the computer. This loops to both players until one player wins or ther is a draw.
    public override void StartGame()
    {
        bool gameover;
        Console.WriteLine("Connect 4 Vs Hard AI");
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
    //A method that gets the AI move and places it to the board.
    public bool PlayGameAI(AIPlayerHard player)
    {
        int move;

        move = player.GetMove();

        PlacePiece(move, player.PlayerSymbol);
        Console.Clear();
        if (Connect4Board.IsWinner(player.PlayerSymbol))
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
}
