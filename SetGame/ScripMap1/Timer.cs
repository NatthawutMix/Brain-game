using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText,textOut,M_Suc;
    public GameObject showScore, showWarpEnd, timeOut, blackScreen;
    public static float timeStart;
    public static string countTime;
    public static int score = 0;
    public static bool finnished = false;
    public Text scoreTime, scoreWrong, scoreCount, scoreCom;

    private int contTest;


    public static int countHelp , countWrong, countSuc;
    void Start()
    {
        timeStart = 0;
        countHelp = countWrong = countSuc = 0;        

        finnished = false;
    }

    void Update()
    {    
        if (finnished)
            return;
        M_Suc.text = countSuc.ToString();
        timeStart += Time.deltaTime;
        timerText.text = timeStart.ToString("f0");


        if (timeStart == 900)
        {
            textOut.text = "เวลาของคุณหมดเเล้ว";
            timeOut.SetActive(true);
            blackScreen.SetActive(true);
        }

        if (countWrong+countHelp == 10)
        {
            textOut.text = "พลังของคุณหมดเเล้ว";
            timeOut.SetActive(true);
            blackScreen.SetActive(true);
        }

        if (countSuc == NewGameSet.Mission)
        {
            scoreTime.text = "   เวลา:  " + timeStart.ToString("f0");
            scoreWrong.text = "   จำนวนไปผิดที่:  " + countWrong.ToString();
            scoreCom.text = "   จำนวนที่ใช้ตัวช่วย:  " + countHelp.ToString();
            scoreCount.text = "   จำนวนทำภารกิจสำเร็จ:  " + countSuc.ToString();
            showWarpEnd.SetActive(true);                            
         }               
    }  

    void ShowUI()
    {        
        showScore.SetActive(true);
    }
}
