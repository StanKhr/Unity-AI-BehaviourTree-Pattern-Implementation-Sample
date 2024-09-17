using Core.BehaviourTree.Enums;

namespace Core.BehaviourTree.Nodes
{
    public class NodeIdle : Node
    {
        #region Methods

        public override NodeStateType Evaluate(float deltaTime)
        {
            return NodeStateType.Running;
        }

        #endregion
    }
}