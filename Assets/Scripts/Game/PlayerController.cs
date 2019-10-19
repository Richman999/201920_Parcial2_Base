using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using System;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Collider))]
public abstract class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float stopTime = 3F;
    public delegate void OnTagge (string player);
    public event OnTagge eventoOnTagge;
    public bool canCollision =true;
    [SerializeField]
    private bool isTagged;
    protected NavMeshAgent agent { get; set; }

    public bool IsTagged { get { return isTagged; } set { isTagged = value; } }
    public void SwitchRoles()
    {
        isTagged = !IsTagged;

        // Pause all logic and restart after
    }

    public void GoToLocation(Vector3 location)
    {
        agent.SetDestination(location);
    }

    public virtual IEnumerator StopLogic()
    {
        // Stop BT runner if AI player, else stop movement.
        this.GetComponent<NavMeshAgent>().speed = 0;
        canCollision = false;

        yield return new WaitForSeconds(stopTime);

        this.GetComponent<NavMeshAgent>().speed = 3.5f;
        canCollision = true;

        // Restart stuff.
    }

    protected abstract Vector3 GetLocation();

    // Start is called before the first frame update
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void OnCollisionEnter(Collision collision)
    {


        if (IsTagged && canCollision && collision.gameObject.CompareTag("Player"))
        {
            SwitchRoles();
            eventoOnTagge(gameObject.name);
            StartCoroutine( StopLogic());
            collision.gameObject.GetComponent<PlayerController>().SwitchRoles();
        }

    }

}