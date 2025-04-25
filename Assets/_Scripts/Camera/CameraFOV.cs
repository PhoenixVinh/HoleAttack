using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

namespace _Scripts.Camera
{
    public class CameraFOV : MonoBehaviour
    {
        public CinemachineVirtualCamera _virtualCamera;

        public float baseFOV = 60f;
        public float _targetFOV;

        private void Start()
        {
            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
            _targetFOV = _virtualCamera.m_Lens.FieldOfView;
        }


        private void OnEnable()
        {
            // HoleEvent.OnLevelUp += UpdateFOV;
            // HoleEvent.OnStartIncreaseSpecialSkill += UpdateFOVBySkill;
        }

        private void UpdateFOVBySkill(float timeskill)
        {
            StartCoroutine(UpdateFOVBySkillCoroutine(timeskill));
        }

        private IEnumerator UpdateFOVBySkillCoroutine(float timeskill)
        {
            _targetFOV *= 1.2f;
            yield return new WaitForSeconds(timeskill);
            _targetFOV /= 1.2f;
        }

        private void OnDisable()
        {
            HoleEvent.OnLevelUp -= UpdateFOV;
            HoleEvent.OnStartIncreaseSpecialSkill -= UpdateFOVBySkill;
        }


        private void FixedUpdate()
        {

            float addingFOV = HoleController.Instance.transform.localScale.x * 10f;
            
            
            _virtualCamera.m_Lens.FieldOfView =
                Mathf.Lerp(_virtualCamera.m_Lens.FieldOfView, baseFOV + addingFOV, Time.deltaTime);
        }

        private void UpdateFOV() 
        {
            // Change FOV of Camera;
            _targetFOV*= 1.1f;
           
        }
        
        
        
    }
}