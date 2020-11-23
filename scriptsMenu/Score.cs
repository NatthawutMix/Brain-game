using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private string dataURL = "https://testloginfirebase-1eeee.firebaseio.com/";
    private DatabaseReference databaseReference;

    [SerializeField] public GameObject textTime;
    private List<GameObject> textItems;

    public InputField map;

    public Button start;
    ArrayList BoardList;

    void Start()
    {
        map.Select();
        //start.Select();
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(dataURL);
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        BoardList = new ArrayList();
        textItems = new List<GameObject>();      
    }

    
    private void LogText()
    {
        foreach (var i in textItems)
        {
            Destroy(i);
        }
        if(BoardList != null)
        {
            foreach (string i in BoardList)
            {
                GameObject newText1 = Instantiate(textTime) as GameObject;
                newText1.SetActive(true);
                newText1.GetComponent<Text>().text = i;
                newText1.transform.SetParent(textTime.transform.parent, false);
                textItems.Add(newText1.gameObject);
            }
        }        
    } 

    public void SubmitTraining()
    {
        if (map.text == "1" || map.text == "2" || map.text == "3" || map.text == "4")
        {
            BoardList.Clear();
            foreach (var i in textItems)
            {
                Destroy(i);
            }

            FirebaseDatabase.DefaultInstance.GetReference(Login.PATH).Child("TRAINING").Child(map.text).GetValueAsync()
                  .ContinueWith(task =>
                  {
                      DataSnapshot snapshot = task.Result;
                      foreach (var child in snapshot.Children)
                      {
                          string s1 = "";
                          if (child.Key.ToString().Length == 2)
                              s1 += " " + child.Value.ToString();
                          else if (child.Key.ToString().Length == 3)
                              s1 += "" + child.Value.ToString();
                          else
                              s1 += ("  " + child.Key.ToString());                          
                          foreach (var data in child.Children)
                          {                              
                              if (data.Key.ToString() == "เวลา")
                              {
                                  if (data.Value.ToString().Length == 2)
                                      s1 += "                " + data.Value.ToString();
                                  else if (data.Value.ToString().Length == 3)
                                      s1 += "               " + data.Value.ToString();
                                  else
                                    s1 += "                 " + data.Value.ToString();
                              }
                              else if (data.Key.ToString() == "จำนวนสถานที่")
                              {
                                  if (data.Value.ToString().Length == 2)
                                      s1 += "               " + data.Value.ToString();
                                  else if (data.Value.ToString().Length == 3)
                                      s1 += "              " + data.Value.ToString();
                                  else
                                      s1 += "                " + data.Value.ToString();
                              }
                              else if (data.Key.ToString() == "จำนวนการไปผิดสถานที่")
                              {
                                  if (data.Value.ToString().Length == 2)
                                      s1 += "                  " + data.Value.ToString();
                                  else if (data.Value.ToString().Length == 3)
                                      s1 += "                 " + data.Value.ToString();
                                  else
                                      s1 += "                  " + data.Value.ToString();
                              }
                              else if (data.Key.ToString() == "จำนวนการใช้ตัวช่วย")
                              {
                                  if (data.Value.ToString().Length == 2)
                                      s1 += "         " + data.Value.ToString();
                                  else if (data.Value.ToString().Length == 3)
                                      s1 += "        " + data.Value.ToString();
                                  else
                                      s1 += "          " + data.Value.ToString();
                              }
                              else if (data.Key.ToString() == "การวางแผน"){
                                  s1 += "        " + data.Value.ToString();
                              }
                          }
                          BoardList.Add(s1);
                          s1 = "";
                      }
                  });
            ScoreTraining();
        }            
        else
        {
            return;
        }
    }

    public void SubmitTEST()
    {
        if (map.text == "1" || map.text == "2" || map.text == "3" || map.text == "4")
        {
            BoardList.Clear();
            foreach (var i in textItems)
            {
                Destroy(i);
            }

            FirebaseDatabase.DefaultInstance.GetReference(Login.PATH).Child("TEST").Child(map.text).GetValueAsync()
                  .ContinueWith(task =>
                  {
                      DataSnapshot snapshot = task.Result;
                      foreach (var child in snapshot.Children)
                      {
                          string s1 = "";
                          if (child.Key.ToString().Length == 2)
                              s1 += " " + child.Value.ToString();
                          else if (child.Key.ToString().Length == 3)
                              s1 += "" + child.Value.ToString();
                          else
                              s1 += ("  " + child.Key.ToString());
                          foreach (var data in child.Children)
                          {
                              if (data.Key.ToString() == "เวลา")
                              {
                                  if (data.Value.ToString().Length == 2)
                                      s1 += "                " + data.Value.ToString();
                                  else if (data.Value.ToString().Length == 3)
                                      s1 += "               " + data.Value.ToString();
                                  else
                                      s1 += "                 " + data.Value.ToString();
                              }
                              else if (data.Key.ToString() == "จำนวนสถานที่")
                              {
                                  if (data.Value.ToString().Length == 2)
                                      s1 += "               " + data.Value.ToString();
                                  else if (data.Value.ToString().Length == 3)
                                      s1 += "              " + data.Value.ToString();
                                  else
                                      s1 += "                " + data.Value.ToString();
                              }
                              else if (data.Key.ToString() == "จำนวนการไปผิดสถานที่")
                              {
                                  if (data.Value.ToString().Length == 2)
                                      s1 += "                  " + data.Value.ToString();
                                  else if (data.Value.ToString().Length == 3)
                                      s1 += "                 " + data.Value.ToString();
                                  else
                                      s1 += "                  " + data.Value.ToString();
                              }
                              else if (data.Key.ToString() == "จำนวนการใช้ตัวช่วย")
                              {
                                  if (data.Value.ToString().Length == 2)
                                      s1 += "         " + data.Value.ToString();
                                  else if (data.Value.ToString().Length == 3)
                                      s1 += "        " + data.Value.ToString();
                                  else
                                      s1 += "          " + data.Value.ToString();
                              }
                              else if (data.Key.ToString() == "การวางแผน")
                              {
                                  s1 += "        " + data.Value.ToString();
                              }
                          }
                          BoardList.Add(s1);
                          s1 = "";
                      }
                  });
            ScoreTraining();
        }
        else
        {
            return;
        }
    }
    private void ScoreTraining()
    {
        Invoke("LogText", 1f);

    }

    private void ScoreTest()
    {        
        Invoke("LogText", 1f);


    }
    public void Back()
    {
        SceneManager.LoadScene(2);
    }
}

  