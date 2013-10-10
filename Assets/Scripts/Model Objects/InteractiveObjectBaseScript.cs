using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TimerScript))]

abstract public class InteractiveObjectBaseScript : MonoBehaviour
{

    /// <summary>
    /// This is the base class for all objects with names (such as people)
    /// DEPENDENCIES:
    /// Rigidbody
    /// </summary>

    protected bool isInteractive = false;
    protected bool isCompetitor = true;
    protected bool isMobile = true;
    public WorldAreaScript currentArea = null;
    public InteractiveObjectBaseScript interactionTarget = null;

    protected TimerScript timer;
    public float dialogueDisplayLength;
    protected DialogueBox dialogueBox;
    private enum objectState { }

    public virtual void Start()
    {
        SetupDependencies();

        dialogueBox = GetComponentInChildren<DialogueBox>();
        dialogueBox.Start();
        dialogueBox.SetDisplayLength(dialogueDisplayLength);

        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    public virtual void Update()
    {

    }

    public virtual void OnGUI()
    {
    }

    /// <summary>
    /// Called when a player enters interaction range of an object
    /// </summary>
    abstract public void ReceiveInteractionHandshake();

    abstract public void InteractionClose();

    abstract public void OnInteract();

    public virtual void Say(string text)
    {
        dialogueBox.UpdateText(text);
    }

    public void ChangeTextMeshText(TextMeshBaseScript textMesh, string newText)
    {
        textMesh.UpdateText(newText);
    }

    protected virtual void SetupDependencies()
    {
        if (GetComponent<TimerScript>() == null)
        {
            gameObject.AddComponent("TimerScript");
        }

        timer = GetComponent<TimerScript>();

        if (GetComponent<Rigidbody>() == null)
        {
            Debug.LogWarning("Rigidbody was missing on <" + gameObject.name + ">");
            gameObject.AddComponent("Rigidbody");
        }
    }
}
