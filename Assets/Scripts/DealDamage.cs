using Unity.VisualScripting;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    //player'�n k�l�c� ve tekmesi i�in hasar verme scripti
    // enemy'lerin el ve a��z sald�r�lar� i�in hasar verme scripti.
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            IDamageable enemy = other.gameObject.GetComponent<IDamageable>();
            if (enemy != null)
            {
                enemy.TakeDamage(20);

            }

        }
        if (other.gameObject.CompareTag("Player"))
        {
            IDamageable player = other.gameObject.GetComponent<IDamageable>();
            if (player != null)
            {
                player.TakeDamage(10);
            }
        }

    }
}