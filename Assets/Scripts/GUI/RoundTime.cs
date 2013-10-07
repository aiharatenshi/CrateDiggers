using UnityEngine;
using System.Collections;
using System;
using Constants;

public class RoundTime : ScoreboardBaseScript
{

    private TempGameManager manager;

    public override void Start()
    {
        base.Start();
        manager = (TempGameManager)FindObjectOfType(typeof(TempGameManager));
    }

    void Update()
    {
        if (manager.GetState() == CompWorldConstants.worldStates.intermission)
        {
            textMesh.text = "Time Remaining" + Environment.NewLine + Math.Round((double)manager.GetIntermissionTime(), 1);
 
        }
        if (manager.GetState() == CompWorldConstants.worldStates.matchInProgress)
        {
            textMesh.text = "Time Remaining" + Environment.NewLine + Math.Round((double)manager.GetRoundTime(), 1);
        }
        textMesh.maxChars = textMesh.text.Length;
    }
}
