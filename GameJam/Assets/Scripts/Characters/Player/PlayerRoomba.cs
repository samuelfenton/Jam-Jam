using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoomba : PlayerRobot
{
    [SerializeField]
    private float m_forwardSpeed = 10.0f;
    [SerializeField]
    private float m_rotationSpeed = 3.0f;

    [SerializeField]
    private GameObject m_leftWheel = null;
    [SerializeField]
    private GameObject m_rightWheel = null;

    private Rigidbody m_rbCharacter = null;

    // Use this for initialization
    void Start ()
    {
        m_rbCharacter = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public override void Update ()
    {
        //Player trasmission abilities
        base.Update();

        //Player controls
        float inputForwards = Input.GetAxisRaw("Vertical");
        float inputRotation = Input.GetAxis("Mouse X");

        m_rbCharacter.velocity = transform.forward * inputForwards * m_forwardSpeed;

        transform.Rotate(Vector3.up * Time.deltaTime * inputRotation * m_rotationSpeed);
    }
}
