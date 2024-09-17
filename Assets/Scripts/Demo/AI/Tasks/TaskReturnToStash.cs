using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Nodes;
using Demo.AI.Components;

namespace Demo.AI.Tasks
{
    public class TaskReturnToStash : Node
    {

        #region Constructors

        public TaskReturnToStash(Locomotion locomotion, OreNodesStash oreNodesStash)
        {
            Locomotion = locomotion;
            OreNodesStash = oreNodesStash;
        }

        #endregion

        #region Properties
        
        private Locomotion Locomotion { get; }
        private OreNodesStash OreNodesStash { get; }

        #endregion

        #region Methods

        public override NodeStateType Evaluate(float deltaTime)
        {
            var moveDirection = OreNodesStash.transform.position - Locomotion.Position;
            moveDirection.y = 0f;
            moveDirection.Normalize();
            
            Locomotion.SetMoveDirection(moveDirection);
            
            return NodeStateType.Running;
        }

        #endregion
    }
}