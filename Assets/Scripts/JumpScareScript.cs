using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpScareScript : MonoBehaviour
{
    AudioSource audio;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = 200;
    }
    void Start()
    {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("GameOver");
    }
}
