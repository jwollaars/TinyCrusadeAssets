using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroupController : MonoBehaviour
{
    public List<GameObject> m_Group = new List<GameObject>();

    public void AddToGroupList(GameObject go)
    {
        m_Group.Add(go);

        for (int i = 0; i < m_Group.Count; i++)
        {
            m_Group[i].GetComponent<UnitController>().SetGroupOffset(i);
        }
    }

    public void RemoveFromGroupList(GameObject go)
    {
        m_Group.Remove(go);
        Destroy(go);
    }
}