using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//start butonuna bas�ld�g�nda kendisinden sonraki sahneye ge�mesi i�in.
      
    }

    public void Quit()
    {
        Application.Quit();//quit butonuna bas�ld�g�nda oyunun kapanmasi icin.
    }
}
