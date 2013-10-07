using UnityEngine;
using System.Collections;

public class GamepadInfo : MonoBehaviour
{

    /// <summary>
    /// Helper class containing gamepad data.
    /// Vectors for controller axes and array for button states.
    /// Data sent from GamepadInputHandler.
    /// </summary>
    /// 

    public int gamepadNumber;
    public Vector2 leftStick;
    public Vector2 rightStick;
    public float trigger;
    public Vector2 dpad;
    public bool[] buttons = new bool[10]; // 0.A 1.B 2.X 3.Y 4.LS 5.RS 6.Back 7.Start 8.LB 9.RB

    void Start()
    {
        leftStick = new Vector2(0, 0);
        rightStick = new Vector2(0, 0);
        trigger = 0;
        dpad = new Vector2(0, 0);
        for (int i = 0; i < 9; i++)
        {
            buttons[i] = false;
        }
    }

    public void SetData(int _gamepadNumber, Vector2 _leftStick, Vector2 _rightStick, float _trigger, Vector2 _dpad, bool[] _buttons)
    {
        gamepadNumber = _gamepadNumber;
        leftStick = _leftStick;
        rightStick = _rightStick;
        dpad = _dpad;
        trigger = _trigger;
        buttons = _buttons;
    }
}
