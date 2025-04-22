using _Scripts.UI.PauseGameUI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace _Scripts.UI.WinLossUI
{
    public class WinUI : PauseGame
    {
        public TMP_Text coinText;
        public Button continueButton;

        

        public override void OnEnable()
        {
            base.OnEnable();
            coinText.text = "75";
            int coin = PlayerPrefs.GetInt("Coin");
            coin += 75;
            PlayerPrefs.SetInt("Coin", coin);
            continueButton.onClick.AddListener(ShowNextlevel);
        }

        public override void OnDisable()
        {
            base.OnDisable();
            continueButton.onClick.RemoveAllListeners();
        }

        private void ShowNextlevel()
        {
            
            this.gameObject.SetActive(false);
            // Change Data Level 

            ManagerLevelGamePlay.Instance.LoadNextLevel();
           
        }
    }
}