using UnityEngine;
using System.Collections;

public class NPCBoring : NPCBase {

    public float movement = 0f;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        Debug.Log("I'm a boring NPC, and my name is " + objectName + "!");
        isInteractive = true;

        // Component tests for integrity of prefab
        if (GameObject.Find("NPCBoring/InteractionTrigger") == null)
        {
            Debug.LogError("WorldObject " + name + " is missing an InteractionTrigger");
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        transform.Translate(new Vector3(Random.Range(-movement, movement), Random.Range(-movement, movement), 0) * Time.deltaTime);

        if (true)
        {
            
        }
    }

    public override void ReceiveInteractionHandshake()
    {
        //renderer.material = renderer.materials[1];
        renderer.material.color = Color.green;
        Talk("Hi, my name is " + objectName + ".");
    }

    public override void InteractionClose()
    {
        renderer.material.color = Color.white;
    }

    override public void OnInteract()
    {

    }
}
