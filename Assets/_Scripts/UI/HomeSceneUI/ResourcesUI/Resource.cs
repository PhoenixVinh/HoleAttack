using _Scripts.Event;
using TMPro;
using UnityEngine;

namespace _Scripts.UI.HomeSceneUI.ResourcesUI
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] private TMP_Text coin;
        [SerializeField] private TMP_Text heart;


        private int amountCoin = 0;
        private int amountHeart = 0;
        
        public void OnEnable()
        {

            UpdateText();
            ResourceEvent.OnUpdateResource += UpdateText;
        }
        public void OnDisable()
        {
            PlayerPrefs.SetInt("Coin", amountCoin);
            PlayerPrefs.SetInt("Heart", amountHeart);
        }
        private void UpdateText()
        {
            amountCoin = PlayerPrefs.GetInt("Coin", 9000); 
            amountHeart = PlayerPrefs.GetInt("Heart", 5);
            coin.text = amountCoin.ToString();
            heart.text = amountHeart.ToString();

        }
        
    }
}