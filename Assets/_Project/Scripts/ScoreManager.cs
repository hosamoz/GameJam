using System;
using UnityEngine;

public class ScoreManager : SingletonBehaviour<ScoreManager>
{
    [SerializeField] private DeathEvent OnDeath;
    [SerializeField] private DeathEvent OnScoreChanged;
    
    private int _currentDeaths;
    private int _hiScore;
    public int CurrentDeaths => _currentDeaths;
    public int hiScore => _hiScore;

    protected override void Awake()
    {
        base.Awake();
        _hiScore = PlayerPrefs.GetInt("HiScore", 0);
        _currentDeaths = PlayerPrefs.GetInt("Deaths", 0);
    }

    private void Start()
    {
        OnScoreChanged?.Invoke();
    }

    public void Reset()
    {
        _currentDeaths = 0;
        OnScoreChanged?.Invoke();
    }

    public void AddDeathCount(int value)
    {
        _currentDeaths++;
        PlayerPrefs.SetInt("Deaths", _currentDeaths);
        
        OnDeath?.Invoke();
        OnScoreChanged?.Invoke();
       
    }
}