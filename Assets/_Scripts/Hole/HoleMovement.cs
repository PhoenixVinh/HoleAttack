using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace _Scripts.Hole
{
    public class HoleMovement : MonoBehaviour, IMovement
    {
        private Vector2 _movementDirection;
        private float _speedMovement;
        private bool canMove = true;

        

        public Vector2 GetDirectionMovement() => _movementDirection;
        
        public Rigidbody rb;



        private Collider[] hits;
        
        public void Move(Vector2 movementDirection)
        {
            _movementDirection = movementDirection;
        }

        private void Awake()
        {
          
            hits = new Collider[5];
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
            // RaycastHit hitInfo;
            // Physics.Raycast(transform.position, new Vector3(_movementDirection.x, 0, _movementDirection.y), out hitInfo, 1f * HoleController.Instance.GetCurrentScale(), LayerMask.GetMask("Bound"));
            // if (hitInfo.collider != null)
            // {
            //     if (hitInfo.collider.gameObject.CompareTag("Wall"))
            //     {
            //         Debug.Log(hitInfo.collider.gameObject.name);
            //         canMove = false;
            //     }
            // }
            // else canMove = true;
            
            
             Vector3 directionNormalized = new Vector3(_movementDirection.x, 0, _movementDirection.y).normalized;
         
            // // Calculate Max Position Can reach 
            Vector3 newCircleCenter = new Vector3(transform.position.x, 0, transform.position.z) +directionNormalized*_speedMovement/2;
            
            //
            // int numberOfPoints = 8;
            float radius = HoleController.Instance.GetCurrentRadius()/2f;
            
            
            
            int numberCollider = Physics.OverlapSphereNonAlloc(newCircleCenter, radius, hits, LayerMask.GetMask("Bound"));
           
            canMove = numberCollider == 0;
            //
            // List<Vector3> checkpoints  = new List<Vector3>();
            // // Tính toán các điểm
            // for (int i = 0; i < numberOfPoints; i++)
            // {
            //     // Tính góc theta
            //     float theta = i * 2 * Mathf.PI / numberOfPoints;
            //
            //     // Tính tọa độ x, y
            //     float x = newCircleCenter.x + radius * Mathf.Cos(theta);
            //     float y = newCircleCenter.z + radius * Mathf.Sin(theta);
            //
            //     checkpoints.Add(new Vector3(x, areaCanMove.transform.position.y, y));
            // }
            // bool checkOk = true;
            // foreach (var point in checkpoints)
            // {
            //     if (!areaCanMove.bounds.Contains(point))
            //     {
            //         checkOk = false;
            //         break;
            //     }
            // }
            // canMove = checkOk;
            //
            
        }





        public void SetSpeedMovement(float speedMovement)
        {
            this._speedMovement = speedMovement;
        }

      

        public void OnDrawGizmosSelected()
        {
            // Vector3 directionNormalized = new Vector3(_movementDirection.x, 0, _movementDirection.y).normalized;
            // Debug.Log(directionNormalized);
            //
            // // Calculate Max Position Can reach 
            // Vector3 newCircleCenter = new Vector3(transform.position.x, 0, transform.position.z) +directionNormalized*_speedMovement;
            //
            // newCircleCenter.y = 0;
            // // Vector3 checkpointPosition = newCircleCenter + directionNormalized*HoleController.Instance.GetCurrentRadius();
            // // checkpointPosition.y = 0;
            //
            //
            // Gizmos.DrawSphere(newCircleCenter, 2f);
        }
    }
}