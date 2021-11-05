using UnityEngine;

public class DeathScore : MonoBehaviour
{
    [SerializeField] private int scoreValue;
    [SerializeField] private DeathEvent OnDeathScore;
    
    public void ScorePoints()
    {
        ScoreManager.instance?.AddDeathCount(scoreValue);
    }
}