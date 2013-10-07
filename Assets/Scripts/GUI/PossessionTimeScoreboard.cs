using UnityEngine;
using System.Collections;
using System;

public class PossessionTimeScoreboard : ScoreboardBaseScript
{

    public PlayerBaseScript[] player;

    public override void Start()
    {
        base.Start();
        player = FindObjectsOfType(typeof(PlayerBaseScript)) as PlayerBaseScript[];
    }

    public override void Update()
    {
        string[] scoreboardText = new string[player.Length];
        for (int i = 0; i < player.Length; i++)
        {
            scoreboardText[i] = player[i].shortName + ": " + Math.Round((double)player[i].GetPossessionTime(), 1) + "s" + Environment.NewLine;
        }
        textMesh.text = "Times" + Environment.NewLine + string.Concat(scoreboardText);
        textMesh.maxChars = textMesh.text.Length;
    }
}
