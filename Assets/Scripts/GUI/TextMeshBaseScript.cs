using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TimerScript))]

abstract public class TextMeshBaseScript : MonoBehaviour
{

    /// <summary>
    /// This is a framework for tk2d text meshes attached to other objects.
    /// </summary>

    protected TimerScript timer;
    public tk2dTextMesh textMesh;
    private int timerIndex;
    public bool startActive = true;
    public int defaultDisplayTime = 2;
    public bool alwaysDisplay = false;
    public float displayLength;

    public virtual void Start()
    {
        if (GetComponent<TimerScript>() == null)
        {
            gameObject.AddComponent<TimerScript>();
        }

        if (GetComponent<tk2dTextMesh>() == null)
        {
            gameObject.AddComponent<tk2dTextMesh>();
        }
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

    public virtual void Update()
    {
        CheckActive();
    }

    public virtual void UpdateText(string text)
    {
        textMesh.text = text;
        timerIndex = timer.StartTimer(defaultDisplayTime);
        textMesh.maxChars = text.Length;
    }

    public void CheckActive()
    {
        if (timer.IsTimerActive(timerIndex))
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