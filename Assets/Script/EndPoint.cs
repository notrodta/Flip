using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour {

    public string nextLevel;

    public bool isGameFinished;
    public GameObject endGameText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("player");
            if (isGameFinished)
            {
                endGameText.SetActive(true);
            }
            else
            {
                LoadLevel();
            }
        }   
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
