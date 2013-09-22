using UnityEngine;
using System.Collections;

public class AreaName : TextMeshBase {

    public Player player;

	// Use this for initialization
	public override void Start () {
        base.Start();
        player = (Player)FindObjectOfType(typeof(Player));
	}
	
	// Update is called once per frame
	public override void Update () {
        if (player.currentArea != null)
        {
            textMesh.text = player.currentArea.areaName;
        }

	}
}
