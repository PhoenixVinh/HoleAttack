using _Scripts.Sound;
using UnityEngine;

namespace _Scripts.UI.HomeSceneUI.ButtonUI
{
    public class PlayBtn : ChangeSceneBtn
    {
        public override void ChangeScene()
        {
            ManagerSound.Instance.PlayEffectSound(EnumEffectSound.ButtonClick);
            int currentEnergy = PlayerPrefs.GetInt(StringPlayerPrefs.CURRENT_ENERGY, 0);
          
            if (currentEnergy == 0) return;
            base.ChangeScene();
          
        }
    }
}