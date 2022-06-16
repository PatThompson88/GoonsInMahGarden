using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int loadingTime = 3;
    private int currentSceneIndex;
    
    public void LoadHomeScreen(){
        SceneManager.LoadScene("HomeScreen");
    }
    public void LoadMainLoop(){
        SceneManager.LoadScene("MainLoop");
    }
    public void QuitGame(){
        Application.Quit();
    }
    private IEnumerator CountdownAndLoadHomeScreen(){
        yield return new WaitForSeconds(loadingTime);
        LoadHomeScreen();
    }
    private void Start(){
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0){
            StartCoroutine(CountdownAndLoadHomeScreen());
        }
    }
}
