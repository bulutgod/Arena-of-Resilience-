using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KickCoolDown : MonoBehaviour
{
    //kick skill'inin ui �zerinde bekleme s�resini ayarlad�k.
    public Image skillImage;
    public float cooldown1 = 5f;
   public bool isCooldown = false;
    public KeyCode ability;
    
    void Start()
    {
        
        skillImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        Kick();
    }
    //Kick skill'i kullan�ld�g�nda vfx olarak bir bekleme s�resi ekledik
    void Kick()
    {
        if (Input.GetKey(ability) && isCooldown == false)
        {
            skillImage.fillAmount = 1;
            isCooldown = true;
        }

        if (isCooldown)
        {

            skillImage.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if (skillImage.fillAmount <= 0)
            {
                skillImage.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
  
}
