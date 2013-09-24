using UnityEngine;
using System.Collections;

public class AreaName : TextMeshBaseScript {

    public PlayerScript player;

	// Use this for initialization
	public override void Start () {
        base.Start();
        player = (PlayerScript)FindObjectOfType(typeof(PlayerScript));
	}
	
	// Update is called once per frame
	public override void Update () {
        if (player.currentArea != null)
        {
            textMesh.text = player.currentArea.areaName;
        }

	}
}
