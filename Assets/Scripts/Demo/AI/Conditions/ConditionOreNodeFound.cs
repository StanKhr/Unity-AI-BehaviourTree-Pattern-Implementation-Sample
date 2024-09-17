﻿using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Nodes;
using Demo.AI.Components;

namespace Demo.AI.Conditions
{
    public class ConditionOreNodeFound : Node
    {

        #region Constructors

        public ConditionOreNodeFound(OreNodeCarrier oreNodeCarrier)
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
}