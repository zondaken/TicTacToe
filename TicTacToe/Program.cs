using System;
using TicTacToe.MVC;
using TicTacToe.MVC.ControllerNS;
using TicTacToe.MVC.ViewNS;
using TicTacToe.Unrelated;

namespace TicTacToe
{

    public static class Program
    {
        public static void Main(string[] args)
        {
            var board = new Board(3);
            var model = new Model(board);
            
            var view = new View(model);
            
            var controller = new Controller(model, view);
            controller.Run();
        }
    }
}