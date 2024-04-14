using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_MainScreen : MonoBehaviour
{
     [SerializeField] private GameObject creditImage;
     [SerializeField] private GameObject blackImage;

    private void Start()
    {
        blackImage.GetComponent<Animator>().SetTrigger("FadeOut");
    }

    public void LaunchMainScene()
    {
        StartCoroutine(LaunchScene("Main_Scene"));
    }

    public void ShowCredits()
    {
        creditImage.SetActive(!creditImage.activeSelf);
    }

    public IEnumerator LaunchScene(string sceneName)
    {
        blackImage.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitUntil(() => blackImage.GetComponent<Image>().color.a == 1);
        SceneManager.LoadScene(sceneName);
    }
}