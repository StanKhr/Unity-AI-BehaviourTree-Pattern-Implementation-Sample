using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Nodes;
using Demo.AI.Components;
using UnityEngine;

namespace Demo.AI.Tasks
{
    public class TaskReachFoundOreNode : Node
    {
        #region Constructors

        public TaskReachFoundOreNode(OreNodeCarrier oreNodeCarrier, Locomotion locomotion)
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
}