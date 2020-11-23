using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogPanel;
    public Text npcNameText;
    public Text dialogText;
    public Text btnNext;

    private List<string> conver;
    private int convoIndex;

  

    // Start is called before the first frame update
    private void Start()
    {
        dialogPanel.SetActive(false);
    }

    public void Start_Dialog(string _npcName, List<string> _convo)
    {
        npcNameText.text = _npcName;
        conver = new List<string>(_convo);
        dialogPanel.SetActive(true);
        convoIndex = 0;
        ShowText();
    }

    public void StopDialog()
    {
        dialogPanel.SetActive(false);
    }

    public void ShowText()
    {
        dialogText.text = conver[convoIndex];
    }

    public void Next()
    {   
        if(convoIndex < conver.Count - 1)
        {
            convoIndex += 1;
            ShowText();
        }
        else
        {
            dialogPanel.SetActive(false);
        }
        
    }
}
