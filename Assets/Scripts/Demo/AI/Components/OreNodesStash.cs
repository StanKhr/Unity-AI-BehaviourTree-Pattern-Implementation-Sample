using System.Collections.Generic;
using Demo.Props;
using UnityEngine;

namespace Demo.AI.Components
{
    public class OreNodesStash : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private float _collectOreNodeDistance = 2f;

        #endregion
        
        #region Fields

        private readonly List<OreNode> _collectedOreNodes = new();

        #endregion

        #region Properties
        
        public List<OreNode> CollectedNodes => _collectedOreNodes;

        #endregion
        
        #region Methods

        public bool TryCollectOreNode(OreNode pickedOreNode)
        {
            if (!pickedOreNode)
            {
                return false;
            }

            var distance = Vector3.Distance(pickedOreNode.transform.position, transform.position);
            if (distance > _collectOreNodeDistance)
            {
                return false;
            }
            
            _collectedOreNodes.Add(pickedOreNode);

            return true;
        }

        #endregion
    }
}