using UnityEngine;
using System.Collections;

public class DialogueBox : TextMeshBase {

    private Timer timer;
    private float displayLength;

	// Use this for initialization
	public override void Start () {
        base.Start();
        timer = GetComponentInChildren<Timer>();
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

    public void SetDisplayLength(float length)
    {
        displayLength = length;
    }

    public void UpdateMessage(string msg)
    {
        textMesh.text = msg;
        timer.StartTimer(displayLength);
    }
}
