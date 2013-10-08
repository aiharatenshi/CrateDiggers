using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GamepadInputHandler))]

public class Controller : MonoBehaviour
{

    /// <summary>
    /// This is the controller class that should accompany each client
    /// 
    /// </summary>

    private tk2dCamera mainCamera;
    private GamepadInputHandler gamepadInputHandler;

    void Start()
    {
        if (GetComponent<GamepadInputHandler>() == null)
        {
            gameObject.AddComponent("JoystickInfo");
        }
        gamepadInputHandler = GetComponent<GamepadInputHandler>();

        if (GameObject.FindGameObjectWithTag("MainCamera").GetComponent<tk2dCamera>() != null)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<tk2dCamera>();
        }
        else
        {
            Debug.LogError("ERROR: No Main tk2dCamera found.");
        }
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
