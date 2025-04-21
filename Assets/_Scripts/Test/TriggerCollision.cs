using System;
using UnityEngine;

namespace _Scripts.Test
{
    public class TriggerCollision : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log(other.gameObject.name);
        }
    }
}