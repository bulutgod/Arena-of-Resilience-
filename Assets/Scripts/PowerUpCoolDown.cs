using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpCoolDown : MonoBehaviour
{
    public Image skillImage;
    public float cooldown1 = 10f;
    public bool isCooldown = false;
    public KeyCode ability;

    void Start()
    {

        skillImage.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        powerUp();
    }
    void powerUp()
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
