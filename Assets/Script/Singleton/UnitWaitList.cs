using System.Collections.Generic;
using Assets.Script.AssetsScripts.Enum;
using UnityEngine;
using UnityEngine.UI;

public class UnitWaitList : MonoBehaviour
{

    public static UnitWaitList _instance;
    [SerializeField] GameObject UIWaitingList;
    UnitData currentUnit = null;
    readonly List<UnitData> waitingList = new();
    bool isTraining = false;
    float trainingTime = 999f;
    float currentTime = 0f;
    Image TrainingOverlay;

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    void Start()
    {
        UpdateOrder();
        UIWaitingList.SetActive(false);
        Transform spawnIconTransform = UIWaitingList.transform.GetChild(0);
        TrainingOverlay = spawnIconTransform.transform.GetChild(0).GetComponent<Image>();
    }

    void Update()
    {
        if (isTraining)
        {
            currentTime -= Time.deltaTime;
            TrainingOverlay.fillAmount = currentTime / trainingTime;
            if (currentTime <= 0 && currentUnit != null)
            {
                Spawn_Manager._instance.Spawn_Unit(currentUnit, Team.Team1);
                currentUnit = null;
                isTraining = false;
                currentTime = 0f;
                UpdateOrder();
            }

        }
    }

    public bool AddUnit(UnitData unit)
    {
        if (RessourceManager._instance.ConsumResources(unit.GetUnitStats(LevelManager._instance.GetLevelUnit(Team.Team1, unit)).baseCost, Team.Team1))
        {
            if (currentUnit == null)
            {
                currentUnit = unit;
                UIWaitingList.SetActive(true);
            }
            else if (waitingList.Count < 9)
            {
                waitingList.Add(unit);
            }
            UpdateOrder();
            return true;
        }
        return false;
    }

    public void RemoveUnit()
    {
        if (waitingList.Count > 0)
        {
            RessourceManager._instance.AddResources(waitingList[^1].GetUnitStats(LevelManager._instance.GetLevelUnit(Team.Team1, currentUnit)).baseCost, Team.Team1);
            waitingList.RemoveAt(waitingList.Count - 1);
        }
        else if (currentUnit != null)
        {
            RessourceManager._instance.AddResources(currentUnit.GetUnitStats(LevelManager._instance.GetLevelUnit(Team.Team1, currentUnit)).baseCost, Team.Team1);
            currentUnit = null;
            isTraining = false;
            currentTime = 0f;
        }
        UpdateOrder();
    }

    void UpdateOrder()
    {
        if (currentUnit != null)
        {
            UIWaitingList.SetActive(true);
            TrainNextUnit();
        }
        else if (waitingList.Count > 0)
        {
            currentUnit = waitingList[0];
            waitingList.RemoveAt(0);
            TrainNextUnit();
        }
        else
        {
            UIWaitingList.SetActive(false);
        }
        UpdateUI();
    }

    void TrainNextUnit()
    {
        if (isTraining) return;
        trainingTime = currentUnit.GetUnitStats(LevelManager._instance.GetLevelUnit(Team.Team1, currentUnit)).spawnTime;
        currentTime = trainingTime;
        isTraining = true;
    }

    void UpdateUI()
    {
        Transform spawnIconTransform = UIWaitingList.transform.GetChild(0);
        Image spawnImage = spawnIconTransform.GetComponent<Image>();

        if (currentUnit != null)
        {
            spawnImage.sprite = currentUnit.Icon;
            spawnImage.color = Color.white;
        }
        else
        {
            spawnImage.sprite = null;
            spawnImage.color = new Color(1, 1, 1, 0);
        }

        for (int i = 0; i < 9; i++)
        {
            Transform waitingIconTransform = UIWaitingList.transform.GetChild(i + 1);
            Image waitingImage = waitingIconTransform.GetComponent<Image>();

            if (i < waitingList.Count)
            {
                waitingImage.sprite = waitingList[i].Icon;
                waitingImage.color = Color.white;
            }
            else
            {
                waitingImage.sprite = null;
                waitingImage.color = new Color(1, 1, 1, 0);
            }
        }
    }


}