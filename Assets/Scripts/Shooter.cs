using System;
using Photon.Pun;
using UnityEngine;

public class Shooter : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float force;
    [SerializeField] private PlayerMove input;
    [SerializeField] private Transform player;

    private PhotonView photonView;
    private void Start()
    {
        // input.shoot += MakeShoot;
        photonView = PhotonView.Get(this.gameObject);

    }

    private void Update()
    {
        if (photonView.IsMine)
        {
            if(Input.GetMouseButtonDown(0)) MakeShoot();
        }
    }

    private void MakeShoot()
    {
        this.photonView.RPC("Shoot", RpcTarget.All);
    }
    
    [PunRPC]
    public void Shoot()
    {
        var b = PhotonNetwork.Instantiate(bullet.name, player.position, Quaternion.identity);
        b.GetComponent<Rigidbody>().AddForce(Vector3.forward * force, ForceMode.Impulse);
    }
}
