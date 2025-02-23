using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour, IDamageable//IDamageable interface'ini kullanmak i�in buraya yaz�yoruz.
{
    public HealthController healthController;    
    public UIController controller;
    public GameObject footCollider;
    public GameObject swordCollider;
   
   
    private void Start()
    {
        healthController = GetComponent<HealthController>();        
        controller = GetComponent<UIController>();
        healthController.health = 100;//ba�lang��ta can�m�z� 100'e ayarl�yoruz.
        
        
    }
    private void Update()
    { 
        //PowerUp Skill'inden can kazan�yoruz can�m�z 100'�n �zerine ��kmas�n� istemiyoruz.
        if(healthController.health > 100)
        {
            healthController.health = 100;
        }
      
    }

    //IDamageable interface'i �zerinden ald���m�z hasar yeme metotu
    public void TakeDamage(int damageValue)
    {
        healthController.Hit(damageValue);//can azalmas� i�in healthController scriptinden hit metotunu ald�k.
        
            
    }
  
}