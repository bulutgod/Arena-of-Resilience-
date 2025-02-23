using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPanel : MonoBehaviour
{
    HealthController healthController;
    PlayerController playerController;
    public GameObject panel;//panel objesinin hangisi oldugunu unityden atamak i�in kulland�k.

    private void Start()
    {
        healthController = GetComponent<HealthController>();      
        playerController = GetComponent<PlayerController>();
        panel.SetActive(false);//ba�lang�cta paneli gormek istemiyoruz.
    }
    // Update is called once per frame
    void Update()
    {
       if (playerController.healthController.health <= 0)
        {
            StartCoroutine(toActive(3));//panel karakterimiz �ld�kten 3 saniye sonra aktif oluyor. �l�m animasyonunun �al��mas� i�in 3 saniye bekliyoruz.
            
        }
    }
    //panelin aktif olmas� icin sayac
    IEnumerator toActive(float index)
    {
        yield return new WaitForSeconds(index);//beklememiz gereken saniyeyi ifade ediyor parametre olarak index ald�k ve yukar�da startcoroutine'in i�erisinde atamas�n� yapt�k.
        panel.SetActive(true);
        Time.timeScale = 0f;//oyun zaman�n� durdurmak i�in
    }
}
