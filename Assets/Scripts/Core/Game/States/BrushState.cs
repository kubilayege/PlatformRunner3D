using UnityEngine;
public class BrushState : IGameState
{
    private Game game;
    private LoadType type;
    public BrushState(Game game,LoadType _type)
    {
        this.game = game;
        this.type = _type;
        game.uiManager.ChangeUI(UIScreen.BrushScreen);
        Debug.Log("BrushState");
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

    public void Play()
    {
        game.state = new PlayingState(game);
        game.levelManager.LoadLevel(type);

        game.InitLevel(Object.FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement,
                                                 Object.FindObjectsOfType(typeof(AIMovement)) as AIMovement[]);

        game.player.ResetAgent();
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
}