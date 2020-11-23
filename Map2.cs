using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map2 : MonoBehaviour
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
    public List<string> list55;
    void Start()
    {
        result.Clear();
        countSelect = 0;
        userOrder.Clear();
        list0 = new List<int>{8,6,7,9,5,10,4,2,1,3};
        list1 = new List<int>{2,9,3,8,7,4,10,5,6};
        list2 = new List<int>{1,3,9,8,7,4,10,5,6};
        list3 = new List<int>{2,4,10,1,5,7,6,9,8};
        list4 = new List<int>{10,5,3,6,2,7,1,8,9};
        list5 = new List<int>{6,4,10,8,7,3,2,9,1};
        list6 = new List<int>{5,10,4,8,7,9,3,2,1};
        list7 = new List<int>{8,10,9,6,4,5,2,3,1};
        list8 = new List<int>{7,9,6,5,10,4,2,1,3};
        list9 = new List<int>{8,1,7,2,6,10,5,4,3};
        list10 = new List<int>{4,7,6,5,8,3,2,9,1};
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

        for (int f = 0; f < 11; f++)
        {
            print(f);
            foreach (var i in listAll[f])
            {
                if (i == 1)
                    list55.Add("โกดังเล็ก");
                if (i == 2)
                    list55.Add("คอกม้า");
                if (i == 3)
                    list55.Add("บ้านคุณตา");
                if (i == 4)
                    list55.Add("ร้านขายของ");
                if (i == 5)
                    list55.Add("โรงพยาบาล");
                if (i == 6)
                    list55.Add("ศาลาริมน้ำ");
                if (i == 7)
                    list55.Add("โกดังใหญ่");
                if (i == 8)
                    list55.Add("คอกหมู");
                if (i == 9)
                    list55.Add("นาข้าวจำลอง");
                if (i == 10)
                    list55.Add("ตลาด");
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
