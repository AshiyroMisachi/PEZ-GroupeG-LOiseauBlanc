using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S_NavigationManager : Manager
{
    [SerializeField] private GameObject blackImage;

    void Start()
    {
        blackImage.GetComponent<Animator>().SetTrigger("FadeOut");
    }

    public void LaunchVictory()
    {
        LaunchScene("Victory_Screen");
    }

    public void LaunchDefeat()
    {
        LaunchScene("Defeat_Screen");
    }

    private IEnumerator LaunchScene(string sceneName)
    {
        Destroy(gameObject);
        blackImage.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitUntil(() => blackImage.GetComponent<Image>().color.a == 1);
        SceneManager.LoadScene(sceneName);
    }
}