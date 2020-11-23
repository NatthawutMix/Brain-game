using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameSet : MonoBehaviour
{
    //1=ภูเขา
    //2=โรงพยาบาล
    //3=ร้านกาแฟ
    //4=อพาท
    //5=รร
    //6=บ้านเพื่อน
    //7=ตลาด
    //8=ร้านอาหาร

    public static int myMap = 5;
    public static int C = 8;
    public static int[] SpawnWarp = new int[8];
    public static int IndexSpawn;
    public static float startTime;
    public static int countWrong = 0;
    public static int EndGame = 0;
    public static int countCommand = 0;
    public static int countPath = 0;
    public static int countMap = 0;

    public Text TextCountObject;
    public Text scoreText;

    List<int> resIndex = new List<int>();
    public static List<int> result = new List<int>();
    List<int> placeStart = new List<int> { 3, 7, 8, 4, 1, 2, 5, 6 };
    List<int> place1 = new List<int> { 8, 4, 7, 3, 6, 5, 2 };
    List<int> place2 = new List<int> { 8, 3, 7, 6, 5, 4, 1 };
    List<int> place3 = new List<int> { 7, 2, 8, 6, 4, 5, 1 };
    List<int> place4 = new List<int> { 6, 7, 8, 1, 3, 5, 2 };
    List<int> place5 = new List<int> { 7, 3, 6, 2, 8, 4, 1 };
    List<int> place6 = new List<int> { 7, 4, 3, 5, 2, 8, 1 };
    List<int> place7 = new List<int> { 3, 6, 4, 5, 2, 8, 1 };
    List<int> place8 = new List<int> { 4, 2, 5, 3, 8, 6, 7 };

    List<int> Check = new List<int> ();

    int next = 0;
    int a = 0;

    void Start()
    {
        int a = 0;
        int yet = 0;        
        EndGame = 0;
        Timer.score = 0;
        countWrong = 0;
        countCommand = 0;
        countPath = 0;
        countMap = 0;

        for (int i = 0; i < SpawnWarp.Length; i++)
        {
            SpawnWarp[i] = -1;
        }

        while (a < C)
        {
            IndexSpawn = Random.Range(1, SpawnWarp.Length + 1);
            for (int i = 0; i < SpawnWarp.Length; i++)
            {
                if (IndexSpawn == SpawnWarp[i])
                {
                    yet = 1;
                    break;
                }
            }
            if (yet == 0)
            {
                SpawnWarp[a] = IndexSpawn;
                a++;
            }
            yet = 0;
        }
        for (int i = 0; i < myMap; i++)
        {
            if (SpawnWarp[i] == 1)
            {
                SpawnHill.Number1 = 1;
            }

            else if (SpawnWarp[i] == 2)
            {
                SpawnHospital.Number2 = 1;
            }
            else if (SpawnWarp[i] == 3)
            {
                SpawnCoffe.Number3 = 1;
            }

            else if (SpawnWarp[i] == 4)
            {
                SpawnAmp.Number4 = 1;
            }

            else if (SpawnWarp[i] == 5)
            {
                SpawnSchool.Number5 = 1;
            }
            else if (SpawnWarp[i] == 6)
            {
                SpawnHome.Number6 = 1;
            }
            else if (SpawnWarp[i] == 7)
            {
                SpawnMarket.Number7 = 1;
            }
            else if (SpawnWarp[i] == 8)
            {
                SpawnRes.Number8 = 1;
            }
            Check.Add(SpawnWarp[i]);
        }        

        ShortestPath();
                
        
    }

    // Update is called once per frame
    void Update()
    {
        string TextEnd = EndGame.ToString("f0");
        TextCountObject.text = TextEnd;

        string TextScore = Timer.score.ToString("f0");
        scoreText.text = TextScore;
        
    }
    void ShortestPath()
    {        
        while (a!=5)
        {            
            if (next == 0)
            {
                for (int i = 0; i < Check.Count; i++){
                    for(int j = 0; j < placeStart.Count; j++){
                        if(Check[i] == placeStart[j])
                        {
                            resIndex.Add(j);
                        }
                    }
                }
                int min = resIndex.IndexOf(resIndex.Min());
                result.Add(Check[min]);
                next = Check[min];
                Check.RemoveAt(min);
                a++;
                resIndex.Clear();

            }
            else if (next == 1)
            {
                for (int i = 0; i < Check.Count; i++)
                {
                    for (int j = 0; j < place1.Count; j++)
                    {
                        if (Check[i] == place1[j])
                        {
                            resIndex.Add(j);
                        }
                    }
                }
                int min = resIndex.IndexOf(resIndex.Min());
                result.Add(Check[min]);
                next = Check[min];
                Check.RemoveAt(min);
                a++;
                resIndex.Clear();
            }
            else if (next == 2)
            {
                for (int i = 0; i < Check.Count; i++)
                {
                    for (int j = 0; j < place2.Count; j++)
                    {
                        if (Check[i] == place2[j])
                        {
                            resIndex.Add(j);
                        }
                    }
                }
                int min = resIndex.IndexOf(resIndex.Min());
                result.Add(Check[min]);
                next = Check[min];
                Check.RemoveAt(min);
                a++;
                resIndex.Clear();
            }
            else if(next == 3)
            {
                for (int i = 0; i < Check.Count; i++)
                {
                    for (int j = 0; j < place3.Count; j++)
                    {
                        if (Check[i] == place3[j])
                        {
                            resIndex.Add(j);
                        }
                    }
                }
                int min = resIndex.IndexOf(resIndex.Min());
                result.Add(Check[min]);
                next = Check[min];
                Check.RemoveAt(min);
                a++;
                resIndex.Clear();
            }
            else if (next == 4)
            { 
                for (int i = 0; i < Check.Count; i++)
                {
                    for (int j = 0; j < place4.Count; j++)
                    {
                        if (Check[i] == place4[j])
                        {
                            resIndex.Add(j);
                        }
                    }
                }
                int min = resIndex.IndexOf(resIndex.Min());
                result.Add(Check[min]);
                next = Check[min];
                Check.RemoveAt(min);
                a++;
                resIndex.Clear();
            }
            else if (next == 5)
            {
                for (int i = 0; i < Check.Count; i++)
                {
                    for (int j = 0; j < place5.Count; j++)
                    {
                        if (Check[i] == place5[j])
                        {
                            resIndex.Add(j);
                        }
                    }
                }
                int min = resIndex.IndexOf(resIndex.Min());
                result.Add(Check[min]);
                next = Check[min];
                Check.RemoveAt(min);
                a++;
                resIndex.Clear();
            }
            else if (next == 6)
            {
                for (int i = 0; i < Check.Count; i++)
                {
                    for (int j = 0; j < place6.Count; j++)
                    {
                        if (Check[i] == place6[j])
                        {
                            resIndex.Add(j);
                        }
                    }
                }
                int min = resIndex.IndexOf(resIndex.Min());
                result.Add(Check[min]);
                next = Check[min];
                Check.RemoveAt(min);
                a++;
                resIndex.Clear();
            }
            else if (next == 7)
            {
                for (int i = 0; i < Check.Count; i++)
                {
                    for (int j = 0; j < place7.Count; j++)
                    {
                        if (Check[i] == place7[j])
                        {
                            resIndex.Add(j);
                        }
                    }
                }
                int min = resIndex.IndexOf(resIndex.Min());
                result.Add(Check[min]);
                next = Check[min];
                Check.RemoveAt(min);
                a++;
                resIndex.Clear();
            }
            else if (next == 8)
            {
                for (int i = 0; i < Check.Count; i++)
                {
                    for (int j = 0; j < place8.Count; j++)
                    {
                        if (Check[i] == place8[j])
                        {
                            resIndex.Add(j);
                        }
                    }
                }
                int min = resIndex.IndexOf(resIndex.Min());
                result.Add(Check[min]);
                next = Check[min];
                Check.RemoveAt(min);
                a++;
                resIndex.Clear();
            }
        }
    }
    
}
