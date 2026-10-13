using TMPro;
using UnityEngine;

public class BallW3 : MonoBehaviour
{
    public SpriteRenderer ballRenderer;

    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speedMultiplier = 1.0f;
    [SerializeField] private float _speedThreshold = 10.0f;

    // Unity calls this method when the ball hits something.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // STEP 1: Adjust the ball's velocity.
        _rigidbody.linearVelocity *= _speedMultiplier;

        // STEP 9: Apply the color multiplier.
        ballRenderer.color *= GetColorMultiplier(
            Mathf.Abs(_rigidbody.linearVelocity.x),
            Mathf.Abs(_rigidbody.linearVelocity.y)
        );
    }

    // STEP 8: Calculate a color multiplier from the X and Y speeds.
    private float GetColorMultiplier(float xSpeed, float ySpeed)
    {
        float averageSpeed = (xSpeed + ySpeed) / 2.0f;

        if (averageSpeed > _speedThreshold)
        {
            return 1.5f;
        }
        else
        {
            return 1.0f;
        }
    }
}