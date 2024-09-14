using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Interfaces;

namespace Core.BehaviourTree.Nodes
{
    public class NodeNegation : Node
    {
        #region Constructors

        public NodeNegation(INode node)
        {
            Node = node;
        }

        #endregion

        #region Properties

        private INode Node { get; }

        #endregion
        
        #region Methods

        public override NodeStateType Evaluate(float deltaTime)
        {
#pragma warning disable CS8524 // The switch expression does not handle some values of its input type (it is not exhaustive) involving an unnamed enum value.
            return Node.Evaluate(deltaTime) switch
#pragma warning restore CS8524 // The switch expression does not handle some values of its input type (it is not exhaustive) involving an unnamed enum value.
            {
                NodeStateType.Running => NodeStateType.Running,
                NodeStateType.Success => NodeStateType.Failure,
                NodeStateType.Failure => NodeStateType.Success,
            };
        }

        #endregion
    }
}