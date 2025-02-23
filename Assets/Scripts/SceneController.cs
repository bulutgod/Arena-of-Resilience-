using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour 
{
    //Sonraki level'e geçmek için  yazdýðýmýz script.
    
    public string scenename;

    private void Start()
    {
         
    }
    private void Update()
    {
       LoadScene();
    }
    public void LoadScene()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Tusalgilandi");
            SceneManager.LoadScene(scenename);
            Time.timeScale = 1.0f;

        }
    }
    
}
