using UnityEngine;
using System.Collections;

public class NameTextMesh : TextMeshBaseScript {

    /// <summary>
    /// This is a texh mesh script intended for use on "nametags" that display WorldObject names.
    /// </summary>
    /// 

    public string fullName;
    public string shortName;

	public override void Start () {
        base.Start();
        startActive = false;

        if (fullName == System.String.Empty)
        {
            fullName = gameObject.name;
        }

        if (shortName == System.String.Empty)
        {
            shortName = fullName;
        }

        UpdateText(fullName);
	}

}
