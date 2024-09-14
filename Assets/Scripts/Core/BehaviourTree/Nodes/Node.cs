using Core.BehaviourTree.Enums;
using Core.BehaviourTree.Interfaces;

namespace Core.BehaviourTree.Nodes
{
    public abstract class Node : INode
    {
        #region Constructors

        protected Node()
        {
            Parent = null;
        }

        protected Node(INode[] children)
        {
            Children = new INode[children.Length];
            for (var i = 0; i < children.Length; i++)
            {
                var child = children[i];
                child.Parent = this;
                Children[i] = child;
            }
        }

        #endregion

        #region Fields

        // private readonly Dictionary<string, object> _dataContext = new();

        #endregion
        
        #region Properties

        public INode Parent { get; set; }
        protected INode[] Children { get; }

        #endregion

        #region Methods

        // public void SetData(string key, object data)
        // {
        //     _dataContext[key] = data;
        // }
        //
        // public object GetData(string key)
        // {
        //     if (_dataContext.TryGetValue(key, out var data))
        //     {
        //         return data;
        //     }
        //
        //     return Parent?.GetData(key);
        // }
        //
        // public bool ClearData(string key)
        // {
        //     if (_dataContext.ContainsKey(key))
        //     {
        //         _dataContext.Remove(key);
        //         return true;
        //     }
        //
        //     if (Parent == null)
        //     {
        //         return false;
        //     }
        //
        //     return Parent.ClearData(key);
        // }

        #endregion

        #region Abstract Methods
        
        public abstract NodeStateType Evaluate(float deltaTime);

        #endregion
    }
}
