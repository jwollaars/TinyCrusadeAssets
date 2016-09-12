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
    private GroupController m_GroupController;

    void Start()
    {
        m_CrusadeLeader = GameObject.Find("CrusadeLeader");
        m_GameManagerObj = GameObject.Find("GameManager");
        m_GroupController = m_GameManagerObj.GetComponent<GroupController>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            SpawnUnit(0);
        }
    }
    
    public void SpawnUnit(int unit)
    {
        GameObject clone = Instantiate(m_Units[unit], new Vector3(m_CrusadeLeader.transform.position.x, m_CrusadeLeader.transform.position.y, 0), Quaternion.identity) as GameObject;
        clone.name = "Knight_Type_" + unit;
        m_GroupController.AddToGroupList(clone);
    }

    public void SpawnThreat(int hazard)
    {
        GameObject clone = Instantiate(m_Units[hazard], m_HazardSpawnLoc, Quaternion.identity) as GameObject;
        clone.name = "Hazard_Type_" + hazard;
    }
}
