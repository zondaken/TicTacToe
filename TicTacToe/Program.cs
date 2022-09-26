using TicTacToe.MVC.ControllerNS;
using TicTacToe.MVC.ModelNS;
using TicTacToe.MVC.ViewNS;

namespace TicTacToe
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var model = new Model
            {
                Board = new Board(3)
            };

            var view = new View(model);
            var controller = new Controller(model, view);
            
            controller.Run();
        }
    }
}