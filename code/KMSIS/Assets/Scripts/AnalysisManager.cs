using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AnalysisManager : MonoBehaviour
{
    // This class manages analysis for the information of sunlight.

    // Manager component
    private RayManager rayManager;
    private SunManager sunManager;
    private UIManager uiManager;

    // GameObject component
    private GameObject pointPrefab;
    private GameObject analysisPoints;

    // Material component
    public Material selectMaterial;
    public Material normalMaterial;
    public Material pointMaterial;

    // GameObject variable
    private List<GameObject> pointList;
    private List<GameObject> selectedPointList;
    private List<GameObject> optimizedPointList;
    public GameObject targetBuilding;

    // Time variable
    private int[] dayForMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

    // Variable
    private float radius = 0.01f;
    private int month, day;
    private float clock;
    private List<double> timeInfo;
    private int[] result;
    private int max, average, currentDay;
    private int startYear, startMonth, startDay, startHour, startMinute, endYear, endMonth, endDay, endHour, endMinute;

    void Start()
    {
        // Get manager component
        rayManager = GameObject.Find("RayManager").GetComponent<RayManager>();
        sunManager = GameObject.Find("SunManager").GetComponent<SunManager>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();

        // Get gameObject component
        pointPrefab = GameObject.Find("PointPrefab");
        analysisPoints = GameObject.Find("AnalysisPoints");

        // Initialize variable
        pointList = new List<GameObject>();
        selectedPointList = new List<GameObject>();
    }

    // Check if current state is analysis mode or not
    public bool IsAnalyzing()
    {
        return pointList.Count != 0;
    }

    // Initialize AnalysisManager
    public void Init(GameObject building)
    {
        targetBuilding = building;
        building.GetComponent<MeshRenderer>().material = pointMaterial;
        List<RaycastHit> hitPointList = rayManager.GetPointOnObject(building);
        InstantiateObject(hitPointList);
    }

    // Release AnalysisManager
    public void Release()
    {
        targetBuilding.GetComponent<MeshRenderer>().material = normalMaterial;
        DestroyObject();
        selectedPointList.Clear();
        pointList.Clear();
    }

    // Check environment and estimate execution time
    public float EstimateTime()
    {
        int month = 8, day = 8;
        float startTime = Time.realtimeSinceStartup;
        for (float clock = 0f; clock < 24f; clock += 24f / 1440f)
        {
            List<double> tempList = sunManager.Calculate(month, day, clock);
            if (rayManager.CheckSunlight(pointList[0], sunManager.CalculateSunVector(-tempList[0], tempList[1]))) continue;
        }
        return (Time.realtimeSinceStartup - startTime);
    }

    // Optimize points
    private List<GameObject> OptimizePoints(List<GameObject> pointList)
    {
        if (pointList.Count < 200) return pointList;

        int[] tempList = new int[pointList.Count];
        for (int i = 0; i < tempList.Length; i++)
        {
            tempList[i] = 0;
        }
        System.Random rand = new System.Random();
        int count = 0;
        while (count < 200)
        {
            int index = rand.Next(0, pointList.Count);
            if (tempList[index] != 0) continue;
            else
            {
                tempList[index] = 1;
                count++;
            }
        }
        List<GameObject> optimizedPointList = new List<GameObject>();
        for (int i = 0; i < tempList.Length; i++)
        {
            if (tempList[i] == 1)
            {
                optimizedPointList.Add(pointList[i]);
            }
        }
        return optimizedPointList;
    }

    // Coroutine
    IEnumerator InitializeCoroutine()
    {
        for (float clock = (float)timeInfo[2]; clock < (float)timeInfo[3]; clock += 24f / 1440f)
        {
            List<double> tempList = sunManager.Calculate(month, day, clock);
            for (int i = 0; i < pointList.Count; i++)
            {
                if (rayManager.CheckSunlight(pointList[i], sunManager.CalculateSunVector(-tempList[0], tempList[1]))) result[i]++;
            }
            int percentage = (int)(((clock - (float)timeInfo[2]) / ((float)timeInfo[3] - (float)timeInfo[2])) * 100);
            uiManager.UpdateProgress(percentage);
            yield return null;
        }

        average = 0;
        max = 0;
        for (int i = 0; i < result.Length; i++)
        {
            if (max < result[i]) max = result[i];
            average += result[i];
        }
        average = average / result.Length;
        for (int i = 0; i < pointList.Count; i++)
        {
            pointList[i].layer = 0;
        }

        List<int> resultList = new List<int>();
        resultList.Add(average);
        resultList.Add(max);
        uiManager.UpdateSunlightPanel(resultList);
    }

    // Analyze the sunlight of the building
    public void AnalyzeBuilding()
    {
        if (pointList.Count < 1)
        {
            Debug.Log("Error");
        }
        else
        {
            for (int i = 0; i < pointList.Count; i++)
            {
                pointList[i].layer = 2;
            }

            List<float> dayInfo = uiManager.GetTimeValue();
            if (dayInfo != null)
            {
                month = (int)(dayInfo[0]);
                day = (int)(dayInfo[1]);
                timeInfo = sunManager.Calculate(month, day, 12f);

                result = new int[pointList.Count];
                for (int i = 0; i < result.Length; i++)
                {
                    result[i] = 0;
                }

                StartCoroutine("InitializeCoroutine");
            }
        }
    }

    // Coroutine
    IEnumerator AnalyzeCoroutine()
    {
        for (int year = startYear; year <= endYear; year++)
        {
            int month = 0;
            if (year == startYear) month = startMonth;
            else month = 1;
            for (; month < 13; month++)
            {
                if (year == endYear && month > endMonth) break;
                int day = 0;
                if (year == startYear && month == startMonth) day = startDay;
                else day = 1;
                for (; day <= dayForMonth[month - 1]; day++)
                {
                    if (year == endYear && month == endMonth && day > endDay) break;

                    timeInfo = sunManager.Calculate(month, day, 12f);

                    int[] temp = new int[optimizedPointList.Count];
                    for (int i = 0; i < temp.Length; i++)
                    {
                        temp[i] = 0;
                    }

                    float clock = 0f;
                    if (year == startYear && month == startMonth && day == startDay && startHour * 60 + startMinute > timeInfo[2] * 60f)
                    {
                        clock = (float)(startHour * 60 + startMinute) / 60f;
                    }
                    else clock = (float)timeInfo[2];
                    float endClock = 0f;
                    if (year == endYear && month == endMonth && day == endDay && endHour * 60 + endMinute < timeInfo[3] * 60f)
                    {
                        endClock = (float)(endHour * 60 + endMinute) / 60f;
                    }
                    else endClock = (float)timeInfo[3];

                    for (; clock < endClock; clock += 24f / 1440f)
                    {
                        List<double> sunInfo = sunManager.Calculate(month, day, clock);
                        for (int i = 0; i < optimizedPointList.Count; i++)
                        {
                            if (rayManager.CheckSunlight(optimizedPointList[i], sunManager.CalculateSunVector(-sunInfo[0], sunInfo[1]))) temp[i]++;
                        }
                    }

                    int tempAverage = 0;
                    for (int i = 0; i < temp.Length; i++)
                    {
                        if (max < temp[i]) max = temp[i];
                        tempAverage += temp[i];
                    }
                    tempAverage = tempAverage / temp.Length;
                    average += tempAverage;
                    currentDay++;
                    int percentage = (int)((float)currentDay / (float)uiManager.GetInterval() * 100f);
                    uiManager.UpdateProgress(percentage);
                    yield return null;
                }
            }
        }
        average = average / uiManager.GetInterval();

        for (int i = 0; i < pointList.Count; i++)
        {
            pointList[i].layer = 0;
        }

        List<int> resultList = new List<int>();
        resultList.Add(average);
        resultList.Add(max);
        uiManager.UpdateAnalysisPanel(resultList);
    }

    // Analyze the sunlight of the selected points during the period which user set
    public void Analyze(int startYear, int startMonth, int startDay, int startHour, int startMinute, int endYear, int endMonth, int endDay, int endHour, int endMinute)
    {
        if (selectedPointList.Count < 1)
        {
            Debug.Log("You should select the points.");
        }
        else if (selectedPointList.Count > 2000)
        {
            Debug.Log("You've choose too many points.");
        }
        else
        {
            for (int i = 0; i < pointList.Count; i++)
            {
                pointList[i].layer = 2;
            }

            optimizedPointList = OptimizePoints(selectedPointList);
            max = 0;
            average = 0;
            this.startYear = startYear;
            this.startMonth = startMonth;
            this.startDay = startDay;
            this.startHour = startHour;
            this.startMinute = startMinute;
            this.endYear = endYear;
            this.endMonth = endMonth;
            this.endDay = endDay;
            this.endHour = endHour;
            this.endMinute = endMinute;
            currentDay = 0;

            StartCoroutine("AnalyzeCoroutine");
        }
    }

    // Intantiate plane object on the points
    public void InstantiateObject(List<RaycastHit> hitPointList)
    {
        for (int i = 0; i < hitPointList.Count; i++)
        {
            GameObject temp = Instantiate(pointPrefab, hitPointList[i].point + 0.000005f * hitPointList[i].normal, Quaternion.identity);
            temp.transform.up = hitPointList[i].normal;
            temp.transform.parent = analysisPoints.transform;
            pointList.Add(temp);
        }
    }

    // Destroy plane objects in the objectList
    private void DestroyObject()
    {
        for (int i = 0; i < pointList.Count; i++)
        {
            Destroy(pointList[i], 0.5f);
        }
        pointList.Clear();
    }

    // Select points with circle
    public void SelectPoint(GameObject gameObject)
    {
        if (gameObject.transform.parent.name == "AnalysisPoints")
        {
            for (int i = 0; i < pointList.Count; i++)
            {
                if (pointList[i].transform.up == gameObject.transform.up && Vector3.Distance(pointList[i].transform.position, gameObject.transform.position) < radius)
                {
                    if (!selectedPointList.Contains(pointList[i]))
                    {
                        selectedPointList.Add(pointList[i]);
                        pointList[i].GetComponent<MeshRenderer>().material = selectMaterial;
                    }
                }
            }
        }
    }

    // Select object
    public void SelectObject(GameObject gameObject)
    {
        if (!selectedPointList.Contains(gameObject))
        {
            selectedPointList.Add(gameObject);
            gameObject.GetComponent<MeshRenderer>().material = selectMaterial;
        }
    }

    // Clear selectedObjectList
    public void ClearSelectedObjectList()
    {
        for (int i = 0; i < selectedPointList.Count; i++)
        {
            selectedPointList[i].GetComponent<MeshRenderer>().material = pointMaterial;
        }
        selectedPointList.Clear();
    }

    // Return selectedObjectList
    public List<GameObject> GetSelectedObjectList()
    {
        return selectedPointList;
    }
}
