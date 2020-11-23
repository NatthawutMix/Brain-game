using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.SceneManagement;

public class Database : MonoBehaviour
{
    public InputField Username,count;
    private string dataURL = "https://testloginfirebase-1eeee.firebaseio.com/";
    private DatabaseReference databaseReference;
    
    private string contTest;

    private void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(dataURL);
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;
        
    }
    private void Update()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Unity/" + Username.text).GetValueAsync()
                .ContinueWith(task =>
                {
                    DataSnapshot snapshot = task.Result;
                    contTest = (snapshot.ChildrenCount + 1).ToString();
                });
    }
    public void Submit()
    {   

        if (Username.text == "")
        {
            return;
        }
        databaseReference.Child("Unity/" + Username.text).Child(contTest).Child("ระยะที่เดิน").SetValueAsync(Timer.score);
        databaseReference.Child("Unity/" + Username.text).Child(contTest).Child("จำนวนสถานที่").SetValueAsync(GameSet.EndGame);
        databaseReference.Child("Unity/" + Username.text).Child(contTest).Child("เวลา").SetValueAsync(Timer.countTime);
        databaseReference.Child("Unity/" + Username.text).Child(contTest).Child("จำนวนการไปผิดสถานที่").SetValueAsync(GameSet.countWrong);
        databaseReference.Child("Unity/" + Username.text).Child(contTest).Child("จำนวนการเปิดดูคำสั่ง").SetValueAsync(GameSet.countCommand);
       
        SceneManager.LoadScene(0);
    }
}
