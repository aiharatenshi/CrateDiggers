using UnityEngine;
using System.Collections;
using System;

public class Scoreboard : MonoBehaviour {

    /// <summary>
    /// This class displays the current players and their scores.
    /// </summary>

    private tk2dTextMesh textMesh;
    private WorldObjectScript[] player;

	// Use this for initialization
	void Start () {
        player = FindObjectsOfType(typeof(WorldObjectScript)) as WorldObjectScript[];
        textMesh = (tk2dTextMesh)gameObject.GetComponent<tk2dTextMesh>();
        textMesh.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
        string[] scoreboardText = new string[player.Length];
        int totalDollarz = 0;
        for (int i = 0; i < player.Length; i++)
        {
            scoreboardText[i] = player[i].shortName + ": " + player[i].GetScore().ToString() + " | $" + player[i].dollarBillz + " | Bet: $" + player[i].currentBet + Environment.NewLine;
            totalDollarz += player[i].dollarBillz + player[i].currentBet;
            textMesh.text = "Scores" + Environment.NewLine + string.Concat(scoreboardText) + Environment.NewLine + "Total: $" + totalDollarz.ToString();
        }

        textMesh.maxChars = textMesh.text.Length;
	}
}
