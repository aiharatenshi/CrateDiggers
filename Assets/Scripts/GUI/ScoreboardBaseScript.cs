using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(tk2dTextMesh))]

abstract public class ScoreboardBaseScript : MonoBehaviour
{

    /// <summary>
    /// Base class for scoreboards.
    /// Contains either a list of all WorldObjects
    /// </summary>

    protected tk2dTextMesh textMesh;
    protected CompetitivePlayerBaseScript[] player;

    // Use this for initialization
    public virtual void Start()
    {
        if (!GetComponent<tk2dTextMesh>())
        {
            gameObject.AddComponent("tk2dTextMesh");
        }
        player = FindObjectsOfType(typeof(CompetitivePlayerBaseScript)) as CompetitivePlayerBaseScript[];
        textMesh = gameObject.GetComponent<tk2dTextMesh>();
        textMesh.text = "0";
    }

    /// <summary>
    /// Template for scoreboard display
    /// </summary>
    public virtual void Update()
    {

        //TODO:REIMPLEMENT PROPERLY BY ADDING NAMES TO PLAYER
        /*
        string[] scoreboardText = new string[player.Length];
        for (int i = 0; i < player.Length; i++)
        {
            scoreboardText[i] = player[i].nameTextMesh.shortName + ": " + "" + Environment.NewLine;
            textMesh.text = "Scores" + Environment.NewLine + string.Concat(scoreboardText);
        }

        textMesh.maxChars = textMesh.text.Length;
        */
    }
}
