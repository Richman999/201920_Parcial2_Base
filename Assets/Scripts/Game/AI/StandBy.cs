using AI;
using UnityEngine;

public class StandBy : Node
{
    public override void Execute()
    {
        Debug.Log(gameObject.name + "StandBy ok");
    }
}