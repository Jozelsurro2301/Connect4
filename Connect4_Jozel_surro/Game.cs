using System.Numerics;

namespace Connect4_Jozel_surro;

//Class for the Basic Implementation of the Game
public class Game
{
    //Creates 1 Human Player for every Game
    private HumanPlayer _Player1;

    public HumanPlayer Player1
    {
        get { return _Player1; }
        set { _Player1 = value; }
    }

    public Game()
    {
        Player1 = new HumanPlayer();
    }


    //Get a valid input for the menu option. throws a Ecxeption if the input is invalid
    public int GetInput()
    {
        int input = 0;
        do
        {
            try
            {
                input = Convert.ToInt32(Console.ReadLine());

                if (input < 1 || input > 3)
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


    //Displays the Menu and Gets the user input on the mode to be played
    public void GameMenu()
    {
        int play;
        Console.Clear();
        Console.WriteLine("Welcome to Connect 4 Game!");
        Console.WriteLine("Please Select Mode:");
        Console.WriteLine("[1] Vs Human\n[2] Vs Computer(Easy)\n[3] Vs Computer(Hard)");
        play = GetInput();
        if (play == 1)
        {
            Console.Clear();
            var NewGame = new GameVsHuman();
            NewGame.StartGame();
        }
        else if (play == 2)
        {
             Console.Clear();
             var NewGame = new GameAIEasy();
             NewGame.StartGame();
        }
        else if (play == 3)
        {
                Console.Clear();
                var NewGame = new GameAIHard();
                NewGame.StartGame();
        }
        
    }

    //Gets both players information and assigns the symbol for the game
    public virtual void GetPlayers()
    {
        Console.WriteLine("Please enter name for Player 1");
        Player1.Playername = Console.ReadLine();
        Player1.PlayerSymbol = 'X';
    }


    //Starts the Game. This loops to both players until one player wins or ther is a draw
    public virtual void StartGame()
    {

    }


    //A method that get the Human Players Move and places it to the board.
    public bool PlayGame(HumanPlayer player)
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


    //A Helper method that places the piece to the board
    public void PlacePiece(int piece, char Player_Symbol)
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


    //Previews the Restart Menu after a successful Game
    public bool Restart()
    {
        int restart;
        do
        {
            Console.WriteLine("Play Again? [1] = Yes, [2] = Main Menu, [3] = Exit");
            restart = GetInput();
            if (restart == 3)
            {
                Environment.Exit(0);
            }
            else if (restart == 2)
            {
                GameMenu();
            }
            else
            {
                return true;
            }
        } while (true);
    }



    //Prints the winner of the game
    public void PrintWinner(string Playername)
    {
        Console.WriteLine($"It is a Connect 4!, {Playername} Wins!");
    }
}
