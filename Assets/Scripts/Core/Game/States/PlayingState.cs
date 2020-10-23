using System;
using UnityEngine;
public class PlayingState : IGameState
{
    Game game;
    public PlayingState(Game currentGame)
    {
        this.game = currentGame;
        game.uiManager.ChangeUI(UIScreen.InGame);
        Debug.Log("PlayingState");
    }

    public void BackToMenu()
    {
        game.state = new MainMenu(game);
        return;
    }

    public void Fail()
    {
        game.state = new FailState(game);
        return;
    }

    public void FinishRace()
    {
        return;
    }

    public void Play()
    {
        game.state = this;
        return;
    }

    public void Win()
    {
        game.state = new WinState(game);
        return;
    }
}

