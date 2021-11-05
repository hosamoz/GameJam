
using UnityEngine;

public class LevelEnd : MonoBehaviour

{
    [SerializeField] private GameManagerProxy gameManager;
    [SerializeField] public string nextScene;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.NextScene(nextScene);
    }
}
