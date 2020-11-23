
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Training : MonoBehaviour
{
    public static int map;
    public Button start;
    private void Start()
    {
        start.Select();
    }
    public void GoToMap1()
    {
        map = 1;
        SceneManager.LoadScene(9);
    }
    public void GoToMap2()
    {
        map = 2;
        SceneManager.LoadScene(9);
    }
    public void GoToMap3()
    {
        map = 3;
        SceneManager.LoadScene(9);
    }
    public void GoToMap4()
    {
        map = 4;
        SceneManager.LoadScene(9);
    }
    public void Back()
    {
        SceneManager.LoadScene(2);
    }

    public void BackMission()
    {
        SceneManager.LoadScene(4);
    }
    public void OneMission()
    {
        NewGameSet.Mission = 1;
        if (Menu.PATH == "TEST")
        {
            if (map == 1)
                SceneManager.LoadScene(13);
            else if (map == 2)
                SceneManager.LoadScene(14);
            else if (map == 3)
                SceneManager.LoadScene(15);
            else if (map == 4)
                SceneManager.LoadScene(16);
        }
        else if(Menu.PATH == "TRAINING")
        {            
            if (map == 1)
                SceneManager.LoadScene(7);
            else if (map == 2)
                SceneManager.LoadScene(10);
            else if (map == 3)
                SceneManager.LoadScene(11);
            else if (map == 4)
                SceneManager.LoadScene(12);
        }
    }
    public void TwoMission()
    {
        NewGameSet.Mission = 2;
        if (Menu.PATH == "TEST")
        {
            if (map == 1)
                SceneManager.LoadScene(13);
            else if (map == 2)
                SceneManager.LoadScene(14);
            else if (map == 3)
                SceneManager.LoadScene(15);
            else if (map == 4)
                SceneManager.LoadScene(16);
        }
        else if (Menu.PATH == "TRAINING")
        {            
            if (map == 1)
                SceneManager.LoadScene(7);
            else if (map == 2)
                SceneManager.LoadScene(10);
            else if (map == 3)
                SceneManager.LoadScene(11);
            else if (map == 4)
                SceneManager.LoadScene(12);
        }
    }
    public void fourMission()
    {
        NewGameSet.Mission = 4;
        if (Menu.PATH == "TEST")
        {            
            if (map == 1)
                SceneManager.LoadScene(13);
            else if (map == 2)
                SceneManager.LoadScene(14);
            else if (map == 3)
                SceneManager.LoadScene(15);
            else if (map == 4)
                SceneManager.LoadScene(16);
        }
        else if (Menu.PATH == "TRAINING")
        {
            if (map == 1)
                SceneManager.LoadScene(7);
            else if (map == 2)
                SceneManager.LoadScene(10);
            else if (map == 3)
                SceneManager.LoadScene(11);
            else if (map == 4)
                SceneManager.LoadScene(12);
        }

    }
    public void fiveMission()
    {
        NewGameSet.Mission = 5;
        if (Menu.PATH == "TEST")
        {            
            if (map == 1)
                SceneManager.LoadScene(13);
            else if (map == 2)
                SceneManager.LoadScene(14);
            else if (map == 3)
                SceneManager.LoadScene(15);
            else if (map == 4)
                SceneManager.LoadScene(16);
        }
        else if (Menu.PATH == "TRAINING")
        {
            if (map == 1)
                SceneManager.LoadScene(7);
            else if (map == 2)
                SceneManager.LoadScene(10);
            else if (map == 3)
                SceneManager.LoadScene(11);
            else if (map == 4)
                SceneManager.LoadScene(12);
        }
    }
}
