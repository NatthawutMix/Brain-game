using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesiMalcolm : MonoBehaviour
{
    public int y;
    public int x1, z1;
    public int x2, z2;
    public int x3, z3;
    public int x4, z4;
    private int state = 0; 
    private void OnTriggerEnter(Collider other)
    {
        if (state == 0)
        {
            if (other.tag == "NPC")
            {
                this.gameObject.transform.position = new Vector3(x1, y, z1);
            }
            state = 1;
        }
        else if (state == 1)
        {
            if (other.tag == "NPC")
            {
                this.gameObject.transform.position = new Vector3(x2, y, z2);
            }
            state = 2;
        }
        else if (state == 2)
        {
            if (other.tag == "NPC")
            {
                this.gameObject.transform.position = new Vector3(x3, y, z3);
            }
            state = 3;
        }
        else if (state == 3)
        {
            if (other.tag == "NPC")
            {
                this.gameObject.transform.position = new Vector3(x4, y, z4);
            }
            state = 0;
        }

    }
}
