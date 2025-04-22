
using System.Collections;

using UnityEngine;



public enum LayerMaskVariable
{
    Collision,
    NoCollision,
}


public class HoleCenter : MonoBehaviour
{
    [Header("   Back Hole Variables ")]
    [SerializeField] private float _backHoleGravity = 1f;
    [SerializeField] private float _timeSuction = 0.3f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            var rb = other.transform.parent.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            other.transform.parent.Translate(new Vector3(0,0.1f,0));
            other.transform.parent.gameObject.layer = LayerMask.NameToLayer(LayerMaskVariable.NoCollision.ToString());
            other.gameObject.layer = LayerMask.NameToLayer(LayerMaskVariable.NoCollision.ToString());
            
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            other.gameObject.layer = LayerMask.NameToLayer(LayerMaskVariable.Collision.ToString());
            other.transform.parent.gameObject.layer = LayerMask.NameToLayer(LayerMaskVariable.Collision.ToString());
        }
    }
}