using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScoreManager
{
    public void Reset();

    public void AddDeathCount(int value);
   
}
