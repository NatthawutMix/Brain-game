using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField User, Password, passAd;
    private string dataURL = "https://testloginfirebase-1eeee.firebaseio.com/";
    private DatabaseReference databaseReference;
    private bool check = true;
    public Text textAlert;
    public static string PATH,Pwd;

    public GameObject showLogin;

    public InputField start,t2;

    void Start()
    {
        start.Select();
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Disconnect");
        }
        else
        {
            FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(dataURL);
            databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        }

    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
    public void show()
    {
        showLogin.SetActive(true);
        t2.Select();
    }
    public void close()
    {
        showLogin.SetActive(false);
    }
    public void addmin()
    {
        
        string pass = databaseReference.Child("Unity").Child("password/kusrc").Key.ToString();
        if (passAd.text.ToString() == pass)
        {
            SceneManager.LoadScene(6);
        }
    }
    public void submit()
    {
        if (User.text == "" || Password.text == "")
        {
            User.text = "";
            Password.text = "";
            textAlert.text = "***กรุณาใส่ชื่อบัญชีผู้ใช้หรือรหัสผ่าน";
            return;
        }
        else if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("No internet");
            Pwd = Password.text;
            Invoke("upUser", 1f);
        }
        else
        {
            FirebaseDatabase.DefaultInstance.GetReference("Unity/").GetValueAsync()
              .ContinueWith(task => {
                  DataSnapshot snapshot = task.Result;
                  foreach (var child in snapshot.Children)
                  {
                      if (child.Key.ToString() == User.text)
                      {
                          foreach (var data in child.Children)
                          {
                              if (data.Key == "Password")
                              {
                                  if ( data.Value.ToString() != Password.text )
                                  {
                                     // print(data.Value + ">>" + Password.text + "false");
                                      check = false;
                                      return;
                                  }
                                  else
                                  {
                                      check = true;
                                      //print(data.Value + ">>" + Password.text + "True");
                                      return;
                                  }
                              }
                          }
                      }                      
                  }
                  check = false;
              });
        }
        Invoke("upUser", 1f);
    }

    private void upUser()
    {
        if (check)
        {
            StartGame();
        }
        else
        {
            textAlert.text = "***บัญชีหรือรหัสผ่านผิดพลาด";
            User.text = "";
            Password.text = "";
        }
    }

    public void StartGame()
    {
        PATH = "Unity/" + User.text;
        SceneManager.LoadScene(2);
    }

    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }
}
