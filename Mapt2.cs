using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mapt2 : MonoBehaviour
{
    public GameObject Submit, closeStart;

    public List<GameObject> UiSelect;
    public List<int> userOrder;    
    public int countSelect = 0;

    private int index;

    public List<int> listCompare;
    public List<int> result = new List<int>();
    public  List<List<int>> listAll = new List<List<int>>();

    private List<int> list0, list1, list2, list3, list4, list5, list6, list7, list8, list9, list10;

    void Start()
    {
        result.Clear();
        countSelect = 0;
        userOrder.Clear();
        list0 = new List<int>{8,6,7,9,5,10,3,2,1,4};
        list1 = new List<int>{2,9,4,8,7,3,10,5,6};
        list2 = new List<int>{1,4,9,8,7,3,10,5,6};
        list4 = new List<int>{2,3,10,1,5,7,6,9,8};
        list3 = new List<int>{10,5,4,6,2,7,1,8,9};
        list5 = new List<int>{6,3,10,8,7,4,2,9,1};
        list6 = new List<int>{5,10,3,8,7,9,4,2,1};
        list7 = new List<int>{8,10,9,6,3,5,2,4,1};
        list8 = new List<int>{7,9,6,5,10,3,2,1,4};
        list9 = new List<int>{8,1,7,2,6,10,5,3,4};
        list10 = new List<int>{3,7,6,5,8,4,2,9,1};
        listAll.Add(list0);
        listAll.Add(list1);
        listAll.Add(list2);
        listAll.Add(list3);
        listAll.Add(list4);
        listAll.Add(list5);
        listAll.Add(list6);
        listAll.Add(list7);
        listAll.Add(list8);
        listAll.Add(list9);
        listAll.Add(list10);
        Invoke("shortestPath",3f);
    }

    void Update()
    {
        if (countSelect == NewGameSet.Mission)
        {
            Submit.SetActive(true);
        }
    }
    public void Go()
    {
        for(int i = 0; i < userOrder.Count; i++)
        {
            if(userOrder[i] == result[i])
                NewGameSet.Planning++;        
            else
                break;  
        }
        Timer.timeStart = 0;
        closeStart.SetActive(false);
    }

    public void reset()
    {  
        userOrder.Clear();
        foreach(GameObject i in UiSelect)
        {
            countSelect = 0;
            i.SetActive(false);
            Submit.SetActive(false);
        }
    }    

    public void setUI(Transform transform)
    {
        if (countSelect == NewGameSet.Mission)
            return;
        UiSelect[countSelect].SetActive(true);
        UiSelect[countSelect].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        userOrder.Add(int.Parse(transform.name.ToString()));       
        countSelect++;
    }

    public void choose(Transform transform)
    {
        if (countSelect == NewGameSet.Mission)
            return;
        UiSelect[countSelect].SetActive(true);
        UiSelect[countSelect].transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        userOrder.Add(int.Parse(transform.name.ToString()));        
        countSelect++;
    }
int indexMin = 0;
int len;
    public void shortestPath()
    {
        int min = 1000;
        if(indexMin == 0)
            len = list1.Count+1;
        listCompare = NewGameSet.listOrder;
        while(listCompare.Count > 0){
            if(listCompare.Count==1){
                result.Add(listCompare[0]);
                return;
            }                
            else{
                for(int k=0 ; k < listCompare.Count ; k++){
                    for(int i=0 ; i < len ; i++){
                        if(listCompare[k] == listAll[indexMin][i]){
                            if(i < min){
                                min = i;
                                index = listCompare[k];
                            }                       
                        }                        
                    }
                }
            }             
            result.Add(index);               
            listCompare.Remove(index);
            indexMin = index;                        
        }
           
    }
}
