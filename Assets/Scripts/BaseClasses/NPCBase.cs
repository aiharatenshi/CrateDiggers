using UnityEngine;
using System.Collections;

abstract public class NPCBase : WorldObject {

    public float dialogueDisplayLength;
    private DialogueBox dialogueBox;

    public virtual void Start()
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
