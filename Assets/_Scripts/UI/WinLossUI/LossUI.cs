using System;
using _Scripts.ManagerScene;
using _Scripts.ManagerScene.HomeScene;
using _Scripts.UI.PauseGameUI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts.UI.WinLossUI
{
    public class LossUI: PauseGame
    {
        public Button playOnBtn;
        public Button retryBtn;
        public Button homeBtn;

        
        public float timeAdd = 60f;
        public int pricePlayOn = 600;
        private void Start()
        {
            playOnBtn.onClick.AddListener(OnClickPlayOnBtn);
            retryBtn.onClick.AddListener(OnClickRetryBtn);
            homeBtn.onClick.AddListener(OnClickHomeBtn);
        }

        private void OnClickHomeBtn()
        {
            this.gameObject.SetActive(false);
            SceneManager.LoadScene(EnumScene.HomeScene.ToString());
            ManagerHomeScene.Instance.ShowLoseGameUI();
        }

        private void OnClickRetryBtn()
        {
            AddTimeGamePlay();
            this.gameObject.SetActive(false);   
            
        }

        private void OnClickPlayOnBtn()
        {
            // Check if have enough gold then minus it and Add Time to the Game play 
            
           
            int coin = PlayerPrefs.GetInt("Coin");
            if (coin >= pricePlayOn)
            {
                AddTimeGamePlay();
                coin -= pricePlayOn;
                PlayerPrefs.SetInt("Coin", coin);
                this.gameObject.SetActive(false);   
            }
            
            
            
        }
        
        


        public void AddTimeGamePlay()
        {
            ColdownTime.Instance.AddTime(timeAdd);
        }
    }
}