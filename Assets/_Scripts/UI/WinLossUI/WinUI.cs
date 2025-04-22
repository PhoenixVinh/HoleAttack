using _Scripts.UI.PauseGameUI;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace _Scripts.UI.WinLossUI
{
    public class WinUI : MonoBehaviour
    {
        public TMP_Text coinText;
        public Button continueButton;



        public void OnEnable()
        {
            coinText.text = "75";
            continueButton.onClick.AddListener(ShowNextlevel);
        }

        public void OnDisable()
        {
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