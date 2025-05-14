using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadLevelScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Time.timeScale != 1) Time.timeScale = 1;
        StartCoroutine(letsGo());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator letsGo()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync(2);
    }
}
