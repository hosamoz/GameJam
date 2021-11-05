using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>, IGameManager
{
    public void Quit()
    {
        Application.Quit();
    }


    public void NextScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
        PlayerPrefs.SetString("Scene", nextScene);
    }

    public void NextUI(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("Scene"));
    }

}
