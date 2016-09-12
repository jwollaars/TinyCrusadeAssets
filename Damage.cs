using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour
{
    private GameObject m_GameManagerObj;
    private SpawnController m_SpawnController;

    void Start()
    {
        m_GameManagerObj = GameObject.Find("GameManager");
        m_SpawnController = m_GameManagerObj.GetComponent<SpawnController>();
    }
}
