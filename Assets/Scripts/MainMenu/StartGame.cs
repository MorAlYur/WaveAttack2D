using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject popapItem;
   
    
 public void StartGameButton()
    {
        
       SceneManager.LoadScene("TestLevel1");
    }
}
