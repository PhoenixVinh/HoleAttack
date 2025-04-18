using System;
using System.Collections.Generic;
using _Scripts.Event;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.UI.MissionUI
{
    public class ManagerMission : MonoBehaviour
    {
        public static ManagerMission Instance;
        
        
        public GameObject Mission;
        
        // Misition For One Level => Get next level using Addressable
        public MissionSO MissionsSO;
        
        
        public Dictionary<string, Mission> TypeItems = new Dictionary<string, Mission>();

        private void Awake()
        {
            Instance = this;
            //Genetate Data for Mission 
            CreateMissions();


        }

        private void CreateMissions()
        {
            foreach (var missionSo in MissionsSO.misstionsData)
            {
                GameObject mission = Instantiate(Mission, transform);
                mission.name = "Mission";
                mission.GetComponent<Mission>().SetData(missionSo);
                TypeItems[missionSo.idItem] = mission.GetComponent<Mission>();
            }
        }


        public void CheckMinusItems(string itemType, Vector3 position)
        {
            if (!TypeItems.ContainsKey(itemType)) return;
            TypeItems[itemType].MinusItem(position);
            if (TypeItems[itemType].IsDone())
            {
                TypeItems.Remove(itemType);
            }
        }

        public Sprite GetSprite(string itemType)
        {
            if (!TypeItems.ContainsKey(itemType)) return null;
            return TypeItems[itemType].GetImage();
        }
        
        
        public Dictionary<string, int> GetSuggestItems(int amount)
        {
            Dictionary<string, int > results = new Dictionary<string, int >();
            
            int amountTypeItem = Mathf.CeilToInt(TypeItems.Count / 2);
            amountTypeItem = amountTypeItem <= 3 ? amountTypeItem : 3;
            int indexRandom = -1;
            List<string> typeItemString = new List<string>();
            int amountSussgest = 0;
            foreach (var item in TypeItems)
            {
                typeItemString.Add(item.Key);
                
            }

            for (int i = 0; i < amountTypeItem + 1; i++)
            {
                amountSussgest += TypeItems[typeItemString[i]].GetAmountItem();
            }

            amount = amount <= amountSussgest ? amount : amountSussgest;
            
            for (int i = 0; i < amount; i++)
            {
                indexRandom = Random.Range(0, amountTypeItem + 1);
                if(!results.ContainsKey(typeItemString[indexRandom]))
                {
                    results[typeItemString[indexRandom]] = 1;
                }else
                {
                    if (TypeItems[typeItemString[indexRandom]].amountItem > results[typeItemString[indexRandom]])
                    {
                        results[typeItemString[indexRandom]]++;
                    }
                }
            }
            return results;
        }
    }
}