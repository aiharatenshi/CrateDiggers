using UnityEngine;
using System.Collections;
using System;

public class PossessionTimeScoreboard : ScoreboardBaseScript
{

    public PlayerBaseScript[] playerList;

    public override void Start()
    {
        base.Start();
        playerList = FindObjectsOfType(typeof(PlayerBaseScript)) as PlayerBaseScript[];
    }

    public override void Update()
    {
        string[] scoreboardText = new string[playerList.Length];
        for (int i = 0; i < playerList.Length; i++)
        {
            scoreboardText[i] = playerList[i].shortName + ": " + Math.Round((double)playerList[i].GetPossessionTime(), 1) + "s" + Environment.NewLine;
        }
        textMesh.text = "Times" + Environment.NewLine + string.Concat(scoreboardText);
        textMesh.maxChars = textMesh.text.Length;
    }
}
