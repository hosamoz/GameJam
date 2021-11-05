using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyScoreManager : MonoBehaviour, IScoreManager
{
    public void AddDeathCount(int value)
    {
        ScoreManager.instance.AddDeathCount(value);
    }

    public void Reset()
    {
        ScoreManager.instance.Reset();
    }
}
