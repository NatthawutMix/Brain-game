using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcPolice : MonoBehaviour
{
    public GameObject dialogPanel, helpPanel, btn;
    public GameObject hill, hospital, coffe, amp, school, house, market, res, btn1,btn2;
    public Dialogue dialogueManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogPanel.SetActive(true);
        }
    }
    public void show_hill()
    {
        hill.SetActive(true);
        btn.SetActive(false);
    }
    public void show_hospital()
    {
        hospital.SetActive(true);
        btn.SetActive(false);
    }
    public void show_coffe()
    {
        coffe.SetActive(true);
        btn.SetActive(false);
    }
    public void show_amp()
    {
        amp.SetActive(true);
        btn.SetActive(false);
    }
    public void show_school()
    {
        school.SetActive(true);
        btn.SetActive(false);
    }
    public void show_house()
    {
        house.SetActive(true);
        btn.SetActive(false);
    }
    public void show_market()
    {
        market.SetActive(true);
        btn.SetActive(false);
    }
    public void show_res()
    {
        res.SetActive(true);
        btn.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        dialogPanel.SetActive(false);
        helpPanel.SetActive(false);
        btn.SetActive(false);
        hill.SetActive(false);
        hospital.SetActive(false); 
        coffe.SetActive(false);
        amp.SetActive(false);
        school.SetActive(false);
        house.SetActive(false);
        market.SetActive(false);
        res.SetActive(false);
    }

    public void open_help_Panel()
    {
        helpPanel.SetActive(true);
        Timer.countHelp++;
        dialogPanel.SetActive(false);
    }

    public void close_help_Panel()
    {
        helpPanel.SetActive(false);
    }
    public void close_dialogBox()
    {
        dialogPanel.SetActive(false);
    }
}
