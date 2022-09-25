namespace TicTacToe.MVC.ViewNS;

public class View
{
    private readonly Model _model;
    private readonly BoardDrawer _drawer;

    public event Action<string>? InputSubmitted;

    public View(Model model)
    {
        _model = model;
        _drawer = new BoardDrawer(model.Board);
    }

    public void Render()
    {
        _drawer.Draw();
        
        Console.WriteLine();
        Console.WriteLine("Turns: {0}", _model.TurnCount);
        
        string input = GetInput();
        InputSubmitted?.Invoke(input);
    }

    private string GetInput()
    {
        Console.Write("Input: ");
        string input = Console.ReadLine() ?? throw new ArgumentException("no input");
        return input;
    }
}