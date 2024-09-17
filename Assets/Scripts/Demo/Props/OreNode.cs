using Demo.AI.Components;
using UnityEngine;

namespace Demo.Props
{
    public class OreNode : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private Rigidbody _rigidbody;

        [Header("Settings")]
        [SerializeField] private float _throwForce = 5f;

        #endregion
        
        #region Properties

        public Vector3 Position => transform.position;

        #endregion

        #region Methods

        public void StopCarrying(OreNodeCarrier oreNodeCarrier)
        {
            if (transform.parent != oreNodeCarrier.OreCarryParentAnchor)
            {
                return;
            }

            transform.parent = null;
            _rigidbody.isKinematic = false;
            
            _rigidbody.AddForce(Vector3.up * _throwForce);
        }

        public void Carry(OreNodeCarrier oreNodeCarrier)
        {
            if (transform.parent == oreNodeCarrier.OreCarryParentAnchor)
            {
                return;
            }

            _rigidbody.velocity = Vector3.zero;
            _rigidbody.isKinematic = true;
            
            transform.parent = oreNodeCarrier.OreCarryParentAnchor;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }

        #endregion
    }
}