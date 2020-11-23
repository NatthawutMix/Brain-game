using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Text UpdateText;
    public GameObject c1, c2, c3, c4, c5, submit, pos, hide;

    public static List<int> listChoice = new List<int>();
    public List<int> listCheckChoice = new List<int>();

    public static string resChoice = "";
    private int count = 1;

    public void Choice1()
    {
        if(GameSet.myMap < count)
        {
            return;
        }
        if (count == 1)        
        {
            c1.transform.position = new Vector3(pos.transform.position.x -30, pos.transform.position.y, 0);
            c1.SetActive(true);
            listChoice.Add(1);
            resChoice += "1";
        }
        else if (count == 2)
        {
            c2.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y, 0);
            c2.SetActive(true);
            listChoice.Add(1);
            resChoice += "1";
        }
        else if (count == 3)
        {
            c3.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y, 0);
            c3.SetActive(true);
            listChoice.Add(1);
            resChoice += "1";
        }
        else if (count == 4)
        {
            c4.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y, 0);
            c4.SetActive(true);
            listChoice.Add(1);
            resChoice += "1";
        }
        else if (count == 5)
        {
            c5.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y, 0);
            c5.SetActive(true);
            listChoice.Add(1);
            resChoice += "1";
        }
        
        count++;
    }
    public void Choice2()
    {
        if (GameSet.myMap < count)
        {
            return;
        }
        if (count == 1)
        {
            c1.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 50, 0);
            c1.SetActive(true);
            listChoice.Add(2);
            resChoice += "2";
        }
        else if (count == 2)
        {
            c2.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 50, 0);
            c2.SetActive(true);
            listChoice.Add(2);
            resChoice += "2";
        }
        else if (count == 3)
        {
            c3.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 50, 0);
            c3.SetActive(true);
            listChoice.Add(2);
            resChoice += "2";
        }
        else if (count == 4)
        {
            c4.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 50, 0);
            c4.SetActive(true);
            listChoice.Add(2);
            resChoice += "2";
        }
        else if (count == 5)
        {
            c5.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 50, 0);
            c5.SetActive(true);
            listChoice.Add(2);
            resChoice += "2";
        }
        
        count++;
    }

    public void Choice3()
    {
        if (GameSet.myMap < count)
        {
            return;
        }
        if (count == 1)
        {
            c1.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 100, 0);
            c1.SetActive(true);
            listChoice.Add(3);
            resChoice += "3";
        }
        else if (count == 2)
        {
            c2.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 100, 0);
            c2.SetActive(true);
            listChoice.Add(3);
            resChoice += "3";
        }
        else if (count == 3)
        {
            c3.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 100, 0);
            c3.SetActive(true);
            listChoice.Add(3);
            resChoice += "3";
        }
        else if (count == 4)
        {
            c4.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 100, 0);
            c4.SetActive(true);
            listChoice.Add(3);
            resChoice += "3";
        }
        else if (count == 5)
        {
            c5.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 100, 0);
            c5.SetActive(true);
            listChoice.Add(3);
            resChoice += "3";
        }
        count++;
    }

    public void Choice4()
    {
        if (GameSet.myMap < count)
        {
            return;
        }
        if (count == 1)
        {
            c1.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 150, 0);
            c1.SetActive(true);
            listChoice.Add(4);
            resChoice += "4";
        }
        else if (count == 2)
        {
            c2.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 150, 0);
            c2.SetActive(true);
            listChoice.Add(4);
            resChoice += "4";
        }
        else if (count == 3)
        {
            c3.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 150, 0);
            c3.SetActive(true);
            listChoice.Add(4);
            resChoice += "4";
        }
        else if (count == 4)
        {
            c4.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 150, 0);
            c4.SetActive(true);
            listChoice.Add(4);
            resChoice += "4";
        }
        else if (count == 5)
        {
            c5.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 150, 0);
            c5.SetActive(true);
            listChoice.Add(4);
            resChoice += "4";
        }
        count++;
    }

    public void Choice5()
    {
        if (GameSet.myMap < count)
        {
            return;
        }
        if (count == 1)
        {
            c1.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 200, 0);
            c1.SetActive(true);
            listChoice.Add(5);
            resChoice += "5";
        }
        else if (count == 2)
        {
            c2.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 200, 0);
            c2.SetActive(true);
            listChoice.Add(5);
            resChoice += "5";
        }
        else if (count == 3)
        {
            c3.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 200, 0);
            c3.SetActive(true);
            listChoice.Add(5);
            resChoice += "5";
        }
        else if (count == 4)
        {
            c4.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 200, 0);
            c4.SetActive(true);
            listChoice.Add(5);
            resChoice += "5";
        }
        else if (count == 5)
        {
            c5.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 200, 0);
            c5.SetActive(true);
            listChoice.Add(5);
            resChoice += "5";
        }
        count++;
    }

    public void Choice6()
    {
        if (GameSet.myMap < count)
        {
            return;
        }
        if (count == 1)
        {
            c1.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 250, 0);
            c1.SetActive(true);
            listChoice.Add(6);
            resChoice += "6";
        }
        else if (count == 2)
        {
            c2.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 250, 0);
            c2.SetActive(true);
            listChoice.Add(6);
            resChoice += "6";
        }
        else if (count == 3)
        {
            c3.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 250, 0);
            c3.SetActive(true);
            listChoice.Add(6);
            resChoice += "6";
        }
        else if (count == 4)
        {
            c4.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 250, 0);
            c4.SetActive(true);
            listChoice.Add(6);
            resChoice += "6";
        }
        else if (count == 5)
        {
            c5.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 250, 0);
            c5.SetActive(true);
            listChoice.Add(6);
            resChoice += "6";
        }
        count++;
    }

    public void Choice7()
    {
        if (GameSet.myMap < count)
        {
            return;
        }
        if (count == 1)
        {
            c1.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 300, 0);
            c1.SetActive(true);
            listChoice.Add(7);
            resChoice += "7";
        }
        else if (count == 2)
        {
            c2.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 300, 0);
            c2.SetActive(true);
            listChoice.Add(7);
            resChoice += "7";
        }
        else if (count == 3)
        {
            c3.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 300, 0);
            c3.SetActive(true);
            listChoice.Add(7);
            resChoice += "7";
        }
        else if (count == 4)
        {
            c4.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 300, 0);
            c4.SetActive(true);
            listChoice.Add(7);
            resChoice += "7";
        }
        else if (count == 5)
        {
            c5.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 300, 0);
            c5.SetActive(true);
            listChoice.Add(7);
            resChoice += "7";
        }
        count++;
    }

    public void Choice8()
    {
        if (GameSet.myMap < count)
        {
            return;
        }
        if (count == 1)
        {
            c1.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 350, 0);
            c1.SetActive(true);
            listChoice.Add(8);
            resChoice += "8";
        }
        else if (count == 2)
        {
            c2.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 350, 0);
            c2.SetActive(true);
            listChoice.Add(8);
            resChoice += "8";
        }
        else if (count == 3)
        {
            c3.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 350, 0);
            c3.SetActive(true);
            listChoice.Add(8);
            resChoice += "8";
        }
        else if (count == 4)
        {
            c4.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 350, 0);
            c4.SetActive(true);
            listChoice.Add(8);
            resChoice += "8";
        }
        else if (count == 5)
        {
            c5.transform.position = new Vector3(pos.transform.position.x - 30, pos.transform.position.y - 350, 0);
            c5.SetActive(true);
            listChoice.Add(8);
            resChoice += "8";
        }
        count++;
    }

    public void reSet()
    {
        count = 1;
        c1.SetActive(false);
        c2.SetActive(false);
        c3.SetActive(false);
        c4.SetActive(false);
        c5.SetActive(false);
        resChoice = "";
        listChoice.Clear();
        submit.SetActive(false);
    }

    public void Submit()
    {
        hide.SetActive(false);
        for (int i = 0; i < 5; i++)
        {
            if (GameSet.result[i] == listChoice[i])
            {
                GameSet.countPath++;
            }
            else
                break;
        }
        //print(GameSet.countPath);
    }
    void Start()
    {
        
         for(int i = 0; i < GameSet.myMap; i++)
         {
            if (GameSet.SpawnWarp[i] == 1)
            {
                UpdateText.text += "\n"+ "    " + (i + 1).ToString() + ".ภูเขา";
            }
            else if (GameSet.SpawnWarp[i] == 2)
            {
                UpdateText.text += "\n" + "    " + (i + 1).ToString() + ".โรงพยาบาล";
            }
            else if (GameSet.SpawnWarp[i] == 3)
            {
                UpdateText.text += "\n" + "    " + (i + 1).ToString() + ".ร้านกาแฟ";
            }
            else if (GameSet.SpawnWarp[i] == 4)
            {
                UpdateText.text += "\n" + "    " + (i + 1).ToString() + ".อพาร์ทเม้น";
            }
            else if (GameSet.SpawnWarp[i] == 5)
            {
                UpdateText.text += "\n" + "    " + (i + 1).ToString() + ".โรงเรียน";
            }
            else if (GameSet.SpawnWarp[i] == 6)
            {
                UpdateText.text += "\n" + "    " + (i + 1).ToString() + ".บ้านเเพื่อน";
            }
            else if (GameSet.SpawnWarp[i] == 7)
            {
                UpdateText.text += "\n" + "    " + (i + 1).ToString() + ".ตลาด";
            }
            else if (GameSet.SpawnWarp[i] == 8)
            {
                UpdateText.text += "\n" + "    " + (i + 1).ToString() + ".ร้านอาหาร";
            }
         }
        for (int i = 0; i < GameSet.myMap; i++)
        {
            listCheckChoice.Add(GameSet.SpawnWarp[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (count == GameSet.myMap+1)
        {
            submit.SetActive(true);
        }
    }
}
