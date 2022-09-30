using System.Diagnostics;
using TicTacToe.Models;
using TicTacToe.Models.BoardNS;
using TicTacToe.Views;

namespace TicTacToe.Controllers;

public class Controller
{
    private readonly Model _model;
    private readonly View _view;

    public Controller(Model model, View view)
    {
        _model = model;
    
        _view = view;
        _view.InputSubmitted += OnInputSubmitted;
    }

    public void Run()
    {
        while (true)
        {
            _view.Render();

            // win
            if (_model.Board.CheckWin(out Player? player))
            {
                Debug.Assert(player != null); // if check returns true, player will be non-null
            }
            
            // tie
            if (_model.TurnCount >= _model.Board.Count) break;
        }
    }

    private void OnInputSubmitted(string input)
    {
        int iPosition = int.Parse(input);
        if (iPosition < 0 || iPosition >= _model.Board.Count) return;

        BoardPosition pPosition = new BoardPosition(_model.Board, iPosition);

        if (_model.Board[pPosition] == null)
        {
            _model.Board[pPosition] = _model.Players[_model.CurrentPlayer];
            _model.CurrentPlayer = (_model.CurrentPlayer + 1) % _model.Players.Length;
            _model.TurnCount++;
        }
    }
}