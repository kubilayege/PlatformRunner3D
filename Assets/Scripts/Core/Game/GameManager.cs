using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager main;
    public GameObject[] levels;
    public GameObject[] uiScreens;


    public Game game;


    private LevelManager levelManager;
    private UIManager uiManager;

    void Awake()
    {
        main = this;
        levelManager = new LevelManager(levels);
        uiManager = new UIManager(uiScreens);

        game = new Game(levelManager, uiManager);
        game.InitGame(new MainMenu(game));

    }
    private void Update()
    {
        if(Helper.IsPlaying())
            game.UpdatePlayerPlace();
    }

}
