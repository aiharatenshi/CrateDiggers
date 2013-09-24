﻿using UnityEngine;
using System.Collections;

abstract public class NPCBaseScript : WorldObjectScript {

    public float dialogueDisplayLength;
    private DialogueBox dialogueBox;

    public override void Start()
    {
        base.Start();
        dialogueBox = GetComponentInChildren<DialogueBox>();
        dialogueBox.Start();
        dialogueBox.SetDisplayLength(dialogueDisplayLength);
    }

    public virtual void Talk(string text)
    {
        dialogueBox.UpdateMessage(text);
    }

    override public void IncreaseScore()
    {
        score++;
        Talk(shortName + ": I won!");
    }

}
