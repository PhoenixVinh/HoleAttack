using UnityEngine;

namespace _Scripts.UI.HomeSceneUI.ButtonUI
{
    public class PlayBtn : ChangeSceneBtn
    {
        public override void ChangeScene()
        {
            int currentEnergy = PlayerPrefs.GetInt(StringPlayerPrefs.CURRENT_ENERGY, 0);
            Debug.Log(currentEnergy);
            if (currentEnergy == 0) return;
            base.ChangeScene();
        }
    }
}