using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrone : PlayerRobot
{
    public Animator m_animator = null;
    public GameObject m_capsuleHome = null;
    [SerializeField]
    private float m_forwardSpeed = 10.0f;
    [SerializeField]
    private float m_strafeSpeed = 5.0f;
    [SerializeField]
    private float m_rotationSpeed = 3.0f;

    private Rigidbody m_rbCharacter = null;

    [SerializeField]
    private float m_leanAmount = 1.0f;

    private bool m_deployingDroneSequence = true;

    // Use this for initialization
    void Start ()
    {
        m_rbCharacter = GetComponent<Rigidbody>();
        m_animator.speed = 0;
        this.enabled = false;
    }

    // Update is called once per frame
    public override void Update ()
    {
        //Player trasmission abilities
        base.Update();

        if (m_deployingDroneSequence)
        {
            if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("drone_flight"))
            {
                m_deployingDroneSequence = false;
                m_rbCharacter.velocity = Vector3.zero;
            }
        }
        else
        {
            //Player controls
            float inputForwards = Input.GetAxisRaw("Vertical");
            float inputStrafe = Input.GetAxisRaw("Horizontal");
            float inputRotation = Input.GetAxis("Mouse X");

            m_rbCharacter.velocity = transform.forward * inputForwards * m_forwardSpeed + transform.right * inputStrafe * m_strafeSpeed;

            transform.Rotate(Vector3.up * Time.deltaTime * inputRotation * m_rotationSpeed);

            m_charaterModelHolder.transform.localRotation = Quaternion.Euler(inputForwards * m_leanAmount, 0.0f, -inputStrafe * m_leanAmount);
        }
    }

    public void HackDrone()
    {
        m_rbCharacter.isKinematic = false;
        m_animator.speed = 1;
        m_capsuleHome.GetComponent<Animator>().SetTrigger("OpenCapsule");
        m_rbCharacter.velocity = transform.forward * 1.5f;
    }

    public void SetHome(GameObject home)
    {
        m_capsuleHome = home;
    }
}
