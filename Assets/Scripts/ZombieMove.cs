using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMove : MonoBehaviour
{

    private NavMeshAgent agent;
    public GameObject target;

    private WaitForSeconds pushWait = new WaitForSeconds(1);
    private bool canPush = true;
    private bool dying = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Target");
        agent.SetDestination(target.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("ChainFence"))
        {
            if(canPush == true)
            {
                canPush = false;
                StartCoroutine(ResetPush(other));
                other.GetComponentInParent<Pushed>().pushes++;
                agent.isStopped = true; 
            }
        }
    }


    private void OnTriggerEnter (Collider other)
    {
        if(other.CompareTag("Barricade"))
        {
            if(dying == false)
            {
                dying = true;
                agent.isStopped = true;
            }
        }
    }


    IEnumerator ResetPush(Collider other)
    {
        yield return pushWait;
        if(other.transform.gameObject.activeInHierarchy == false)
        {
            agent.isStopped = false;
        }

        canPush = true;
    }

}
