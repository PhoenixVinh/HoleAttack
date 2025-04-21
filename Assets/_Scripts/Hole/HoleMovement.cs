using System;
using Unity.VisualScripting;
using UnityEngine;

namespace _Scripts.Hole
{
    public class HoleMovement : MonoBehaviour, IMovement
    {
        private Vector2 _movementDirection;
        private float _speedMovement;
        private bool canMove = true;
  
        
        
        public void Move(Vector2 movementDirection)
        {
            _movementDirection = movementDirection;
        }


        private void FixedUpdate()
        {
            
            CheckCanMove();
            if (canMove)
            {
                transform.Translate(new Vector3(_movementDirection.x, 0, _movementDirection.y)*_speedMovement*Time.deltaTime);
            }
        }





        public void CheckCanMove()
        {
            RaycastHit hitInfo;
            Physics.Raycast(transform.position, new Vector3(_movementDirection.x, 0, _movementDirection.y), out hitInfo, 1f * HoleController.Instance.GetCurrentScale(), LayerMask.GetMask("Bound"));
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.gameObject.CompareTag("Wall"))
                {
                    Debug.Log(hitInfo.collider.gameObject.name);
                    canMove = false;
                }
            }
            else canMove = true;
        }





        public void SetSpeedMovement(float speedMovement)
        {
            this._speedMovement = speedMovement;
        }

        public void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position,  new Vector3(_movementDirection.x, 0, _movementDirection.y) * 2);
        }
    }
}