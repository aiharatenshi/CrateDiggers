using UnityEngine;
using System.Collections;

public class NameTextMesh : TextMeshBase {

    /// <summary>
    /// This is a texh mesh script intended for use on "nametags" that display WorldObject names.
    /// </summary>

	public override void Start () {
        base.Start();
        startActive = false;
        textMesh.text = parentObject.objectName;
        textMesh.maxChars = textMesh.text.Length;
	}
	
	public override void Update () {
	    
	}
}
