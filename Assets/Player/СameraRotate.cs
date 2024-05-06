using UnityEngine;

public class СameraRotate : MonoBehaviour
{
    [SerializeField] private Transform  _cameraTransform;

    [SerializeField] private float _minAngle = -20f;
    [SerializeField] private float _maxAngle = 40f;
    [SerializeField] private float _rotationSpeed = 300f;

    [SerializeField] private float _maxShakeAngle;
    [SerializeField] private float _shakeForce = 30f;

    [SerializeField] private PlayerMovement _playerMovement;

    private float _newAngleZ;
    private float newAngleZ;

    private void Start()
    {
        LockCursor();
    }
    private void Update()
    {
        CameraRotateUpdate();
    }

    private void CameraRotateUpdate()
    {
        var newAngleX = _cameraTransform.localEulerAngles.x - Input.GetAxis("Mouse Y") * _rotationSpeed * Time.deltaTime;
        if (newAngleX > 180)
            newAngleX -= 360;
        newAngleX = Mathf.Clamp(newAngleX, _minAngle, _maxAngle);

        var newAngleY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * _rotationSpeed * Time.deltaTime;

        transform.localEulerAngles = new Vector3(0, newAngleY, 0);
        CameraShakeUpdate(newAngleX);

    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void CameraShakeUpdate(float newAngleX)
    {
        
        if (_playerMovement.RightMoveCondition)
        {
            newAngleZ -= _shakeForce * Time.deltaTime;
            newAngleZ = Mathf.Clamp(newAngleZ, -_maxShakeAngle, _maxShakeAngle);
        }
        if (_playerMovement.LeftMoveCondition)
        {
            newAngleZ += _shakeForce * Time.deltaTime;
            newAngleZ = Mathf.Clamp(newAngleZ, -_maxShakeAngle, _maxShakeAngle);
        }

        if (!_playerMovement.IsCameraRotateCondition || (_playerMovement.LeftMoveCondition&&_playerMovement.RightMoveCondition))
        {
            if (newAngleZ != 0)
            {
                if (newAngleZ > 0 + 30f * Time.deltaTime)
                {
                    newAngleZ -= _shakeForce * Time.deltaTime;
                }
                else if (newAngleZ < 0 - 30f * Time.deltaTime)
                {
                    newAngleZ += _shakeForce * Time.deltaTime;
                }
                else
                {
                    newAngleZ = 0;
                }
            }
        }


        if (newAngleZ < 0)
        {
            _newAngleZ = 360 + newAngleZ;
        }
        else if (newAngleZ > 0)
        {
            _newAngleZ = newAngleZ;
        }


        _cameraTransform.localEulerAngles = new Vector3(newAngleX, 0, _newAngleZ);
    }
}
