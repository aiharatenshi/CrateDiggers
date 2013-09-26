using UnityEngine;
using System.Collections;

public class DialogueBox : TextMeshBaseScript {

    // Use this for initialization
	public override void Start () {
        base.Start();
        timer = GetComponentInChildren<TimerScript>();
	}
	
	// Update is called once per frame
	public override void Update () {
        if (timer.isActive)
        {
            renderer.enabled = true;
        }
        else
        {
            renderer.enabled = false;
        }
	}

    public void UpdateMessage(string msg)
    {
        textMesh.text = msg;
        timer.StartTimer(displayLength);
        textMesh.maxChars = msg.Length;
    }
}
