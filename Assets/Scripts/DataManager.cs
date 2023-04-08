using UnityEngine;

public class DataManager
{
    private int currentLevel;
    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
    }

    public int CurrentTargetScore;

    private string levelSaveKey = "level_save_key";

    public int GetSavedProgressLevel()
    {
        int savedProgressLevel = -1;

        if (PlayerPrefs.HasKey(levelSaveKey))
        {
            savedProgressLevel = PlayerPrefs.GetInt(levelSaveKey);
        }

        return savedProgressLevel;
    }

    public void SaveCurrentLevel(int currentLevel)
    {
        this.currentLevel = currentLevel;
        PlayerPrefs.SetInt(levelSaveKey, currentLevel);
        PlayerPrefs.Save();
    }
}
