using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public float levelLoadDelay = 1f;
    public SpriteRenderer BlackBoxSprite;
    public float fadeSpeed = 1;
    public Player player;
    public CinemaMachineSwitcher cameraScript;

    private Color changeFade;
    private bool canFade;

    private void Start()
    {
        canFade = false;
        changeFade = new Color(0f, 0f, 0f, fadeSpeed);
    }
    private void Update()
    {
        if (canFade)
        {
            FadeToBlack();
        }
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
        canFade = true;
        player.moveRight = true;
        //if (canMove) {
        //NORMAL MOVEMENT
        //else {
        //horizontalMove = runSpeed;
        //}
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    

    private void FadeToBlack()
    {
        BlackBoxSprite.color += changeFade * Time.deltaTime;
    }
}
