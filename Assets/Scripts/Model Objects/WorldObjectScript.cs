using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(TimerScript))]

abstract public class WorldObjectScript : MonoBehaviour
{

    /// <summary>
    /// This is the base class for all objects with names (such as people)
    /// DEPENDENCIES:
    /// Rigidbody
    /// tk2dTextMesh
    /// </summary>

    public string objectName;
    public string shortName;
    protected bool isInteractive = false;
    protected bool isCompetitor = true;
    protected bool isMobile = true;
    protected Material[] material;
    protected int score = 0;
    protected TimerScript timer;
    public int dollarBillz = 1000;
    public int currentBet = 0;
    public float dialogueDisplayLength;
    protected DialogueBox dialogueBox;
    public RockPaperScissors.RPS choice = RockPaperScissors.RPS.rock;
    [Range(1.0f, 100.0f)]
    public int health = 4;
    public bool godMode = false;

    private enum objectState { }

    // Use this for initialization
    public virtual void Start()
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

        if (objectName == System.String.Empty)
        {
            objectName = gameObject.name;
        }

        if (shortName == System.String.Empty)
        {
            shortName = objectName;
        }

        if (GetComponentInChildren<tk2dTextMesh>() == null)
        {
            Debug.LogError("NamedObject " + name + " needs a NameTextMesh in one of its children!");
        }

        // TODO Something is broken with this. Causes cascading errors if called.
        //ChangeTextMeshText(GetComponentInChildren<NameTextMesh>() as TextMeshBaseScript, objectName);

        dialogueBox = GetComponentInChildren<DialogueBox>();
        dialogueBox.Start();
        dialogueBox.SetDisplayLength(dialogueDisplayLength);

        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (health <= 0)
        {
            // TODO: Define death behaviors.
        }
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

    public void Win(int winnings)
    {
        score++;
        currentBet = 0;
        dollarBillz += winnings;
    }

    public int GetScore()
    {
        return score;
    }

    public void IncreaseBet()
    {
        if (dollarBillz > 0)
        {
            dollarBillz -= 100;
            currentBet += 100; 
        }
    }

    public void Lose()
    {
        currentBet = 0;
        if (dollarBillz == 0)
        {
            dollarBillz = 100;
        }
    }

    public virtual void Say(string text)
    {
        dialogueBox.UpdateText(text);
    }

    public virtual RockPaperScissors.RPS MakeRandomRPSChoice()
    {
        int choice = UnityEngine.Random.Range(0, 3);
        switch (choice)
        {
            case 0:
                Say(shortName + ": " + Enum.GetName(typeof(RockPaperScissors.RPS), RockPaperScissors.RPS.rock));
                return RockPaperScissors.RPS.rock;
            case 1:
                Say(shortName + ": " + Enum.GetName(typeof(RockPaperScissors.RPS), RockPaperScissors.RPS.paper));
                return RockPaperScissors.RPS.paper;
            case 2:
                Say(shortName + ": " + Enum.GetName(typeof(RockPaperScissors.RPS), RockPaperScissors.RPS.scissors));
                return RockPaperScissors.RPS.scissors;
        }
        return RockPaperScissors.RPS.scissors;
    }

    public virtual void TakeDamage(int amount)
    {
        if (!godMode)
        {
           health -= amount;   
        }
    }

    public void ChangeTextMeshText(TextMeshBaseScript textMesh, string newText)
    {
        textMesh.UpdateText(newText);
    }
}
