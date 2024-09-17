using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Nodes;
using Demo.AI.Components;

namespace Demo.AI.Conditions
{
    public class ConditionCarryingOreNode : Node
    {
        public ConditionCarryingOreNode(OreNodeCarrier oreNodeCarrier)
        {
            OreNodeCarrier = oreNodeCarrier;
        }

        #region Properties

        private OreNodeCarrier OreNodeCarrier { get; }

        #endregion

        #region Methods

        public override NodeStateType Evaluate(float deltaTime)
        {
            return OreNodeCarrier.PickedOreNode ? NodeStateType.Success : NodeStateType.Failure;
        }

        #endregion
    }
}