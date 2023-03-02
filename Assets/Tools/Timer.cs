using System;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Timer : MonoBehaviour {
    private float seconds;
    private Action action;
    
    public void SetTimer(Action action, float seconds) {
        this.action = action;
        this.seconds = seconds;
    }
    
    void Update() {
        if (seconds > 0) seconds -= Time.deltaTime;
        if (IsTimerComplete()) action();
    }

    private bool IsTimerComplete() => seconds <= 0;
}
