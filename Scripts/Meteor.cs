using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;
    private GameObject m_CrusadeLeader;
    private Vector2 m_StartPos = new Vector2(0, 0);
    private Vector2 m_NormalizedDir;
    private bool m_NoHit = true;

    private bool m_Destroy = false;
    private float m_DestroyTimer = 1;

    void Update()
    {
        m_CrusadeLeader = GameObject.Find("CrusadeLeader");
        Vector2 dir = new Vector2(m_CrusadeLeader.transform.position.x, m_CrusadeLeader.transform.position.y) - m_StartPos;
        if (m_NoHit)
        {
            m_NormalizedDir = dir.normalized;
        }

        if (m_StartPos == new Vector2(0, 0))
        {
            m_StartPos = transform.position;
            m_Rigidbody = gameObject.GetComponent<Rigidbody2D>();

            Debug.Log(m_NormalizedDir);

            //int Force = Random.Range(0, 10);
            //m_Rigidbody.AddForce(new Vector2((normalizedDir.x + Random.Range(-0.1f, 0.1f)) * Force, normalizedDir.y * Force), ForceMode2D.Impulse);
        }

        //if (m_NoHit)
        //{
            transform.position += new Vector3(m_NormalizedDir.x, m_NormalizedDir.y, 0) * Time.deltaTime * 4;
        //}
        //else
        //{
            //transform.position += new Vector3(m_NormalizedDir.x, m_NormalizedDir.y, 0) * Time.deltaTime * 4;
        //}

        if(m_Destroy)
        {
            m_DestroyTimer -= Time.deltaTime;

            if(m_DestroyTimer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void ShootMeteor(Vector2 dir, float force)
    {
        m_NormalizedDir = dir * force;
        //Debug.Log(m_NormalizedDir);
        m_NoHit = false;
        m_Destroy = true;
    }
}