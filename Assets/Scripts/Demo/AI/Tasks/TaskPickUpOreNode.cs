using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Nodes;
using Demo.AI.Components;
using UnityEngine;

namespace Demo.AI.Tasks
{
    public class TaskPickUpOreNode : Node
    {
        #region Constructors

        public TaskPickUpOreNode(OreNodeCarrier oreNodeCarrier, CharacterController characterController)
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
            
            return NodeStateType.Running;
        }

        #endregion
    }
}