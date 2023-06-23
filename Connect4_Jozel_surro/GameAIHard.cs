namespace Connect4_Jozel_surro;

public class GameAIHard : Game, IGameProcess
{
    public AIPlayerHard Player2;

    public GameAIHard()
    {
        Player2 = new AIPlayerHard();
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
    public bool PlayGameAI(AIPlayerHard player)
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
}
