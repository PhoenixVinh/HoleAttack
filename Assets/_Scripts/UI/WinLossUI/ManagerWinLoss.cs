using _Scripts.Event;
using _Scripts.UI;
using UnityEngine;

public class ManagerWinLoss : MonoBehaviour
{
    public GameObject WinUI;
    public GameObject LoseUI;

    public void OnEnable()
    {
        WinLossEvent.OnWin += ShowUIWin;
        WinLossEvent.OnLoss += ShowUILoss;
    }

   

    public void OnDisable()
    {
        WinLossEvent.OnWin -= ShowUIWin;
        WinLossEvent.OnLoss -= ShowUILoss;
    }
    
    private void ShowUIWin()
    {
        
        WinUI.SetActive(true);
        int currentLevel = PlayerPrefs.GetInt(StringPlayerPrefs.CURRENT_LEVEL);
        PlayerPrefs.SetInt(StringPlayerPrefs.CURRENT_LEVEL, currentLevel + 1);
       
    }
    private void ShowUILoss()
    {
        if (WinUI.activeSelf) return;
        
        LoseUI.SetActive(true);
    }

   

        
}