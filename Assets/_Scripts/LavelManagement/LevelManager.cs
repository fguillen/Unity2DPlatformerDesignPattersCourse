using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum LevelName
{
    Menu,
    Win,
    Level1,
    Level2
}

public class LevelManager : MonoBehaviour
{
    public Dictionary<LevelName, int> levels = new Dictionary<LevelName, int>();

    void Awake()
    {
        levels.Add(LevelName.Menu, 0);
        levels.Add(LevelName.Win, 1);
        levels.Add(LevelName.Level1, 2);
        levels.Add(LevelName.Level2, 3);
    }

    public void LoadLevel(LevelName levelName)
    {
        LoadLevelByIndex(levels[levelName]);
    }

    public void LoadLevelByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadLevelMenu()
    {
        LoadLevel(LevelName.Menu);
    }

    public void LoadLevelWin()
    {
        LoadLevel(LevelName.Win);
    }

    public void LoadLevelLevel1()
    {
        LoadLevel(LevelName.Level1);
    }

    public void LoadNextLevel()
    {
        LoadLevelByIndex(GetNextLevelIndex());
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    int GetNextLevelIndex()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        if (index < SceneManager.sceneCountInBuildSettings)
            return index;
        else
            return levels[LevelName.Win];
    }
}
