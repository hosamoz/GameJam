using UnityEngine;

public class ScoreManager : SingletonBehaviour<ScoreManager>
{
    [SerializeField] private ScoreEvent OnScoreChanged;
    
    private int _currentDeaths;
    public int CurrentDeaths => _currentDeaths;

    protected override void Awake()
    {
        base.Awake();
        _currentDeaths = PlayerPrefs.GetInt("Deaths", 0);
    }

    private void Start()
    {
        OnScoreChanged?.Invoke(_currentDeaths);
    }

    public void Reset()
    {
        _currentDeaths = 0;
        OnScoreChanged?.Invoke(_currentDeaths);
    }

    public void AddDeathCount(int value)
    {
        _currentDeaths++;
        PlayerPrefs.SetInt("Deaths", _currentDeaths);
        OnScoreChanged?.Invoke(_currentDeaths);
    }
}