using UnityEngine;
using System.Collections;

public class Scoreboard : MonoBehaviour {

    private tk2dTextMesh textMesh;
    public Player player;

	// Use this for initialization
	void Start () {
        textMesh = (tk2dTextMesh)gameObject.GetComponent<tk2dTextMesh>();
        textMesh.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
        textMesh.text = "Score: " + player.GetScore().ToString();
        textMesh.maxChars = textMesh.text.Length;
	}
}
