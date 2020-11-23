using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testgrr : MonoBehaviour
{
    [SerializeField] private Sprite circle;
    private RectTransform graphCon;
    private RectTransform labx;
    private RectTransform laby;
    private RectTransform desx;
    private RectTransform desy;

    private List<GameObject> gameObjectsList;

    private void Awake()
    {
        graphCon = transform.Find("graphCon").GetComponent<RectTransform>();
        labx = graphCon.Find("labx").GetComponent<RectTransform>();
        laby = graphCon.Find("laby").GetComponent<RectTransform>();
        desx = graphCon.Find("desx").GetComponent<RectTransform>();
        desy = graphCon.Find("desy").GetComponent<RectTransform>();

        //List<int> val = new List<int>() { 5, 98, 56, 45, 30, 22, 17, 15, 13, 17, 25, 37, 40, 36, 33 };
        List<int> val = new List<int>() { 5, 6, 7, 8, 9 };
        show(val);
    }
    private GameObject CreateCircle(Vector2 anc)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphCon, false);
        gameObject.GetComponent<Image>().sprite = circle;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anc;
        rectTransform.sizeDelta = new Vector2(10, 10);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    private void show(List<int> val)
    {
        float graphWidth = graphCon.sizeDelta.x;
        float gH = graphCon.sizeDelta.y;
        float yMaximum = (val[0]);
        float yMinimum = (val[0]);

        for (int i = Mathf.Max(val.Count - -1, 0); i < val.Count; i++)
        {
            int value = (val[i]);
            if (value > yMaximum)
            {
                yMaximum = value;
            }
            if (value < yMinimum)
            {
                yMinimum = value;
            }
        }

        float yDifference = yMaximum - yMinimum;
        if (yDifference <= 0)
        {
            yDifference = 5f;
        }
        yMaximum = yMaximum + (yDifference * 0.2f);
        yMinimum = yMinimum - (yDifference * 0.2f);
        yMinimum = 0f;
        float xS = graphWidth / val.Count - 2;

        //int xIndex = 0;
        GameObject lastCircleGameObject = null;
        for (int i = 0; i < val.Count; i++)
        {
            float xP = xS + i * xS;
            float yP = (val[i] / yMaximum) * gH;
            GameObject circleGameObject = CreateCircle(new Vector2(xP, yP));
            //gameObjectsList.Add(circleGameObject);
            if (lastCircleGameObject != null)
            {
                CreateDotConnetion(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameObject = circleGameObject;

            RectTransform labelX = Instantiate(labx);
            labelX.SetParent(graphCon, false);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(xP, -7f);
            labelX.GetComponent<Text>().text = i.ToString();

            RectTransform deshX = Instantiate(desx);
            deshX.SetParent(graphCon, false);
            deshX.gameObject.SetActive(true);
            deshX.anchoredPosition = new Vector2(xP, -7f);
            //gameObjectsList.Add(deshX.gameObject);
            //xIndex++;
            //gameObjectsList.Add(labelX.gameObject);
        }
        for (int i = 0; i <= val.Count; i++)
        {
            RectTransform labelY = Instantiate(laby);
            labelY.SetParent(graphCon, false);
            labelY.gameObject.SetActive(true);
            float nomalizedValue = i * 1f / val.Count;
            labelY.anchoredPosition = new Vector2(-7f, nomalizedValue * gH);
            labelY.GetComponent<Text>().text = Mathf.RoundToInt(nomalizedValue * yMaximum).ToString();

            RectTransform deshY = Instantiate(desy);
            deshY.SetParent(graphCon, false);
            deshY.gameObject.SetActive(true);
            deshY.anchoredPosition = new Vector2(-7f, nomalizedValue * gH);
            //gameObjectsList.Add(labelY.gameObject);
        }
    }

    private void CreateDotConnetion(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dontConnection", typeof(Image));
        gameObject.transform.SetParent(graphCon, false);
        gameObject.GetComponent<Image>().color = new Color(1, 0, 0, .5f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(dir));

        
        //return gameObject;
    }
    private float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }
}
