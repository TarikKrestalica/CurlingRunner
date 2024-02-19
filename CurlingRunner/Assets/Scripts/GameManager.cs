using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public static Character character
    {
        get
        {
            if (gameManager.m_character == null)
            {
                gameManager.m_character = GameObject.FindGameObjectWithTag("Character").GetComponent<Character>();
            }

            return gameManager.m_character;
        }
    }

    private Character m_character;

    public static TargetManager targetManager
    {
        get
        {
            if (gameManager.m_targetManager == null)
            {
                gameManager.m_targetManager = GameObject.FindGameObjectWithTag("TargetManager").GetComponent<TargetManager>();
            }

            return gameManager.m_targetManager;
        }
    }

    private TargetManager m_targetManager;


    private void Awake()
    {
        if(gameManager)
        {
            Destroy(gameManager);
        }

        gameManager = this;
        DontDestroyOnLoad(gameManager);
        targetManager.gameObject.SetActive(false);

    }

    private void Update()
    {
        if (gameManager.m_character == null)
            return;

        if(character.GetSpeed() <= 0 && PlacementManager.resultingPlace == "")  // Character has come to a full stop!
        {
            if(!targetManager.gameObject.activeInHierarchy)
            {
                targetManager.gameObject.SetActive(true);
                gameManager.m_targetManager.FindResult();
            }
            
        }
    }

    public void GoToScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
