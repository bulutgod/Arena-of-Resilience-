using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//start butonuna basýldýgýnda kendisinden sonraki sahneye geçmesi için.
      
    }

    public void Quit()
    {
        Application.Quit();//quit butonuna basýldýgýnda oyunun kapanmasi icin.
    }
}
