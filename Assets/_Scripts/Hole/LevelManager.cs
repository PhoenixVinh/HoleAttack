using HoleLevelData;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // it can load by recouses
    public LevelHoleSO datalevel;

    public int currentLevel = 0;
    public void Start()
    {
        UpdateLevel();
    }

    private void OnEnable()
    {
        HoleEvent.OnLevelUp += OnLevelup;
    }

    private void OnLevelup()
    {
        currentLevel++;
        if (currentLevel < datalevel.levels.Length)
        {
            UpdateLevel();
        }
        else
        {
            Debug.Log("No more levels");
        }
       
    }

    private void OnDisable()
    {
        HoleEvent.OnLevelUp -= OnLevelup;
    }

    private void UpdateLevel()
    {
        var dataLevel = datalevel.levels[currentLevel];
        int expUpLevel = 0;
        if (currentLevel + 1 < datalevel.levels.Length)
        {
            expUpLevel = datalevel.levels[currentLevel + 1].amountExp;
        }
        else
        {
            expUpLevel = 100000;
        }
       
        HoleController.Instance.LoadLevel(expUpLevel, dataLevel.radious);
    }
    
    
    
    
}