using UnityEngine;
using System.Collections.Generic;
using Constants;

public class CompWorldManagerScript : ManagerScript
{
    private bool isMatchInProgress;
    private CompWorldConstants.worldStates state;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        isMatchInProgress = false;
        state = CompWorldConstants.worldStates.noMatchInProgress;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (isMatchInProgress)
        {
            
            //Continue running through game.
        }
        else
        {
            if (CheckMatchStartingRequirements() == true)
            {
                //startMatch();
            }
            else
            {
                //do nothing
            }
        }

    }

    /// <summary>
    /// Attempt to place player in the playerList to 
    /// be used when the next match begins
    /// </summary>
    /// <param name="newPlayer">Player to be placed into the playerList</param>
    /// <returns>true if placement was a success, false otherwise</returns>
    public bool PlacePlayerInMatch(PlayerScript newPlayer)
    {
        if (!isMatchInProgress)
        {
            //add player to player list.
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Check to see if we meet the requirements to start a new game.
    /// </summary>
    /// <returns>true, if we meet the match starting requirements. False otherwise.</returns>
    public bool CheckMatchStartingRequirements()
    {
        if (base.GetPlayerList().Count == 2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void StartMatch()
    {
        state = CompWorldConstants.worldStates.matchInProgress;
        List<GameObject> playerList = GetPlayerList();
        
        foreach (GameObject cPlayer in playerList)
        {
            
            //create new representations of the player in the comp world
            //set player state to be in the compworld   
        }

    }

    private void createPlayer()
    {
        

    }



}
