using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class delayText : MonoBehaviour
{
    public GameObject btnClose, btnContinue, changeLocation;
    public Text textDisplay;
    public string [] sentences;
    private string updatetext="";
    private int index;
    private float speed = 0.02f;
    
    void Start()
    {
        btnClose.SetActive(false);
        btnContinue.SetActive(false);
        StartCoroutine(delay());
    }

    void Update()
    {
        if(updatetext == sentences[index])
        {
            btnContinue.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                btnContinue.SetActive(false);
                nextSentence();
            }
        }
    }
    IEnumerator delay()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {            
            textDisplay.text += letter;
            updatetext += letter;
            yield return new WaitForSeconds(speed);
        }
    }
    public void nextSentence()
    {
        btnContinue.SetActive(false);
        updatetext = "";
        if(index < sentences.Length - 1)
        {
            textDisplay.text += "\n";
            index++;
            StartCoroutine(delay());
        }
        if (index == sentences.Length-1)
        {
            btnClose.SetActive(true);
        }
    }
    public void closeSentence()
    {
        this.gameObject.SetActive(false);
        changeLocation.SetActive(true);
    }
}
