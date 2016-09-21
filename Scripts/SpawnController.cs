using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_Units;
    private GameObject m_CrusadeLeader;

    [SerializeField]
    private GameObject[] m_Hazard;
    [SerializeField]
    private Vector2 m_HazardSpawnLoc;

    private GameObject m_GameManagerObj;
    private GameManager m_GameManager;
    private GroupController m_GroupController;

    private Coroutine m_ThreatController;
    private float m_ThreatLevel;
    private float m_HazardCooldown = 10;

    void Start()
    {
        m_CrusadeLeader = GameObject.Find("CrusadeLeader");
        //m_GameManagerObj.GetComponent<GameManager>().m_CrusadeGroup.Add(m_CrusadeLeader);

        m_GameManagerObj = GameObject.Find("GameManager");
        m_GameManager = m_GameManagerObj.GetComponent<GameManager>();
        m_GroupController = m_GameManagerObj.GetComponent<GroupController>();

        StartThreats();

        for (int i = 0; i < 10; i++)
        {
            SpawnUnit(0);
            SpawnUnit(1);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BuyUnit(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            BuyUnit(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            BuyUnit(2);
        }
    }

    public void BuyUnit(int unit)
    {
        if (m_GameManager.Buy() == true)
        {
            GameObject clone = Instantiate(m_Units[unit], new Vector3(m_CrusadeLeader.transform.position.x, m_CrusadeLeader.transform.position.y, 0), Quaternion.identity) as GameObject;
            clone.name = "Knight_Type_" + unit;
            m_GroupController.AddToGroupList(clone);
        }
        //m_GameManagerObj.GetComponent<GameManager>().m_CrusadeGroup.Add(clone);
    }
    public void SpawnUnit(int unit)
    {
        GameObject clone = Instantiate(m_Units[unit], new Vector3(m_CrusadeLeader.transform.position.x, m_CrusadeLeader.transform.position.y, 0), Quaternion.identity) as GameObject;
        clone.name = "Knight_Type_" + unit;
        m_GroupController.AddToGroupList(clone);
        //m_GameManagerObj.GetComponent<GameManager>().m_CrusadeGroup.Add(clone);
    }
    public void SpawnThreat(int hazard)
    {
        GameObject clone = Instantiate(m_Hazard[hazard], m_HazardSpawnLoc + new Vector2(m_CrusadeLeader.transform.position.x + Random.Range(-4f, 4f), 7), Quaternion.identity) as GameObject;
        clone.name = "Hazard_Type_" + hazard;

        if (hazard == 0)
        {
            m_GameManagerObj.GetComponent<Swipe>().SetOTI.Add(clone);
        }
    }

    public void StartThreats()
    {
        m_ThreatController = StartCoroutine(ThreatCaller(10));
    }

    IEnumerator ThreatCaller(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        m_ThreatLevel = m_GameManagerObj.GetComponent<GameManager>().GetDistanceMade / 10;
        SpawnThreat(Random.Range(0, m_Hazard.Length));

        m_ThreatController = StartCoroutine(ThreatCaller(10 - m_ThreatLevel));//m_HazardCooldown / m_ThreatLevel));
    }
}