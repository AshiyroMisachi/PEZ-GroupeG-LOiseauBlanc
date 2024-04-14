using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_EndScreen : MonoBehaviour
{
    [SerializeField] private GameObject blackImage;

    private void Start()
    {
        blackImage.GetComponent<Animator>().SetTrigger("FadeOut");
    }

    public void LaunchMainScreen()
    {
        StartCoroutine(LaunchScene("Main_Screen"));
    }

    public IEnumerator LaunchScene(string sceneName)
    {
        blackImage.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitUntil(() => blackImage.GetComponent<Image>().color.a == 1);
        SceneManager.LoadScene(sceneName);
    }
}