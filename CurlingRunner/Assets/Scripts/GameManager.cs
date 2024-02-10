using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public static Ball ball
    {
        get
        {
            if(gameManager.m_ball == null)
            {
                gameManager.m_ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
            }

            return gameManager.m_ball;
        }
    }

    private Ball m_ball;

    public static Broom broom
    {
        get
        {
            if (gameManager.m_broom == null)
            {
                gameManager.m_broom = GameObject.FindGameObjectWithTag("Broom").GetComponent<Broom>();
            }

            return gameManager.m_broom;
        }
    }

    private Broom m_broom;

    private void Awake()
    {
        if(gameManager)
        {
            Destroy(gameManager);
        }

        gameManager = this;
        DontDestroyOnLoad(gameManager);
    }

}
