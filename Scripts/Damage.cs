using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour
{
    private GameObject m_GameManagerObj;
    private SpawnController m_SpawnController;
    private GroupController m_GroupController;

    [SerializeField]
    private bool m_Meteor;
    [SerializeField]
    private bool m_Earthquake;

    private float m_EarthquakeKillTimer = 0.7f;

    void Start()
    {
        m_GameManagerObj = GameObject.Find("GameManager");
        m_SpawnController = m_GameManagerObj.GetComponent<SpawnController>();
        m_GroupController = m_GameManagerObj.GetComponent<GroupController>();
    }

    void Update()
    {
        if (m_Earthquake)
        {
            EarthquakeDamage();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (m_Meteor)
        {
            MeteorDamage(other.collider.gameObject);
        }
    }

    private void MeteorDamage(GameObject go)
    {
        if (go.tag == "Ground" && gameObject.tag == "Meteor")
        {
            Debug.Log("Hit");
            for (int i = 0; i < m_GroupController.m_Group.Count; i++)
            {
                float distance = Vector2.Distance(m_GroupController.m_Group[i].transform.position, gameObject.transform.position);

                if (distance <= 5f)
                {
                    m_GroupController.RemoveFromGroupList(m_GroupController.m_Group[i]);
                    //Destroy(m_GroupController.m_Group[i]);
                }
            }
            Destroy(gameObject);
        }
    }
    private void EarthquakeDamage()
    {
        m_EarthquakeKillTimer -= Time.deltaTime;

        if (m_EarthquakeKillTimer <= 0)
        {
            if (m_GroupController.m_Group.Count != 0)
            {
                m_GroupController.RemoveFromGroupList(m_GroupController.m_Group[m_GroupController.m_Group.Count - 1]);
                m_EarthquakeKillTimer = 0.7f;
            }
        }
    }
}