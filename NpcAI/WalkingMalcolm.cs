using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingMalcolm : MonoBehaviour
{
     public AudioSource audioSource;
    public GameObject desinationPoint;
    NavMeshAgent theAgent;
    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {        
        theAgent.SetDestination(desinationPoint.transform.position);
    }
}
