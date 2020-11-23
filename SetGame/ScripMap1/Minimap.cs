using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public static bool ViewMap = false;
    public static bool ViewMinimap = true;
    public GameObject ShowMap,ShowMinimap;

    private void Start()
    {
        ShowMap.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (ViewMap)
            {
                ShowMinimap.SetActive(true);
                ShowMap.SetActive(false);
                ViewMap = false;
                ViewMinimap = true;
                GameSet.countMap++;
                hp.countHp -= 1;
                Movement.canMove = true;

            }
            else
            {
                ShowMinimap.SetActive(false);
                ShowMap.SetActive(true);
                ViewMap = true;
                ViewMinimap = false;
                Movement.canMove = false;                
            }
        }
    }
}
