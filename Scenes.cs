using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Transform cris;
    public Transform mari;

    private void Update()
    {
        if (cris && mari == null)
        {
            Die();
        }
    }
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void End()
    {
        SceneManager.LoadScene("End");
    }

    public void Die()
    {
        SceneManager.LoadScene("GameOver");
    }
}
