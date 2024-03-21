using Photon.Pun;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private int damage;
        
        private void OnCollisionEnter(Collision other)
        {
            print($"collision with {other.transform.name}");
            if(other.transform.TryGetComponent(out IDamagable damagable))
            {
                damagable.TakeDamage(damage);
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }
}