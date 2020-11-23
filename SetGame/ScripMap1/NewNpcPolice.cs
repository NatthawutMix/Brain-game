using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewNpcPolice : MonoBehaviour
{
    public List<GameObject> list;
    public List<GameObject> listname;
    public GameObject hideBtn, help_panel, count_help;

    void Start(){
        for(int i=0 ; i<listname.Count ; i++){
            listname[i].GetComponentInChildren<Text>().text = list[i].transform.name;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            count_help.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        count_help.SetActive(false);
        help_panel.SetActive(false);
        foreach(GameObject i in list)
            i.SetActive(false);
    }
    public void EventBtn(Transform transform){
        list[int.Parse(transform.name)].SetActive(true);
        hideBtn.SetActive(false);
    }
    public void count_help_btn1(){
        help_panel.SetActive(true);
        Timer.countHelp++;
        count_help.SetActive(false);
    }
    public void btn_Back(){
        help_panel.SetActive(false);
    }
    public void count_help_btn2(){
        count_help.SetActive(false);
    }
}
