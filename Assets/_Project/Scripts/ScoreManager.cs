using System.Collections.Generic;
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
        GameObject[] uis = GameObject.FindGameObjectsWithTag("Player UI");
        if (uis.Length > 1) {
            Destroy(uis[1]);
            
        }

        Reset();

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
        PlayerPrefs.SetInt("Deaths", 0);
    }

    public void AddDeathCount(int value)
    {
        _currentDeaths++;
        PlayerPrefs.SetInt("Deaths", _currentDeaths);
        OnScoreChanged?.Invoke(_currentDeaths);
    }
}