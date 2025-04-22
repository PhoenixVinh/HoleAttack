using System;
using System.Threading.Tasks;
using _Scripts.Event;
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
            ShowLoseGame.SetActive(false);
        }



        public async void ShowLoseGameUI()
        {
            ShowLoseGame.SetActive(true);
            await Task.Delay(3000);
            ShowLoseGame.SetActive(false);
            int heart = PlayerPrefs.GetInt ("Heart");
            heart -= 1;
            PlayerPrefs.SetInt ("Heart", heart);
            ResourceEvent.OnUpdateResource?.Invoke();
        }
        
        
        
        
    }
}