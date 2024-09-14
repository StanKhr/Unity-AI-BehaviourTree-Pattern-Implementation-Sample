using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Interfaces;

namespace Core.BehaviourTree.Nodes
{
    /// <summary>
    /// Composite AND node; if any child fails, evaluation returns Failed state
    /// </summary>
    public class NodeSequence : Node
    {
        #region Constructors

        public NodeSequence(INode[] children) : base(children)
        {
            
        }

        #endregion
        
        #region Methods

        public override NodeStateType Evaluate(float deltaTime)
        {
            var anyChildIsRunning = false;

            foreach (var child in Children)
            {
                switch (child.Evaluate(deltaTime))
                {
                    case NodeStateType.Running:
                        anyChildIsRunning = true;
                        continue;
                    case NodeStateType.Success:
                        continue;
                    case NodeStateType.Failure:
                        return NodeStateType.Failure;
                }
            }

            return anyChildIsRunning ? NodeStateType.Running : NodeStateType.Success;
        }

        #endregion
    }
}