using _Scripts.Event;
using _Scripts.UI;
using _Scripts.UI.HomeSceneUI.ResourcesUI;
using UnityEngine;

namespace _Scripts.HACK
{
    public class ResetLevel: MonoBehaviour
    {
        public void ResetLevelGamePlay()
        {
            Resource.Instance.AddMaxHealth();
            PlayerPrefs.SetInt("Level", 1);
            PlayerPrefs.Save();
        }
    }
}