using System;
using System.Threading.Tasks;
using _Scripts.Event;
using _Scripts.UI;
using _Scripts.UI.HomeSceneUI.ResourcesUI;
using _Scripts.UI.PopupUI;
using Unity.VisualScripting;
using UnityEngine;

namespace _Scripts.ManagerScene.HomeScene
{
    public class ManagerHomeScene: MonoBehaviour
    {
        public static ManagerHomeScene Instance;

        public GameObject ShowLoseGame;

        private void Awake()
        {
            if (Instance == null) {
                Instance = this;
                DontDestroyOnLoad (this);
            } else {
                Destroy (gameObject);
            }
            //ShowLoseGame.SetActive(false);
        }

        private void Start()
        {
            int CurrentLevel = PlayerPrefs.GetInt(StringPlayerPrefs.CURRENT_LEVEL, 1);
            if (CurrentLevel == 3)
            {
                int showTutorialLv3 = PlayerPrefs.GetInt(StringPlayerPrefs.TUTORIAL_LEVEL_3, 0);
                if (showTutorialLv3 == 0)
                {
                    // Show Pop Up Free Item  
                    ManagerPopup.Instance.ShowPopupFreeItem(0);
                }
            }
        }


        public async void ShowLoseGameUI()
        {
            ShowLoseGame.SetActive(true);
            await Task.Delay(3000);
            ShowLoseGame.SetActive(false);
            Resource.Instance.MinusHealth();
            
        }
        
        
        
        
    }
}