using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnHome : MonoBehaviour
{
    public static int Number6 = 0;
    public Text textAlert;
    public GameObject ShowText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Number6 == 0)
            {
                textAlert.text = "คุณมาผิดที่แล้ว !";
                GameSet.countWrong += 1;
                hp.countHp -= 1;
                ShowText.SetActive(true);
                Invoke("sleepHide2sec", 2f);
                this.gameObject.SetActive(false);
                Invoke("sleep2sec", 5f);
            }
            else if (Number6 == 1)
            {
                textAlert.text = "ยินดีด้วยคุณได้มาถึงบ้านเพื่อนแล้ว !";
                ShowText.SetActive(true);
                Number6 = 2;
                GameSet.EndGame += 1;
                Invoke("sleepHide2sec", 2f);
                this.gameObject.SetActive(false);
                Invoke("sleep2sec", 5f);
            }
            else if (Number6 == 2)
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
