using Core.BehaviourTree.Interfaces;
using Core.BehaviourTree.Nodes;
using Core.BehaviourTree.Trees;
using Demo.AI.Components;
using Demo.AI.Conditions;
using Demo.AI.Tasks;
using UnityEngine;

namespace Demo.AI.Main
{
    public class BehaviourTreeWorker : BehaviourTree
    {
        #region Editor Fields

        [SerializeField] private OreNodeCarrier _oreNodeCarrier;
        [SerializeField] private Locomotion _locomotion;
        [SerializeField] private OreNodesStash _oreNodesStash;

        #endregion

        #region Fields

        #endregion

        #region Methods

        protected override INode BuildRootNode()
        {
            return new NodeSelector(new INode[]
            {
                new NodeBranchSuccessOnly
                (
                    new ConditionCarryingOreNode(_oreNodeCarrier),
                    new NodeBranchSuccessOnly
                    (
                        new NodeNegation(new ConditionOreNodeCollected(_oreNodeCarrier, _oreNodesStash)),
                        new TaskReturnToStash(_locomotion, _oreNodesStash)
                    )
                ),
                new NodeBranch
                (
                    new ConditionOreNodeFound(_oreNodeCarrier),
                    new NodeBranch
                    (
                        new NodeNegation(new ConditionOreNodeReached(_oreNodeCarrier)),
                        new TaskReachFoundOreNode(_oreNodeCarrier, _locomotion),
                        new TaskPickUpOreNode(_oreNodeCarrier)
                    ),
                    new TaskSearchForOreNode(_oreNodeCarrier, _oreNodesStash)
                )
            });
        }

        #endregion
    }
}