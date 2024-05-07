//using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;

    public float Speed;

    public bool RightMoveCondition { get; private set; }
    public bool LeftMoveCondition { get; private set; }
    public bool ForwardMoveCondition { get; private set; }
    public bool BackMoveCondition { get; private set; }

    public bool IdleMoveCondition { get; private set; }

    public bool JumpMoveCondition { get; private set; }
    public bool IsCameraRotateCondition { get; private set; }

    private Vector3 _moveVector = Vector3.zero;


    private void Update()
    {
        MoveConditionUpdate();
        MoveVectorUpdate();
    }

    private void FixedUpdate()
    {
        _characterController.Move(_moveVector * Time.fixedDeltaTime);
    }

    private void MoveConditionUpdate()
    {
        RightMoveCondition = Input.GetKey(KeyCode.D);
        LeftMoveCondition = Input.GetKey(KeyCode.A);
        ForwardMoveCondition = Input.GetKey(KeyCode.W);
        BackMoveCondition = Input.GetKey(KeyCode.S);

        JumpMoveCondition = Input.GetKey(KeyCode.Space);

        IsCameraRotateCondition = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);

        IdleMoveCondition = !(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D));

    }

    private void MoveVectorUpdate()
    {
        _moveVector = Vector3.zero;
        if (RightMoveCondition)
        {
            _moveVector += transform.right * Speed;
        }
        if (LeftMoveCondition)
        {
            _moveVector -= transform.right * Speed;
        }
        if (ForwardMoveCondition)
        {
            _moveVector += transform.forward * Speed;
        }
        if (BackMoveCondition)
        {
            _moveVector -= transform.forward * Speed;
        }
    }
        

   

}
