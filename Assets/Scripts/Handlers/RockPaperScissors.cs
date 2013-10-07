using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TimerScript))]

public class RockPaperScissors : MonoBehaviour
{

    public enum RPS { rock, paper, scissors }
    public enum result { p1win, p2win, draw, error }

    private TimerScript playTimer;
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
        if (!playTimer.IsTimerActive(0))
        {
            GetRandomPlayerPair();
            playTimer.StartTimer(playPollingDelay);
        }
    }

    void GetRandomPlayerPair()
    {
        WorldObjectScript[] players = FindObjectsOfType(typeof(WorldObjectScript)) as WorldObjectScript[];
        int a = UnityEngine.Random.Range(0, players.Length);
        int b = UnityEngine.Random.Range(0, players.Length);
        while (a == b)
        {
            a = UnityEngine.Random.Range(0, players.Length);
            b = UnityEngine.Random.Range(0, players.Length);
        }
        if (players[a].currentBet > 0 && players[b].currentBet > 0)
        {
            Play(players[a], players[b]);
        }
    }

    /// <summary>
    /// Initiate a game of rock-paper-scissors. Should only be called bu the challenging player.
    /// </summary>
    /// <param name="player1">Must be the player initiating the game</param>
    /// <param name="player2">Must be the player being challenged</param>
    public void Play(WorldObjectScript player1, WorldObjectScript player2)
    {
        if (player1.currentBet == 0 || player2.currentBet == 0)
        {
            return;
        }

        int stakes = player1.currentBet + player2.currentBet;

        result gameResult = GetResult(player1.choice, player2.MakeRandomRPSChoice());
        switch (gameResult)
        {
            case result.p1win:
                player1.Win(stakes);
                player2.Lose();

                //Debug.Log("You won!");
                break;
            case result.p2win:
                player2.Win(stakes);
                player1.Lose();
                //Debug.Log("You lost!");
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