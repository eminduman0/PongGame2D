using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rgb;
    public float speed = 6f;
    public float speedIncrease = 0.5f;
    public float maxSpeed = 15f;
    private Vector3 startPos;
    


    public ScoreManager scoreManager;
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        LaunchBall();
    }

    void LaunchBall()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.Range(-0.5f, 0.5f);
        rgb.linearVelocity = new Vector2(x, y).normalized * speed;
        Vector2 vel = rgb.linearVelocity;

        if (Mathf.Abs(vel.y) < 0.5f)
        {
            vel.y = Random.Range(-1f, 1f);
        }

        rgb.linearVelocity = vel.normalized * speed;
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
            AudioManager.instance.PlaySFX(AudioManager.instance.paddleHit);
            rgb.linearVelocity = rgb.linearVelocity.normalized * (speed + speedIncrease);
            speed += speedIncrease;

            if (speed > maxSpeed)
                speed = maxSpeed;

            rgb.linearVelocity = rgb.linearVelocity.normalized * speed;
        }

    }

    void ResetBall()
    {
        rgb.linearVelocity = Vector3.zero;
        transform.position = startPos;
        Invoke(nameof(LaunchBall), 0.4f);
    }

}
