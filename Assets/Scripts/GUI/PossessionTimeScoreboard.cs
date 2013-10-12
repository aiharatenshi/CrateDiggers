using UnityEngine;
using System.Collections;
using System;

public class PossessionTimeScoreboard : ScoreboardBaseScript
{

    public CompetitorBaseScript[] competitorList;

    public override void Start()
    {
        base.Start();
        competitorList = FindObjectsOfType(typeof(CompetitorBaseScript)) as CompetitorBaseScript[];
    }

    public override void Update()
    {
        string[] scoreboardText = new string[competitorList.Length];
        for (int i = 0; i < competitorList.Length; i++)
        {
            // BUG: Turrets are currently "competitors" -- causing null ref
            scoreboardText[i] = competitorList[i].nameTextMesh.shortName + ": " + Math.Round((double)competitorList[i].competitorModule.GetPossessionTime(), 1) + "s" + Environment.NewLine;
        }
        textMesh.text = "Times" + Environment.NewLine + string.Concat(scoreboardText);
        textMesh.maxChars = textMesh.text.Length;
    }
}
