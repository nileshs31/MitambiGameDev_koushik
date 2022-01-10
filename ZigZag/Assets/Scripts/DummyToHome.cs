using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DummyToHome : MonoBehaviour
{
    public AsyncOperation op;
    float prog;
    void Start()
    {
        StartCoroutine(LoadAds());
    }

    IEnumerator LoadAds()
    {
        op = SceneManager.LoadSceneAsync("MainMenu");
        op.allowSceneActivation = false;

        yield return new WaitForSeconds(3.5f);
        op.allowSceneActivation = true;
    }

    
}
