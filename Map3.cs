using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map3 : MonoBehaviour
{
    public GameObject Submit, closeStart;

    public List<GameObject> UiSelect;
    public List<int> userOrder;    
    public int countSelect = 0;

    private int index;

    public List<int> listCompare;
    public List<int> result = new List<int>();
    public  List<List<int>> listAll = new List<List<int>>();

    private List<int> list0, list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12;
    public List<string> list55;
    void Start()
    {
        result.Clear();
        countSelect = 0;
        userOrder.Clear();
        list0 = new List<int>{5,6,8,2,7,10,3,11,12,4,9,1};
        list1 = new List<int>{9,6,10,11,2,7,5,8,3,12,4};
        list2 = new List<int>{10,4,5,6,7,8,11,3,9,12,1};
        list3 = new List<int>{5,12,4,8,6,2,7,10,11,9,1};
        list4 = new List<int>{5,2,3,12,8,10,6,7,11,9,1};
        list5 = new List<int>{3,8,4,2,12,6,10,7,11,9,1};
        list6 = new List<int>{10,11,7,2,5,8,9,3,12,1,4};
        list7 = new List<int>{8,6,12,11,2,10,5,3,9,4,1};
        list8 = new List<int>{7,12,5,6,3,2,11,10,4,9,1};
        list9 = new List<int>{10,1,6,11,7,5,2,3,8,12,4};
        list10 = new List<int>{6,2,11,9,7,5,1,8,3,4,12};
        list11 = new List<int>{6,7,10,9,2,5,8,1,12,3,4};
        list12 = new List<int>{8,5,3,7,4,6,11,10,2,9,1};
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
        listAll.Add(list11);
        listAll.Add(list12);
        for (int f = 0; f < 13; f++)
        {
            print(f);
            foreach (var i in listAll[f])
            {
                if (i == 1)
                    list55.Add("ร้านอาหารริมน้ำ");
                if (i == 2)
                    list55.Add("ตึกแถว");
                if (i == 3)
                    list55.Add("7-11(ท้ายซอย)");
                if (i == 4)
                    list55.Add("ร้านก๋วยเตี๋ยว");
                if (i == 5)
                    list55.Add("บ้านสองชั้น");
                if (i == 6)
                    list55.Add("บ้านชั้นเดียว");
                if (i == 7)
                    list55.Add("อพาร์ทเม้น");
                if (i == 8)
                    list55.Add("สนามเด็กเล่น");
                if (i == 9)
                    list55.Add("สะพาน");
                if (i == 10)
                    list55.Add("วินรถ");
                if (i == 11)
                    list55.Add("7-11(ปากซอย)");
                if (i == 12)
                    list55.Add("ป่า");
            }
            foreach (var i in list55)
                print(i);
            list55.Clear();
        }
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
