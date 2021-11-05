using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameManager
{
    void Quit();

    void NextScene(string nextScene);

    void ReloadScene();

    public void NextUI(string nextScene);
}
