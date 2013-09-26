using UnityEngine;
using System.Collections;

public class RockPaperScissors : MonoBehaviour
{

    public enum RPS { rock, paper, scissors }
    public enum result { win, lose, draw, error }

    void Start()
    {

    }

    void Update()
    {

    }
    /// <summary>
    /// Initiate a game of rock-paper-scissors. Should only be called bu the challenging player.
    /// </summary>
    /// <param name="player1">Must be the player initiating the game</param>
    /// <param name="player2">Must be the player being challenged</param>
    public void Play(WorldObjectScript _player1, WorldObjectScript _player2)
    {
        PlayerScript player1 = (PlayerScript)_player1;
        NPCBaseScript player2 = (NPCBaseScript)_player2;
        result gameResult = GetResult(player1.choice, player2.MakeRPSChoice());
        switch (gameResult)
        {
            case result.win:
                player1.IncreaseScore();
                Debug.Log("You won!");
                break;
            case result.lose:
                player2.IncreaseScore();
                Debug.Log("You lost!");
                break;
            case result.draw:
                Debug.Log("Draw game!");
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
                        return result.lose;
                    case RPS.scissors:
                        return result.win;
                }
                return result.draw;
            case RPS.scissors:
                switch (player2choice)
                {
                    case RPS.rock:
                        return result.lose;
                    case RPS.paper:
                        return result.win;
                    case RPS.scissors:
                        return result.draw;
                }
                return result.draw;
            case RPS.paper:
                switch (player2choice)
                {
                    case RPS.rock:
                        return result.win;
                    case RPS.paper:
                        return result.draw;
                    case RPS.scissors:
                        return result.lose;
                }
                return result.draw;
        }
        return result.error;
    }
}