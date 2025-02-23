using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour, IDamageable//IDamageable interface'ini kullanmak için buraya yazýyoruz.
{
    public HealthController healthController;    
    public UIController controller;
    public GameObject footCollider;
    public GameObject swordCollider;
   
   
    private void Start()
    {
        healthController = GetComponent<HealthController>();        
        controller = GetComponent<UIController>();
        healthController.health = 100;//baþlangýçta canýmýzý 100'e ayarlýyoruz.
        
        
    }
    private void Update()
    { 
        //PowerUp Skill'inden can kazanýyoruz canýmýz 100'ün üzerine çýkmasýný istemiyoruz.
        if(healthController.health > 100)
        {
            healthController.health = 100;
        }
      
    }

    //IDamageable interface'i üzerinden aldýðýmýz hasar yeme metotu
    public void TakeDamage(int damageValue)
    {
        healthController.Hit(damageValue);//can azalmasý için healthController scriptinden hit metotunu aldýk.
        
            
    }
  
}