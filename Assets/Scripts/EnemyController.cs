using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour, IDamageable//IDamageable interface'ini çaðýrýyoruz.
{
    public HealthController healthController;
    public Rigidbody rb;    
    public GameObject deathPanel;
    public GameObject enemy;
    public TMP_Text health;

   
    private void Start()
    {
        healthController = GetComponent<HealthController>();
        rb = GetComponent<Rigidbody>();
        deathPanel.SetActive(false);//baþlangýçta ölüm panelini pasif yapýyoruz.
      
        
    }
    private void Update()
    {
        health.text = "Health : " + healthController.health;//can barýnýn üzerinde can yazmasý amacýyla yazýlan kod
    }

    //IDamageable interface'inden aldýðýmýz hasar yeme metotu.
    public virtual void TakeDamage(int damageValue)
    {
       healthController.health -= damageValue;//healthcontroller scriptinden health'i cekiyoruz ki hasar aldýgýmýzda damageValue kadar canýmýz azalsýn.
        if (healthController.health <= 0)
        {
            Destroy(enemy);
            die();//enemy öldüðünde panel aktif etmek istediðimiz icin buraya yazýyoruz.
            
                      
        }
    }

    //Enemy attack yaptýgýnda player hasar almasý icin yazýlan metot.
    //Collider'lar birbirleriyle etkileþime girdiginde çalýþýyor.
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(10);  
            }
        }
    }
    //Enemy öldüðünde oyun zamanýný durdurmak ve ölüm panelini aktive etmek için metot
    void die()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0;
    }

   
}