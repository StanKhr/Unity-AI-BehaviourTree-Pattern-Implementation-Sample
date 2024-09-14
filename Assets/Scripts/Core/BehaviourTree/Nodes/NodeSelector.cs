using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Interfaces;

namespace Core.BehaviourTree.Nodes
{
    /// <summary>
    /// Composite OR node; fails only if every child is failed
    /// </summary>
    public class NodeSelector : Node
    {
        #region Constructors

        public NodeSelector(INode[] children) : base(children)
        {
            
        }

        #endregion
        
        #region Methods

        public override NodeStateType Evaluate(float deltaTime)
        {
            foreach (var child in Children)
            {
                switch (child.Evaluate(deltaTime))
                {
                    case NodeStateType.Running:
                        return NodeStateType.Running;
                    case NodeStateType.Success:
                        return NodeStateType.Success;
                    case NodeStateType.Failure:
                        continue;
                }
            }

            return NodeStateType.Failure;
        }

        #endregion
    }
}