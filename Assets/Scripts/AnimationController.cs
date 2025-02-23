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
    //skillerin animator icerisinde parametre isimlerini kodda kolayla�t�rmak i�in kullan�ld�.
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

        //isAttack true oldu�unda hareket etmesini engellemek i�i kullan�yoruz
        if (!isAttack)
        {
            playerMovement.Movement();
        }

        //her sahnede yeni yetenekler elde etti�imiz i�in kullanabiliyor mu true oldu�unda skill'i kullanmam�za izin vermesi i�in
        if (skillManager.canUseKick)
            KickSkill();
        if (skillManager.canUseSlash)
            SlashSkill();
        if (skillManager.canUsePowerUp)
            PowerUpSkill();
    }
    //Normal sald�r�lar�m�z�n metotu
    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
            isAttack = true;
            StartCoroutine(ToFalse(1.01f));//isAttack'� false yapmak i�in 1.01 saniye bekliyor
            playerController.swordCollider.SetActive(true);//y�r�rken k�l�c�m�z collider'la etkile�ime girdi�inde hasar vermesin diye sadece kullan�ld���nda collider'� aktif ediyoruz.
        }
    }
    //Kick Skill'inin metotu.
    public virtual void KickSkill()
    {
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            animator.SetTrigger(Kick);
            isAttack = true;
            StartCoroutine(ToFalse(1.12f));//isAttack'� 1.12 saniye sonra false'a �evirmek i�in.
            StartCoroutine(WaitToUse(kickCoolDown, () => skillManager.canUseKick = true));
            playerController.footCollider.SetActive(true);//Ayakta bulunan collider sadece skill kullan�ld���nda aktif oluyor.
            skillManager.canUseKick = false; 
        }
    }
    //PowerUp Skill'inin metotu.
    public void PowerUpSkill()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            animator.SetTrigger(PowerUp);
            StartCoroutine(ToFalse(2.4f));//isAttack'� 2.4 saniye sonra false'a �evirmek i�in.
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
            StartCoroutine(ToFalse(1.51f));//isAttack'� 1.5 saniye sonra false'a �evirmek i�in kullan�yoruz.
            StartCoroutine(WaitToUse(slashCoolDown, () => skillManager.canUseSlash = true));//cooldown 
            playerController.swordCollider.SetActive(true);//d�md�z y�r�rken k�l�c�m�z hasar vermesin diye k�l�c�n collider'� sadece slash skillini kulland���m�zda aktif oluyor.
            isAttack = true;
            skillManager.canUseSlash = false; //s�rekli kullanmay� engellemek i�in.
        }
    }

    //h�zl� ko�ma animasyonu i�in metot.
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
    //�l�m animasyonunu �al��t�r�r.
    public void Death()
    {
        if(healthController.health  <= 0)
        {
            animator.SetBool("isDead",true);
        }
    }
    //isAttack boolean'�n�n false'a �evirmek i�in saya�.
     IEnumerator ToFalse(float index)
    {
        yield return new WaitForSeconds(index);
        isAttack = false;
        playerController.footCollider.SetActive(false);
        playerController.swordCollider.SetActive(false);
    }
    //Sahnelerde skillerin kullan�m�n� kontrol etmek ve bekleme s�relerini belirlemek i�in metot.
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
