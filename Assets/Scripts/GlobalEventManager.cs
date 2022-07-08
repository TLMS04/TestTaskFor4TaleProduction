using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager 
{
    public static UnityEvent OnCoinTake = new UnityEvent();
    public static UnityEvent OnWin = new UnityEvent();
    public static UnityEvent OnLose = new UnityEvent();
    public static UnityEvent<int> OnScoreChanged = new UnityEvent<int>();
    public static UnityEvent<int, int> OnTimeChanged = new UnityEvent<int, int>();
    public static void SendCoinTake()
    {
        OnCoinTake.Invoke();
    }
    public static void SendScoreChanged(int score)
    {
        OnScoreChanged.Invoke(score);
    }
    public static void SendTimeChanged(int seconds, int milliseconds)
    {
        OnTimeChanged.Invoke(seconds, milliseconds);
    }
    public static void SendWin()
    {
        OnWin.Invoke();
    }
    public static void SendLose()
    {
        OnLose.Invoke();
    }
}
