using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewHP : MonoBehaviour
{
    public List<GameObject> UIhp;
    public GameObject showM, showI, showEsc;

    public Button esc;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer.countHelp + Timer.countWrong < 10)
            UIhp[Timer.countHelp + Timer.countWrong].SetActive(false);
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (showM.activeSelf){
                showM.SetActive(false);
                return;
            }
            Timer.countHelp++;
            showM.SetActive(true);
        }                
        
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (showI.activeSelf)
            {
                showI.SetActive(false);
                return;
            }
            Timer.countHelp++;
            showI.SetActive(true);
        }
        if(Timer.countHelp + Timer.countWrong == 10)
        {
            showI.SetActive(false);
            showM.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (showM.activeSelf || showI.activeSelf || showEsc.activeSelf)
            {
                showEsc.SetActive(false);
                showI.SetActive(false);
                showM.SetActive(false);
                return;
            }
            showEsc.SetActive(true);
            esc.Select();
        }
        
    }
    public void ExitScenes()
    {
        SceneManager.LoadScene(2);
    }
    public void cancelExit()
    {
        showEsc.SetActive(false);
    }

}
