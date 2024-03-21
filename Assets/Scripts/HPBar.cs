using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class HPBar : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Slider hp;
        [SerializeField] private Health health;
        [SerializeField] private PhotonView photonView;

        private void Start()
        {
            print("Hello");
            health.healthChanged += HPChanged;
            health.healthChanged?.Invoke(health.CurrentHealth);
        }

        private void HPChanged(int currentHp)
        {
            photonView.RPC("ChangeHpBarValue", RpcTarget.All, currentHp);
        }

        [PunRPC]
        public void ChangeHpBarValue(int currentHealth)
        {
            print(currentHealth);
            hp.value = currentHealth;
        }
    }
}