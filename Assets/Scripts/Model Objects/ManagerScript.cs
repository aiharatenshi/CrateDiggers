using UnityEngine;
using System.Collections.Generic;

public class ManagerScript : MonoBehaviour {
    private List<GameObject> playerList;
    public tk2dTileMap tileMap;
    public tk2dCamera worldCamera;

	// Use this for initialization
	public virtual void Start () {
        playerList = new List<GameObject>();

        if (tileMap == null) Debug.Log("ERROR: Tile Map is empty in " + this.gameObject.name);
        if (worldCamera == null) Debug.Log("ERROR: Camera is empty in " + this.gameObject.name);
	}
	
	// Update is called once per frame
	public virtual void Update () {
	    
	}

    public List<GameObject> GetPlayerList() { return playerList; }
    public tk2dTileMap GetTileMap() { return tileMap; }
    public tk2dCamera GetWorldCamera() { return worldCamera; }
}
