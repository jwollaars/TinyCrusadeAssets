using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Hazard : MonoBehaviour
{
    [SerializeField]
    private float m_JumpHeight = 4;
    [SerializeField]
    private float m_TimeToJumpApex = 0.4f;
    private float m_JumpAcceleration;
    [SerializeField]
    private float m_AccelerationTimeAirborn = 0.2f;
    [SerializeField]
    private float m_AccelerationTimeGrounded = 0.1f;
    private float m_MoveSpeed = 0.2f;
    public float MoveSpeed
    {
        get { return m_MoveSpeed; }
        set { m_MoveSpeed = value; }
    }

    private float m_Gravity;
    private float m_JumpVelocity;
    private float m_VelocityXSmoothing;

    private Vector3 m_Velocity;

    private Controller2D m_Controller;
    public Controller2D getController
    {
        get { return m_Controller; }
    }

    [SerializeField]
    private float m_RayLength;
    private float m_JumpReload = 0.5f;

    [SerializeField]
    private LayerMask m_LayerMask;

    void Start()
    {
        m_Controller = GetComponent<Controller2D>();

        m_Gravity = -(2 * m_JumpHeight) / Mathf.Pow(m_TimeToJumpApex, 2);
        m_JumpVelocity = Mathf.Abs(m_Gravity) * m_TimeToJumpApex;
    }

    void Update()
    {
        if (m_Controller.GetCollisions.above || m_Controller.GetCollisions.below)
        {
            m_Velocity.y = 0;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(1*m_MoveSpeed/6, 0), m_RayLength, m_LayerMask);
        Debug.DrawRay(transform.position, new Vector2(1, 0), Color.red, m_RayLength);
        
        //if (hit && hit.collider.gameObject.tag == "Jumper")
        //{
        //    float objHeigth = hit.collider.gameObject.transform.localScale.y;
        //    float distance = Vector2.Distance(transform.position, new Vector2(hit.collider.transform.position.x, transform.position.y));

        //    if (distance <= 2.8f && m_Controller.GetCollisions.below)
        //    {
        //        m_JumpHeight = objHeigth * 2;

        //        m_Gravity = -(2 * m_JumpHeight) / Mathf.Pow(m_TimeToJumpApex, 2);
        //        m_JumpVelocity = Mathf.Abs(m_Gravity) * m_TimeToJumpApex;

        //        m_Velocity.y = m_JumpVelocity;
        //    }
        //}

        CollisionChecks(m_Controller.GetCollisions.gAbove);
        CollisionChecks(m_Controller.GetCollisions.gBelow);
        CollisionChecks(m_Controller.GetCollisions.gLeft);
        CollisionChecks(m_Controller.GetCollisions.gRight);

        float targetVelocityX = 1 * m_MoveSpeed;
        //m_Velocity.x = Mathf.SmoothDamp(m_Velocity.x, targetVelocityX, ref m_VelocityXSmoothing, m_AccelerationTimeGrounded);
        m_Velocity.y += m_Gravity * Time.deltaTime;
        m_Controller.Move(m_Velocity * Time.deltaTime);
    }

    private void CollisionChecks(GameObject direction)
    {
        if (direction != null)
        {
        }

        if (m_Controller.GetCollisions.gRight != null)
        {
        } 
        
        if (m_Controller.GetCollisions.gLeft != null)
        {
        }

        if (m_Controller.GetCollisions.gAbove != null)
        {
        }

        if (m_Controller.GetCollisions.gBelow != null)
        {
        }
    }
}