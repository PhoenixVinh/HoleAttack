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
    }
    private void ShowUILoss()
    {
        LoseUI.SetActive(true);
    }

        
}