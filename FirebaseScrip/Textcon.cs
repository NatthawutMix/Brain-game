using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.SceneManagement;

public class Textcon : MonoBehaviour
{
    private string dataURL = "https://testloginfirebase-1eeee.firebaseio.com/";
    private DatabaseReference databaseReference;

    [SerializeField] public GameObject textTemp;
    private List<GameObject> textItems;

    ArrayList BoardList;

    public InputField myName;

    ArrayList TestList;
    public Text TestText;

    private bool del = false;
    private void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(dataURL);
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        BoardList = new ArrayList();
        TestList = new ArrayList();
        textItems = new List<GameObject>(); 

    }
     
    private void LogText()
    {   
        foreach (string i in BoardList)
        {
            GameObject newText = Instantiate(textTemp) as GameObject;
            newText.SetActive(true);
            newText.GetComponent<Text>().text = i;
            newText.transform.SetParent(textTemp.transform.parent, false);
            textItems.Add(newText.gameObject);
        }        
    }

    public void Genarate()
    {
        if (myName.text == "")
        {
            return;
        }
        FirebaseDatabase.DefaultInstance.GetReference("Unity/"+ myName.text).GetValueAsync()
              .ContinueWith(task => {
                  DataSnapshot snapshot = task.Result;                 
                  foreach (var child in snapshot.Children)
                  {
                      TestList.Add("ครั้งที่่ทดสอบ: " + child.Key.ToString());
                      foreach (var data in child.Children)
                      {
                          TestList.Add(data.Key.ToString() +": "+ data.Value.ToString());                 
                      }
                      TestList.Add("--------------------");
                  }
              });
        if (del)
        {
            TestList.Clear();
            TestText.text = "";
            del = false;
        }
        del = true;
        Invoke("UpdateScoreTest", 1f);
    }

    private void UpdateScoreTest()
    {
        foreach (string i in TestList)
        {
            TestText.text += "\n" + i;
        }
    }

    public void listName()
    {
        BoardList.Clear();
        foreach(var i in textItems)
        {
            Destroy(i);
        }

        FirebaseDatabase.DefaultInstance.GetReference("Unity").GetValueAsync()
              .ContinueWith(task => {
                  DataSnapshot snapshot = task.Result;              
                  foreach (var child in snapshot.Children)
                  {
                      BoardList.Add(child.Key.ToString() + " จำนวนครั้งที่ทดสอบ: " + child.ChildrenCount);
                  }
              });

        Invoke("LogText", 1f);
    }
    public void clickHere()
    {        
        listName();
    }
    public void StaticToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
