using System;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class HPBar : MonoBehaviour
    {
        [SerializeField] private Slider hp;
        [SerializeField] private Health health;

        private void Start()
        {
            print("Hello");
            health.healthChanged += HPChanged;
            health.healthChanged?.Invoke(health.CurrentHealth);
        }

        private void HPChanged(int currentHp)
        {
            print(currentHp);
            hp.value = currentHp;
        }
    }
}