using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map4 : MonoBehaviour
{
    public GameObject Submit, closeStart;

    public List<GameObject> UiSelect;
    public List<int> userOrder;    
    public int countSelect = 0;

    private int index;

    public List<int> listCompare;
    public List<string> list55;
    public List<int> result = new List<int>();
    public  List<List<int>> listAll = new List<List<int>>();

    private List<int> list0, list1, list2, list3, list4, list5, list6, list7, list8, list9, list10, list11, list12, list13;

    void Start()
    {
        result.Clear();
        countSelect = 0;
        userOrder.Clear();
        list0 = new List<int>{13,1,5,6,8,4,3,12,9,11,7,10,2};
        list1 = new List<int>{4,5,13,6,8,11,12,9,3,7,10,2};
        list2 = new List<int>{10,7,8,3,9,13,12,1,5,6,11,4};
        list3 = new List<int>{8,13,10,2,7,9,1,5,6,12,11,4};
        list4 = new List<int>{1,11,12,9,13,5,6,8,7,3,10,2};
        list5 = new List<int>{12,13,1,6,8,9,11,7,3,4,10,2};
        list6 = new List<int>{1,13,5,8,12,3,9,11,4,7,10,2};
        list7 = new List<int>{9,12,8,2,10,3,13,11,5,4,1,6};
        list8 = new List<int>{13,3,7,10,2,1,5,6,9,12,4,11};
        list9 = new List<int>{12,7,11,5,2,10,4,8,13,3,1,6};
        list10 = new List<int>{2,7,9,8,13,3,12,11,1,5,6,4};
        list11 = new List<int>{12,9,4,5,1,7,13,6,2,10,8,3};
        list12 = new List<int>{9,11,5,7,4,2,10,13,1,6,8,3};
        list13 = new List<int>{8,1,5,6,3,7,10,2,4,12,9,11};
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
        listAll.Add(list13);
        for (int f = 0; f < 14; f++)
        {
            print(f);
            foreach (var i in listAll[f])
            {
                if (i == 1)
                    list55.Add("ศาลากลาง");
                if (i == 2)
                    list55.Add("ธนาคาร");
                if (i == 3)
                    list55.Add("สนามฟุตบอล");
                if (i == 4)
                    list55.Add("ห้างโรบินสัน");
                if (i == 5)
                    list55.Add("ปั๊มน้ำมัน");
                if (i == 6)
                    list55.Add("หมู่บ้าน");
                if (i == 7)
                    list55.Add("แอมเวย์");
                if (i == 8)
                    list55.Add("ร้านขายรถ");
                if (i == 9)
                    list55.Add("โรงพยาบาล");
                if (i == 10)
                    list55.Add("โลตัส");
                if (i == 11)
                    list55.Add("ร้านอาหาร");
                if (i == 12)
                    list55.Add("วัด");
                if (i == 13)
                    list55.Add("7-11");
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
