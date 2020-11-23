using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAll : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    float speed;
    void Start()
    {
        transform.position = this.gameObject.transform.position;
    }
    void Update()
    {
        Vector3 targetDirection = target.position - transform.position;
        float singleStep = Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        transform.position = Vector3.Lerp(transform.position, target.position, 0.001f);
    }
}
