using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
using UnityEngine.SceneManagement;

public class addmin : MonoBehaviour
{

    private string dataURL = "https://testloginfirebase-1eeee.firebaseio.com/";
    private DatabaseReference databaseReference;

    public InputField map, number;
    private bool del = false;

    ///Graph
    [SerializeField] private Sprite circleSprite;
    [SerializeField] private GameObject InputTextValue;

    public Text GraphText;

    private RectTransform graphContainer;
    private RectTransform labelTemplateX, labelTemplateY;
    private RectTransform TextValue;
    private List<GameObject> gameObjectsList;

    List<int> CountList = new List<int>();
    List<int> ScoreList = new List<int>();
    List<int> TimeList = new List<int>();
    List<int> WrongList = new List<int>();
    List<int> OpenList = new List<int>();
    List<int> PlanList = new List<int>();
    string User;

    private bool isCoroutineExecuting;

    public InputField start;
   
    IEnumerator ExecuteAfterTime(float time, Action task)
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        task();
        isCoroutineExecuting = false;
    } 

    public void GraphCount()
    {
        ShowGraph(CountList, -1);
        GraphText.text = "จำนวน/ครั้ง";
    }

    public void GraphTime()
    {
        ShowGraph(TimeList, -1);
        GraphText.text = "เวลา/วินาที";
    }

    public void GraphScore()
    {
        ShowGraph(ScoreList, -1);
        GraphText.text = "คะแนน";
    }

    public void GraphWrong()
    {
        ShowGraph(WrongList, -1);
        GraphText.text = "จำนวน/ครั้ง";
    }

    public void GraphOpen()
    {
        ShowGraph(OpenList, -1);
        GraphText.text = "จำนวน/ครั้ง";
    }

    public void PlanOpen()
    {
        ShowGraph(PlanList, -1);
        GraphText.text = "จำนวน/ครั้ง";
    }
    void Start()
    {
        start.Select();
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(dataURL);
        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        TextValue = graphContainer.Find("TextValue").GetComponent<RectTransform>();
        gameObjectsList = new List<GameObject>();
    }

    /////////////////////////////////////////////////////////////////

    private GameObject CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(10, 10);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);

        return gameObject;
    }

    private GameObject CreateText(Vector2 anchoredPosition, string Value)
    {
        GameObject TextGameObject = Instantiate(InputTextValue) as GameObject;
        TextGameObject.SetActive(true);
        TextGameObject.transform.SetParent(graphContainer, false);
        TextGameObject.GetComponent<Text>().text = Value;
        TextGameObject.GetComponent<Text>().fontSize = 20;
        TextGameObject.GetComponent<Text>().color = new Color(0, 0, 0);
        RectTransform TextRectTransform = TextGameObject.GetComponent<RectTransform>();
        TextRectTransform.anchoredPosition = anchoredPosition;
        TextRectTransform.sizeDelta = new Vector2(40, 40);
        TextRectTransform.anchorMin = new Vector2(0, 0);
        TextRectTransform.anchorMax = new Vector2(0, 0);

        return TextGameObject;
    }

    private void ShowGraph(List<int> valueList, int max = -1)
    {
        if (max <= 0)
        {
            max = valueList.Count;
        }

        foreach (GameObject i in gameObjectsList)
        {
            Destroy(i);
        }
        gameObjectsList.Clear();

        float graphWidth = graphContainer.sizeDelta.x;
        float graphHeight = graphContainer.sizeDelta.y;

        float xSize = graphWidth / max - 1;

        float yMaximum = (valueList[0]);
        float yMinimum = (valueList[0]);

        for (int i = Mathf.Max(valueList.Count - max, 0); i < valueList.Count; i++)
        {
            int value = (valueList[i]);
            if (value > yMaximum)
            {
                yMaximum = value;
            }
            if (value < yMinimum)
            {
                yMinimum = value;
            }
        }
        yMinimum = 0f;

        GameObject lastCircleGameObject = null;
        int xIndex = 0;
        for (int i = Mathf.Max(valueList.Count - max, 0); i < valueList.Count; i++)
        {
            float xPosition = (xSize + xIndex + i * xSize);
            float yPosition = (((valueList[i]) - yMinimum) / (yMaximum - yMinimum)) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            gameObjectsList.Add(circleGameObject);

            GameObject TextObject = CreateText(new Vector2(xPosition + 20f, yPosition + 10f), valueList[i].ToString());
            gameObjectsList.Add(TextObject);

            if (lastCircleGameObject != null)
            {
                GameObject dotConnect = CreateDotConnetion(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
                gameObjectsList.Add(dotConnect);
            }
            lastCircleGameObject = circleGameObject;

            RectTransform labelX = Instantiate(labelTemplateX);
            labelX.SetParent(graphContainer, false);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(xPosition, -10f);
            labelX.GetComponent<Text>().text = (i+1).ToString();
            gameObjectsList.Add(labelX.gameObject);

            xIndex++;
        }

        for (int i = 0; i <= valueList.Count; i++)
        {
            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer, false);
            labelY.gameObject.SetActive(true);
            float nomalizedValue = i * 1f / valueList.Count;
            labelY.anchoredPosition = new Vector2(-20f, nomalizedValue * graphHeight);
            labelY.GetComponent<Text>().text = Mathf.RoundToInt(yMinimum + (nomalizedValue * (yMaximum - yMinimum))).ToString();
            gameObjectsList.Add(labelY.gameObject);

        }
    }

    private GameObject CreateDotConnetion(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dontConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(0, 0, 0);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(dir));
        return gameObject;
    }

    private float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

    /////////////////////////////////////////////////////    


    public void SubmitTraining()
    {
        User = "Unity/" + number.text;
        if (map.text == "1" || map.text == "2" || map.text == "3" || map.text == "4")
        {
            CountList.Clear();
            ScoreList.Clear();
            TimeList.Clear();
            OpenList.Clear();
            WrongList.Clear();

            FirebaseDatabase.DefaultInstance.GetReference(User).Child("TRAINING").Child(map.text).GetValueAsync()
                  .ContinueWith(task =>
                  {
                      DataSnapshot snapshot = task.Result;
                      foreach (var child in snapshot.Children)
                      {
                          foreach (var data in child.Children)
                          {
                              if (data.Key.ToString() == "เวลา")
                              {
                                  TimeList.Add(int.Parse(data.Value.ToString()));
                              }
                              else if (data.Key.ToString() == "คะแนน")
                              {
                                  ScoreList.Add(int.Parse(data.Value.ToString()));
                              }
                              else if (data.Key.ToString() == "จำนวนสถานที่")
                              {
                                  CountList.Add(int.Parse(data.Value.ToString()));
                              }
                              else if (data.Key.ToString() == "จำนวนการไปผิดสถานที่")
                              {
                                  WrongList.Add(int.Parse(data.Value.ToString()));
                              }
                              else if (data.Key.ToString() == "จำนวนการใช้ตัวช่วย")
                              {
                                  OpenList.Add(int.Parse(data.Value.ToString()));
                              }
                              else if (data.Key.ToString() == "การวางแผน")
                              {
                                  PlanList.Add(int.Parse(data.Value.ToString()));
                              }
                          }

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
        User = "Unity/" + number.text;
        if (map.text == "1" || map.text == "2" || map.text == "3" || map.text == "4")
        {
            CountList.Clear();
            ScoreList.Clear();
            TimeList.Clear();
            OpenList.Clear();
            WrongList.Clear();

            FirebaseDatabase.DefaultInstance.GetReference(User).Child("TEST").Child(map.text).GetValueAsync()
                  .ContinueWith(task =>
                  {
                      DataSnapshot snapshot = task.Result;
                      foreach (var child in snapshot.Children)
                      {
                          foreach (var data in child.Children)
                          {
                              if (data.Key.ToString() == "เวลา")
                              {
                                  TimeList.Add(int.Parse(data.Value.ToString()));
                              }
                              else if (data.Key.ToString() == "คะแนน")
                              {
                                  ScoreList.Add(int.Parse(data.Value.ToString()));
                              }
                              else if (data.Key.ToString() == "จำนวนสถานที่")
                              {
                                  CountList.Add(int.Parse(data.Value.ToString()));
                              }
                              else if (data.Key.ToString() == "จำนวนการไปผิดสถานที่")
                              {
                                  WrongList.Add(int.Parse(data.Value.ToString()));
                              }
                              else if (data.Key.ToString() == "จำนวนการใช้ตัวช่วย")
                              {
                                  OpenList.Add(int.Parse(data.Value.ToString()));
                              }
                              else if (data.Key.ToString() == "การวางแผน")
                              {
                                  PlanList.Add(int.Parse(data.Value.ToString()));
                              }
                          }

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

        StartCoroutine(ExecuteAfterTime(4f, () =>
        {
            ShowGraph(TimeList, -1);
            GraphText.text = "เวลา/วินาที";
        }));
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}

