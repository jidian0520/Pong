using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public float speed = 30;

    private Rigidbody2D _rigidBody;

    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.velocity = Vector2.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //LeftPaddle or RightPaddle
        if ((col.gameObject.name == "LeftPaddle") ||
            (col.gameObject.name == "RightPaddle"))
        {
            HandlePaddleHit(col);
        }

        //WallBottom or WallTop
        if ((col.gameObject.name == "BottomWall") ||
            (col.gameObject.name == "TopWall"))
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.wallBloop);
        }

        //LeftGoal or RightGoal
        if ((col.gameObject.name == "LeftWall") ||
            (col.gameObject.name == "RightWall"))
        {
            SoundManager.Instance.PlayOneShot(SoundManager.Instance.goalBloop);

            if (col.gameObject.name == "LeftWall")
            {
                IncreaseTextUIScore("RightScoreUI");
            }

            if (col.gameObject.name == "RightWall")
            {
                IncreaseTextUIScore("LeftScoreUI");
            }

            //Move the ball to the center of the screen
            transform.position = new Vector2(0, 0);
        }
    }

    void HandlePaddleHit(Collision2D col)
    {
        float y = BallHitPaddleWhere(transform.position, col.transform.position, col.collider.bounds.size.y);

        Vector2 dir = new Vector2();

        if (col.gameObject.name == "LeftPaddle")
        {
            dir = new Vector2(1, y).normalized;
        }

        if (col.gameObject.name == "RightPaddle")
        {
            dir = new Vector2(-1, y).normalized;
        }

        _rigidBody.velocity = dir * speed;

        SoundManager.Instance.PlayOneShot(SoundManager.Instance.HitPaddleBloop);
    }

    float BallHitPaddleWhere(Vector2 ball, Vector2 paddle, float paddleHeight)
    {
        return (ball.y - paddle.y) / paddleHeight;
    }

    void IncreaseTextUIScore(string textUIName)
    {
        var textUIComp = GameObject.Find(textUIName).GetComponent<Text>();

        int score = int.Parse(textUIComp.text);

        score++;

        textUIComp.text = score.ToString();
    }
}
