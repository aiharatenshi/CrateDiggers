using UnityEngine;
using System.Collections;

public class TextMeshBase : MonoBehaviour {

    /// <summary>
    /// This is a framework for tk2d text meshes attached to other objects.
    /// </summary>

    public tk2dTextMesh textMesh;
    protected WorldObject parentObject;
    public bool startActive = true;

	// Use this for initialization
	public virtual void Start () {
        parentObject = (WorldObject)transform.parent.gameObject.GetComponent<WorldObject>();
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
