namespace Connect4_Jozel_surro;


//A User difined Exception For Each User inputs.
public class GettingValidMove : ApplicationException
{
    public GettingValidMove(string msg) : base(msg)
    {
    }
    public void EnterValidMove()
    {
        Console.WriteLine("Please enter a valid move(1 - 7)");
    }
    public void EnterVAlidOption()
    {
        Console.WriteLine("Please enter a valid input(1 - 3)");
    }
}
