using UnityEngine;

public class WinState : IGameState
{
    private Game game;

    public WinState(Game game)
    {
        this.game = game;
        game.uiManager.ChangeUI(UIScreen.WinScreen);
        Debug.Log("WinState");
    }

    public void BackToMenu()
    {
        game.uiManager.ChangeUI(UIScreen.MainMenu);
        game.state = new MainMenu(game);
        return;
    }

    public void FinishRace()
    {
        return;
    }

    public void Fail()
    {
        return;
    }

    public void Play()
    {
        game.state = new BrushState(game,LoadType.Pass);
        return;
    }

    public void Win()
    {
        return;
    }
}