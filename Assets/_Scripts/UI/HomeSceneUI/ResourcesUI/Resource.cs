using _Scripts.Event;
using TMPro;
using UnityEngine;

namespace _Scripts.UI.HomeSceneUI.ResourcesUI
{
    public class Resource : MonoBehaviour
    {
        
        [SerializeField] private TMP_Text coin;
        [SerializeField] private TMP_Text heart;
        public Energy Energy;
        private int amountCoin = 0;
        
        public static Resource Instance;
        
        private void Awake()
        {
            if (Instance == null) {
                Instance = this;
               
            } else {
                Destroy (gameObject);
            }
           
        }
        
        public void OnEnable()
        {

            UpdateText();
            ResourceEvent.OnUpdateResource += UpdateText;
        }
        public void OnDisable()
        {
            // PlayerPrefs.SetInt("Coin", amountCoin);
            // PlayerPrefs.SetInt("Heart", amountHeart);
        }
        private void UpdateText()
        {
            amountCoin = PlayerPrefs.GetInt("Coin", 9000); 
            coin.text = amountCoin.ToString();
            
        }

        public void MinusHealth()
        {
            this.Energy.UseEnergy();
        }

        public void AddMaxHealth()
        {
            this.Energy.AddMaxEnergy();
            
        }
        
    }
}