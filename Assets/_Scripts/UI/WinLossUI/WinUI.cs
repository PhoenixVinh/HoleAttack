using _Scripts.Sound;
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
            int coin = PlayerPrefs.GetInt(StringPlayerPrefs.CURRENT_COIN);
            coin += 75;
            PlayerPrefs.SetInt(StringPlayerPrefs.CURRENT_COIN, coin);
            continueButton.onClick.AddListener(ShowNextlevel);
            this.pauseButton.gameObject.SetActive(true);
            if(ManagerSound.Instance != null)
                ManagerSound.Instance.PlayEffectSound(EnumEffectSound.LevelComplete);
        }

        public override void OnDisable()
        {
            base.OnDisable();
            continueButton.onClick.RemoveAllListeners();
            this.pauseButton.gameObject.SetActive(true);
        }

        private void ShowNextlevel()
        {
            
            this.gameObject.SetActive(false);
            // Change Data Level 

            ManagerLevelGamePlay.Instance.LoadNextLevel();
           
        }
    }
}