using System.Collections;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    //enemy ve player icin kulland�g�m�z healthcontroller scripti.

    public int health;

    //hasar verme scriptimiz
    public void Hit(int damageValue)
    {
        health -= damageValue;
        if (health <= 0)
        {
            StartCoroutine(Destroy());
        }
    }
    //player �ldukten 7 saniye sonra destroy ediyoruz.bunun icin saya�.
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);
        
    }
}
