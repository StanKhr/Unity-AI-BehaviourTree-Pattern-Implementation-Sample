using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Nodes;
using Demo.AI.Components;
using UnityEngine;

namespace Demo.AI.Conditions
{
    public class ConditionFindAnyOreNode : Node
    {
        #region Constructors

        public ConditionFindAnyOreNode(OreNodeCarrier oreNodeCarrier)
        {
            _oreNodeCarrier = oreNodeCarrier;
        }

        #endregion

        #region Fields

        private readonly OreNodeCarrier _oreNodeCarrier;

        #endregion
        
        #region Methods

        public override NodeStateType Evaluate(float deltaTime)
        {
            if (_oreNodeCarrier.SearchForNode())
            {
                return NodeStateType.Success;
            }

            return NodeStateType.Failure;
        }

        #endregion
    }
}