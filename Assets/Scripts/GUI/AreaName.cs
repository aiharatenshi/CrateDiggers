using UnityEngine;
using System.Collections;

public class AreaName : TextMeshBaseScript {

    public CompetitivePlayerBaseScript player;

	// Use this for initialization
	public override void Start () {
        base.Start();
        player = (CompetitivePlayerBaseScript)FindObjectOfType(typeof(CompetitivePlayerBaseScript));
	}
	
	// Update is called once per frame
	public override void Update () {
        if (player.currentArea != null)
        {
            textMesh.text = player.currentArea.areaName;
        }
        else
        {
            textMesh.text = "Nowhere";
        }

	}
}
