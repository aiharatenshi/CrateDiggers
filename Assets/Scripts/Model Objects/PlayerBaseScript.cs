using UnityEngine;
using System.Collections;

public class PlayerBaseScript : WorldObjectScript
{

    /// <summary>
    /// Base abstract class for player objects.
    /// Contains basic controller movement and interaction.
    /// </summary>

    public int moveSpeed = 1;
    public WorldObjectScript interactionTarget = null;
    public WorldAreaScript currentArea = null;
    private RockPaperScissors rpsGame = null;

    // Use this for initialization
    new public virtual void Start()
    {
        base.Start();
        rpsGame = GameObject.FindGameObjectWithTag("CompetitiveGame").GetComponent<RockPaperScissors>();
    }

    // Update is called once per frame
    new public virtual void Update()
    {
        base.Update();
        HandleInput();
    }

    public virtual void OnCollisionEnter(Collision collision) { }

    public virtual void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }

    public virtual void OnCollisionExit(Collision collision) { }

    public virtual void OnTriggerEnter(Collider other)
    {
        // Interaction test
        if (other.gameObject.transform.parent.GetComponentInChildren<WorldObjectScript>())
        {
            interactionTarget = other.gameObject.transform.parent.GetComponentInChildren<WorldObjectScript>();
            interactionTarget.ReceiveInteractionHandshake();
        }

        if (other.gameObject.transform.parent.GetComponentInChildren<WorldAreaScript>())
        {
            Debug.Log("Entered area");
            currentArea = other.gameObject.transform.parent.GetComponentInChildren<WorldAreaScript>();
        }

    }

    public virtual void OnTriggerStay(Collider other) 
    {

    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (interactionTarget != null)
        {
            interactionTarget.InteractionClose();
            interactionTarget = null;
        }
        if (other.gameObject.transform.parent.GetComponentInChildren<WorldAreaScript>())
        {
            currentArea = null;
        }


    }

    /// <summary>
    /// This method should only be called as an escape during an Interact() attempt.
    /// </summary>
    /// <returns>True if in range to interact, false if not possible</returns>
    public virtual bool InteractionPossible()
    {
        if (interactionTarget != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// This method should be called when the player pressed "use"
    /// </summary>
    /// <param name="target">Requires a valid NamedObject otherwise does nothing</param>
    public virtual void Interact(WorldObjectScript target)
    {
        if (!InteractionPossible())
        {
            Debug.Log("Nothing to interact with!");
        }
        else
        {
            Debug.Log("Interacting with " + target.objectName + ".");
            target.OnInteract();
            rpsGame.Play(gameObject.GetComponentInChildren<PlayerScript>(), target);
        }
    }

    public virtual void HandleInput()
    {
        if (Input.GetKey("up"))
        {
            transform.Translate(new Vector3(0, moveSpeed, 0) * Time.deltaTime);
        }

        if (Input.GetKey("down"))
        {
            transform.Translate(new Vector3(0, -moveSpeed, 0) * Time.deltaTime);
        }

        if (Input.GetKey("left"))
        {
            transform.Translate(new Vector3(-moveSpeed, 0, 0) * Time.deltaTime);
        }

        if (Input.GetKey("right"))
        {
            transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact(interactionTarget);
        }
    }

    public virtual void HandleInput(KeyCode key) { }

    public override void ReceiveInteractionHandshake() 
    {
        throw new System.NotImplementedException();
    }

    public override void InteractionClose()
    {
        throw new System.NotImplementedException();
    }

    public override void OnInteract()
    {
        throw new System.NotImplementedException();
    }

    override public void IncreaseScore()
    {
        score++;
    }
}
