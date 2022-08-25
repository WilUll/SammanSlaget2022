using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
    [SerializeField] public static int Misses = 0;
    [SerializeField] public static int Correct = 0;

    public static int MoneyCollected;

    public static void AddScore(int score)
    {
        MoneyCollected += score;
    }
}
