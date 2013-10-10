using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CompetitorModuleScript))]
[RequireComponent(typeof(PurseScript))]

abstract public class CompetitorBaseScript : InteractiveObjectBaseScript
{

    /// <summary>
    /// Inherit from this class to create an object that can interact with
    /// the competitive game components
    /// </summary>

    public CompetitorModuleScript competitorModule;
    public NameTextMesh nameTextMesh;
    public PurseScript purse;

    public override void Start()
    {
        base.Start();

    }

    protected override void SetupDependencies()
    {
        base.SetupDependencies();
        if (GameObject.FindGameObjectWithTag("CompetitiveGame"))
        {
            competitorModule.rpsGame = GameObject.FindGameObjectWithTag("CompetitiveGame").GetComponent<RockPaperScissors>();
        }

        if (GetComponent<CompetitorModuleScript>() == null)
        {
            gameObject.AddComponent<CompetitorModuleScript>();
        }
        competitorModule = GetComponent<CompetitorModuleScript>();

        if (GetComponentInChildren<NameTextMesh>() == null)
        {
            gameObject.AddComponent<NameTextMesh>();
        }
        nameTextMesh = GetComponentInChildren<NameTextMesh>();

        if (GetComponent<PurseScript>() == null)
        {
            gameObject.AddComponent<PurseScript>();
        }
        purse = GetComponent<PurseScript>();
    }

}
