using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Nodes;
using Demo.AI.Components;

namespace Demo.AI.OreCarrier
{
    public static class OreCarrierTasks
    {
        public class PickUpOreNode : Node
        {
            #region Constructors

            public PickUpOreNode(OreNodeCarrier oreNodeCarrier)
            {
                OreNodeCarrier = oreNodeCarrier;
            }

            #endregion

            #region Properties

            private OreNodeCarrier OreNodeCarrier { get; }

            #endregion

            #region Methods

            public override NodeStateType Evaluate(float deltaTime)
            {
                return OreNodeCarrier.TryPickUpOreNode(OreNodeCarrier.FoundOreNode)
                    ? NodeStateType.Success
                    : NodeStateType.Failure;
            }

            #endregion
        }
        
        public class ReachFoundOreNode : Node
        {
            #region Constructors

            public ReachFoundOreNode(OreNodeCarrier oreNodeCarrier, Locomotion locomotion)
            {
                OreNodeCarrier = oreNodeCarrier;
                Locomotion = locomotion;
            }

            #endregion

            #region Properties

            private OreNodeCarrier OreNodeCarrier { get; }
            private Locomotion Locomotion { get; }

            #endregion

            #region Methods

            public override NodeStateType Evaluate(float deltaTime)
            {
                var moveDirection = OreNodeCarrier.FoundOreNode.Position - Locomotion.Position;
                moveDirection.y = 0f;
                moveDirection.Normalize();
            
                Locomotion.SetMoveDirection(moveDirection);
            
                return NodeStateType.Running;
            }

            #endregion
        }
        
        public class ReturnToStash : Node
        {

            #region Constructors

            public ReturnToStash(Locomotion locomotion, OreNodesStash oreNodesStash)
            {
                Locomotion = locomotion;
                OreNodesStash = oreNodesStash;
            }

            #endregion

            #region Properties
        
            private Locomotion Locomotion { get; }
            private OreNodesStash OreNodesStash { get; }

            #endregion

            #region Methods

            public override NodeStateType Evaluate(float deltaTime)
            {
                var moveDirection = OreNodesStash.transform.position - Locomotion.Position;
                moveDirection.y = 0f;
                moveDirection.Normalize();
            
                Locomotion.SetMoveDirection(moveDirection);
            
                return NodeStateType.Running;
            }

            #endregion
        }
        
        public class SearchForOreNode : Node
        {
            #region Constructors

            public SearchForOreNode(OreNodeCarrier oreNodeCarrier, OreNodesStash oreNodesStash)
            {
                OreNodeCarrier = oreNodeCarrier;
                OreNodesStash = oreNodesStash;
            }

            #endregion

            #region Fields

            private OreNodeCarrier OreNodeCarrier { get; }
            private OreNodesStash OreNodesStash { get; }

            #endregion
        
            #region Methods

            public override NodeStateType Evaluate(float deltaTime)
            {
                if (OreNodeCarrier.SearchForNode(OreNodesStash.CollectedNodes))
                {
                    return NodeStateType.Success;
                }

                return NodeStateType.Failure;
            }

            #endregion
        }
    }
}