using System;
using UnityEngine;

namespace _Scripts.Hole
{
    public class HoleMovement : MonoBehaviour, IMovement
    {
        private Vector2 _movementDirection;
        private float _speedMovement;
        
        
        
        public void Move(Vector2 movementDirection)
        {
            _movementDirection = movementDirection;
        }


        private void Update()
        {
            transform.Translate(new Vector3(_movementDirection.x, 0, _movementDirection.y)*_speedMovement*Time.deltaTime);
        }


        public void SetSpeedMovement(float speedMovement)
        {
            this._speedMovement = speedMovement;
        }
    }
}