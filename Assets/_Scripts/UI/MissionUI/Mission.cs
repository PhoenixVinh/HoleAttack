using System;
using System.Collections;
using _Scripts.ObjectPooling;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.UI.MissionUI
{
    public class Mission : MonoBehaviour
    {
        
        public int amountItem;
        public string itemType;
        
        [SerializeField]private TMP_Text _text;
        [SerializeField]private Image image;


        public bool IsDone() => amountItem == 0;
        public int GetAmountItem() => amountItem;

        
        private string IdDotween = "MissionDT";

        public void SetData(MissionData missionData)
        {
            this.amountItem = missionData.AmountItems;
            this.itemType = missionData.idItem;
            _text.text = this.amountItem.ToString();
            image.sprite = missionData.image;    
        }
        public Sprite GetImage() => image.sprite;
        public void MinusItem(Vector3 positionMinus)
        {
            AddItem(positionMinus);
        }

        private void AddItem(Vector3 positionMinus)
        {
            amountItem--;
            amountItem = amountItem >= 0 ? amountItem : 0;
            
            GameObject EffectMission = MissionPooling.Instance.spawnImage();
            
            Vector3 screenPosition = UnityEngine.Camera.main.WorldToScreenPoint(positionMinus + new Vector3(0,0,5f));
            EffectMission.GetComponent<RectTransform>().position = screenPosition;

            EffectMission.GetComponent<Image>().sprite = image.sprite;
            EffectMission.SetActive(true);
            
            
            // Using Dotween To move Object
            
            EffectMission.transform.localScale = new Vector3(1, 1, 1) * 1.2f;
           
            DOTween.Sequence()
                .SetId(IdDotween)
                .Append(EffectMission.transform.DOMove(this.transform.position, 1.5f))
                .Join(EffectMission.transform.DOScale(new Vector3(0.7f, 0.7f, 0.7f), 1.5f))
                .SetUpdate(true)
                .OnComplete(delegate
                {
                    EffectMission.SetActive(false);
                    this._text.text = this.amountItem.ToString();
                });
        }

        private void OnDestroy()
        {
            //if(_sequence != null)
                //DOTween.Kill(_sequence);
            DOTween.Kill(IdDotween);
            
        }
    }
}