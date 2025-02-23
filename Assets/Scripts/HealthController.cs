using System.Collections;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    //enemy ve player icin kullandýgýmýz healthcontroller scripti.

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
    //player öldukten 7 saniye sonra destroy ediyoruz.bunun icin sayaç.
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(7f);
        Destroy(gameObject);
        
    }
}
