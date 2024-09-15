using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Nodes;
using Demo.AI.Components;
using UnityEngine;

namespace Demo.AI.Tasks
{
    public class TaskFollowOreNode : Node
    {
        #region Constants

        private const float MoveSpeedMultiplier = 5f;

        #endregion
        
        #region Constructors

        public TaskFollowOreNode(OreNodeCarrier oreNodeCarrier, CharacterController characterController)
        {
            _oreNodeCarrier = oreNodeCarrier;
            _characterController = characterController;
        }

        #endregion

        #region Fields

        private readonly OreNodeCarrier _oreNodeCarrier;
        private readonly CharacterController _characterController;

        #endregion

        #region Methods

        public override NodeStateType Evaluate(float deltaTime)
        {
            var moveDirection = _oreNodeCarrier.FoundOreNode.Position - _characterController.transform.position;
            moveDirection.Normalize();
            
            _characterController.Move(moveDirection * (MoveSpeedMultiplier * deltaTime));
            
            return NodeStateType.Running;
        }

        #endregion
    }
}