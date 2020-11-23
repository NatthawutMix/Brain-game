using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show_Dialogue : MonoBehaviour
{
    public GameObject dialogPanel;
    public void show_dialogBox()
    {
        dialogPanel.SetActive(true);
    }
    public void close_dialogBox()
    {
        dialogPanel.SetActive(false);
    }
}
