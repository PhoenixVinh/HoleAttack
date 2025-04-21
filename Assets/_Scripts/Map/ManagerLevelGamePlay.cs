using System;
using _Scripts.Data.LevelGamePlayData;
using _Scripts.Map.MapSpawnItem;
using _Scripts.UI.MissionUI;
using UnityEngine;
public class ManagerLevelGamePlay : MonoBehaviour
{
    public static ManagerLevelGamePlay Instance;

    public LevelGamePlaySO level;
    
    
    private void Awake()
    {
        Instance = this;
        LoadLevelSO();
       
    }
    public int currentLevel = 1;


    private void Start()
    {
        SpawnLevel();
    }

    public void ChangeLevel(int level)
    {
        currentLevel = level;
        
        
    }

    public void LoadLevelSO()
    {
        level = Resources.Load<LevelGamePlaySO>($"DataLevelSO/DataLevel_{currentLevel}");

        if (level == null)
        {
            Debug.LogError($"No DataLevelSO found in Resources at path: {Application.dataPath}");
        }
    }

    public void SpawnLevel()
    {
        SpawnItemMap.Instance.SetData(level.levelSpawnData);
        ManagerMission.Instance.SetData(level.missionData);
        ColdownTime.Instance.SetData(level.timeToComplete);
    }
    
    
    
    
}