using UnityEngine;
using System.Collections;
using System;

public class BettingScoreboard : ScoreboardBaseScript
{

    public override void Update()
    {
        //TODO:REIMPLEMENT PLAYER NAME AND CHANGE HERE
        /*
        string[] scoreboardText = new string[player.Length];
        int totalDollarz = 0;
        for (int i = 0; i < player.Length; i++)
        {
            scoreboardText[i] = player[i].nameTextMesh.shortName + ": " + player[i].competitorModule.GetScore().ToString() + " | $" + player[i].purse.dollarBillz + " | Bet: $" + player[i].purse.currentBet + Environment.NewLine;
            totalDollarz += player[i].purse.dollarBillz + player[i].purse.currentBet;
            textMesh.text = "Scores" + Environment.NewLine + string.Concat(scoreboardText) + Environment.NewLine + "Total: $" + totalDollarz.ToString();
        }

        textMesh.maxChars = textMesh.text.Length;
        */ 
    }
}
