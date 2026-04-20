using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    public Transform ball;
    public float speed;
    float offset;
    float timer;
    public float changeOffsetTime = 0.5f;

    void Start()
    {
        switch (GameSettings.selectedDifficulty)
        {
            case Difficulty.Easy:
                speed = 4f;
                break;
            case Difficulty.Medium:
                speed = 7f;
                break;
            case Difficulty.Hard:
                speed = 10f;
                break;
        }
    }

    void Update()
    {
        if (!GameSettings.isSinglePlayer) return;

        timer += Time.deltaTime;

        if (timer >= changeOffsetTime)
        {
            offset = Random.Range(-0.3f, 0.3f);
            timer = 0f;
        }

        float targetY = ball.position.y + offset;

        float distance = Mathf.Abs(transform.position.y - targetY);

        if (distance > 0.2f)
        {
            Vector3 targetPos = new Vector3(transform.position.x, targetY, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }

        // Clamp
        float limit = 3.8f;
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -limit, limit);
        transform.position = pos;
    }
}