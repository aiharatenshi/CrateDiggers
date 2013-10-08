using UnityEngine;
using System.Collections;
using Constants;

public class GamepadInputHandler : MonoBehaviour
{

    /// <summary>
    /// This class polls the connected gamepads and populates their GamepadInfo with
    /// the values of all their joysticks and buttons.
    /// 
    /// Essentially just mirrors the behavior of the InputManager, with the benefit of
    /// the data for an entire gamepad being an object that you can reference by
    /// gamepad rather than individual axis/button names.
    /// </summary>
    
    // TODO: Best way of setting this up for performance?

    private int NumberOfActiveControllers;
    private int controllerNumber;
    public GamepadInfo[] gamepadInfo = new GamepadInfo[4];
    public GamepadInfo gamepadInfoTemplate;
    public PlayerBaseScript playerTemplate;

    void Start()
    {
        NumberOfActiveControllers = Input.GetJoystickNames().Length;
        Debug.Log(Input.GetJoystickNames().Length);

        for (int i = 0; i < NumberOfActiveControllers; i++)
        {
            GamepadInfo gamepadInfoPrefab;
            gamepadInfoPrefab = Instantiate(gamepadInfoTemplate, new Vector3(0, 0, 0), Quaternion.identity) as GamepadInfo;
            gamepadInfo[i] = gamepadInfoPrefab;

            
            // TODO: Players shouldn't be instantiated here, but is convenient shortcut for setting their gamepads
            PlayerBaseScript player;
            player = Instantiate(playerTemplate, new Vector3(75, 25, 0), Quaternion.identity) as PlayerBaseScript;

            // TODO: Instantiating prefabs with the dictionary is causing null ref. @ player.SetGamePad;
            //player = Instantiate(Resources.Load(CharacterConstants.PREFAB_NAMES[CharacterConstants.type.Player]), new Vector3(75, 25, 0), Quaternion.identity) as PlayerBaseScript;
            player.SetGamepad(gamepadInfo[i]);
        }

    }

    void Update()
    {
        GetJoystickData();
    }

    void SetControllerNumber(int val)
    {
        controllerNumber = val;
    }

    void GetJoystickData()
    {    
        for (int i = 1; i < NumberOfActiveControllers+1; i++)
        {
            string leftX = "L_XAxis_" + i.ToString();
            string leftY = "L_YAxis_" + i.ToString();
            string rightX = "R_XAxis_" + i.ToString();
            string rightY = "R_YAxis_" + i.ToString();
            string triggerAxis = "Triggers_" + i.ToString();
            string dpadX = "DPad_XAxis_" + i.ToString();
            string dpadY = "DPad_YAxis_" + i.ToString();
            string a = "A_" + i.ToString();
            string b = "B_" + i.ToString();
            string x = "X_" + i.ToString();
            string y = "Y_" + i.ToString();
            string LB = "LB_" + i.ToString();
            string RB = "RB_" + i.ToString();
            string back = "Back_" + i.ToString();
            string start = "Start_" + i.ToString();
            string LS = "LS_" + i.ToString();
            string RS = "RS_" + i.ToString();

            bool[] button = new bool[10];
            button[0] = Input.GetButton(a);
            button[1] = Input.GetButton(b);
            button[2] = Input.GetButton(x);
            button[3] = Input.GetButton(y);
            button[4] = Input.GetButton(LS);
            button[5] = Input.GetButton(RS);
            button[6] = Input.GetButton(back);
            button[7] = Input.GetButton(start);
            button[8] = Input.GetButton(LB);
            button[9] = Input.GetButton(RB);

            bool[] buttonUp = new bool[10];
            buttonUp[0] = Input.GetButtonUp(a);
            buttonUp[1] = Input.GetButtonUp(b);
            buttonUp[2] = Input.GetButtonUp(x);
            buttonUp[3] = Input.GetButtonUp(y);
            buttonUp[4] = Input.GetButtonUp(LS);
            buttonUp[5] = Input.GetButtonUp(RS);
            buttonUp[6] = Input.GetButtonUp(back);
            buttonUp[7] = Input.GetButtonUp(start);
            buttonUp[8] = Input.GetButtonUp(LB);
            buttonUp[9] = Input.GetButtonUp(RB);

            bool[] buttonDown = new bool[10];
            buttonDown[0] = Input.GetButtonDown(a);
            buttonDown[1] = Input.GetButtonDown(b);
            buttonDown[2] = Input.GetButtonDown(x);
            buttonDown[3] = Input.GetButtonDown(y);
            buttonDown[4] = Input.GetButtonDown(LS);
            buttonDown[5] = Input.GetButtonDown(RS);
            buttonDown[6] = Input.GetButtonDown(back);
            buttonDown[7] = Input.GetButtonDown(start);
            buttonDown[8] = Input.GetButtonDown(LB);
            buttonDown[9] = Input.GetButtonDown(RB);

            gamepadInfo[i-1].SetData(i, new Vector2(Input.GetAxis(leftX), Input.GetAxis(leftY)), new Vector2(Input.GetAxis(rightX), Input.GetAxis(rightY)), Input.GetAxis(triggerAxis), new Vector2(Input.GetAxis(dpadX), Input.GetAxis(dpadY)), button, buttonUp, buttonDown);
        }
    }
}
