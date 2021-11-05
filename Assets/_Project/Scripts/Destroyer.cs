using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private DestroyerEvent OnDestroy;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        OnDestroy?.Invoke();
        
    }
    
}
