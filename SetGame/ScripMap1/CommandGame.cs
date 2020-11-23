using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CommandGame : MonoBehaviour
{
    public GameObject showCommand,showExit;

    public Text textCommand;
    private bool Commd = false;
    private bool check = true;
    void Start()
    {
        
        for(int i = 0; i < GameSet.myMap; i++)
        {
            if (GameSet.SpawnWarp[i] == 1)
            {
                textCommand.text += "\n" + (i + 1).ToString() + ".ภูเขา";
            }
            else if (GameSet.SpawnWarp[i] == 2)
            {
                textCommand.text += "\n" + (i + 1).ToString() + ".โรงพยาบาล";
            }
            else if (GameSet.SpawnWarp[i] == 3)
            {
                textCommand.text += "\n" + (i + 1).ToString() + ".ร้านกาแฟ";
            }
            else if (GameSet.SpawnWarp[i] == 4)
            {
                textCommand.text += "\n" + (i + 1).ToString() + ".อพาร์ทเม้น";
            }
            else if (GameSet.SpawnWarp[i] == 5)
            {
                textCommand.text += "\n" + (i + 1).ToString() + ".โรงเรียน";
            }
            else if (GameSet.SpawnWarp[i] == 6)
            {
                textCommand.text += "\n" + (i + 1).ToString() + ".บ้านเพื่อน";
            }
            else if (GameSet.SpawnWarp[i] == 7)
            {
                textCommand.text += "\n" + (i + 1).ToString() + ".ตลาด";
            }
            else if (GameSet.SpawnWarp[i] == 8)
            {
                textCommand.text += "\n" + (i + 1).ToString() + ".ร้านอาหาร";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(Commd)
            {
                Movement.canMove = true;
                showCommand.SetActive(false);
                Commd = false;
                hp.countHp -= 1;
                GameSet.countCommand += 1;
            }
            else
            {
                Movement.canMove = false;
                showCommand.SetActive(true);
                Commd = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (check)
            {
                showExit.SetActive(true);
                check = false;
            }
            else
            {
                showExit.SetActive(false);
                check = true;
            }
                
        }
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(2);
    }
    
    public void CancelExit()
    {
        showExit.SetActive(false);
        check = true;
    }
}
