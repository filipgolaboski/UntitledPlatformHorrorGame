using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public string nextLevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !collision.gameObject.GetComponent<Character>().characterDeath)
        {
            SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
        }
    }
}
