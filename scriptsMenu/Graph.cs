using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Graph : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    [SerializeField] private GameObject InputTextValue;

    private RectTransform graphContainer;
    private RectTransform labelTemplateX, labelTemplateY;
    private RectTransform deshTemplateX;
    private RectTransform deshTemplateY;
    private RectTransform TextValue;
    private List<GameObject> gameObjectsList;
    

    List<int> valueList = new List<int>();

    private bool isCoroutineExecuting;

    IEnumerator ExecuteAfterTime(float time, Action task)
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        task();
        isCoroutineExecuting = false;
    }

    private void Awake()
    {
        List<int> valueList = new List<int>() { 5, 98, 56, 45, 30, 22, 17, 15, 13, 17, 25, 37, 40, 36, 33 };

        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        deshTemplateX = graphContainer.Find("deshTemplateX").GetComponent<RectTransform>();
        deshTemplateY = graphContainer.Find("deshTemplateY").GetComponent<RectTransform>();
        TextValue = graphContainer.Find("TextValue").GetComponent<RectTransform>();

        gameObjectsList = new List<GameObject>();

        StartCoroutine(ExecuteAfterTime(2f, () =>
        {
            ShowGraph(valueList, -1, (int _i) => "Day" + (_i + 1));
        }));
        

    }

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
        TextGameObject.GetComponent<Text>().color = new Color(0, 1, 0);
        RectTransform TextRectTransform = TextGameObject.GetComponent<RectTransform>();
        TextRectTransform.anchoredPosition = anchoredPosition;
        TextRectTransform.sizeDelta = new Vector2(40, 40);
        TextRectTransform.anchorMin = new Vector2(0, 0);
        TextRectTransform.anchorMax = new Vector2(0, 0);

        return TextGameObject;
    }

    private void ShowGraph(List<int> valueList, int max = -1, Func<int, string> getAxisLabelX = null, Func<float, string> getAxisLabelY = null)
    {
        if (getAxisLabelX == null)
        {
            getAxisLabelX = delegate (int _i) { return _i.ToString(); };
        }
        if(getAxisLabelY == null)
        {
            getAxisLabelY = delegate (float _f) { return Mathf.RoundToInt(_f).ToString(); };
        }

        if(max <= 0)
        {
            max = valueList.Count;
        }

        foreach(GameObject i in gameObjectsList)
        {
            Destroy(i);
        }
        gameObjectsList.Clear();

        float graphWidth = graphContainer.sizeDelta.x;
        float graphHeight = graphContainer.sizeDelta.y;

        float xSize = graphWidth / max -2;

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

            GameObject TextObject = CreateText(new Vector2(xPosition + 20f, yPosition+ 10f), valueList[i].ToString());
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
            labelX.anchoredPosition = new Vector2(xPosition, -2f);
            labelX.GetComponent<Text>().text = getAxisLabelX(i);
            gameObjectsList.Add(labelX.gameObject);

            RectTransform deshX = Instantiate(deshTemplateX);
            deshX.SetParent(graphContainer, false);
            deshX.gameObject.SetActive(true);
            deshX.anchoredPosition = new Vector2(xPosition, 250f);
            gameObjectsList.Add(deshX.gameObject);
            xIndex++;
        }

       // int separatorCount = 10;
        for(int i = 0; i <= valueList.Count; i++)
        {
            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer, false);
            labelY.gameObject.SetActive(true);
            float nomalizedValue = i * 1f / valueList.Count;
            labelY.anchoredPosition = new Vector2(-3f, nomalizedValue * graphHeight);
            labelY.GetComponent<Text>().text = getAxisLabelY(yMinimum + (nomalizedValue * (yMaximum - yMinimum)));
            gameObjectsList.Add(labelY.gameObject);

            RectTransform deshY = Instantiate(deshTemplateY);
            deshY.SetParent(graphContainer, false);
            deshY.gameObject.SetActive(true);
            deshY.anchoredPosition = new Vector2(-3F, (nomalizedValue * graphHeight)-250f);
            gameObjectsList.Add(deshY.gameObject);
        }
    }

    private GameObject CreateDotConnetion(Vector2 dotPositionA,Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dontConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1, 0, 0, .5f);
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
}
