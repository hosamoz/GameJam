using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>, IGameManager
{
    [SerializeField] private ScoreManager scoreManager;
    public void Quit()
    {
        Application.Quit();
    }


    public void NextScene(string nextScene)
    {
        if (nextScene == "Tutorial")
        {
            scoreManager.Disapeare();
            SceneManager.LoadScene(nextScene);
            PlayerPrefs.SetString("Scene", nextScene);
        }
        else if (nextScene == "Main UI")
        {
            scoreManager.Appear();
        }
        else {
            SceneManager.LoadScene(nextScene);
            PlayerPrefs.SetString("Scene", nextScene);
        }
        
    }

    public void NextUI(string nextScene)
    {
        if (nextScene == "Main UI")
        {
            scoreManager.Appear();
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("Scene"));
    }

}
