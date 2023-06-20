using System;
using System.Diagnostics;
using System.Numerics;
using static Connect4_Jozel_surro.Program;

namespace Connect4_Jozel_surro;

//Class for Players
public class Player
{
    //Properties
    public string? Playername { get; set; }
    private char _PlayerSymbol;

    public char PlayerSymbol
    {
        get { return _PlayerSymbol; }
        set { _PlayerSymbol = value; }
    }
}


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

}


//The interface of the Game Process
public interface IGameProcess
{
    void GetPlayers();
    void StartGame();
    void Restart();
}

//Class for the Basic Implementation of the Game
public class Game
{
    //Creates 2 players
    protected Player Player1;
    protected Player Player2;

    public Game()
    {
        Player1 = new Player();
        Player2 = new Player();
    }

    //Every Game has 1 human playing
    //This is the method that gets the move of Human
    public static bool PlayGame(Player player)
    {
        int move;
        do
        {
            Connect4Board.DisplayBoard();
            Console.WriteLine($"{player.Playername}, Enter a number from 1-7: ");
            move = Convert.ToInt32(Console.ReadLine()) - 1;
            if (IsColumnFull(move))
            {
                move = 10;
            }

        } while (move > 6 || move < 0);

        PlacePiece(move, player);
        CheckIfFull();
        Console.Clear();
        if (IsWinner(player))
        {
            Connect4Board.DisplayBoard();
            return true;
        }
        return false;
    }


    //Checks if the a column is full
    public static bool IsColumnFull(int piece)
    {
        for (int i = Connect4Board.Rows - 1; i >= 0; i--)
        {
            if (Connect4Board.Board[i, piece] == '#')
            {
                return false;
            }
        }
        Console.Clear();
        Console.WriteLine("That Column is Full! Enter a Number Again!");

        return true;
    }

    //Places the players piece to the board
    public static void PlacePiece(int piece, Player player)
    {
        for (int i = Connect4Board.Rows - 1; i >= 0; i--)
        {
            if (Connect4Board.Board[i, piece] == '#')
            {
                Connect4Board.Board[i, piece] = player.PlayerSymbol;
                return;
            }
        }
    }


    //Check for winning patters
    public static bool IsWinner(Player player)
    {
        for (int i = 5; i >= 0; i--)
        {
            for (int j = 0; j <= 3; j++)
            {
                //Horizontal Win
                if (Connect4Board.Board[i, j] == player.PlayerSymbol &&
                    Connect4Board.Board[i, j + 1] == player.PlayerSymbol &&
                    Connect4Board.Board[i, j + 2] == player.PlayerSymbol &&
                    Connect4Board.Board[i, j + 3] == player.PlayerSymbol)
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
                if (Connect4Board.Board[i, j] == player.PlayerSymbol &&
                    Connect4Board.Board[i - 1, j] == player.PlayerSymbol &&
                    Connect4Board.Board[i - 2, j] == player.PlayerSymbol &&
                    Connect4Board.Board[i - 3, j] == player.PlayerSymbol)
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
                if (Connect4Board.Board[i, j] == player.PlayerSymbol &&
                Connect4Board.Board[i - 1, j + 1] == player.PlayerSymbol &&
                Connect4Board.Board[i - 2, j + 2] == player.PlayerSymbol &&
                Connect4Board.Board[i - 3, j + 3] == player.PlayerSymbol)
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
                if (Connect4Board.Board[i, j] == player.PlayerSymbol &&
                    Connect4Board.Board[i - 1, j - 1] == player.PlayerSymbol &&
                    Connect4Board.Board[i - 2, j - 2] == player.PlayerSymbol &&
                    Connect4Board.Board[i - 3, j - 3] == player.PlayerSymbol)
                {
                    //Return Win
                    return true;
                }
            }
        }

        //return fase if there is not winning pattern
        return false;

    }

    //Checks if the board is full
    public static bool CheckIfFull()
    {
        for (int i = 5; i >= 0; i--)
        {
            for (int j = 0; j < 7; j++)
            {
                if (Connect4Board.Board[i, j] == '#')
                {
                    return false;
                }
            }
        }
        Console.WriteLine("It's a Draw!");
        return true;
    }

    //Prints the winner of the game
    public static void PrintWinner(Player player)
    {
        Console.WriteLine($"It is a Connect 4!, {player.Playername} Wins!");
    }
}


