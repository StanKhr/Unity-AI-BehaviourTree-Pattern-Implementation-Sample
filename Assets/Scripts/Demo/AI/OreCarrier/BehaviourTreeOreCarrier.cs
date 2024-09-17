using Core.BehaviourTree.Interfaces;
using Core.BehaviourTree.Nodes;
using Core.BehaviourTree.Trees;
using Demo.AI.Components;
using UnityEngine;

namespace Demo.AI.OreCarrier
{
    public class BehaviourTreeOreCarrier : BehaviourTree
    {
        #region Editor Fields

        [SerializeField] private OreNodeCarrier _oreNodeCarrier;
        [SerializeField] private Locomotion _locomotion;
        [SerializeField] private OreNodesStash _oreNodesStash;

        #endregion

        #region Methods

        protected override INode BuildRootNode()
        {
            return new NodeSelector(new INode[]
            {
                new NodeBranchSuccessOnly
                (
                    new OreCarrierConditions.IsCarryingOreNode(_oreNodeCarrier),
                    new NodeBranchSuccessOnly
                    (
                        new NodeNegation(new OreCarrierConditions.OreNodeCollected(_oreNodeCarrier, _oreNodesStash)),
                        new OreCarrierTasks.ReturnToStash(_locomotion, _oreNodesStash)
                    )
                ),
                new NodeBranch
                (
                    new OreCarrierConditions.OreNodeFound(_oreNodeCarrier),
                    new NodeBranch
                    (
                        new NodeNegation(new OreCarrierConditions.OreNodeReached(_oreNodeCarrier)),
                        new OreCarrierTasks.ReachFoundOreNode(_oreNodeCarrier, _locomotion),
                        new OreCarrierTasks.PickUpOreNode(_oreNodeCarrier)
                    ),
                    new OreCarrierTasks.SearchForOreNode(_oreNodeCarrier, _oreNodesStash)
                )
            });
        }

        #endregion
    }
}