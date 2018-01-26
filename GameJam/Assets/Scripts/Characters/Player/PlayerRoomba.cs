using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoomba : BaseCharacter
{
    [SerializeField]
    private float m_forwardSpeed = 10.0f;
    [SerializeField]
    private float m_strafeSpeed = 5.0f;
    [SerializeField]
    private float m_rotationSpeed = 3.0f;

    private Rigidbody m_rbCharacter = null;

    // Use this for initialization
    void Start ()
    {
        m_rbCharacter = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Player controls
        float inputForwards = Input.GetAxisRaw("Vertical");
        float inputStrafe = Input.GetAxisRaw("Horizontal");
        float inputRotation = Input.GetAxis("Mouse X");

        m_rbCharacter.velocity = transform.forward * inputForwards * m_forwardSpeed + transform.right * inputStrafe * m_strafeSpeed;

        transform.Rotate(Vector3.up * Time.deltaTime * inputRotation * m_rotationSpeed);
    }
}
