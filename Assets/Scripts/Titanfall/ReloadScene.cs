using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour
{
    private bool Once = true;

    void FixedUpdate(){
        if(Input.GetKey(KeyCode.R) && Once){
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
            Once = false;
        }
    }
}
