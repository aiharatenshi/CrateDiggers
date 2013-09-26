using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

abstract public class WorldObjectScript : MonoBehaviour
{

    /// <summary>
    /// This is the base class for all objects with names (such as people)
    /// DEPENDENCIES:
    /// Rigidbody
    /// tk2dTextMesh
    /// </summary>

    public string objectName = "UnnamedObject";
    public string shortName;
    protected bool isInteractive = false;
    protected bool isCompetitor = true;
    protected bool isMobile = true;
    protected Material[] material;
    protected int score = 0;
    protected TimerScript[] timer;

    private enum objectState { }

    // Use this for initialization
    public virtual void Start()
    {
        if (!GetComponent<Rigidbody>())
        {
            Debug.LogWarning("Rigidbody was missing on <" + gameObject.name + ">");
            gameObject.AddComponent("Rigidbody");
        }
        if (shortName == System.String.Empty)
        {
            shortName = objectName;
        }

        if (!GetComponentInChildren<tk2dTextMesh>())
        {
            Debug.LogError("NamedObject " + name + " needs a NameTextMesh in one of its children!");
        }
        else
        {
            //textMesh = GetComponentInChildren<tk2dTextMesh>();
        }
        rigidbody.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    // Update is called once per frame
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

    abstract public void IncreaseScore();

    public int GetScore()
    {
        return score;
    }
}
