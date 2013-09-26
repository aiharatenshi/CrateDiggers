using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]

abstract public class NPCBaseScript : WorldObjectScript
{

    public float dialogueDisplayLength;
    private DialogueBox dialogueBox;

    public override void Start()
    {
        base.Start();
        dialogueBox = GetComponentInChildren<DialogueBox>();
        dialogueBox.Start();
        dialogueBox.SetDisplayLength(dialogueDisplayLength);
    }

    public virtual void Say(string text)
    {
        dialogueBox.UpdateText(text);
    }

    override public void IncreaseScore()
    {
        score++;
    }

    public virtual RockPaperScissors.RPS MakeRandomRPSChoice()
    {
        int choice = UnityEngine.Random.Range(0, 3);
        switch (choice)
        {
            case 0:
                Say(Enum.GetName(typeof(RockPaperScissors.RPS), RockPaperScissors.RPS.rock));
                return RockPaperScissors.RPS.rock;
            case 1:
                Say(Enum.GetName(typeof(RockPaperScissors.RPS), RockPaperScissors.RPS.paper));
                return RockPaperScissors.RPS.paper;
            case 2:
                Say(Enum.GetName(typeof(RockPaperScissors.RPS), RockPaperScissors.RPS.scissors));
                return RockPaperScissors.RPS.scissors;
        }
        return RockPaperScissors.RPS.scissors;
    }

}