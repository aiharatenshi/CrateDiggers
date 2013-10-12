using UnityEngine;
using System.Collections;
using System;

public class PossessionTimeScoreboard : ScoreboardBaseScript
{

    public CompetitivePlayerBaseScript[] competitorList;

    public override void Start()
    {
        base.Start();
        competitorList = FindObjectsOfType(typeof(CompetitivePlayerBaseScript)) as CompetitivePlayerBaseScript[];
    }

    public override void Update()
    {
        //TODO: REIMPLEMENT THIS PROPERLY BY ADDING PLAYER NAMES TO COMPETITIVEPLAYERBASESCRIPT
        string[] scoreboardText = new string[competitorList.Length];
        for (int i = 0; i < competitorList.Length; i++)
        {
            // BUG: Turrets are currently "competitors" -- causing null ref
            //scoreboardText[i] = CompetitivePlayerBaseScript[i].nameTextMesh.shortName + ": " + Math.Round((double)competitorList[i].competitorModule.GetPossessionTime(), 1) + "s" + Environment.NewLine;
        }
        //textMesh.text = "Times" + Environment.NewLine + string.Concat(scoreboardText);
        //textMesh.maxChars = textMesh.text.Length;
    }
}
