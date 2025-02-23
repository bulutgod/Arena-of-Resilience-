using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : EnemyController
{
    //EnemyController scriptinden kal�t�m al�yoruz.
    //boss di�er canl�lardan daha fazla vursun diye hasar metotu buraya yaz�ld�.
    //Boss ve player'�n collider'lar� etkilesime girdiginde karakterin hasar almas� i�in metot.
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
