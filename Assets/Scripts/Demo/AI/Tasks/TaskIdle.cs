using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Nodes;

namespace Demo.AI.Tasks
{
    public class TaskIdle : Node
    {
        #region Methods

        public override NodeStateType Evaluate(float deltaTime)
        {
            return NodeStateType.Running;
        }

        #endregion
    }
}