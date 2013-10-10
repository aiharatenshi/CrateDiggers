using UnityEngine;
using System.Collections;
using Constants;

public class BettingManagerScript : MonoBehaviour
{
    /// <summary>
    /// Contains methods to handle the betting system.
    /// </summary>
    /// <param name="purse"></param>

    public static void Lose(PurseScript purse)
    {
        purse.currentBet = 0;
        if (purse.dollarBillz == 0)
        {
            purse.dollarBillz = 100;
        }
    }

    public static void ResolveGame(CompetitorBaseScript winner, CompetitorBaseScript loser, int stakes)
    {
        Win(winner.purse, stakes);
        Lose(loser.purse);
    }

    public static void IncreaseBet(PurseScript purse)
    {
        if (purse.dollarBillz > 0)
        {
            purse.dollarBillz -= 100;
            purse.currentBet += 100;
        }
    }

    public static void Win(PurseScript purse, int stakes)
    {
        purse.currentBet = 0;
        purse.dollarBillz += stakes;
    }

    public static RockPaperScissors.RPS RotateRPSChoice(RockPaperScissors.RPS currentChoice)
    {
        RockPaperScissors.RPS newChoice = RockPaperScissors.RPS.rock;
        switch (currentChoice)
        {
            case RockPaperScissors.RPS.rock:
                newChoice = RockPaperScissors.RPS.paper;
                break;
            case RockPaperScissors.RPS.paper:
                newChoice = RockPaperScissors.RPS.scissors;
                break;
            case RockPaperScissors.RPS.scissors:
                newChoice = RockPaperScissors.RPS.rock;
                break;
        }
        return newChoice;
    }

    public static RockPaperScissors.RPS MakeRandomRPSChoice()
    {
        int choice = UnityEngine.Random.Range(0, 3);
        switch (choice)
        {
            case 0:
                //Say(shortName + ": " + Enum.GetName(typeof(RockPaperScissors.RPS), RockPaperScissors.RPS.rock));
                return RockPaperScissors.RPS.rock;
            case 1:
                //Say(shortName + ": " + Enum.GetName(typeof(RockPaperScissors.RPS), RockPaperScissors.RPS.paper));
                return RockPaperScissors.RPS.paper;
            case 2:
                //Say(shortName + ": " + Enum.GetName(typeof(RockPaperScissors.RPS), RockPaperScissors.RPS.scissors));
                return RockPaperScissors.RPS.scissors;
        }
        return RockPaperScissors.RPS.scissors;
    }
}
