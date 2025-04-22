using _Scripts.Event;
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
        int currentLevel = PlayerPrefs.GetInt("Level");
        PlayerPrefs.SetInt("Level", currentLevel + 1);
       
    }
    private void ShowUILoss()
    {
        if (WinUI.activeSelf) return;
        
        LoseUI.SetActive(true);
    }

   

        
}