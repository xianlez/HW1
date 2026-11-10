using UnityEngine;

public class BatW6 : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;

    private Transform _target;

    public void Chase(Transform target)
    {
        _target = target;
    }

    public void StopChasing()
    {
        _target = null;
    }

    private void Update()
    {
        if (_target == null)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            _target.position,
            _moveSpeed * Time.deltaTime
        );
    }
}