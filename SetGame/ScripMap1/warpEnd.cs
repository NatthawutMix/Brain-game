using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.SceneManagement;
using System.IO;

public class warpEnd : MonoBehaviour
{

    private int contTest;
    public GameObject showScore, blackScreen;

    private string dataURL = "https://testloginfirebase-1eeee.firebaseio.com/";
    private DatabaseReference databaseReference;
    void Start()
    {
        if (Application.internetReachability != NetworkReachability.NotReachable)
        {
            FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(dataURL);
            databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        }         
    }
    void Update()
    {
        if(Application.internetReachability != NetworkReachability.NotReachable)
        {
            FirebaseDatabase.DefaultInstance.GetReference(Login.PATH).Child(Menu.PATH).Child(Training.map.ToString()).GetValueAsync()
                 .ContinueWith(task =>
                 {
                     DataSnapshot snapshot = task.Result;
                     contTest = int.Parse((snapshot.ChildrenCount).ToString()) + 1;
                 });
        }      
    }
    private void OnTriggerEnter(Collider other)
    {
        /*if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            if (other.tag == "Player")
            {
                Timer.finnished = true;
                mySave saveData = new mySave();
                saveData.loginPath = Login.PATH.ToString();
                saveData.mapPath = Training.map.ToString();
                saveData.menuPath = Menu.PATH.ToString();
                saveData.Planning = NewStartGame.Planning.ToString();
                saveData.countHelp = Timer.countHelp.ToString();
                saveData.countSuc = Timer.countSuc.ToString();
                saveData.countWrong = Timer.countWrong.ToString();
                saveData.timeStart = Timer.timeStart.ToString("f0");

                string json = JsonUtility.ToJson(saveData);
                File.AppendAllText(Application.dataPath + "/" + Login.PATH.ToString() + ".json", json);

                this.gameObject.SetActive(false);
            }
        }
        else if (Application.internetReachability != NetworkReachability.NotReachable)
        {*/
            if (other.tag == "Player")
            {
                Timer.finnished = true;
                if(Application.internetReachability == NetworkReachability.NotReachable)
                {
                    mySave saveData = new mySave();
                    saveData.loginPath = Login.PATH.ToString();
                    saveData.pwd = Login.Pwd.ToString();
                    saveData.mapPath = Training.map.ToString();
                    saveData.menuPath = Menu.PATH.ToString();
                    saveData.Planning = NewGameSet.Planning.ToString();
                    saveData.countHelp = Timer.countHelp.ToString();
                    saveData.countSuc = Timer.countSuc.ToString();
                    saveData.countWrong = Timer.countWrong.ToString();
                    saveData.timeStart = Timer.timeStart.ToString("f0");

                    string json = JsonUtility.ToJson(saveData);
                    File.WriteAllText(Application.dataPath + "/" + Login.PATH.ToString() + ".txt", json);
                    Debug.Log("Add to Local");
                }
                else
                {
                    databaseReference.Child(Login.PATH).Child(Menu.PATH).Child(Training.map.ToString()).Child(contTest.ToString()).Child("การวางแผน").SetValueAsync(NewGameSet.Planning);
                    databaseReference.Child(Login.PATH).Child(Menu.PATH).Child(Training.map.ToString()).Child(contTest.ToString()).Child("จำนวนสถานที่").SetValueAsync(Timer.countSuc);
                    databaseReference.Child(Login.PATH).Child(Menu.PATH).Child(Training.map.ToString()).Child(contTest.ToString()).Child("เวลา").SetValueAsync(Timer.timeStart.ToString("f0"));
                    databaseReference.Child(Login.PATH).Child(Menu.PATH).Child(Training.map.ToString()).Child(contTest.ToString()).Child("จำนวนการไปผิดสถานที่").SetValueAsync(Timer.countWrong);
                    databaseReference.Child(Login.PATH).Child(Menu.PATH).Child(Training.map.ToString()).Child(contTest.ToString()).Child("จำนวนการใช้ตัวช่วย").SetValueAsync(Timer.countHelp);
                    Debug.Log("Add to firebase");
                }              

                showScore.SetActive(true);
                blackScreen.SetActive(true);
                this.gameObject.SetActive(false);
            }
        //}
        
    }
    public void ExitGame()
    {
        SceneManager.LoadScene(2);
    }
    private class mySave
    {
        public string loginPath, menuPath, mapPath,pwd;
        public string Planning, countSuc, timeStart, countWrong, countHelp;
    }
}
