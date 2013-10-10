using UnityEngine;
using System.Collections;

public class PossessionTimer : MonoBehaviour
{
    /// <summary>
    /// Simple script counts up if its associated player
    /// has possession of the ball
    /// </summary>
    public CompetitorBaseScript player;
    private float possessionTime;

    // Use this for initialization
    void Start()
    {
        possessionTime = 0;
        //player.competitorModule.possessionTimer = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.competitorModule.ball)
        {
            possessionTime += Time.deltaTime;
        }
    }

    public float GetPossessionTime()
    {
        return possessionTime;
    }

    public void SetPlayer(CompetitorBaseScript _player)
    {
        player = _player;
    }

    public void Reset()
    {
        possessionTime = 0;
    }
}
