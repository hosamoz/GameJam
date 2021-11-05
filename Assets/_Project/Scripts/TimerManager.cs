using System;
using UnityEngine;

public class TimerManager : SingletonBehaviour<TimerManager>,ITimerManager
{
    [SerializeField] private TimerEvent OnTimeChange;
    [SerializeField] private DeathEvent OnDeath;
    [SerializeField] private float _timeLimit;

    [SerializeField] private GameManager _gameManager;
    
    private float _remainingTimeInSec;
    public float RemainingTimeInSec => _remainingTimeInSec;
    private bool timerIsRunning;

    public void Reset()
    {
        OnTimeChange?.Invoke((int)_timeLimit);
    }
     
    private void Start()
    {
        _remainingTimeInSec = _timeLimit;
        OnTimeChange?.Invoke((int)_remainingTimeInSec);
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (_remainingTimeInSec > 0)
            {
                _remainingTimeInSec -= Time.deltaTime;
            }
            else
            {
                // Debug.Log("Time has run out!");
                _remainingTimeInSec = 0;
                timerIsRunning = false;
                // OnDeath?.Invoke();
                // died?.Invoke();
                _gameManager.NextUI("Main UI");
                SetTimer((int)_timeLimit);
            }
            OnTimeChange?.Invoke((int)_remainingTimeInSec);
        }
        // PlayerPrefs.SetInt("TimerHighScore", (int)_remainingTimeInSec);
    }

    public void SetTimer(int timeToDisplay)
    {
        _timeLimit = timeToDisplay;
        _remainingTimeInSec = _timeLimit;
    }
    public void SetTimerIsRunning()
    {
        timerIsRunning = true;
    }

   
}
