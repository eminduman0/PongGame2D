using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rgb;
    public float startSpeed = 8f;
    public float speed;
    public float speedIncrease = 0.5f;
    public float maxSpeed = 15f;
    private Vector3 startPos;
    


    public ScoreManager scoreManager;
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        speed = startSpeed;
        LaunchBall();
    }

    void LaunchBall()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.Range(-0.5f, 0.5f);
        rgb.linearVelocity = new Vector2(x, y).normalized * speed;
        Vector2 vel = rgb.linearVelocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftBar"))
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.scoreSound);
            scoreManager.AddScorePlayer2();
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("RightBar"))
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.scoreSound);
            scoreManager.AddScorePlayer1();
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.paddleHit);
        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {
            float paddleHeight = collision.collider.bounds.size.y;

            float hitPoint = transform.position.y - collision.transform.position.y;

            float normalizedHit = hitPoint / (paddleHeight / 2f);

            Vector2 direction = new Vector2(rgb.linearVelocity.x > 0 ? 1 : -1, normalizedHit).normalized;

            speed += speedIncrease;
            speed = Mathf.Clamp(speed, 0, maxSpeed);

            rgb.linearVelocity = direction * speed;

            AudioManager.instance.PlaySFX(AudioManager.instance.paddleHit);
        }

    }

    void ResetBall()
    {
        rgb.linearVelocity = Vector2.zero;
        transform.position = startPos;
        speed = startSpeed;
        Invoke(nameof(LaunchBall), 0.4f);
    }

}
