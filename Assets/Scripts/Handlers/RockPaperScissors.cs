using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TimerScript))]

public class RockPaperScissors : MonoBehaviour
{

    public enum RPS { rock, paper, scissors }
    public enum result { p1win, p2win, draw, error }

    private TimerScript playTimer;
    private int timerIndex;
    public float playPollingDelay = 1; // In seconds

    void Start()
    {
        if (gameObject.GetComponent<TimerScript>() == null)
        {
            gameObject.AddComponent("TimerScript");
        }

        playTimer = gameObject.GetComponent<TimerScript>();
    }

    void Update()
    {
        if (!playTimer.IsTimerActive(timerIndex))
        {
            GetRandomPlayerPair();
            timerIndex = playTimer.StartTimer(playPollingDelay);
        }
    }

    void GetRandomPlayerPair()
    {
        CompetitorBaseScript[] players = FindObjectsOfType(typeof(CompetitorBaseScript)) as CompetitorBaseScript[];
        int a = UnityEngine.Random.Range(0, players.Length);
        int b = UnityEngine.Random.Range(0, players.Length);
        while (a == b)
        {
            a = UnityEngine.Random.Range(0, players.Length);
            b = UnityEngine.Random.Range(0, players.Length);
        }
        if (players[a].purse.currentBet > 0 && players[b].purse.currentBet > 0)
        {
            Play(players[a], players[b]);
        }
    }

    /// <summary>
    /// Initiate a game of rock-paper-scissors. Should only be called bu the challenging player.
    /// </summary>
    /// <param name="player1">Must be the player initiating the game</param>
    /// <param name="player2">Must be the player being challenged</param>
    public void Play(CompetitorBaseScript player1, CompetitorBaseScript player2)
    {
        if (player1.purse.currentBet == 0 || player2.purse.currentBet == 0)
        {
            return;
        }

        int stakes = player1.purse.currentBet + player2.purse.currentBet;

        result gameResult = GetResult(player1.purse.choice, BettingManagerScript.MakeRandomRPSChoice());
        switch (gameResult)
        {
            case result.p1win:
                BettingManagerScript.ResolveGame(player1, player2, stakes);
                break;
            case result.p2win:
                BettingManagerScript.ResolveGame(player2, player1, stakes);
                break;
            case result.draw:
                //Debug.Log("Draw game!");
                break;
            case result.error:
                Debug.LogError("RockPaperScissors did something wrong!");
                break;
        }
    }

    /// <summary>
    /// This method is called when Play is called and returns the result of the game
    /// </summary>
    /// <returns>win, lose, or draw for the challenger</returns>
    private result GetResult(RPS player1choice, RPS player2choice)
    {
        switch (player1choice)
        {
            case RPS.rock:
                switch (player2choice)
                {
                    case RPS.rock:
                        return result.draw;
                    case RPS.paper:
                        return result.p2win;
                    case RPS.scissors:
                        return result.p1win;
                }
                return result.draw;
            case RPS.scissors:
                switch (player2choice)
                {
                    case RPS.rock:
                        return result.p2win;
                    case RPS.paper:
                        return result.p1win;
                    case RPS.scissors:
                        return result.draw;
                }
                return result.draw;
            case RPS.paper:
                switch (player2choice)
                {
                    case RPS.rock:
                        return result.p1win;
                    case RPS.paper:
                        return result.draw;
                    case RPS.scissors:
                        return result.p2win;
                }
                return result.draw;
        }
        return result.error;
    }
}