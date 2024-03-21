using Photon.Pun;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int damage;
        [SerializeField] private PhotonView pv;

        private void OnTriggerEnter(Collider other)
        {

            if (other.transform.TryGetComponent(out IDamagable damagable))
            {
                print("Damagable includes");
                damagable.TakeDamage(damage);
            }
            if (pv.IsMine) PhotonNetwork.Destroy(transform.parent.gameObject);

        }
    }
}