using UnityEngine;

namespace _Scripts.HACK
{
    public class ResetLevel: MonoBehaviour
    {
        public void ResetLevelGamePlay()
        {
            PlayerPrefs.SetInt("Level", 1);
            int heart = PlayerPrefs.GetInt ("Heart");
            Debug.Log(heart);
            heart = 5;
            PlayerPrefs.SetInt ("Heart", heart);
            
        }
    }
}