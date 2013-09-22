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
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        transform.Translate(new Vector3(Random.Range(-movement, movement), Random.Range(-movement, movement), 0) * Time.deltaTime);
    }

    override public void OnInteract()
    {
        Debug.Log(gameObject.name + ": " + "Hi, my name is " + objectName + ".");
    }

    public void Test()
    {
        Debug.Log(gameObject.name + ": " + "Hi, my name is " + objectName + ".");
    }
}
