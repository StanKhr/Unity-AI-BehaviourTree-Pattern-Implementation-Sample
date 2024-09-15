using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Nodes;
using Demo.AI.Components;

namespace Demo.AI.Conditions
{
    public class ConditionOreNodeFound : Node
    {
        #region Constructors

        public ConditionOreNodeFound(OreNodeCarrier oreNodeCarrier)
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
            return _oreNodeCarrier.FoundOreNode ? NodeStateType.Success : NodeStateType.Failure;
        }

        #endregion
    }
}