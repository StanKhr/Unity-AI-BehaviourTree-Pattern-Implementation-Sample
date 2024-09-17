﻿using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Nodes;
using Demo.AI.Components;

namespace Demo.AI.Tasks
{
    public class TaskSearchForOreNode : Node
    {
        #region Constructors

        public TaskSearchForOreNode(OreNodeCarrier oreNodeCarrier, OreNodesStash oreNodesStash)
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