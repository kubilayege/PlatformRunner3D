using UnityEngine;
using UnityEngine.UI;


public enum UIScreen
{
    MainMenu,
    InGame,
    WinScreen,
    FailScreen,
    BrushScreen
}

[System.Serializable]
public class UIManager 
{
    [SerializeField]
    private GameObject[] screens;
    [SerializeField]
    private int currentScreenIndex;

    public UIManager(GameObject[] _screens)
    {
        screens = _screens;
    }

    public void UpdatePlace(int value,int outOf)
    {
        screens[(int)UIScreen.InGame].transform.GetChild(0).GetComponent<Text>().text = value.ToString() + "/" + outOf.ToString();
    }

    public void UpdateWallPercentage(float value)
    {
        screens[(int)UIScreen.BrushScreen].transform.GetChild(0).GetComponent<Text>().text = value.ToString("0.00") + "%";
    }

    public void ChangeUI(UIScreen screen)
    {
        screens[currentScreenIndex].SetActive(false);
        currentScreenIndex = (int)screen;
        screens[currentScreenIndex].SetActive(true);
    }
}