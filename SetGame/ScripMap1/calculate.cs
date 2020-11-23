using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class calculate : MonoBehaviour
{
    public GameObject desinationPoint;
    long s;
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
