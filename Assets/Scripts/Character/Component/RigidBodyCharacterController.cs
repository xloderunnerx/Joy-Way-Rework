using Character.SO;
using Sirenix.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Character.Component
{
    /// <summary>
    /// Да, с первого взгляда может показаться, что здесь происходит что-то невнятное. 
    /// Дело в том, что я не очень хотел юзать чарактер контроллер из коробки, потому что хотелось использовать физику для передвижения.
    /// И это встает в определенную цену, приходится писать такие вот конструкции, чтобы камера следовала за позицией тела, а тело поворачивалось на угол поворота камеры.
    /// Иначе камера статтерит, джиттерит, вот это вот все, очень некрасиво.
    /// </summary>
    public class RigidBodyCharacterController : MonoBehaviour
    {
        [Inject] private CharacterInput characterInput;

        [SerializeField] private CharacterControllerSettings characterControllerSettings;
        [SerializeField] private Camera _camera;
        [SerializeField] private Rigidbody _rigidbody;

        private Vector3 resultMovementVelocity;
        private Vector3 resultRotationAngle;
        private Vector3 cameraOffset;

        private void Awake()
        {
            DisableCursor();   
        }

        void Update()
        {
            UpdateInput();
        }

        private void LateUpdate()
        {
            characterControllerSettings.CameraRotationBehaviour.Rotate(_camera.transform, new Vector3(resultRotationAngle.x, 0, resultRotationAngle.y));
            _camera.transform.position = _rigidbody.transform.position + cameraOffset;
        }

        private void FixedUpdate()
        {
            characterControllerSettings.MovementBehaviour.Move(_rigidbody, resultMovementVelocity);
            _rigidbody.MoveRotation(Quaternion.Euler(0, _camera.transform.eulerAngles.y, 0));
        }

        private void DisableCursor()
        {
            cameraOffset = _camera.transform.localPosition;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void UpdateInput()
        {
            resultMovementVelocity = _rigidbody.transform.right * characterInput.Horizontal + _rigidbody.transform.forward * characterInput.Vertical;
            resultRotationAngle = new Vector3(characterInput.MouseX, characterInput.MouseY, 0);
        }
    }
}