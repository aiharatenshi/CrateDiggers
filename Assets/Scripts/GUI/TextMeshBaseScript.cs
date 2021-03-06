﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TimerScript))]

public class TextMeshBaseScript : MonoBehaviour
{

    /// <summary>
    /// This is a framework for tk2d text meshes attached to other objects.
    /// </summary>

    protected TimerScript timer;
    public tk2dTextMesh textMesh;
    protected WorldObjectScript parentObject;
    public bool startActive = true;
    public int defaultDisplayTime = 2;
    public bool alwaysDisplay = false;
    public float displayLength;

    // Use this for initialization
    public virtual void Start()
    {
        if (GetComponent<TimerScript>() == null)
        {
            gameObject.AddComponent<TimerScript>();
        }
        parentObject = (WorldObjectScript)transform.parent.gameObject.GetComponent<WorldObjectScript>();
        textMesh = GetComponent<tk2dTextMesh>();
        timer = GetComponent<TimerScript>();

        if (startActive)
        {
            renderer.enabled = true;
        }
        else
        {
            renderer.enabled = false;
        }
    }

    // Update is called once per frame
    public virtual void Update()
    {
        CheckActive();
    }

    public virtual void UpdateText(string text)
    {
        textMesh.text = text;
        timer.StartTimer(defaultDisplayTime);
    }

    public void CheckActive()
    {
        if (timer.isActive)
        {
            renderer.enabled = true;
        }
        else
        {
            renderer.enabled = false;
        }
        if (alwaysDisplay)
        {
            renderer.enabled = true;
        }
    }

    public void SetDisplayLength(float length)
    {
        displayLength = length;
    }
}