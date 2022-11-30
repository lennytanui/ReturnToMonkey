using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEntrance : MonoBehaviour
{
    public float levelStartDelay;
    public Player player;
    public CinemaMachineSwitcher cameraScript;
    public Fade fade;

    private bool isFade;

    private void Start()
    {
        player.moveRight = true;
        StartCoroutine(StartLevel());
        fade.FadeIn();
    }

    IEnumerator StartLevel()
    {
        player.transform.position = transform.position;
        cameraScript.SwitchToEntranceState();

        yield return new WaitForSecondsRealtime(levelStartDelay);
        cameraScript.SwitchToCamState();
        player.moveRight = false;
        isFade = false;
    }

}
