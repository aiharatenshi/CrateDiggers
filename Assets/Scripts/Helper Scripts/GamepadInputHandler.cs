using UnityEngine;
using System.Collections;
using Constants;

public class GamepadInputHandler : MonoBehaviour
{

    /// <summary>
    /// This class polls the connected gamepads and populates their GamepadInfo with
    /// the values of all their joysticks and buttons.
    /// </summary>

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

            PlayerBaseScript player;
            player = Instantiate(playerTemplate, new Vector3(75, 25, 0), Quaternion.identity) as PlayerBaseScript;
            //player = Instantiate(Resources.Load(CharacterConstants.PREFAB_NAMES[CharacterConstants.type.Player]), new Vector3(75, 25, 0), Quaternion.identity) as PlayerBaseScript;
            //player.SetGamepad(gamepadInfoPrefab);
            player.gamepad = gamepadInfo[i];
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

            bool[] buttons = new bool[10];
            buttons[0] = Input.GetButton(a);
            buttons[1] = Input.GetButton(b);
            buttons[2] = Input.GetButton(x);
            buttons[3] = Input.GetButton(y);
            buttons[4] = Input.GetButton(LS);
            buttons[5] = Input.GetButton(RS);
            buttons[6] = Input.GetButton(back);
            buttons[7] = Input.GetButton(start);
            buttons[8] = Input.GetButton(LB);
            buttons[9] = Input.GetButton(RB);

            gamepadInfo[i-1].SetData(i, new Vector2(Input.GetAxis(leftX), Input.GetAxis(leftY)), new Vector2(Input.GetAxis(rightX), Input.GetAxis(rightY)), Input.GetAxis(triggerAxis), new Vector2(Input.GetAxis(dpadX), Input.GetAxis(dpadY)), buttons);
        }
    }
}
