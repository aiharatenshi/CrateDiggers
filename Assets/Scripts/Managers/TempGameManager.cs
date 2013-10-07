using UnityEngine;
using System.Collections.Generic;
using Constants;

[RequireComponent(typeof(TimerScript))]

public class TempGameManager : ManagerScript
{

    private CompWorldConstants.worldStates state;
    public float roundTime;
    public int roundTimerNumber = 1;
    public float intermissionTime;
    public int intermissionTimerNumber = 0;
    private TimerScript timer;

    public override void Start()
    {
        base.Start();
        timer = GetComponent<TimerScript>();
        StartIntermission();
    }

    public override void Update()
    {
        switch (state)
        {
            case CompWorldConstants.worldStates.noMatchInProgress:
                if (!timer.IsTimerActive(intermissionTimerNumber))  StartIntermission();
                break;
            case CompWorldConstants.worldStates.matchInProgress:
               if (!timer.IsTimerActive(roundTimerNumber))  EndGame();
                break;
            case CompWorldConstants.worldStates.intermission:
                if (!timer.IsTimerActive(intermissionTimerNumber)) StartGame();
                break;
            default:
                break;
        }
    }

    public void StartGame()
    {
        roundTimerNumber = timer.StartTimer(roundTime);
        state = CompWorldConstants.worldStates.matchInProgress;

        PlayerBaseScript[] playerList = FindObjectsOfType(typeof(PlayerBaseScript)) as PlayerBaseScript[];

        foreach (PlayerBaseScript cPlayer in playerList)
        {
            cPlayer.ResetPossessionTime();
        }
    }

    public void EndGame()
    {
        state = CompWorldConstants.worldStates.noMatchInProgress;
        StartIntermission();
    }

    public void StartIntermission()
    {
        intermissionTimerNumber = timer.StartTimer(intermissionTime);
        state = CompWorldConstants.worldStates.intermission;

        PlayerBaseScript[] playerList = FindObjectsOfType(typeof(PlayerBaseScript)) as PlayerBaseScript[];

        foreach (PlayerBaseScript cPlayer in playerList)
        {
            cPlayer.DropBall();
        }
    }

    public float GetRoundTime()
    {
        return timer.GetTimeRemaining(roundTimerNumber);
    }

    public float GetIntermissionTime()
    {
        return timer.GetTimeRemaining(intermissionTimerNumber);
    }

    public CompWorldConstants.worldStates GetState()
    {
        return state;
    }

}
