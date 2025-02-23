using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillManager : MonoBehaviour
{
    //her sahnede her skilli kullanam�yoruz bu y�zden sahneler de�i�ti�inde skillerimizi kullanabilmemiz i�in script.
    public bool canUseKick = false;
    public bool canUseSlash = false;
    public bool canUsePowerUp = false;

    private void Start()
    {
        ApplySceneSkills();
    }

    private void ApplySceneSkills()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        Debug.Log("�u anki sahne: " + currentSceneName);

        switch (currentSceneName)
        {
            case "Scene1"://sahne 1'ken sadece tekme atabiliyoruz.
                canUseKick = true;  
                canUseSlash = false;
                canUsePowerUp = false;
                break;
            case "Scene2"://sahne 2'iken sadece powerup kullanam�yoruz.
                canUseKick = true;
                canUseSlash = true; 
                canUsePowerUp = false;
                break;
            case "Scene3"://sahne 3'te her skilli kullanabiliyoruz.
                canUseKick = true;
                canUseSlash = true;
                canUsePowerUp = true; 
                break;
            case "Scene4"://sahne 4'te boss fight ve her skilli kullanabiliyoruz.
                canUseKick = true;
                canUsePowerUp = true;
                canUseSlash=true;
                break;
            
        }
    }
}