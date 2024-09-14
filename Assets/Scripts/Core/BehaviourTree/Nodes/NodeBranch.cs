using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Interfaces;

namespace Core.BehaviourTree.Nodes
{
    public class NodeBranch : Node
    {
        #region Constructors

        public NodeBranch(INode conditionNode, INode successTransitionNode, INode failureTransitionNode)
        {
            ConditionNode = conditionNode;
            SuccessTransitionNode = successTransitionNode;
            FailureTransitionNode = failureTransitionNode;
        }

        #endregion

        #region Properties
        private INode ConditionNode { get; }
        private INode SuccessTransitionNode { get; }
        private INode FailureTransitionNode { get; }

        #endregion

        #region Methods

        public override NodeStateType Evaluate(float deltaTime)
        {
#pragma warning disable CS8524 // The switch expression does not handle some values of its input type (it is not exhaustive) involving an unnamed enum value.
            return ConditionNode.Evaluate(deltaTime) switch
#pragma warning restore CS8524 // The switch expression does not handle some values of its input type (it is not exhaustive) involving an unnamed enum value.
            {
                NodeStateType.Running => NodeStateType.Running,
                NodeStateType.Success => SuccessTransitionNode.Evaluate(deltaTime),
                NodeStateType.Failure => FailureTransitionNode.Evaluate(deltaTime),
            };
        }

        #endregion
    }
}