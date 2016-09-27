using UnityEngine;
using System.Collections;

public class UnitController : MonoBehaviour
{
    private float m_TargetXpos;
    private float m_UnitPos;
    private GameObject m_CrusadeLeader;

    private int m_Uses = 3;

    private AI m_AI;

    void Start()
    {
        m_AI = gameObject.GetComponent<AI>();
        m_CrusadeLeader = GameObject.Find("CrusadeLeader");
    }

    void Update()
    {
        m_TargetXpos = m_UnitPos + m_CrusadeLeader.transform.position.x;

        if (transform.position.x < m_TargetXpos+0.2f)
        {
            m_AI.MoveSpeed = Random.Range(1f, 3f);
        }
        else if (transform.position.x > m_TargetXpos+0.2f)
        {
            m_AI.MoveSpeed = Random.Range(-6f, -1f);
        }
        else
        {
            m_AI.MoveSpeed = m_CrusadeLeader.GetComponent<AI>().MoveSpeed;
        }
    }

    public void SetGroupOffset(float i)
    {
        m_UnitPos = Random.Range(-i/10, -3.5f) + Random.Range(-0.2f, 0);
    }
}
