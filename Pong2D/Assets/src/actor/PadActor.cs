using UnityEngine;

///////////////////////////////////////////////////////////////////
///                     PadActor.cs
///             Logic for pad entity/actor.
/// Controls for pad from axis defined in the project settings.
/// Or by mouse Y position if `m_MouseTakeover` is true.
///////////////////////////////////////////////////////////////////
public class PadActor : MonoBehaviour
{
    public float m_Speed;
    public string m_AxisController;
    public bool m_MouseTakeover = false;

    private const float arenaHeightMax = 3.6f;

    void Update()
    {
        if (!m_MouseTakeover)
        {
            float move = Input.GetAxis(m_AxisController) * m_Speed * Time.deltaTime;
            float nextPosition = transform.position.y + move;

            // Vibe check
            if (nextPosition > arenaHeightMax || nextPosition < arenaHeightMax * -1f)
            {
                move = 0f;
            }

            // Move
            transform.position += new Vector3(0, move, 0);
        }
        if (m_MouseTakeover)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 move = new Vector3(transform.position.x, mousePosition.y, transform.position.z);
            transform.position = move;
        }
    }
}