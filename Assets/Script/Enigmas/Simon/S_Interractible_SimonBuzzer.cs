using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Interractible_SimonBuzzer : Interractibles
{
    [SerializeField]
    private S_SimonManager simonManager;

    [SerializeField]
    private int buzzerIndex;

    private bool isPushed;

    [SerializeField]
    private Light buzzerLight, redLight;

    [SerializeField]
    private GameObject buzzer;
    [SerializeField]
    private Vector3 buzzerBasePosition, buzzerPushPosition;


    public override void Interraction()
    {
        if (!isPushed)
        {
            StartCoroutine(PushButton());
        }
    }

    private IEnumerator PushButton()
    {

        isPushed = true;
        buzzer.transform.localPosition = buzzerPushPosition;
        if (simonManager.GetActivated() && !simonManager.GetInSequence())
        {
            buzzerLight.enabled = true;
            simonManager.AddPlayerSequence(buzzerIndex);
        }

        yield return new WaitForSeconds(0.5f);

        isPushed = false;
        buzzer.transform.localPosition = buzzerBasePosition;
        if (simonManager.GetActivated() && !simonManager.GetInSequence())
        {
            buzzerLight.enabled = false;
        }

    }

    public IEnumerator ActiveLight()
    {
        buzzerLight.enabled = true;

        yield return new WaitForSeconds(0.5f);

        buzzerLight.enabled = false;
    }

    public IEnumerator ErrorLight()
    {
        redLight.enabled = true;

        yield return new WaitForSeconds(0.5f);

        redLight.enabled = false;
    }
}