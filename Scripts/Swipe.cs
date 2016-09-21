using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Swipe : MonoBehaviour
{
    [SerializeField]
    private int m_SwipePower;
    private bool m_Count = false;
    private float m_SwipeForce = 1;

    [SerializeField]
    private List<GameObject> m_ObjectToInteract = new List<GameObject>();
    public List<GameObject> SetOTI
    {
        get { return m_ObjectToInteract; }
        set { m_ObjectToInteract = value; }
    }
    private GameObject m_SelectedObj;
    private Vector2 m_FirstPosition;
    private Vector2 m_LastPosition;

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                m_Count = true;
                m_FirstPosition = touch.position;
                m_LastPosition = touch.position;

            }

            if(touch.phase == TouchPhase.Moved)
            {
                m_LastPosition = touch.position;

                Ray ray = Camera.main.ScreenPointToRay(m_FirstPosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

                for (int i = 0; i < m_ObjectToInteract.Count; i++)
                {
                    if (hit.collider != null && hit.collider.gameObject.tag == "Meteor")
                    {
                        m_SelectedObj = hit.collider.gameObject;
                    }
                }
            }

            if(touch.phase == TouchPhase.Ended)
            {
                Vector2 dir = m_LastPosition - m_FirstPosition;
                Vector2 normalizedDir = dir.normalized;

                float distance = Vector2.Distance(m_LastPosition, m_FirstPosition);
                Debug.Log(distance);

                //Debug.Log(normalizedDir);

                if (m_SelectedObj != null && distance > 30f)
                {
                    //m_SelectedObj.GetComponent<Rigidbody2D>().AddForce(normalizedDir * m_SwipePower * m_SwipeForce * (distance / 10), ForceMode2D.Force);
                    //m_SelectedObj.transform.position += new Vector3(normalizedDir.x, normalizedDir.y, 0) * m_SwipePower * m_SwipeForce;
                    m_SelectedObj.GetComponent<Meteor>().ShootMeteor(normalizedDir, m_SwipePower * m_SwipeForce);
                    m_SelectedObj = null;
                }

                m_Count = false;
            }
        }

        if (m_Count && m_SwipeForce > 0)
        {
            m_SwipeForce -= 1 * Time.deltaTime;
        }
        else
        {
            if (m_SwipeForce != 1)
            {
                m_SwipeForce = 1;
            }
            m_Count = false;
        }
    }
}