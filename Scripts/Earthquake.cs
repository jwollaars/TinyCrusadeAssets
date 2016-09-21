using UnityEngine;
using System.Collections;

public class Earthquake : MonoBehaviour
{
    private GameObject m_Cam;
    
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Destroy(gameObject);
        }

        if (m_Cam == null)
        {
            m_Cam = Camera.main.gameObject;
        }

        m_Cam.GetComponent<CameraMovement>().Earthquake();
	}
}