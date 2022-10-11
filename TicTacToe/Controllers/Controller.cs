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
        // game loop
        while (true)
        {
            // render
            _view.Render();

            // win
            if (_model.Board.CheckWin(out Player? player))
            {
                Debug.Assert(player != null); // if check returns true, player will be non-null
                // TODO: make win screen
                break;
            }
            
            // tie
            if (_model.TurnCount >= _model.Board.Count) break;
        }
    }

    // input is string because of view independency, so that multiple views dont need to parse altogether (it happens in one place by passing a normalized value into the event)
    private void OnInputSubmitted(string input)
    {
        // input is defined as the new tile to mark for a player (X or O, depending on current player)
        
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