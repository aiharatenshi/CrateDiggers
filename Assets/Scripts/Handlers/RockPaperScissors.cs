using UnityEngine;
using System.Collections;

public class RockPaperScissors : MonoBehaviour {

    private enum RPS { rock, paper, scissors }
    public enum result { win, lose, draw, error }

	void Start () {

	}

	void Update () {
	
	}
    /// <summary>
    /// Initiate a game of rock-paper-scissors. Should only be called bu the challenging player.
    /// </summary>
    /// <param name="player1">Must be the player initiating the game</param>
    /// <param name="player2">Must be the player being challenged</param>
    public void Play(NamedObject player1, NamedObject player2)
    {
        result gameResult = GetResult();
        if (gameResult == result.win)
        {
            player1.IncreaseScore();
            Debug.Log("You won!");
        }
        else if (gameResult == result.lose)
        {
            player2.IncreaseScore();
            Debug.Log("You lost!");
        }
        else if (gameResult == result.draw)
        {
            Debug.Log("Draw game!");
        }
        else if (gameResult == result.error)
        {
            Debug.LogError("RockPaperScissors did something wrong!");
        }
    }
    /// <summary>
    /// This method is called when Play is called and returns the result of the game
    /// </summary>
    /// <returns>win, lose, or draw for the challenger</returns>
    private result GetResult()
    {
        int player1choice = Random.Range(0, 2);
        int player2choice = Random.Range(0, 2);

        switch (player1choice)
        {
            case (int)RPS.rock:
                switch (player2choice)
                {
                    case (int)RPS.rock:
                        return result.draw;
                        break;
                    case (int)RPS.paper:
                        return result.lose;
                        break;
                    case (int)RPS.scissors:
                        return result.win;
                        break;
                }
                return result.draw;
                break;
            case (int)RPS.scissors:
                switch (player2choice)
                {
                    case (int)RPS.rock:
                        return result.lose;
                        break;
                    case (int)RPS.paper:
                        return result.win;
                        break;
                    case (int)RPS.scissors:
                        return result.draw;
                        break;
                }
                return result.draw;
                break;
            case (int)RPS.paper:
                switch (player2choice)
                {
                    case (int)RPS.rock:
                        return result.win;
                        break;
                    case (int)RPS.paper:
                        return result.draw;
                        break;
                    case (int)RPS.scissors:
                        return result.lose;
                        break;
                }
                return result.draw;
                break;
        }
        return result.error;
    }
}
