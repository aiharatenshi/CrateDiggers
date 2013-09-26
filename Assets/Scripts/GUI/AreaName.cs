using UnityEngine;
using System.Collections;

public class AreaName : TextMeshBaseScript {

    public PlayerBaseScript player;

	// Use this for initialization
	public override void Start () {
        base.Start();
        player = (PlayerBaseScript)FindObjectOfType(typeof(PlayerBaseScript));
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
