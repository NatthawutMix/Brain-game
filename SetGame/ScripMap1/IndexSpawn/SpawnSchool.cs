using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnSchool : MonoBehaviour
{
    public static int Number5 = 0;
    public Text textAlert;
    public GameObject ShowText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Number5 == 0)
            {
                textAlert.text = "คุณมาผิดที่แล้ว !";
                GameSet.countWrong += 1;
                hp.countHp -= 1;
                ShowText.SetActive(true);
                Invoke("sleepHide2sec", 2f);
                this.gameObject.SetActive(false);
                Invoke("sleep2sec", 5f);
            }
            else if (Number5 == 1)
            {
                textAlert.text = "ยินดีด้วยคุณได้มาถึงโรงเรียนแล้ว !";
                ShowText.SetActive(true);
                Number5 = 2;
                GameSet.EndGame += 1;
                Invoke("sleepHide2sec", 2f);
                this.gameObject.SetActive(false);
                Invoke("sleep2sec", 5f);
            }
            else if (Number5 == 2)
            {
                textAlert.text = "คุณได้มาที่นี่แล้ว !";
                GameSet.countWrong += 1;
                hp.countHp -= 1;
                ShowText.SetActive(true);
                Invoke("sleepHide2sec", 2f);
                this.gameObject.SetActive(false);
                Invoke("sleep2sec", 5f);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        ShowText.SetActive(false);
    }
    private void sleep2sec()
    {
        this.gameObject.SetActive(true);
    }
    private void sleepHide2sec()
    {
        ShowText.SetActive(false);
    }
}

