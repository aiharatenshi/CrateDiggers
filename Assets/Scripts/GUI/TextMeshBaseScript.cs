using UnityEngine;
using System.Collections;

public class TextMeshBaseScript : MonoBehaviour {

    /// <summary>
    /// This is a framework for tk2d text meshes attached to other objects.
    /// </summary>

    public tk2dTextMesh textMesh;
    protected WorldObjectScript parentObject;
    public bool startActive = true;

	// Use this for initialization
	public virtual void Start () {
        parentObject = (WorldObjectScript)transform.parent.gameObject.GetComponent<WorldObjectScript>();
        textMesh = GetComponent<tk2dTextMesh>();

        if (startActive)
        {
            renderer.enabled = true;
        }
        else
        {
            renderer.enabled = false;
        }
	}
	
	// Update is called once per frame
	public virtual void Update () {
	
	}
}
