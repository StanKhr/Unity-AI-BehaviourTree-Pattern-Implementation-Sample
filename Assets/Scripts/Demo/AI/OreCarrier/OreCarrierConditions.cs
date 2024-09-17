using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Nodes;
using Demo.AI.Components;

namespace Demo.AI.OreCarrier
{
    public static class OreCarrierConditions
    {
        public class IsCarryingOreNode : Node
        {
            public IsCarryingOreNode(OreNodeCarrier oreNodeCarrier)
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
        
        public class OreNodeCollected : Node
        {
            #region Constructors

            public OreNodeCollected(OreNodeCarrier oreNodeCarrier, OreNodesStash oreNodesStash)
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
        
        public class OreNodeFound : Node
        {

            #region Constructors

            public OreNodeFound(OreNodeCarrier oreNodeCarrier)
            {
                OreNodeCarrier = oreNodeCarrier;
            }

            #endregion

            #region Fields
        
            private OreNodeCarrier OreNodeCarrier { get; }
            #endregion

            #region Methods

            public override NodeStateType Evaluate(float deltaTime)
            {
                return OreNodeCarrier.FoundOreNode ? NodeStateType.Success : NodeStateType.Failure;
            }

            #endregion
        }
        
        public class OreNodeReached : Node
        {
            #region Constructors

            public OreNodeReached(OreNodeCarrier oreNodeCarrier)
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
}