using UnityEngine;
using System.Collections;

public class NameTextMesh : MonoBehaviour {

    /// <summary>
    /// This class grabs the objectName of whatever parent it is attached to and
    /// changes the textmesh's text to the name
    /// </summary>

    private tk2dTextMesh textMesh;
    private NamedObject parentObject;
    public bool startActive = false;

	void Start () {
        parentObject = (NamedObject)transform.parent.gameObject.GetComponent<NamedObject>();
        textMesh = (tk2dTextMesh)gameObject.GetComponent<tk2dTextMesh>();
        textMesh.text = parentObject.objectName;
        textMesh.maxChars = textMesh.text.Length;

        if (startActive)
        {
            renderer.enabled = true;
        }
        else
        {
            renderer.enabled = false;
        }
 
	}
	
	void Update () {
	
	}
}
