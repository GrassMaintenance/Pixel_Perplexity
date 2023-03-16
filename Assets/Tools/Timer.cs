using System;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _seconds;
    private Action _action;
    public void SetTimer(Action action, float seconds)
    {
        _action = action;
        _seconds = seconds;
    }

    private void Update()
    {
        if (_seconds > 0) _seconds -= Time.deltaTime;
        if (IsTimerComplete())
        {
            _action?.Invoke();
            _action = null; // Prevent the action from being called multiple times
        }
    }

    private bool IsTimerComplete() => _seconds <= 0;
}