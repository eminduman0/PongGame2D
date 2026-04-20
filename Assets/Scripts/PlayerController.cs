using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isPlayer1;
    public Rigidbody2D rgb;
    public float speed = 12f;
    float move;
    void Update()
    {
        if (!isPlayer1 && GameSettings.isSinglePlayer) return;

        if (isPlayer1)
            move = Input.GetAxisRaw("VerticalPlayer2");
        else
            move = Input.GetAxisRaw("Vertical");

        rgb.linearVelocity = Vector2.up * move * speed;
    }
}
