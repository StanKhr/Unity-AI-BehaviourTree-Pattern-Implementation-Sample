using UnityEngine;

namespace Demo.AI.Components
{
    public class Locomotion : MonoBehaviour
    {
        #region Editor Fields

        [SerializeField] private CharacterController _characterController;

        [Header("Settings")]
        [SerializeField] private float _speed = 5f;


        #endregion

        #region Properties

        public Vector3 Position => _characterController.transform.position;

        #endregion

        #region Methods
        
        public void SetMoveDirection(Vector3 velocity)
        {
            _characterController.Move(velocity * (_speed * Time.deltaTime));
        }

        #endregion
    }
}