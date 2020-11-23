using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour
{
    public InputField User, Password;
    public GameObject alert,hide;
    public Text Wrong;
    private bool check = true;

    private string dataURL = "https://testloginfirebase-1eeee.firebaseio.com/";
    private DatabaseReference databaseReference;

    public InputField start;

    void Start()
    {
        start.Select();
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(dataURL);
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

    }
    public void submit()
    {
        if(User.text == "" || Password.text == "")
        {
            return;
        }
        else
        {
            FirebaseDatabase.DefaultInstance.GetReference("Unity/").GetValueAsync()
              .ContinueWith(task => {
                  DataSnapshot snapshot = task.Result;
                  foreach (var child in snapshot.Children)
                  {
                      if(child.Key.ToString() == User.text)
                      {
                          check = false;
                          return;
                      }
                  }
                  check = true;
              });            
        }
        Invoke("upUser", 1f);
    }
    private void upUser()
    {
        if (check)
        {
            databaseReference.Child("Unity/" + User.text).Child("Password").SetValueAsync(Password.text);
            Login.PATH= "Unity/" + User.text;
            SceneManager.LoadScene(2);     
        }
        else
        {
            Wrong.text = "***มีคนใช้ชื่อบัญชีนี้แล้ว";
            User.text = "";
            Password.text = "";
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
