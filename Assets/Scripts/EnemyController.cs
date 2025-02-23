using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour, IDamageable//IDamageable interface'ini �a��r�yoruz.
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
        deathPanel.SetActive(false);//ba�lang��ta �l�m panelini pasif yap�yoruz.
      
        
    }
    private void Update()
    {
        health.text = "Health : " + healthController.health;//can bar�n�n �zerinde can yazmas� amac�yla yaz�lan kod
    }

    //IDamageable interface'inden ald���m�z hasar yeme metotu.
    public virtual void TakeDamage(int damageValue)
    {
       healthController.health -= damageValue;//healthcontroller scriptinden health'i cekiyoruz ki hasar ald�g�m�zda damageValue kadar can�m�z azals�n.
        if (healthController.health <= 0)
        {
            Destroy(enemy);
            die();//enemy �ld���nde panel aktif etmek istedi�imiz icin buraya yaz�yoruz.
            
                      
        }
    }

    //Enemy attack yapt�g�nda player hasar almas� icin yaz�lan metot.
    //Collider'lar birbirleriyle etkile�ime girdiginde �al���yor.
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
    //Enemy �ld���nde oyun zaman�n� durdurmak ve �l�m panelini aktive etmek i�in metot
    void die()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0;
    }

   
}