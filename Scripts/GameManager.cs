using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private Vector3 m_GroupStartPos;

    [SerializeField]
    private float m_DistanceMade;
    public float GetDistanceMade
    {
        get { return m_DistanceMade; }
    }

    private float m_CurrentCurrency;
    private int m_CurrencyUsed;

    private List<GameObject> m_CrusadeGroup = new List<GameObject>();
    public List<GameObject> SetCrusadeGroup
    {
        get { return m_CrusadeGroup; }
        set { m_CrusadeGroup = value; }
    }

    private GameObject m_CrusadeLeader;

    private GroupController m_GroupController;
    [SerializeField]
    private GameObject m_EndScreen;
    [SerializeField]
    private GameObject m_InGameScreen;

    [SerializeField]
    private Text m_Distance;
    [SerializeField]
    private Text m_Currency;
    [SerializeField]
    private Text m_EndScore;

    void Start()
    {
        Application.targetFrameRate = 30;
        m_CrusadeLeader = GameObject.Find("CrusadeLeader");

        m_GroupController = GetComponent<GroupController>();
        //m_GroupStartPos = m_CrusadeGroup[0].transform.position;
    }

    void Update()
    {
        m_DistanceMade = m_CrusadeLeader.transform.position.x;
        m_Distance.text = "Meters: " + Mathf.Round(m_DistanceMade);

        m_CurrentCurrency = m_DistanceMade / 10;
        m_CurrentCurrency = Mathf.Round(m_CurrentCurrency);
        m_Currency.text = "Currency: " + (m_CurrentCurrency - m_CurrencyUsed);
        GameOver();

        if(Input.GetKeyDown(KeyCode.R))
        {
            Replay();
        }
        //m_DistanceMade = m_CrusadeGroup[0].transform.position.x - m_GroupStartPos.x;
    }

    public bool Buy()
    {
        if ((m_CurrentCurrency - m_CurrencyUsed) >= 1)
        {
            m_CurrencyUsed += 1;
            return true;
        }
        return false;
    }

    private void GameOver()
    {
        if(m_GroupController.m_Group.Count <= 0 && m_EndScreen.active == false)
        {
            m_EndScore.text = "Score: " + Mathf.Round(m_DistanceMade);
            m_InGameScreen.SetActive(false);
            m_EndScreen.SetActive(true);
        }
    }

    public void Replay()
    {
        Application.LoadLevel(0);
    }
}
