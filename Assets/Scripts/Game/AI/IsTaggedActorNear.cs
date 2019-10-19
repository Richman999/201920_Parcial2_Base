using AI;
using UnityEngine;

public class IsTaggedActorNear : SelectWithOption
{
    [SerializeField] private bool areyouok;
    public override bool Check()
    {
        Debug.Log(gameObject.name + "IsTaggedActorNear ok");
        return areyouok;
    }
}