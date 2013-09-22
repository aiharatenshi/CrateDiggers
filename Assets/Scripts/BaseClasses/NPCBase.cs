using UnityEngine;
using System.Collections;

abstract public class NPCBase : NamedObject {

    //// Use this for initialization
    //public virtual void Start () {
    //    base.Start();
    //}
	
    //// Update is called once per frame
    //public virtual void Update () {
    //    base.Update();
    //}

    override public void IncreaseScore()
    {
        score++;
    }

}
