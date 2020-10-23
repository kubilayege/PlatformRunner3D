using UnityEngine;

public class FailState : IGameState
{
    private Game game;

    public FailState(Game game)
    {
        this.game = game;
        game.uiManager.ChangeUI(UIScreen.FailScreen);
        Debug.Log("FailState");
    }

    public void BackToMenu()
    {
        game.uiManager.ChangeUI(UIScreen.MainMenu);
        game.state = new MainMenu(game);

        return;
    }

    public void Play()
    {
        game.state = new BrushState(game,LoadType.Restart);
        return;
    }

    public void Win()
    {

        return;
    }

    public void Fail()
    {
        return;
    }

    public void FinishRace()
    {
        return;
    }
}