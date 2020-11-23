using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Warp : MonoBehaviour
{
    public GameObject Alert;
    public Text textAlert, textMission , btnText , textCommand, btntextDis;
    public int num;
    private int step = 0;

    void Start()
    {
        btnText.text = transform.name;
        btntextDis.text = transform.name;
        Invoke("deleyListOrder", 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (step == 0)
            {
                Timer.countWrong++;
                textAlert.text = "คุณมาผิดที่แล้ว";
                Alert.SetActive(true);
                this.gameObject.SetActive(false);
                Invoke("deleyCloseAlert", 1.5f);
                Invoke("deleyShowObj", 30f);
            }
            else if (step == 1)
            {
                Timer.countSuc++;
                textAlert.text = "ยินดีด้วยคุณได้มาถึง"+this.transform.name+"แล้ว";
                Alert.SetActive(true);
                step = 2;
                this.gameObject.SetActive(false);
                Invoke("deleyCloseAlert", 1.5f);
                Invoke("deleyShowObj", 30f);
            }
            else if (step == 2)
            {
                Timer.countWrong++;
                textAlert.text = "คุณได้มาที่นี่แล้ว";
                Alert.SetActive(true);
                step = 2;
                this.gameObject.SetActive(false);
                Invoke("deleyCloseAlert", 1.5f);
                Invoke("deleyShowObj", 30f);
            }
        }
        
    }
   
    private void deleyShowObj()
    {
        this.gameObject.SetActive(true);
    }
    private void deleyCloseAlert()
    {
        Alert.SetActive(false);
    }

    private void deleyListOrder()
    {
        if (NewGameSet.listOrder.Contains(num))
        {
            textMission.text += "\n  " + (NewGameSet.showMission + 1).ToString() + ") " + transform.name;
            textCommand.text += "\n    " + (NewGameSet.showMission + 1).ToString() + ") " + transform.name;
            NewGameSet.showMission++;
            step = 1;
        }
    }
}
