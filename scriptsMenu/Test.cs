using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public Button start;
    private void Start()
    {
        start.Select();
    }
    public void GoToMap1()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToMap2()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToMap3()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToMap4()
    {
        SceneManager.LoadScene(0);
    }
    public void Back()
    {
        SceneManager.LoadScene(2);
    }
}
