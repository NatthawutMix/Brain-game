using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPos : MonoBehaviour
{
    public GameObject Object;
    public int x1, y1, x2, y2;
    private void Start()
    {
        this.gameObject.transform.position = new Vector3(Random.Range(x1, y1), Random.Range(x2, y2), Random.Range(x1, y1));
    }
    private void OnTriggerEnter(Collider other)
    {
            this.gameObject.transform.position = new Vector3(Random.Range(x1, y1), Random.Range(x2, y2), Random.Range(x1, y1));
    }
}
