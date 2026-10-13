using TMPro;
using UnityEngine;

public class CatW3 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private float _speed;
    [SerializeField] private float _jump;

    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private TMP_Text _speechText;

    [SerializeField] private float _maxHealth = 5;
    [SerializeField] private bool _destroyCatWhenDead;

    private bool _facingLeft;
    private bool _isGrounded = true;
    private int _points = 0;
    private float _health;

    private void Start()
    {
        _health = _maxHealth;
    }

    private void Update()
    {
        // Move left and right.
        _rigidbody.linearVelocity = new Vector2(
            Input.GetAxis("Horizontal") * _speed,
            _rigidbody.linearVelocity.y
        );

        // Jump.
        if (Input.GetAxis("Vertical") > 0 && _isGrounded)
        {
            _isGrounded = false;

            _rigidbody.linearVelocity = new Vector2(
                _rigidbody.linearVelocity.x,
                _jump
            );
        }

        // Change the direction the cat faces.
        if (Input.GetAxis("Horizontal") < 0 && !_facingLeft)
        {
            _spriteRenderer.flipX = true;
            _facingLeft = true;
        }
        else if (Input.GetAxis("Horizontal") > 0 && _facingLeft)
        {
            _spriteRenderer.flipX = false;
            _facingLeft = false;
        }

        // Update the walking animation.
        _animator.SetBool(
            "walking",
            _rigidbody.linearVelocity.x != 0.0f
        );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Item"))
        {
            _points++;
            _pointsText.text = "points: " + _points;
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            _isGrounded = true;
        }

        BallW3 ball = collision.gameObject.GetComponent<BallW3>();

        if (ball != null)
        {
            ChangeColor(ball);

            // STEP 2: Call the health method.
            DecreaseHealth();

            // STEP 6: Destroy the cat only when this option is enabled.
            if (_health <= 0 && _destroyCatWhenDead)
            {
                DestroyCat();
            }
        }
    }

    // STEP 3: Decrease health and update the health text.
    private void DecreaseHealth()
    {
        _health -= 1;
        _healthText.text = "health = " + _health;

        // STEP 5: Display the returned speech text.
        _speechText.text = GetHealthSpeechText();
    }

    // STEP 4: Return speech based on remaining health.
    private string GetHealthSpeechText()
    {
        if (_health < _maxHealth / 2.0f)
        {
            return "OH NO!";
        }
        else
        {
            return "ouch";
        }
    }

    // STEP 7: Copy the ball's color to the cat.
    private void ChangeColor(BallW3 ball)
    {
        _spriteRenderer.color = ball.ballRenderer.color;
    }

    private void DestroyCat()
    {
        Destroy(gameObject);
    }
}