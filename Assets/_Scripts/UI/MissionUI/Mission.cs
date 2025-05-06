using System;
using System.Collections;
using _Scripts.Effects;
using _Scripts.ObjectPooling;
using _Scripts.Sound;
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

        
        [SerializeField] private ParticleSystem particle;

        public bool IsDone() => amountItem == 0;
        public int GetAmountItem() => amountItem;

        
        private string IdDotween = "MissionDT";

        public void SetData(MissionData missionData)
        {
            particle.Stop();
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
            
            
            GameObject EffectMission = MissionPooling.Instance.spawnImage();
            
            Vector3 screenPosition = UnityEngine.Camera.main.WorldToScreenPoint(positionMinus + new Vector3(0,0,5f));
            EffectMission.GetComponent<RectTransform>().position = screenPosition;

            EffectMission.GetComponent<Image>().sprite = image.sprite;
            EffectMission.SetActive(true);
            
            
            // Using Dotween To move Object
            if (ManagerSound.Instance != null)
            {
                ManagerSound.Instance.PlayEffectSound(EnumEffectSound.ItemMission);
            }
            
            
            EffectMission.transform.localScale = new Vector3(1, 1, 1) * 1.2f;
            amountItem--;
            amountItem = amountItem >= 0 ? amountItem : 0;
            DOTween.Sequence()
                .SetId(IdDotween)
                .Append(EffectMission.transform.DOMove(this.transform.position, 1.2f))
                .Join(EffectMission.transform.DOScale(new Vector3(0.7f, 0.7f, 0.7f), 1.2f))
                .SetUpdate(true)
                .OnComplete(delegate
                {
                    EffectMission.SetActive(false);
                    
                    DOTween.Sequence()
                        .Append(transform.DOScale(Vector3.one*1.2f, 0.2f))
                        .Append(transform.DOScale(Vector3.one, 0.1f));
                    this._text.text = this.amountItem.ToString();
                    particle.Play();
                    
                });
            
        }

        private void OnDestroy()
        {
            
            DOTween.Kill(IdDotween);
            DOTween.KillAll();

        }
    }
}