using UnityEngine;
using System.Collections;

public class NameTextMesh : TextMeshBaseScript {

    /// <summary>
    /// This is a texh mesh script intended for use on "nametags" that display WorldObject names.
    /// </summary>

	public override void Start () {
        base.Start();
        startActive = false;
	}
	
	public override void Update () {
	    
	}
}
