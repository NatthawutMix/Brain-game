using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp : MonoBehaviour
{
    
    public GameObject hp1, hp2, hp3, hp4, hp5, hp6, hp7, hp8, hp9, hp10;

    public static int countHp = 10;

     void Start()
    {
        countHp = 10;
    }
    void Update()
    {
        if(countHp < 10)
        {
            hp10.SetActive(false);
        }
        if (countHp < 9)
        {
            hp9.SetActive(false);
        }
        if (countHp < 8)
        {
            hp8.SetActive(false);
        }
        if (countHp < 7)
        {
            hp7.SetActive(false);
        }
        if (countHp < 6)
        {
            hp6.SetActive(false);
        }
        if (countHp < 5)
        {
            hp5.SetActive(false);
        }
        if (countHp < 4)
        {
            hp4.SetActive(false);
        }
        if (countHp < 3)
        {
            hp3.SetActive(false);
        }
        if (countHp < 2)
        {
            hp2.SetActive(false);
        }
        if (countHp < 1)
        {
            hp1.SetActive(false);
        }
    }
}
