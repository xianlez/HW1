using UnityEngine;

public class CatW5 : MonoBehaviour
{
    [SerializeField] private bool _flipWSControls;
    [SerializeField] private float _moveSpeed = 1.0f;
    [SerializeField] private float _turnSpeed = 1.0f;
    [SerializeField] private Animator _animator;

    private string _isWalkingName = "IsWalking";

    private void Update()
    {
        Vector3 translation = Vector3.zero;

        // W 
        if (Input.GetKey(KeyCode.W))
        {
            translation += Vector3.forward;
        }

        // S 
        if (Input.GetKey(KeyCode.S))
        {
            translation += Vector3.back;
        }

        // 
        if (_flipWSControls)
        {
            translation *= -1;
        }

        transform.Translate(
            translation * _moveSpeed * Time.deltaTime
        );

        // A/D 
        float rotation = Input.GetAxis("Horizontal")
            * _turnSpeed * Time.deltaTime;

        transform.Rotate(0, rotation, 0);

        //
        if (translation.magnitude != 0.0f || rotation != 0.0f)
        {
            _animator.SetBool(_isWalkingName, true);
        }
        else
        {
            _animator.SetBool(_isWalkingName, false);
        }
    }
}