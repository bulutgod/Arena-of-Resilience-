using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPanel : MonoBehaviour
{
    HealthController healthController;
    PlayerController playerController;
    public GameObject panel;//panel objesinin hangisi oldugunu unityden atamak için kullandýk.

    private void Start()
    {
        healthController = GetComponent<HealthController>();      
        playerController = GetComponent<PlayerController>();
        panel.SetActive(false);//baþlangýcta paneli gormek istemiyoruz.
    }
    // Update is called once per frame
    void Update()
    {
       if (playerController.healthController.health <= 0)
        {
            StartCoroutine(toActive(3));//panel karakterimiz öldükten 3 saniye sonra aktif oluyor. Ölüm animasyonunun çalýþmasý için 3 saniye bekliyoruz.
            
        }
    }
    //panelin aktif olmasý icin sayac
    IEnumerator toActive(float index)
    {
        yield return new WaitForSeconds(index);//beklememiz gereken saniyeyi ifade ediyor parametre olarak index aldýk ve yukarýda startcoroutine'in içerisinde atamasýný yaptýk.
        panel.SetActive(true);
        Time.timeScale = 0f;//oyun zamanýný durdurmak için
    }
}
