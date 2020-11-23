using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Menu : MonoBehaviour
{
    public GameObject showExit;
    public Button start;
    public static string PATH;

    public InputField passAd;
    public GameObject showLogin, login;

    private List<string> listData;

    private int contTest;

    private string dataURL = "https://testloginfirebase-1eeee.firebaseio.com/";
    private DatabaseReference databaseReference;

    private void Start()
    {
        start.Select();
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(dataURL);
            databaseReference = FirebaseDatabase.DefaultInstance.RootReference;        
            /*FirebaseDatabase.DefaultInstance.GetReference(Login.PATH).Child(Menu.PATH).Child(Training.map.ToString()).GetValueAsync()
                 .ContinueWith(task =>
                 {
                     DataSnapshot snapshot = task.Result;
                     contTest = int.Parse((snapshot.ChildrenCount).ToString()) + 1;
                 });*/

            string readjson = File.ReadAllText(Application.dataPath + "/" + Login.PATH.ToString() + ".txt");
            mySave readData = JsonUtility.FromJson<mySave>(readjson);

            FirebaseDatabase.DefaultInstance.GetReference(readData.loginPath).Child(readData.menuPath).Child(readData.mapPath).GetValueAsync()
                 .ContinueWith(task =>
                 {
                     DataSnapshot snapshot = task.Result;
                     contTest = int.Parse((snapshot.ChildrenCount).ToString()) + 1;
                 });

            Invoke("save", 3f);
            
            Debug.Log("read txt file");
        }


    }
    public void addmin()
    {

        string pass = databaseReference.Child("Unity").Child("password/kusrc").Key.ToString();
        if (passAd.text.ToString() == pass)
        {
            PATH = "TEST";
            SceneManager.LoadScene(4);
        }
    }
    public void close()
    {
        showLogin.SetActive(false);
    }
    private void save()
    {
        string readjson = File.ReadAllText(Application.dataPath + "/" + Login.PATH.ToString() + ".txt");
        mySave readData = JsonUtility.FromJson<mySave>(readjson);
        databaseReference.Child(readData.loginPath).Child(readData.menuPath).Child(readData.mapPath).Child(contTest.ToString()).Child("การวางแผน").SetValueAsync(readData.Planning.ToString());
        databaseReference.Child(readData.loginPath).Child(readData.menuPath).Child(readData.mapPath).Child(contTest.ToString()).Child("จำนวนสถานที่").SetValueAsync(readData.countSuc.ToString());
        databaseReference.Child(readData.loginPath).Child(readData.menuPath).Child(readData.mapPath).Child(contTest.ToString()).Child("เวลา").SetValueAsync(readData.timeStart.ToString());
        databaseReference.Child(readData.loginPath).Child(readData.menuPath).Child(readData.mapPath).Child(contTest.ToString()).Child("จำนวนการไปผิดสถานที่").SetValueAsync(readData.countWrong.ToString());
        databaseReference.Child(readData.loginPath).Child(readData.menuPath).Child(readData.mapPath).Child(contTest.ToString()).Child("จำนวนการใช้ตัวช่วย").SetValueAsync(readData.countHelp.ToString());
        File.Delete(Application.dataPath + "/" + Login.PATH.ToString() + ".txt");
    }
    public void GoToTest()
    {
        showLogin.SetActive(true);
    }
    public void GoTotTraining()
    {
        PATH = "TRAINING";
        SceneManager.LoadScene(4);
    }
    public void GoToScore()
    {
        SceneManager.LoadScene(5);
    }

    public void GoToTutorial()
    {
        SceneManager.LoadScene(8);
    }

    public void Exit()
    {
        Application.Quit();
    }
    public void Back()
    {
        SceneManager.LoadScene(0);
    }

    public void hide()
    {
        showExit.SetActive(false);
    }

    public void show()
    {
        showExit.SetActive(true);
    }

    private class mySave
    {
        public string loginPath, menuPath, mapPath, pwd;
        public string Planning, countSuc, timeStart, countWrong, countHelp;
    }
}
