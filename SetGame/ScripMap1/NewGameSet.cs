using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameSet : MonoBehaviour
{
    public GameObject UIDis;
    public Text DisText,DisText2;
    public int len;
    public static int Mission = 2;
    public static List<int> listOrder = new List<int>();
    private static List<int> lst_w;
    public List<GameObject> listRes = new List<GameObject>();
    private int Rand;
    public static int Planning;
    public static int showMission = 0;
    
    

    void Start()
    {
        Planning = 0;
        showMission = 0;
        listOrder.Clear();        

        for (int i = 0; i < Mission; i++)
        {
            Rand = Random.Range(1, len+1);
            while (listOrder.Contains(Rand))
            {
                Rand = Random.Range(1, len+1);
            }                
            listOrder.Add(Rand);            
        }
    }
    
    public void showUIDis()
    {
        UIDis.SetActive(true);
    }
    public void closeUIDis()
    {
        UIDis.SetActive(false);
    }    

    
}
