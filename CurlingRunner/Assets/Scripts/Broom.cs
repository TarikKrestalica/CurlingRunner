using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Broom : MonoBehaviour
{
    // Click on it to sweep
    public void Sweep()
    {
        GameManager.character.LoseSpeed(Time.deltaTime * 6);
    }
}
