
using System.Threading.Tasks;
using _Scripts.Booster;
using _Scripts.Data.LevelGamePlayData;
using _Scripts.Map.MapSpawnItem;
using _Scripts.ObjectPooling;
using _Scripts.UI;
using _Scripts.UI.MissionUI;
using UnityEngine;


public class ManagerLevelGamePlay : MonoBehaviour
{
    public static ManagerLevelGamePlay Instance;

    public LevelGamePlaySO level;
    public int currentLevel = 1;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
  
        
        currentLevel = PlayerPrefs.GetInt(StringPlayerPrefs.CURRENT_LEVEL, 1);
        LoadLevelSO();
    }
   


    private void Start()
    {
        SpawnLevel();
    }

    public void ChangeLevel(int level)
    {
        currentLevel = level;
        
        
    }

    public bool LoadLevelSO()
    {
        level = Resources.Load<LevelGamePlaySO>($"DataLevelSO/DataLevel_{currentLevel}");
        if (level == null)
        {
            Debug.LogError($"No DataLevelSO found in Resources at path: {Application.dataPath}");
            return false;
        }
        return true;
    }

    public async void SpawnLevel()
    {
        MissionPooling.Instance.DisactiveAllItem();
        HoleController.Instance.Reset();
        HoleController.Instance.SetPosition(Vector3.zero);
        HoleController.Instance.gameObject.SetActive(false);
        await Task.Delay(500);
        SpawnItemMap.Instance.SetData(level.levelSpawnData);
        ManagerMission.Instance.SetData(level.missionData);
        ColdownTime.Instance.SetData(level.timeToComplete);
        HoleController.Instance.gameObject.SetActive(true);
        ManagerBooster.Instance.SetData();



    }


    public void LoadNextLevel()
    {
        currentLevel  = currentLevel + 1;
        if (LoadLevelSO())
        {
            SpawnLevel();
        }
        else
        {
            Debug.LogError($"You are at The Max Level");
        }
    }
}