//Class for the Game Implementation VS Human.
//This inherits the Game class and gets the interface of the IGameProcess
public class GameVsHuman : Game, IGameProcess
{
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
                PrintWinner(Player1);
                Restart();
            }

            gameover = PlayGame(Player2);
            if (gameover)
            {
                PrintWinner(Player2);
                Restart();
            }

        } while (!gameover);


    }

    //Prompts for a restart after a game has ended
    public void Restart()
    {
        int restart;
        do
        {
            Console.WriteLine("Play Again? [1] = Yes, [2] = No");
            restart = Convert.ToInt32(Console.ReadLine());
            if (restart == 1)
            {
                Console.Clear();
                StartGame();
            }
            else if (restart == 2)
            {
                Environment.Exit(0);
            }
        } while (restart != 1 || restart != 2);
    }
}


// An interface for the Human vs AI mode
public interface IGameAI
{
    bool PlayGameAI(Player player);
}


//A class for a the game implementation of the the Game vs an easy AI
//This will inherit the Game class and will get the interface of both IGameProcess and IGameAI
public class GameAIEasy : Game, IGameProcess, IGameAI
{
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
                PrintWinner(Player1);
                Restart();
            }

            gameover = PlayGameAI(Player2);
            if (gameover)
            {
                PrintWinner(Player2);
                Restart();
            }

        } while (!gameover);
    }

    //Generates the move of the AI
    //For the easy AI- It will just generate a random number from 1-7 without checking move of the human
    public virtual bool PlayGameAI(Player player)
    {
        int move;
        do
        {
            Connect4Board.DisplayBoard();
            move = rnd.Next(1, 7);
            if (IsColumnFull(move))
            {
                move = 10;
            }

        } while (move > 6 || move < 0);

        PlacePiece(move, player);
        CheckIfFull();
        Console.Clear();
        if (IsWinner(player))
        {
            Connect4Board.DisplayBoard();
            return true;
        }

        return false;

    }

    //Prompts for a restart
    public void Restart()
    {
        int restart;
        do
        {
            Console.WriteLine("Play Again? [1] = Yes, [2] = No");
            restart = Convert.ToInt32(Console.ReadLine());
            if (restart == 1)
            {
                Console.Clear();
                StartGame();


            }
            else if (restart == 2)
            {
                Environment.Exit(0);
            }
        } while (restart != 1 || restart != 2);
    }
}





public class GameAIHard : GameAIEasy
{
    public override bool PlayGameAI(Player player)
    {
        // Plays the game
        int move;
        do
        {
            Connect4Board.DisplayBoard();

            //Condition for placing the piece
            move = rnd.Next(1, 7);
            //Check if players got connect4
            for (int i = 5; i >= 0; i--)
            {
                for (int j = 0; j <= 3; j++)
                {
                    //Horizontal Win
                    if (Connect4Board.Board[i, j] == 'X' &&
                        Connect4Board.Board[i, j + 1] == 'X' &&
                        Connect4Board.Board[i, j + 2] == 'X')
                    {
                        //Return Win
                        move = j + 3;
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
                        Connect4Board.Board[i - 2, j] == 'X')
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
                    Connect4Board.Board[i - 2, j + 2] == 'X')
                    {
                        //Return Win
                        move = j + 3;
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
                        Connect4Board.Board[i - 2, j - 2] == 'X')
                    {
                        //Return Win
                        move = j - 3;
                    }
                }
            }


            //Condition
            if (IsColumnFull(move))
            {
                move = 10;
            }

        } while (move > 6 || move < 0);

        PlacePiece(move, player);
        CheckIfFull();
        Console.Clear();
        if (IsWinner(player))
        {
            Connect4Board.DisplayBoard();
            return true;
        }

        return false;
    }
}

class Program
{

    static void Main(string[] args)
    {
        int play;
        Console.WriteLine("Please Select Mode:");
        Console.WriteLine("[1] Vs Human, [2] Vs Computer");
        play = Convert.ToInt32(Console.ReadLine());
        if (play == 1)
        {
            var NewGame = new GameVsHuman();
            NewGame.StartGame();
        }
        else if (play == 2)
        {
            Console.WriteLine("Please Select Mode:");
            Console.WriteLine("[1] Easy, [2] Hard");
            play = Convert.ToInt32(Console.ReadLine());

            if (play == 1)
            {
                var NewGame = new GameAIEasy();
                NewGame.StartGame();
            }
            else if (play == 2)
            {
                var NewGame = new GameAIHard();
                NewGame.StartGame();
            }
        }
    }
}
