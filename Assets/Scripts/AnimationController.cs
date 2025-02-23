using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationController : MonoBehaviour
{
    PlayerMovement playerMovement;
    HealthController healthController;
    PlayerController playerController;   
    SkillManager skillManager;
    Animator animator;
    public bool isAttack = false;
    //skillerin animator icerisinde parametre isimlerini kodda kolaylaþtýrmak için kullanýldý.
    string Kick = "Skill1";
    string PowerUp = "Skill2";
    string Slash = "Skill3";
    //Skillerin cooldown sureleri
    float kickCoolDown = 5f;
    float powerUpCoolDown = 10f;
    float slashCoolDown = 4f;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        healthController = GetComponent<HealthController>();
        playerController = GetComponent<PlayerController>();        
        skillManager = GetComponent<SkillManager>();

        playerController.footCollider.SetActive(false);
        playerController.swordCollider.SetActive(false);
    }

    void Update()
    {
        
        Attack();
        Death();
        Move();

        //isAttack true olduðunda hareket etmesini engellemek içi kullanýyoruz
        if (!isAttack)
        {
            playerMovement.Movement();
        }

        //her sahnede yeni yetenekler elde ettiðimiz için kullanabiliyor mu true olduðunda skill'i kullanmamýza izin vermesi için
        if (skillManager.canUseKick)
            KickSkill();
        if (skillManager.canUseSlash)
            SlashSkill();
        if (skillManager.canUsePowerUp)
            PowerUpSkill();
    }
    //Normal saldýrýlarýmýzýn metotu
    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
            isAttack = true;
            StartCoroutine(ToFalse(1.01f));//isAttack'ý false yapmak için 1.01 saniye bekliyor
            playerController.swordCollider.SetActive(true);//yürürken kýlýcýmýz collider'la etkileþime girdiðinde hasar vermesin diye sadece kullanýldýðýnda collider'ý aktif ediyoruz.
        }
    }
    //Kick Skill'inin metotu.
    public virtual void KickSkill()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            animator.SetTrigger(Kick);
            isAttack = true;
            StartCoroutine(ToFalse(1.12f));//isAttack'ý 1.12 saniye sonra false'a çevirmek için.
            StartCoroutine(WaitToUse(kickCoolDown, () => skillManager.canUseKick = true));
            playerController.footCollider.SetActive(true);//Ayakta bulunan collider sadece skill kullanýldýðýnda aktif oluyor.
            skillManager.canUseKick = false; 
        }
    }
    //PowerUp Skill'inin metotu.
    public void PowerUpSkill()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            animator.SetTrigger(PowerUp);
            StartCoroutine(ToFalse(2.4f));//isAttack'ý 2.4 saniye sonra false'a çevirmek için.
            StartCoroutine(WaitToUse(powerUpCoolDown, () => skillManager.canUsePowerUp = true));
            healthController.health += 10; 
            isAttack = true;
            skillManager.canUsePowerUp = false; 
        }
    }
    //Slash Skill'inin metotu.
    public void SlashSkill()
    {
        if (Input.GetMouseButtonDown(1)) 
        {
            animator.SetTrigger(Slash);
            StartCoroutine(ToFalse(1.51f));//isAttack'ý 1.5 saniye sonra false'a çevirmek için kullanýyoruz.
            StartCoroutine(WaitToUse(slashCoolDown, () => skillManager.canUseSlash = true));//cooldown 
            playerController.swordCollider.SetActive(true);//dümdüz yürürken kýlýcýmýz hasar vermesin diye kýlýcýn collider'ý sadece slash skillini kullandýðýmýzda aktif oluyor.
            isAttack = true;
            skillManager.canUseSlash = false; //sürekli kullanmayý engellemek için.
        }
    }

    //hýzlý koþma animasyonu için metot.
    void Move()
    {
        if (playerMovement.direction.magnitude >= 0.1f)

        {
            animator.SetFloat("Speed", playerMovement.direction.magnitude);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
        if (playerMovement.speed > 3f)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
    //ölüm animasyonunu çalýþtýrýr.
    public void Death()
    {
        if(healthController.health  <= 0)
        {
            animator.SetBool("isDead",true);
        }
    }
    //isAttack boolean'ýnýn false'a çevirmek için sayaç.
     IEnumerator ToFalse(float index)
    {
        yield return new WaitForSeconds(index);
        isAttack = false;
        playerController.footCollider.SetActive(false);
        playerController.swordCollider.SetActive(false);
    }
    //Sahnelerde skillerin kullanýmýný kontrol etmek ve bekleme sürelerini belirlemek için metot.
    IEnumerator WaitToUse(float cooldown,System.Action onCooldownComplete)
    {
        
        yield return new WaitForSecondsRealtime(cooldown);
        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "Scene1")
        {
            skillManager.canUseKick = true;
            skillManager.canUseSlash = false;
            skillManager.canUsePowerUp = false;
        }
        else if (currentSceneName == "Scene2")
        {
            skillManager.canUseKick = true;
            skillManager.canUseSlash = true;
            skillManager.canUsePowerUp = false;
        }
        else if (currentSceneName == "Scene3")
        {
            skillManager.canUseKick = true;
            skillManager.canUseSlash = true;
            skillManager.canUsePowerUp = true;
        }
       

    }

}
