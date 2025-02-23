using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : EnemyController
{
    //EnemyController scriptinden kalýtým alýyoruz.
    //boss diðer canlýlardan daha fazla vursun diye hasar metotu buraya yazýldý.
    //Boss ve player'ýn collider'larý etkilesime girdiginde karakterin hasar almasý için metot.
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {

            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(100);
            }
        }
    }
}
