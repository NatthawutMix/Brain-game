using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map1 : MonoBehaviour
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

    private List<int> list0, list1, list2, list3, list4, list5, list6, list7, list8;

    void Start()
    {
        result.Clear();
        countSelect = 0;
        userOrder.Clear();
        list0 = new List<int>{2,4,5,8,7,6,3,1};
        list1 = new List<int>{2,6,4,5,8,7,3};
        list2 = new List<int>{4,1,5,3,8,7,6};
        list3 = new List<int>{4,2,5,7,8,6,1};
        list4 = new List<int>{2,5,3,8,7,6,1};
        list5 = new List<int>{8,6,7,4,2,3,1};
        list6 = new List<int>{8,5,1,7,4,2,3};
        list7 = new List<int>{5,8,6,4,2,3,1};
        list8 = new List<int>{5,6,7,4,3,2,1};
        listAll.Add(list0);
        listAll.Add(list1);
        listAll.Add(list2);
        listAll.Add(list3);
        listAll.Add(list4);
        listAll.Add(list5);
        listAll.Add(list6);
        listAll.Add(list7);
        listAll.Add(list8);
        for(int f = 0; f < 9; f++)
        {
            print(f);
            foreach (var i in listAll[f])
            {
                if (i == 1)
                    list55.Add("ภูเขา");
                if (i == 2)
                    list55.Add("ร้านอาหาร");
                if (i == 3)
                    list55.Add("โรงพยาบาล");
                if (i == 4)
                    list55.Add("ร้านกาแฟ");
                if (i == 5)
                    list55.Add("ตลาด");
                if (i == 6)
                    list55.Add("อพาร์ทเม้น");
                if (i == 7)
                    list55.Add("โรงเรียน");
                if (i == 8)
                    list55.Add("บ้านเพื่อน");
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
