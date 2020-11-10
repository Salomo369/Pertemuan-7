using UnityEngine;

///////////////////////////////////////////////////////////////////
///                     BallActor.cs
///             Logic for the ball entity/actor.
/// Controls the ball movement, handling collision, and SFX.
/// Also modify score data on collision event.
///////////////////////////////////////////////////////////////////
public class BallActor : MonoBehaviour
{
    public int m_Force;

    // SFX
    public AudioSource m_SFXSource;
    public AudioClip m_HitPadSFX, m_HitEdgeSFX;
    Rigidbody2D physicsBody;
    UIMaster canvasMaster;

    // Start is called before the first frame update
    void Start()
    {
        if (!canvasMaster)
        {
            canvasMaster = GameObject.Find("Canvas").GetComponent<UIMaster>();
        }

        physicsBody = GetComponent<Rigidbody2D>();
        Vector2 dir = new Vector2(2, 0).normalized;
        physicsBody.AddForce(dir * m_Force);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Vector2 dir = Vector2.zero;
        switch (other.gameObject.name)
        {
            case "edge_r":
                ResetBall();

                // Update score
                ScoreData.m_P1Score += 1;
                canvasMaster.UpdateScoreHUD();

                // Ball starts moving
                dir = new Vector2(2, 0).normalized;
                physicsBody.AddForce(dir * m_Force);

                // SFX
                m_SFXSource.PlayOneShot(m_HitEdgeSFX);
                break;
            case "edge_l":
                ResetBall();

                // Update score
                ScoreData.m_P2Score += 1;
                canvasMaster.UpdateScoreHUD();

                // Ball starts moving
                dir = new Vector2(-2, 0).normalized;
                physicsBody.AddForce(dir * m_Force);

                // SFX
                m_SFXSource.PlayOneShot(m_HitEdgeSFX);
                break;
            case "player1":
                Bounce(other, dir);
                break;
            case "player2":
                Bounce(other, dir);
                break;
            default:
                break;
        }
    }

    void Bounce(Collision2D collision, Vector2 direction)
    {
        float angle = (transform.position.y - collision.transform.position.y) * 5f;
        direction = new Vector2(physicsBody.velocity.x, angle).normalized;

        physicsBody.velocity = Vector2.zero;
        physicsBody.AddForce(direction * m_Force * 2);

        // SFX
        m_SFXSource.PlayOneShot(m_HitPadSFX);
    }

    // Public Methods
    public void ResetBall()
    {
        transform.localPosition = Vector2.zero;
        physicsBody.velocity = Vector2.zero;
    }
}
