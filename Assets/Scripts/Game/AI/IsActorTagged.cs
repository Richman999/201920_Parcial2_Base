using AI;
using UnityEngine;

public class IsActorTagged : SelectWithOption
{

    public override bool Check()
    {
        bool value = gameObject.GetComponent<PlayerController>().IsTagged;
        return value;
    }
}