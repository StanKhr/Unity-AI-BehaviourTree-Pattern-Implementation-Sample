using Core.BehaviourTree.Interfaces;
using UnityEngine;

namespace Core.BehaviourTree.Trees
{
    public abstract class BehaviourTree : MonoBehaviour
    {
        #region Constructors

        

        #endregion

        #region Fields

        private INode _root;

        #endregion

        #region Properties

        

        #endregion

        #region Unity Callbacks

        private void Start()
        {
            _root = BuildRootNode();
        }

        private void Update()
        {
            _root?.Evaluate(Time.deltaTime);
        }

        #endregion
        
        #region Methods

        protected abstract INode BuildRootNode();

        #endregion
    }
}