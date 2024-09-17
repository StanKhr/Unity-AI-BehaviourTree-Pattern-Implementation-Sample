using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Nodes;
using Demo.AI.Components;

namespace Demo.AI.Tasks
{
    public class TaskPickUpOreNode : Node
    {
        #region Constructors

        public TaskPickUpOreNode(OreNodeCarrier oreNodeCarrier)
        {
            OreNodeCarrier = oreNodeCarrier;
        }

        #endregion

        #region Properties

        private OreNodeCarrier OreNodeCarrier { get; }

        #endregion

        #region Methods

        public override NodeStateType Evaluate(float deltaTime)
        {
            return OreNodeCarrier.TryPickUpOreNode(OreNodeCarrier.FoundOreNode)
                ? NodeStateType.Success
                : NodeStateType.Failure;
        }

        #endregion
    }
}