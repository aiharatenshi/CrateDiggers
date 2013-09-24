using UnityEngine;
using System.Collections;
using Constants;

public class FrameWorldManagerScript : ManagerScript
{

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        GameObject newCharacterObject = CreateCharacter(CharacterConstants.GAMEOBJECT_NAMES[CharacterConstants.type.Player], CharacterConstants.type.Player, Vector3.zero);
    }

    // Update is called once per frame
    public override void Update()
    {

    }

    public GameObject CreateCharacter(string charName, CharacterConstants.type type, Vector3 startingPosition)
    {
        GameObject newCharacterObject = null;

        switch (type)
        {
            case CharacterConstants.type.Player:
                {
                    //TODO: Turn "Enemy" into a constant that is referenced from ConstantsScript
                    newCharacterObject = (GameObject)Instantiate(Resources.Load(CharacterConstants.PREFAB_NAMES[CharacterConstants.type.Player]), Vector3.zero, Quaternion.identity);
                    PlayerScript newPlayerScript = newCharacterObject.GetComponent<PlayerScript>();
                    newCharacterObject.name = charName;
                    newCharacterObject.transform.position = startingPosition;

                    base.GetPlayerList().Add(newCharacterObject);
                    break;
                }
        }
        return newCharacterObject;
    }

}
