using System;
using System.Diagnostics;
using System.Numerics;
using static Connect4_Jozel_surro.Program;

namespace Connect4_Jozel_surro;


class Program
{

    static void Main(string[] args)
    {
        int play;
        Console.WriteLine("Please Select Mode:");
        Console.WriteLine("[1] Vs Human, [2] Vs Computer");
        play = Game.GetInput();
        if (play == 1)
        {
            Console.Clear();
            var NewGame = new GameVsHuman();
            NewGame.StartGame();
        }
        else if (play == 2)
        {
            Console.Clear();
            Console.WriteLine("Please Select Mode:");
            Console.WriteLine("[1] Easy, [2] Hard");
            play = Game.GetInput();
            if (play == 1)
            {
                Console.Clear();
                var NewGame = new GameAIEasy();
                NewGame.StartGame();
            }
            else if (play == 2)
            {
                Console.Clear();
                var NewGame = new GameAIHard();
                NewGame.StartGame();
            }
        }
    }
}
