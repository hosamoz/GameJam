using UnityEngine;

public class ScoreManager : SingletonBehaviour<ScoreManager>, IScoreManager
{
    [SerializeField] private ScoreEvent OnScoreChanged;
    [SerializeField] private GameObject UI;
    
    private int _currentDeaths;
    public int CurrentDeaths => _currentDeaths;

    protected override void Awake()
    {
        base.Awake();
        PlayerPrefs.SetInt("Deaths", 0);
        DontDestroyOnLoad(UI);
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