using UnityEngine;
using System.Collections;

abstract public class NamedObject : MonoBehaviour
{

    /// <summary>
    /// This is the base class for all objects with names (such as people)
    /// This class will require a textMesh somewhere in the prefab
    /// </summary>

    public string objectName;
    protected tk2dTextMesh textMesh;
    protected bool isInteractive = false;
    protected int score = 0;

    // Use this for initialization
    public virtual void Start()
    {
        if (GetComponentInChildren<tk2dTextMesh>() == null)
        {
            Debug.LogError("NamedObject " + name + " needs a NameTextMesh in one of its children!");
        }
        else
        {
            textMesh = GetComponentInChildren<tk2dTextMesh>();
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    public virtual void OnGUI()
    {
    }

    abstract public void OnInteract();
    //{
    //    Debug.Log(name + " interaction.");
    //}

    abstract public void IncreaseScore();

    public int GetScore()
    {
        return score;
    }
}
