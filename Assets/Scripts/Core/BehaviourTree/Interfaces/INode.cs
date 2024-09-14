using Core.BehaviourTree.Enums;

namespace Core.BehaviourTree.Interfaces
{
    public interface INode
    {
        #region Properties

        INode Parent { get; set; }

        #endregion
        
        #region Methods

        NodeStateType Evaluate(float deltaTime);
        // void SetData(string key, object data);
        // object GetData(string key);
        // bool ClearData(string key);

        #endregion
    }
}