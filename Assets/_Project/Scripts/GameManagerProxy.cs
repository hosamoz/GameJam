using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerProxy : MonoBehaviour, IGameManager
{
    public void Quit()
    {
        GameManager.instance.Quit();
    }

    public void NextScene(string nextScene)
    {
        GameManager.instance.NextScene(nextScene);
    }

    public void NextUI(string nextScene)
    {
        GameManager.instance.NextUI(nextScene);
    }

    public void ReloadScene() 
    {
        GameManager.instance.ReloadScene();
    }
}
