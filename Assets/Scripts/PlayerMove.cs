using System;
using Photon.Pun;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector2 movement;
    private Rigidbody rb;
    public PhotonView PhotonView;
    public Action shoot;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        PhotonView = PhotonView.Get(this.gameObject);
    }

    private void Update()
    {
        if (PhotonView.IsMine)
        {
            float vertical = Input.GetAxisRaw("Vertical");
            float horizontal = Input.GetAxisRaw("Horizontal");

            movement = new Vector2(horizontal, vertical);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.y * speed);
    }
}