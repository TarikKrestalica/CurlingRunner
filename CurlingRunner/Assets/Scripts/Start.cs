using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour
{
    public void GoToGame()
    {
        SceneManager.LoadScene("Game");
    }
}
