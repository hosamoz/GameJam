using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : SingletonBehaviour<ScoreManager>, IScoreManager
{
    [SerializeField] private ScoreEvent OnScoreChanged;
    [SerializeField] private GameObject UI;
    
    private int _currentDeaths;
    public int CurrentDeaths => _currentDeaths;
    private GameObject buttonUI;

    protected override void Awake()
    {
        base.Awake();
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Button");
        buttonUI = buttons[0];

        Reset();
        DontDestroyOnLoad(UI);
        DontDestroyOnLoad(buttons[0]);
    }

    public void Appear() {
        buttonUI.SetActive(true);
        Reset();
    }

    public void Disapeare() {
        buttonUI.SetActive(false);
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