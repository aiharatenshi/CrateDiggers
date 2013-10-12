using UnityEngine;
using System.Collections;

public class GamepadInfo : MonoBehaviour
{

    /// <summary>
    /// Helper class containing gamepad data.
    /// Vectors for controller axes and array for button states.
    /// Includes booleans that allows button-like trigger behavior
    /// Data sent from GamepadInputHandler.
    /// </summary>
    /// 

    // These member variables can be made private, but are set
    // public so we can debug the gamepads easily

    // TODO: Does pressing both triggers work?

    public int gamepadNumber;
    public Vector2 leftStick;
    public Vector2 rightStick;
    public float trigger;
    public Vector2 dpad;
    public bool[] button; // 0.A 1.B 2.X 3.Y 4.LS 5.RS 6.Back 7.Start 8.LB 9.RB
    public bool[] buttonDown;
    public bool[] buttonUp;
    public bool triggerReleased;
    public bool leftTrigger; // left trigger is > 0
    public bool rightTrigger; // right trigger is < 0
    public bool leftTriggerDown;
    public bool rightTriggerDown;
    public bool leftTriggerUp;
    public bool rightTriggerUp;

    private static float triggerDeadzone = 0.05f;

    void Start()
    {
        button = new bool[10];
		buttonDown = new bool[10];
		buttonUp = new bool[10];
		leftStick = new Vector2(0, 0);
        rightStick = new Vector2(0, 0);
        trigger = 0;
        dpad = new Vector2(0, 0);
        triggerReleased = true;
        leftTrigger = false;
        rightTrigger = false;
        leftTriggerDown = false;
        rightTriggerDown = false;
        leftTriggerUp = false;
        rightTriggerUp = false;
        for (int i = 0; i < 9; i++)
        {
            button[i] = false;
            buttonDown[i] = false;
            buttonUp[i] = false;
        }
    }

    void Update()
    {
		GetTriggerStates();
    }

    public void SetData(int _gamepadNumber, Vector2 _leftStick, Vector2 _rightStick, float _trigger, Vector2 _dpad, bool[] _button, bool[] _buttonDown, bool[] _buttonUp)
    {
        gamepadNumber = _gamepadNumber;
        leftStick = _leftStick;
        rightStick = _rightStick;
        dpad = _dpad;
        trigger = _trigger;
        button = _button;
        buttonDown = _buttonDown;
        buttonUp = _buttonUp;
    }

    public void GetTriggerStates()
    {
        // Up/Down resets
        if (leftTriggerDown)
        {
            leftTriggerDown = false;
        }

        if (rightTriggerDown)
        {
            rightTriggerDown = false;
        }

        if (leftTriggerUp)
        {
            leftTriggerUp = false;
        }

        if (rightTriggerUp)
        {
            rightTriggerUp = false;
        }

        // Deadzone check
        // NOTE: This won't work if the trigger axis value doesn't pass through the deadzone for at least one cycle
        if (trigger > -triggerDeadzone && trigger < triggerDeadzone)
        {
            triggerReleased = true;
        }

        // TriggerUp evals to true on the cycle a trigger is released
        if (rightTrigger && triggerReleased)
        {
            rightTriggerUp = true;
        }

        if (leftTrigger && triggerReleased)
        {
            leftTriggerUp = true;
        }

        // Finally, check if a trigger is being pressed
        if (trigger < -triggerDeadzone)
        {
            // First time being pressed?
            if (triggerReleased)
            {
                rightTriggerDown = true;
            }
            triggerReleased = false;
            rightTrigger = true;
        }

        if (trigger > triggerDeadzone)
        {
            if (triggerReleased)
            {
                leftTriggerDown = true;
            }
            triggerReleased = false;
            leftTrigger = true;
        }
    }
}
