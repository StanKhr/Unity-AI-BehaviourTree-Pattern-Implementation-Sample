using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Nodes;
using Demo.AI.Components;

namespace Demo.AI.Conditions
{
    public class ConditionOreNodeReached : Node
    {
        #region Constructors

        public ConditionOreNodeReached(OreNodeCarrier oreNodeCarrier)
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
            return _oreNodeCarrier.CanPickUpOreNode() ? NodeStateType.Success : NodeStateType.Failure;
        }

        #endregion
    }
}