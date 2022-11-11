using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public float levelStartDelay;
    public Player player;
    public CinemaMachineSwitcher cameraScript;
    public BlackFade blackFade;

    private bool isFade;

    private void Start()
    {
        player.moveRight = true;
        StartCoroutine(StartLevel());
        isFade = true;
    }

    void Update()
    {
        if (isFade)
        {
            blackFade.FadeIn();
        }
        
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

    // Update is called once per frame
    


}
