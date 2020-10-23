using UnityEngine;
public class MainMenu : IGameState
{
    private Game game;

    public MainMenu(Game currentGame)
    {
        this.game = currentGame;
        game.uiManager.ChangeUI(UIScreen.MainMenu);
        Debug.Log("MainMenu");
    }

    public void BackToMenu()
    {
        game.state = this;
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
        game.levelManager.LoadLevel(LoadType.Restart);
        game.InitLevel(Object.FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement,
                                                 Object.FindObjectsOfType(typeof(AIMovement)) as AIMovement[]);
        game.state = new PlayingState(game);
        return;
    }

    public void Win()
    {
        return;
    }
}

