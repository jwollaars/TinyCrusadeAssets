using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    private GameObject m_CrusadeLeader;
    private Vector3 m_Offset;
    private Vector3 m_TargetOffset;

    private float dampTime = 2f;
    private Vector3 velocity = Vector3.zero;

    private float m_Timer = 3;

    void Start()
    {
        m_CrusadeLeader = GameObject.Find("CrusadeLeader");
        m_TargetOffset = new Vector3(Random.Range(-0.3f, 2), Random.Range(1.5f, 3), 0);
    }

    void Update()
    {
        m_Timer -= Time.deltaTime;

        if (m_Timer <= 0)
        {
            m_TargetOffset = new Vector3(Random.Range(-0.3f, 2), Random.Range(1.5f, 3), 0);
            m_Timer = 3;
        }
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(m_CrusadeLeader.transform.position.x, m_CrusadeLeader.transform.position.y, Camera.main.transform.position.z) + m_TargetOffset, ref velocity, dampTime);
    }

    public void Earthquake()
    {
        transform.position = transform.position + new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0);
    }
}