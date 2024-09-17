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

        public NodeBranchSuccessOnly(INode conditionNode, INode successNode, bool continueRunningIfFailed = false)
        {
            ConditionNode = conditionNode;
            SuccessNode = successNode;
            ContinueRunningIfFailed = continueRunningIfFailed;
        }
        
        #endregion

        #region Properties

        private INode ConditionNode { get; }
        private INode SuccessNode { get; }
        private bool ContinueRunningIfFailed { get; }

        #endregion

        #region Methods

        public override NodeStateType Evaluate(float deltaTime)
        {
#pragma warning disable CS8524 // The switch expression does not handle some values of its input type (it is not exhaustive) involving an unnamed enum value.
            return ConditionNode.Evaluate(deltaTime) switch
#pragma warning restore CS8524 // The switch expression does not handle some values of its input type (it is not exhaustive) involving an unnamed enum value.
            {
                NodeStateType.Running => NodeStateType.Running,
                NodeStateType.Success => SuccessNode.Evaluate(deltaTime),
                NodeStateType.Failure => ContinueRunningIfFailed ? NodeStateType.Running : NodeStateType.Failure,
            };
        }

        #endregion
    }
}