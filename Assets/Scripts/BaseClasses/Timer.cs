using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    /// <summary>
    /// Basic timer. Counts down.
    /// 
    /// </summary>

    //private float startTime;
    private float timerLength;
    private float timeRemaining;
    public bool isActive;

    /// <summary>
    /// Call this method to start a timer.
    /// </summary>
    /// <param name="_timerLength">The length of the timer in seconds</param>
    public void StartTimer(float _timerLength)
    {
        //startTime = Time.time;
        timerLength = _timerLength;
        timeRemaining = timerLength;
    }

    public void EndTimerForcefully() { }

    private void EndTimer()
    {
        isActive = false;
    }

	// Update is called once per frame
	public void Update () {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining > 0)
        {
            isActive = true;
        }
        else
        {
            EndTimer();
        }
	}
}
