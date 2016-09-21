using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnvironmentSpawner : MonoBehaviour
{
    private GameObject m_GameManagerObj;
    private GameManager m_GameManager;

    [SerializeField]
    private GameObject[] m_EnvironmentObjects;
    private float m_EnvironmentArea = 0;

    // Use this for initialization
    void Start()
    {
        m_GameManagerObj = GameObject.Find("GameManager");
        m_GameManager = m_GameManagerObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_GameManager.GetDistanceMade > m_EnvironmentArea)
        {
            m_EnvironmentArea = m_GameManager.GetDistanceMade + 10;

            List<float> usedSpots = new List<float>();

            for (int i = 0; i < 10; i++)
            {
                float randomNum = Random.Range(m_EnvironmentArea, m_EnvironmentArea + 10);

                if (usedSpots.Count <= 0)
                {
                    usedSpots.Add(randomNum);
                    Instantiate(m_EnvironmentObjects[Random.Range(0, m_EnvironmentObjects.Length)], new Vector3(randomNum, Random.Range(-6.3f, -1.88f), 1.24f), Quaternion.identity);
                }
                else
                {
                    bool canSpawn = true;

                    for (int j = 0; j < usedSpots.Count; j++)
                    {
                        if (randomNum >= usedSpots[j] - 3 && randomNum <= usedSpots[j] + 3)
                        {
                            canSpawn = false;
                        }
                    }

                    if (canSpawn)
                    {
                        usedSpots.Add(randomNum);
                        Instantiate(m_EnvironmentObjects[Random.Range(0, m_EnvironmentObjects.Length)], new Vector3(randomNum, Random.Range(-6.3f, -1.88f), 1.24f), Quaternion.identity);
                        randomNum = Random.Range(m_EnvironmentArea, m_EnvironmentArea + 10);
                    }
                }
            }
        }
    }
}