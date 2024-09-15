using System;
using Demo.Props;
using UnityEngine;

namespace Demo.AI.Components
{
    public class OreNodeCarrier : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private Transform _carrierTransform;
        
        [Header("Settings")]
        [SerializeField] private LayerMask _oreNodeLayerMask;
        [SerializeField] private float _searchRadius;

        #endregion

        #region Fields

        private readonly Collider[] _searchResult = new Collider[10];

        #endregion
        
        #region Properties

        public OreNode FoundOreNode { get; private set; }

        #endregion

        #region Unity Callbacks

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_carrierTransform.position, _searchRadius);
        }

        #endregion

        #region Methods

        public bool SearchForNode()
        {
            FoundOreNode = null;
            Array.Clear(_searchResult, 0, _searchResult.Length);

            if (Physics.OverlapSphereNonAlloc(_carrierTransform.position, _searchRadius, _searchResult,
                    _oreNodeLayerMask) <= 0)
            {
                return false;
            }

            for (int i = 0; i < _searchResult.Length; i++)
            {
                if (!_searchResult[i].TryGetComponent<OreNode>(out var oreNode))
                {
                    continue;
                }

                FoundOreNode = oreNode;
                break;
            }

            // returns true if any ore node was found
            return FoundOreNode;
        }

        #endregion
    }
}