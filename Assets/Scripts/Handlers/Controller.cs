using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GamepadInputHandler))]

public class Controller : MonoBehaviour
{

    /// <summary>
    /// This is the controller class that should accompany each client
    /// 
    /// </summary>

    public Camera mainCamera;
    private GamepadInputHandler gamepadInputHandler;

    void Start()
    {
        if (!GetComponent<GamepadInputHandler>())
	     {
		    gameObject.AddComponent("JoystickInfo");
	     }
        gamepadInputHandler = GetComponent<GamepadInputHandler>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            GameObject[] textMeshes;
            textMeshes = GameObject.FindGameObjectsWithTag("NameTextMesh");
            foreach (GameObject textMesh in textMeshes)
            {
                textMesh.renderer.enabled = true;
            }

        }

        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            GameObject[] textMeshes;
            textMeshes = GameObject.FindGameObjectsWithTag("NameTextMesh");
            foreach (GameObject textMesh in textMeshes)
            {
                textMesh.renderer.enabled = false;
            }
        }
    }

    void KeyDown(KeyCode key)
    {

    }

    void KeyUp(KeyCode key) { }

    /// <summary>
    /// Basic input system. Using unity's Input class may be more useful, but this will grab
    /// keyCodes for us. Can use both.
    /// </summary>

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            switch (e.type)
            {
                case EventType.KeyDown:
                    KeyDown(e.keyCode);
                    break;
                case EventType.KeyUp:
                    KeyUp(e.keyCode);
                    break;
            }
        }
    }
}
