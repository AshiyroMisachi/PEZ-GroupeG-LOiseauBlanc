using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class S_TimeManager : Manager
{
    [Header("General")]
    [SerializeField]
    //Stock the time spend in the game since the start, in second
    private float time;
    [SerializeField]
    //The maximum time in the game
    private int maxTime;

    [Header("Directional Light")]
    [SerializeField]
    //Reference to the directional of the scene 
    private Transform directionalLight;
    [SerializeField]
    private Vector3 startRotation, endRotation;

    [Header("Cukoo Clock")]
    [SerializeField]
    //The time between each cukoo activation, multiplied by 60 to be in minutes
    private float cukooTimer;

    //Reference to the AudioSource of the cukoo sound
    [SerializeField]
    private AudioSource cukooClockAudio;

    private void Start()
    {
        StartCoroutine(ActivateCukooClock());
    }

    void Update()
    {
        time = Time.time;

        directionalLight.eulerAngles = Vector3.Lerp(startRotation, endRotation, time / maxTime);

        if (time > maxTime)
        {
            EndGame();
        }
    }

    public float GetTime()
    {
        return time;
    }


    private void EndGame()
    {
        //Stop the game
    }

    private IEnumerator ActivateCukooClock()
    {
        while (true)
        {
            //Animation and sound of the cuckooClock
            yield return new WaitForSeconds(cukooTimer);
            Debug.Log("COUCOU");
            cukooClockAudio.Play();
        }
    }
}