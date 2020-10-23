using UnityEngine;


public enum LoadType
{
    Restart = 0,
    Pass = 1
}

[System.Serializable]
public class LevelManager
{
    [SerializeField]
    public GameObject[] levels;

    private GameObject currentLevel;

    private int currentLevelNumber;

    public LevelManager(GameObject[] _levels)
    {
        levels = (GameObject[])_levels.Clone();
    }

    public void LoadLevel(LoadType loadType)
    {
        if (currentLevel != null)
            Object.Destroy(currentLevel);
        
        currentLevelNumber += (int)loadType;

        currentLevel = Object.Instantiate(levels[currentLevelNumber % levels.Length]);
    }
}
