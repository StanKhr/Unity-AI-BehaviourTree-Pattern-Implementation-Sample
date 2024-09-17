using System;
using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Interfaces;

namespace Core.BehaviourTree.Nodes
{
    /// <summary>
    /// Will only transition whenever the condition node returns success
    /// </summary>
    public class NodeBranchSuccessOnly : Node
    {
        #region Constructors

        public NodeBranchSuccessOnly(INode conditionNode, INode successNode)
        {
            ConditionNode = conditionNode;
            SuccessNode = successNode;
        }
        
        #endregion

        #region Properties

        private INode ConditionNode { get; }
        private INode SuccessNode { get; }

        #endregion

        #region Methods

        public override NodeStateType Evaluate(float deltaTime)
        {
            return ConditionNode.Evaluate(deltaTime) switch
            {
                NodeStateType.Running => NodeStateType.Running,
                NodeStateType.Success => SuccessNode.Evaluate(deltaTime),
                NodeStateType.Failure => NodeStateType.Running,
                _ => NodeStateType.Running
            };
        }

        #endregion
    }
}