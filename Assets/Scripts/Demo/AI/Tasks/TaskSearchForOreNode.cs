using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Nodes;
using Demo.AI.Components;

namespace Demo.AI.Tasks
{
    public class TaskSearchForOreNode : Node
    {
        #region Constructors

        public TaskSearchForOreNode(OreNodeCarrier oreNodeCarrier)
        {
            _oreNodeCarrier = oreNodeCarrier;
        }

        #endregion

        #region Fields

        private readonly OreNodeCarrier _oreNodeCarrier;

        #endregion
        
        #region Methods

        public override NodeStateType Evaluate(float deltaTime)
        {
            if (_oreNodeCarrier.SearchForNode())
            {
                return NodeStateType.Success;
            }

            return NodeStateType.Failure;
        }

        #endregion
    }
}