using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

namespace _Scripts.Camera
{
    public class CameraFOV : MonoBehaviour
    {
        public CinemachineVirtualCamera _virtualCamera;

        public float baseFOV = 10f;
        public float scaleByHole = 1f;
        public float _targetFOV;

        private void Start()
        {
            _virtualCamera = GetComponent<CinemachineVirtualCamera>();
            _targetFOV = _virtualCamera.m_Lens.OrthographicSize;
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

            float addingFOV = HoleController.Instance.transform.localScale.x * scaleByHole;
            
            
            _virtualCamera.m_Lens.OrthographicSize =
                Mathf.Lerp(_virtualCamera.m_Lens.OrthographicSize, baseFOV + addingFOV, Time.deltaTime);
        }

        private void UpdateFOV() 
        {
            // Change FOV of Camera;
            _targetFOV*= 1.1f;
           
        }
        
        
        
    }
}