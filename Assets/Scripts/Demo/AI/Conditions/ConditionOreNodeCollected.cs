using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Nodes;
using Demo.AI.Components;

namespace Demo.AI.Conditions
{
    public class ConditionOreNodeCollected : Node
    {
        #region Constructors

        public ConditionOreNodeCollected(OreNodeCarrier oreNodeCarrier, OreNodesStash oreNodesStash)
        {
            OreNodeCarrier = oreNodeCarrier;
            OreNodesStash = oreNodesStash;
        }

        #endregion

        #region Properties

        private OreNodeCarrier OreNodeCarrier { get; }
        private OreNodesStash OreNodesStash { get; }

        #endregion

        #region Methods

        public override NodeStateType Evaluate(float deltaTime)
        {
            var collectedSuccessfully = OreNodesStash.TryCollectOreNode(OreNodeCarrier.PickedOreNode);

            if (!collectedSuccessfully)
            {
                return NodeStateType.Failure;
            }

            OreNodeCarrier.DropPickedNode();

            return NodeStateType.Success;
        }

        #endregion
    }
}