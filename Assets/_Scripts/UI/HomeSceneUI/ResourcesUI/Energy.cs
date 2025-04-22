using System;
using UnityEngine;

namespace _Scripts.UI.HomeSceneUI.ResourcesUI
{
    public class Energy : MonoBehaviour
    {
        [SerializeField] private int maxEnergy = 25;
        private int currentEnergy;
        [SerializeField] private int restoreDuration = 100;

        private DateTime nextEnergyTime;
        private DateTime lastEnergyTime;
        private bool isRestoring = false;

        private void Start()
        {
            
        }



        private DateTime StringToDate(string date)
        {
            if (String.IsNullOrEmpty(date))
            {
                return DateTime.Now;
            }
            else
            {
                return DateTime.Parse(date);
            }
        }

        private void Load()
        {
            currentEnergy = PlayerPrefs.GetInt("currentEnergy");
            nextEnergyTime = StringToDate(PlayerPrefs.GetString("nextEnergyTime"));
            lastEnergyTime = StringToDate(PlayerPrefs.GetString("lastEnergyTime"));
            
            
        }



        private void Save()
        {
            PlayerPrefs.SetInt("currentEnergy", currentEnergy);
            PlayerPrefs.SetString("nextEnergyTime", nextEnergyTime.ToString());
            PlayerPrefs.SetString("lastEnergyTime", lastEnergyTime.ToString());
        }
    }
}