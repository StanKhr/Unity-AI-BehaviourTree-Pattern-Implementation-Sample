using Core.BehaviourTree.Interfaces;
using Core.BehaviourTree.Nodes;
using Core.BehaviourTree.Trees;
using Demo.AI.Components;
using Demo.AI.Conditions;
using Demo.AI.Tasks;
using UnityEngine;

namespace Demo.AI
{
    public class BehaviourTreeWorker : BehaviourTree
    {
        #region Editor Fields

        [SerializeField] private OreNodeCarrier _oreNodeCarrier;
        [SerializeField] private CharacterController _characterController;

        #endregion

        #region Fields

        

        #endregion
        
        #region Methods

        protected override INode BuildRootNode()
        {
            return new NodeSelector(new INode[]
            {
                new NodeBranch(
                    new ConditionFindAnyOreNode(_oreNodeCarrier),
                    new TaskPickUpOreNode(_oreNodeCarrier, _characterController),
                    new TaskIdle())
            });
        }

        #endregion
    }
}
