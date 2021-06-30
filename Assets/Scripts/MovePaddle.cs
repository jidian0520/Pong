using UnityEngine;

public class MovePaddle : MonoBehaviour
{
    public float speed = 30;

    void FixedUpdate()
    {
        float vertPress = Input.GetAxisRaw("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, vertPress) * speed;
    }
}
