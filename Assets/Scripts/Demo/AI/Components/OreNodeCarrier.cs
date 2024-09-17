using System;
using System.Collections.Generic;
using Core.BehaviourTree.Enums;
using Demo.Props;
using UnityEngine;

namespace Demo.AI.Components
{
    public class OreNodeCarrier : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private Transform _carrierTransform;
        [SerializeField] private Transform _oreCarryParentAnchor;
        
        [Header("Settings")]
        [SerializeField] private LayerMask _oreNodeLayerMask;
        [SerializeField] private float _searchRadius;
        [SerializeField] private float _pickUpDistance = 1f;

        #endregion

        #region Fields

        private readonly Collider[] _searchResult = new Collider[10];

        private OreNode _pickedOreNode;

        #endregion
        
        #region Properties

        private Vector3 Position => _carrierTransform.position;
        public OreNode FoundOreNode { get; private set; }
        public OreNode PickedOreNode
        {
            get => _pickedOreNode;
            private set
            {
                if (_pickedOreNode)
                {
                    _pickedOreNode.StopCarrying(this);
                }

                _pickedOreNode = value;

                if (_pickedOreNode)
                {
                    _pickedOreNode.Carry(this);
                }
            }
        }
        public Transform OreCarryParentAnchor => _oreCarryParentAnchor;

        #endregion

        #region Unity Callbacks

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(Position, _searchRadius);
        }

        #endregion

        #region Methods

        public bool TryPickUpOreNode(OreNode oreNode)
        {
            if (!CanPickUpOreNode())
            {
                return false;
            }

            PickedOreNode = oreNode;

            return PickedOreNode;
        }

        public void DropPickedNode()
        {
            if (!PickedOreNode)
            {
                return;
            }

            PickedOreNode = null;
        }

        public bool CanPickUpOreNode()
        {
            if (!FoundOreNode)
            {
                return false;
            }

            return Vector3.Distance(FoundOreNode.Position, Position) <= _pickUpDistance;
        }

        public bool SearchForNode(List<OreNode> excludedOreNodes = null)
        {
            FoundOreNode = null;
            Array.Clear(_searchResult, 0, _searchResult.Length);

            if (Physics.OverlapSphereNonAlloc(Position, _searchRadius, _searchResult,
                    _oreNodeLayerMask) <= 0)
            {
                return false;
            }

            for (int i = 0; i < _searchResult.Length; i++)
            {
                if (!_searchResult[i])
                {
                    continue;
                }
                
                if (!_searchResult[i].TryGetComponent<OreNode>(out var oreNode))
                {
                    continue;
                }

                if (excludedOreNodes == null)
                {
                    FoundOreNode = oreNode;
                    break;
                }

                if (excludedOreNodes.Contains(oreNode))
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