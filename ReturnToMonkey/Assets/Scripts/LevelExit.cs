using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public float levelLoadDelay = 1f;
    public BlackFade blackFade;
    public Player player;
    public CinemaMachineSwitcher cameraScript;

    private Color changeFade;
    private bool canFade;

    private void Start()
    {
        canFade = false;
    }
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag =="Player")
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        cameraScript.SwitchToExitState();
        blackFade.FadeOut();
        player.moveRight = true;
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    
}
