using Unity.VisualScripting;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    //player'ýn kýlýcý ve tekmesi için hasar verme scripti
    // enemy'lerin el ve aðýz saldýrýlarý için hasar verme scripti.
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