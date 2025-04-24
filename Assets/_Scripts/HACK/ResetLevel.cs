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
            Resource.Instance.AddMaxCoin();
            PlayerPrefs.SetInt(StringPlayerPrefs.CURRENT_LEVEL, 1);
          
            PlayerPrefs.Save();
        }
    }
}