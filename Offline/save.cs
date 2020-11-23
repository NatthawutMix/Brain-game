using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using System.Threading;
using System.Threading.Tasks;


public class save : MonoBehaviour
{
    public string loginPath, menuPath, mapPath;
    public string Planning, countSuc, timeStart, countWrong, countHelp;
    private string dataURL = "https://testloginfirebase-1eeee.firebaseio.com/";
    private DatabaseReference databaseReference;

    public List<string> listData;

    private int c;
    int countChild;
    private void Start()
    {

        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(dataURL);
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        mySave mySave = new mySave();
        mySave.loginPath = "loginPath";
        mySave.mapPath = "mapPath";
        mySave.menuPath = "menuPath";
        mySave.Planning = "Planning";
        mySave.countHelp = "countHelp";
        mySave.countSuc = "countSuc";
        mySave.countWrong = "countWrong";
        mySave.timeStart = "1234";

        string json = JsonUtility.ToJson(mySave);
        //File.AppendAllText(Application.dataPath + "/" + A.ToString() + ".json", json);

        /*string readjson = File.ReadAllText(Application.dataPath + "/savefile.json");
        string[] data = readjson.Split(new[] { '}', });

        foreach (var i in data)
            Debug.Log(i);*/
        //mySave readData = JsonUtility.FromJson<mySave>(readjson);
    }

    private void Update()
    {         
            
    }
    private class mySave{
           public string loginPath, menuPath, mapPath;
           public string Planning, countSuc, timeStart, countWrong, countHelp; 
    }
}   
