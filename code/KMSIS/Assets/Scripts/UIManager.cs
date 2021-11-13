using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class UIManager : MonoBehaviour
{
    // This class manages UI. This might be fixed in the future according to the design.

    // UI component
    public GameObject basePanel;
    public GameObject recentPanel;
    public GameObject iconPanel;
    public GameObject infoPanel;
    public GameObject sunlightPanel;
    public GameObject customPanel;
    public GameObject analysisPanel;
    public GameObject periodPanel;
    public GameObject importPanel;
    public GameObject timePanel;
    public GameObject advertisementPanel;
    public GameObject importPreviewPanel;
    public GameObject savedRecordPanel;

    public Dropdown[] timePanelDropdown;
    public Dropdown[] periodPanelDropdown;

    public InputField searchInput;
    public InputField[] scaleInput;
    public InputField[] rotationInput;

    public Sprite[] adSprite;

    // Manager component
    private SunManager sunManager;
    private DataManager dataManager;
    private BuildingManager buildingManager;
    private ControlManager controlManager;
    private AnalysisManager analysisManager;

    // Time variable
    private int[] dayForMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    string yearString, monthString, dayString, hourString, minuteString;
    float predictionTime;
    int startYear, startMonth, startDay, startHour, startMinute, endYear, endMonth, endDay, endHour, endMinute;

    // Slider click state
    bool sliderClicked;

    void Start()
    {
        // Get manager component
        sunManager = GameObject.Find("SunManager").GetComponent<SunManager>();
        dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
        buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        controlManager = GameObject.Find("ControlManager").GetComponent<ControlManager>();
        analysisManager = GameObject.Find("AnalysisManager").GetComponent<AnalysisManager>();

        // Set variable
        yearString = System.DateTime.Now.ToString("yyyy");
        monthString = System.DateTime.Now.ToString("MM");
        dayString = System.DateTime.Now.ToString("dd");
        hourString = System.DateTime.Now.ToString("HH");
        minuteString = System.DateTime.Now.ToString("mm");

        sliderClicked = false;

        // Set the position of sun
        SetSunPosition();

        // Update time panel
        InitTimePanelDropdown();
        InitPeriodPanelDropdown();
        if (int.TryParse(yearString, out int year) && int.TryParse(monthString, out int month) && int.TryParse(dayString, out int day) && int.TryParse(hourString, out int hour) && int.TryParse(minuteString, out int minute))
        {
            UpdateTimeSlider(year, month, day, hour, minute);
            int clock = hour * 60 + minute;
            timePanel.transform.GetChild(3).GetComponent<Slider>().value = clock;
        }
    }

    // Open request correction link
    public void OpenCorrectionPage()
    {
        Application.OpenURL("mailto:foba1@naver.com");
    }

    // Open help page
    public void OpenHelpPage()
    {
        Application.OpenURL("https://github.com/foba1/ITRC-KMSIS");
    }

    // UI index - infoPanel(0), sunlightPanel(1), customPanel(2), importPreviewPanel(3), importPanel(4), savedRecordPanel(5), periodPanel(6), analysisPanel(7), advertisementPanel(8)

    // Turn off the UI
    public void TurnOffUI(int index)
    {
        if (index == -1)
        {
            for (int i = 0; i < 8; i++)
            {
                TurnOffUI(i);
            }
            for (int i = 0; i < iconPanel.transform.childCount; i++)
            {
                if (i == 2) continue;
                iconPanel.transform.GetChild(i).GetChild(1).gameObject.SetActive(true);
                iconPanel.transform.GetChild(i).GetChild(2).gameObject.SetActive(false);
                iconPanel.transform.GetChild(i).GetChild(0).GetComponent<Text>().color = new Color(50f / 255f, 50f / 255f, 50f / 255f, 255 / 255f);
            }
        }
        else if (index == 0)
        {
            infoPanel.SetActive(false);
        }
        else if (index == 1)
        {
            sunlightPanel.SetActive(false);
            customPanel.SetActive(false);
            periodPanel.SetActive(false);
            analysisPanel.SetActive(false);
            iconPanel.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
            iconPanel.transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
            iconPanel.transform.GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(50f / 255f, 50f / 255f, 50f / 255f, 255 / 255f);
        }
        else if (index == 2)
        {
            customPanel.SetActive(false);
        }
        else if (index == 3)
        {
            importPreviewPanel.SetActive(false);
            iconPanel.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            iconPanel.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
            iconPanel.transform.GetChild(1).GetChild(0).GetComponent<Text>().color = new Color(50f / 255f, 50f / 255f, 50f / 255f, 255 / 255f);
        }
        else if (index == 4)
        {
            importPanel.SetActive(false);
            iconPanel.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            iconPanel.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
            iconPanel.transform.GetChild(1).GetChild(0).GetComponent<Text>().color = new Color(50f / 255f, 50f / 255f, 50f / 255f, 255 / 255f);
        }
        else if (index == 5)
        {
            for (int i = 0; i < savedRecordPanel.transform.GetChild(0).GetChild(13).GetChild(0).GetChild(1).childCount; i++)
            {
                GameObject.Destroy(savedRecordPanel.transform.GetChild(0).GetChild(13).GetChild(0).GetChild(1).GetChild(i).gameObject);
            }
            savedRecordPanel.SetActive(false);
            iconPanel.transform.GetChild(3).GetChild(1).gameObject.SetActive(true);
            iconPanel.transform.GetChild(3).GetChild(2).gameObject.SetActive(false);
            iconPanel.transform.GetChild(3).GetChild(0).GetComponent<Text>().color = new Color(50f / 255f, 50f / 255f, 50f / 255f, 255 / 255f);
        }
        else if (index == 6)
        {
            periodPanel.SetActive(false);
        }
        else if (index == 7)
        {
            analysisPanel.SetActive(false);
        }
        else if (index == 8)
        {
            advertisementPanel.SetActive(false);
        }
    }

    // Turn on the UI
    public void TurnOnUI(int index)
    {
        if (index == 0)
        {
            TurnOffUI(-1);
            infoPanel.SetActive(true);
        }
        else if (index == 1)
        {
            if (buildingManager.GetSelectedBuildingsList().Count == 1)
            {
                if (analysisManager.IsAnalyzing())
                {
                    analysisManager.Release();
                    buildingManager.ClearSelectedBuildingsList();
                    controlManager.SetMode(0);
                    TurnOffUI(-1);
                }
                else
                {
                    TurnOffUI(-1);
                    TurnOnUI(8);
                    controlManager.SetMode(2);
                    analysisManager.Init(buildingManager.GetSelectedBuildingsList()[0]);
                    analysisManager.AnalyzeBuilding();
                }
            }
        }
        else if (index == 2)
        {
            if (CheckPeriod())
            {
                customPanel.SetActive(true);
                float count = analysisManager.GetSelectedObjectList().Count;
                predictionTime = analysisManager.EstimateTime();
                predictionTime = predictionTime * count;
                int interval = GetInterval();
                predictionTime = predictionTime * (float)interval;
                int temp = (int)predictionTime;
                if (temp / 3600 > 0)
                {
                    customPanel.transform.GetChild(4).GetComponent<Text>().text = (temp / 3600).ToString() + "시간 " + (temp / 60 - (temp / 3600) * 60).ToString() + "분 " + (temp % 60).ToString() + "초";
                }
                else if (temp / 60 > 0)
                {
                    customPanel.transform.GetChild(4).GetComponent<Text>().text = (temp / 60).ToString() + "분 " + (temp % 60).ToString() + "초";
                }
                else
                {
                    customPanel.transform.GetChild(4).GetComponent<Text>().text = (temp % 60).ToString() + "초";
                }
            }
        }
        else if (index == 3)
        {
            TurnOffUI(-1);
            importPreviewPanel.SetActive(true);
            iconPanel.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
            iconPanel.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
            iconPanel.transform.GetChild(1).GetChild(0).GetComponent<Text>().color = new Color(249f / 255f, 199f / 255f, 0f, 255 / 255f);
        }
        else if (index == 4)
        {
            TurnOffUI(-1);
            importPanel.SetActive(true);
            iconPanel.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
            iconPanel.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
            iconPanel.transform.GetChild(1).GetChild(0).GetComponent<Text>().color = new Color(249f / 255f, 199f / 255f, 0f, 255 / 255f);
        }
        else if (index == 5)
        {
            TurnOffUI(-1);
            savedRecordPanel.SetActive(true);
            iconPanel.transform.GetChild(3).GetChild(1).gameObject.SetActive(false);
            iconPanel.transform.GetChild(3).GetChild(2).gameObject.SetActive(true);
            iconPanel.transform.GetChild(3).GetChild(0).GetComponent<Text>().color = new Color(249f / 255f, 199f / 255f, 0f, 255 / 255f);
            ShowRecord();
        }
        else if (index == 6)
        {
            TurnOffUI(2);
            periodPanel.SetActive(true);
        }
        else if (index == 7)
        {
            analysisPanel.SetActive(true);
            analysisPanel.transform.GetChild(6).gameObject.SetActive(true);
            analysisPanel.transform.GetChild(7).gameObject.SetActive(false);
        }
        else if (index == 8)
        {
            advertisementPanel.SetActive(true);
            advertisementPanel.transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Text>().text = "0%";
            int value = Random.Range(0, adSprite.Length);
            advertisementPanel.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = adSprite[value];
        }
    }

    // Update analysisPanel
    public void UpdateAnalysisPanel(List<int> result)
    {
        if (result != null)
        {
            TurnOffUI(2);
            TurnOnUI(7);
            analysisPanel.transform.GetChild(0).GetComponent<Text>().text = startYear + "년 " + startMonth + "월 " + startDay + "일 " + startHour + ":" + startMinute;
            analysisPanel.transform.GetChild(1).GetComponent<Text>().text = endYear + "년 " + endMonth + "월 " + endDay + "일 " + endHour + ":" + endMinute;
            if (result[0] / 60 > 0)
            {
                if (result[0] % 60 < 10)
                {
                    analysisPanel.transform.GetChild(4).GetChild(1).GetComponent<Text>().text = result[0] / 60 + "시간 0" + result[0] % 60 + "분";
                }
                else
                {
                    analysisPanel.transform.GetChild(4).GetChild(1).GetComponent<Text>().text = result[0] / 60 + "시간 " + result[0] % 60 + "분";
                }
            }
            else
            {
                if (result[0] % 60 < 10)
                {
                    analysisPanel.transform.GetChild(4).GetChild(1).GetComponent<Text>().text = "0" + result[0] % 60 + "분";
                }
                else
                {
                    analysisPanel.transform.GetChild(4).GetChild(1).GetComponent<Text>().text = result[0] % 60 + "분";
                }
            }
            if (result[1] / 60 > 0)
            {
                if (result[0] % 60 < 10)
                {
                    analysisPanel.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = result[1] / 60 + "시간 0" + result[1] % 60 + "분";
                }
                else
                {
                    analysisPanel.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = result[1] / 60 + "시간 " + result[1] % 60 + "분";
                }
            }
            else
            {
                if (result[0] % 60 < 10)
                {
                    analysisPanel.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = "0" + result[1] % 60 + "분";
                }
                else
                {
                    analysisPanel.transform.GetChild(5).GetChild(1).GetComponent<Text>().text = result[1] % 60 + "분";
                }
            }
        }
        TurnOffUI(8);
    }

    // Update sunlightPanel
    public void UpdateSunlightPanel(List<int> result)
    {
        sunlightPanel.SetActive(true);
        customPanel.SetActive(true);
        if (result != null)
        {
            sunlightPanel.transform.GetChild(1).GetComponent<Text>().text = monthString + "월 " + dayString + "일 평균";
            sunlightPanel.transform.GetChild(2).GetComponent<Text>().text = (result[0] / 60) + "시간 " + (result[0] % 60) + "분";
            sunlightPanel.transform.GetChild(5).GetComponent<Text>().text = monthString + "월 " + dayString + "일 최대";
            sunlightPanel.transform.GetChild(6).GetComponent<Text>().text = (result[1] / 60) + "시간 " + (result[1] % 60) + "분";
        }
        else
        {
            analysisManager.Release();
            buildingManager.ClearSelectedBuildingsList();
            controlManager.SetMode(0);
            TurnOffUI(-1);
        }
        iconPanel.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        iconPanel.transform.GetChild(0).GetChild(2).gameObject.SetActive(true);
        iconPanel.transform.GetChild(0).GetChild(0).GetComponent<Text>().color = new Color(249f / 255f, 199f / 255f, 0f, 255 / 255f);
        TurnOffUI(8);
    }

    // Update percentage of progress in advertisementPanel
    public void UpdateProgress(int percentage)
    {
        advertisementPanel.transform.GetChild(0).GetChild(0).GetChild(2).GetComponent<Text>().text = percentage.ToString() + "%";
    }

    // Update area set mode
    public void UpdateAreaSetMode()
    {
        if (customPanel.transform.GetChild(1).GetChild(2).gameObject.activeSelf) customPanel.transform.GetChild(1).GetChild(2).gameObject.SetActive(false);
        else customPanel.transform.GetChild(1).GetChild(2).gameObject.SetActive(true);
    }

    // Save record of sunlight
    public void SaveRecord()
    {
        GameObject building = analysisManager.targetBuilding;
        string startDay = analysisPanel.transform.GetChild(0).GetComponent<Text>().text;
        string endDay = analysisPanel.transform.GetChild(1).GetComponent<Text>().text;
        string average = analysisPanel.transform.GetChild(4).GetChild(1).GetComponent<Text>().text;
        string max = analysisPanel.transform.GetChild(5).GetChild(1).GetComponent<Text>().text;
        dataManager.SaveRecord(building, startDay, endDay, average, max);
        analysisPanel.transform.GetChild(6).gameObject.SetActive(false);
        analysisPanel.transform.GetChild(7).gameObject.SetActive(true);
    }

    // Show saved record
    public void ShowRecord()
    {
        GameObject item = savedRecordPanel.transform.GetChild(0).GetChild(13).GetChild(0).GetChild(0).gameObject;
        int yValue = 0;
        for (int i = 0; i < dataManager.extraData.GetLength(); i++)
        {
            List<string> record = dataManager.extraData.GetRecord(i);
            GameObject temp = Instantiate(item, new Vector3(0, yValue, 0), Quaternion.identity);
            temp.transform.SetParent(savedRecordPanel.transform.GetChild(0).GetChild(13).GetChild(0).GetChild(1));
            for (int j = 0; j < 5; j++)
            {
                temp.transform.GetChild(j + 6).GetComponent<Text>().text = record[j];
            }
            temp.SetActive(true);
            yValue -= 60;
        }
    }

    // Calculate sunlight during the period which user set
    public void CalculateSunlight()
    {
        TurnOnUI(8);
        analysisManager.Analyze(startYear, startMonth, startDay, startHour, startMinute, endYear, endMonth, endDay, endHour, endMinute);
    }

    // Calculate interval of period
    public int GetInterval()
    {
        string temp = periodPanelDropdown[0].options[periodPanelDropdown[0].value].text;
        temp = temp.Substring(0, temp.Length - 1);
        if (int.TryParse(temp, out int startYearString))
        {
            startYear = startYearString;
        }
        else return -1;
        startMonth = periodPanelDropdown[1].value + 1;
        startDay = periodPanelDropdown[2].value + 1;
        startHour = periodPanelDropdown[3].value + 1;
        startMinute = periodPanelDropdown[4].value;

        temp = periodPanelDropdown[5].options[periodPanelDropdown[5].value].text;
        temp = temp.Substring(0, temp.Length - 1);
        if (int.TryParse(temp, out int endYearString))
        {
            endYear = endYearString;
        }
        else return -1;
        endMonth = periodPanelDropdown[6].value + 1;
        endDay = periodPanelDropdown[7].value + 1;
        endHour = periodPanelDropdown[8].value + 1;
        endMinute = periodPanelDropdown[9].value;

        int interval = 0;
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
                    interval++;
                }
            }
        }
        return interval;
    }

    // Check period is valid
    private bool CheckPeriod()
    {
        if (periodPanelDropdown[0].value < periodPanelDropdown[5].value) return true;
        else if (periodPanelDropdown[0].value == periodPanelDropdown[5].value)
        {
            if (periodPanelDropdown[1].value < periodPanelDropdown[6].value) return true;
            else if (periodPanelDropdown[1].value == periodPanelDropdown[6].value)
            {
                if (periodPanelDropdown[2].value < periodPanelDropdown[7].value) return true;
                else if (periodPanelDropdown[2].value == periodPanelDropdown[7].value)
                {
                    if (periodPanelDropdown[3].value < periodPanelDropdown[8].value) return true;
                    else if (periodPanelDropdown[3].value == periodPanelDropdown[8].value)
                    {
                        if (periodPanelDropdown[4].value <= periodPanelDropdown[9].value) return true;
                        else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        else return false;
    }

    // Get time information from time panel
    public List<int> GetTime()
    {
        if (int.TryParse(monthString, out int month) && int.TryParse(dayString, out int day) && int.TryParse(hourString, out int hour) && int.TryParse(minuteString, out int minute))
        {
            List<int> tempList = new List<int>();
            tempList.Add(month);
            tempList.Add(day);
            tempList.Add(hour);
            tempList.Add(minute);
            return tempList;
        }
        else return null;
    }

    // Initialize periodPanel's dropdown
    public void InitPeriodPanelDropdown()
    {
        periodPanelDropdown[0].options.Clear();
        if (int.TryParse(yearString, out int year1))
        {
            for (int i = 0; i < 10; i++)
            {
                periodPanelDropdown[0].options.Add(new Dropdown.OptionData() { text = (year1 + i).ToString() + "년" });
            }
            periodPanelDropdown[0].value = 0;
        }
        else Debug.Log("Error - yearString value is invalid.");

        periodPanelDropdown[1].options.Clear();
        if (int.TryParse(monthString, out int month1))
        {
            for (int i = 0; i < 12; i++)
            {
                periodPanelDropdown[1].options.Add(new Dropdown.OptionData() { text = (i + 1).ToString() + "월" });
            }
            periodPanelDropdown[1].value = month1 - 1;
        }
        else Debug.Log("Error - monthString value is invalid.");

        periodPanelDropdown[2].options.Clear();
        if (int.TryParse(dayString, out int day1))
        {
            for (int i = 0; i < dayForMonth[periodPanelDropdown[1].value]; i++)
            {
                periodPanelDropdown[2].options.Add(new Dropdown.OptionData() { text = (i + 1).ToString() + "일" });
            }
            periodPanelDropdown[2].value = day1 - 1;
        }
        else Debug.Log("Error - dayString value is invalid.");

        periodPanelDropdown[3].options.Clear();
        if (int.TryParse(hourString, out int hour1))
        {
            for (int i = 0; i < 24; i++)
            {
                periodPanelDropdown[3].options.Add(new Dropdown.OptionData() { text = i.ToString() + "시" });
            }
            periodPanelDropdown[3].value = hour1 - 1;
        }
        else Debug.Log("Error - hourString value is invalid.");

        periodPanelDropdown[4].options.Clear();
        if (int.TryParse(minuteString, out int minute1))
        {
            for (int i = 0; i < 60; i++)
            {
                periodPanelDropdown[4].options.Add(new Dropdown.OptionData() { text = i.ToString() + "분" });
            }
            periodPanelDropdown[4].value = minute1 - 1;
        }
        else Debug.Log("Error - minuteString value is invalid.");

        periodPanelDropdown[5].options.Clear();
        if (int.TryParse(yearString, out int year2))
        {
            for (int i = 0; i < 10; i++)
            {
                periodPanelDropdown[5].options.Add(new Dropdown.OptionData() { text = (year2 + i).ToString() + "년" });
            }
            periodPanelDropdown[5].value = 0;
        }
        else Debug.Log("Error - yearString value is invalid.");

        periodPanelDropdown[6].options.Clear();
        if (int.TryParse(monthString, out int month2))
        {
            for (int i = 0; i < 12; i++)
            {
                periodPanelDropdown[6].options.Add(new Dropdown.OptionData() { text = (i + 1).ToString() + "월" });
            }
            periodPanelDropdown[6].value = month2 - 1;
        }
        else Debug.Log("Error - monthString value is invalid.");

        periodPanelDropdown[7].options.Clear();
        if (int.TryParse(dayString, out int day2))
        {
            for (int i = 0; i < dayForMonth[periodPanelDropdown[6].value]; i++)
            {
                periodPanelDropdown[7].options.Add(new Dropdown.OptionData() { text = (i + 1).ToString() + "일" });
            }
            periodPanelDropdown[7].value = day2 - 1;
        }
        else Debug.Log("Error - dayString value is invalid.");

        periodPanelDropdown[8].options.Clear();
        if (int.TryParse(hourString, out int hour2))
        {
            for (int i = 0; i < 24; i++)
            {
                periodPanelDropdown[8].options.Add(new Dropdown.OptionData() { text = i.ToString() + "시" });
            }
            periodPanelDropdown[8].value = hour2 - 1;
        }
        else Debug.Log("Error - hourString value is invalid.");

        periodPanelDropdown[9].options.Clear();
        if (int.TryParse(minuteString, out int minute2))
        {
            for (int i = 0; i < 60; i++)
            {
                periodPanelDropdown[9].options.Add(new Dropdown.OptionData() { text = i.ToString() + "분" });
            }
            periodPanelDropdown[9].value = minute2 - 1;
        }
        else Debug.Log("Error - minuteString value is invalid.");
    }

    // Initialize timePanel's dropdown
    public void InitTimePanelDropdown()
    {
        timePanelDropdown[0].options.Clear();
        if (int.TryParse(yearString, out int year))
        {
            for (int i = 0; i < 10; i++)
            {
                timePanelDropdown[0].options.Add(new Dropdown.OptionData() { text = (year + i).ToString() + "년" });
            }
            timePanelDropdown[0].value = 0;
        }
        else Debug.Log("Error - yearString value is invalid.");

        timePanelDropdown[1].options.Clear();
        if (int.TryParse(monthString, out int month))
        {
            for (int i = 0; i < 12; i++)
            {
                timePanelDropdown[1].options.Add(new Dropdown.OptionData() { text = (i + 1).ToString() + "월" });
            }
            timePanelDropdown[1].value = month - 1;
        }
        else Debug.Log("Error - monthString value is invalid.");

        timePanelDropdown[2].options.Clear();
        if (int.TryParse(dayString, out int day))
        {
            for (int i = 0; i < dayForMonth[timePanelDropdown[1].value]; i++)
            {
                timePanelDropdown[2].options.Add(new Dropdown.OptionData() { text = (i + 1).ToString() + "일" });
            }
            timePanelDropdown[2].value = day - 1;
        }
        else Debug.Log("Error - dayString value is invalid.");

        timePanelDropdown[3].options.Clear();
        if (int.TryParse(hourString, out int hour))
        {
            for (int i = 0; i < 24; i++)
            {
                timePanelDropdown[3].options.Add(new Dropdown.OptionData() { text = i.ToString() + "시" });
            }
            timePanelDropdown[3].value = hour - 1;
        }
        else Debug.Log("Error - hourString value is invalid.");

        timePanelDropdown[4].options.Clear();
        if (int.TryParse(minuteString, out int minute))
        {
            for (int i = 0; i < 60; i++)
            {
                timePanelDropdown[4].options.Add(new Dropdown.OptionData() { text = i.ToString() + "분" });
            }
            timePanelDropdown[4].value = minute - 1;
        }
        else Debug.Log("Error - minuteString value is invalid.");
    }

    // Update timePanel's dropdown
    public void UpdateTimePanelDropdown(int index)
    {
        if (index == 0)
        {
            string temp = timePanelDropdown[0].options[timePanelDropdown[0].value].text;
            yearString = temp.Substring(0, temp.Length - 1);
        }
        else if (index == 1)
        {
            string temp = timePanelDropdown[1].options[timePanelDropdown[1].value].text;
            monthString = temp.Substring(0, temp.Length - 1);
            if (timePanelDropdown[2].value + 1 > dayForMonth[timePanelDropdown[1].value])
            {
                timePanelDropdown[2].options.Clear();
                for (int i = 0; i < dayForMonth[timePanelDropdown[1].value]; i++)
                {
                    timePanelDropdown[2].options.Add(new Dropdown.OptionData() { text = (i + 1).ToString() + "일" });
                }
                timePanelDropdown[2].value = dayForMonth[timePanelDropdown[1].value] - 1;
                dayString = dayForMonth[timePanelDropdown[1].value].ToString();
            }
        }
        else if (index == 2)
        {
            dayString = (timePanelDropdown[2].value + 1).ToString();
        }
        else if (index == 3)
        {
            hourString = (timePanelDropdown[3].value).ToString();
            if (int.TryParse(minuteString, out int minuteTemp))
            {
                timePanelDropdown[4].value = minuteTemp;
            }
        }
        else if (index == 4)
        {
            if (int.TryParse(hourString, out int hourTemp))
            {
                timePanelDropdown[3].value = hourTemp;
            }
            minuteString = (timePanelDropdown[4].value).ToString();
        }
        if (int.TryParse(yearString, out int year) && int.TryParse(monthString, out int month) && int.TryParse(dayString, out int day) && int.TryParse(hourString, out int hour) && int.TryParse(minuteString, out int minute))
        {
            UpdateTimeSlider(year, month, day, hour, minute);
            int clock = hour * 60 + minute;
            timePanel.transform.GetChild(3).GetComponent<Slider>().value = clock;
            SetSunPosition();
        }
    }

    // Load information from imported building
    public void LoadInfo(GameObject building)
    {
        for (int i = 0; i < 3; i++)
        {
            scaleInput[i].text = "1";
        }
        rotationInput[0].text = building.transform.eulerAngles.x.ToString();
        rotationInput[1].text = building.transform.eulerAngles.y.ToString();
        rotationInput[2].text = building.transform.eulerAngles.z.ToString();
    }
    
    // Set slider state
    public void SetSliderState(bool state)
    {
        sliderClicked = state;
    }

    // Get slider state
    public bool GetSliderState()
    {
        return sliderClicked;
    }

    // Update time
    public void UpdateTime()
    {
        int clock = (int)timePanel.transform.GetChild(3).GetComponent<Slider>().value;
        int hour = clock / 60;
        int minute = clock % 60;
        hourString = hour.ToString();
        minuteString = minute.ToString();
        if (int.TryParse(yearString, out int year) && int.TryParse(monthString, out int month) && int.TryParse(dayString, out int day))
        {
            UpdateTimeSlider(year, month, day, hour, minute);
        }
        SetSunPosition();
    }

    // Update time slider
    public void UpdateTimeSlider(int year, int month, int day, int hour, int minute)
    {
        if (minute < 10)
        {
            if (hour > 11)
            {
                timePanel.transform.GetChild(2).GetComponent<Text>().text = hour + ":0" + minute + " PM";
            }
            else
            {
                timePanel.transform.GetChild(2).GetComponent<Text>().text = hour + ":0" + minute + " AM";
            }
        }
        else
        {
            if (hour > 11)
            {
                timePanel.transform.GetChild(2).GetComponent<Text>().text = hour + ":" + minute + " PM";
            }
            else
            {
                timePanel.transform.GetChild(2).GetComponent<Text>().text = hour + ":" + minute + " AM";
            }
        }
        timePanel.transform.GetChild(4).GetComponent<Text>().text = month + "/" + day + "/" + year;
        if (dayForMonth[month-1] > day)
        {
            timePanel.transform.GetChild(5).GetComponent<Text>().text = month + "/" + (day + 1) + "/" + year;
        }
        else
        {
            if (month == 12)
            {
                timePanel.transform.GetChild(5).GetComponent<Text>().text = "1/1/" + (year + 1);
            }
            else
            {
                timePanel.transform.GetChild(5).GetComponent<Text>().text = (month + 1) + "/1/" + year;
            }
        }
    }

    // Write building name & location on UI
    public void WriteBuildingInfo(int index)
    {
        TurnOnUI(0);
        List<string> result = dataManager.FindData(index);
        if (result[3] == "null")
        {
            infoPanel.transform.GetChild(0).GetComponent<Text>().text = "등록되지 않은 건물입니다.";
        }
        else
        {
            infoPanel.transform.GetChild(0).GetComponent<Text>().text = result[3];
        }
        infoPanel.transform.GetChild(2).GetComponent<Text>().text = result[4] + " " + result[5] + " " + result[6] + " " + result[7];
    }

    // Check if mouse is on UI
    public bool IsMouseOnUI(Vector2 clickPosition)
    {
        RectTransform rect = basePanel.GetComponent<RectTransform>();
        if (clickPosition.x > rect.position.x - rect.sizeDelta.x / 2 && clickPosition.y > rect.position.y - rect.sizeDelta.y / 2 && clickPosition.x < rect.position.x + rect.sizeDelta.x / 2 && clickPosition.y < rect.position.y + rect.sizeDelta.y / 2)
        {
            return true;
        }
        rect = timePanel.GetComponent<RectTransform>();
        if (clickPosition.x > rect.position.x - rect.sizeDelta.x / 2 && clickPosition.y > rect.position.y - rect.sizeDelta.y / 2 && clickPosition.x < rect.position.x + rect.sizeDelta.x / 2 && clickPosition.y < rect.position.y + rect.sizeDelta.y / 2)
        {
            return true;
        }
        return false;
    }

    // Check if inputfield is focused
    public bool CheckInputfieldFocused()
    {
        if (searchInput.isFocused || scaleInput[0].isFocused || scaleInput[1].isFocused || scaleInput[2].isFocused || rotationInput[0].isFocused || rotationInput[1].isFocused || rotationInput[2].isFocused)
        {
            return true;
        }
        else return false;
    }

    // Get UI value
    public List<float> GetTimeValue()
    {
        if (int.TryParse(monthString, out int month) && int.TryParse(dayString, out int day) && int.TryParse(hourString, out int hour) && int.TryParse(minuteString, out int minute))
        {
            // Calculate clock
            float clock = (float)(hour) + (float)(minute) / 60f;
            List<float> result = new List<float>();
            result.Add((float)(month));
            result.Add((float)(day));
            result.Add(clock);
            return result;
        }
        else return null;
    }

    // Set scale of imported building
    public void SetScale()
    {
        if (float.TryParse(scaleInput[0].text, out float x) && float.TryParse(scaleInput[1].text, out float y) && float.TryParse(scaleInput[2].text, out float z))
        {
            controlManager.SetScale(x, y, z);
        }
    }

    // Set rotation of imported building
    public void SetRotation()
    {
        if (float.TryParse(rotationInput[0].text, out float x) && float.TryParse(rotationInput[1].text, out float y) && float.TryParse(rotationInput[2].text, out float z))
        {
            controlManager.SetRotation(x, y, z);
        }
    }

    // Set the position of sun according to the text in UI
    public void SetSunPosition()
    {
        if (int.TryParse(monthString, out int month) && int.TryParse(dayString, out int day) && int.TryParse(hourString, out int hour) && int.TryParse(minuteString, out int minute))
        {
            // Calculate clock
            float clock = (float)(hour) + (float)(minute) / 60f;

            // Calculate data of sun using SunManager
            List<double> sunDataList = sunManager.Calculate(month, day, clock);
            if (sunDataList != null)
            {
                // Set the position of sun
                if (clock > (sunDataList[2] + sunDataList[3]) / 2)
                {
                    GameObject.Find("Directional Light").transform.eulerAngles = new Vector3((float)(sunDataList[1]), (float)(-sunDataList[0]), 0);
                }
                else
                {
                    GameObject.Find("Directional Light").transform.eulerAngles = new Vector3((float)(sunDataList[1]), (float)(sunDataList[0]), 0);
                }
            }
        }
    }

    // Search data with text using DataManager
    public void Search()
    {
        List<GameObject> tempList = dataManager.SearchWithText(searchInput.text);
        if (tempList == null || tempList.Count == 0) Debug.Log("검색 결과가 없습니다.");
        else
        {
            buildingManager.ClearSelectedBuildingsList();
            float x = 0f, z = 0f;
            for (int i = 0; i < tempList.Count; i++)
            {
                buildingManager.SelectBuilding(tempList[i]);
                x += tempList[i].transform.position.x;
                z += tempList[i].transform.position.z;
            }
            x = x / tempList.Count;
            z = z / tempList.Count;
            Camera.main.transform.position = new Vector3(x, 0.005f, z) - Camera.main.transform.forward * 2f;
        }
    }
}
