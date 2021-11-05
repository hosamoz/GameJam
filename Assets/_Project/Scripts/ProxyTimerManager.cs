using UnityEditor;
using UnityEngine;

public class ProxyTimerManager : MonoBehaviour, ITimerManager
{
    public void SetTimer(int timeToDisplay)
    {
        TimerManager.instance.SetTimer(timeToDisplay);
    }
    public void Reset()
    {
        ScoreManager.instance.Reset();
    }
}