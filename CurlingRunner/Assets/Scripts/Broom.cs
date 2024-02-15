using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Broom : MonoBehaviour
{
    // Click on it to sweep
    public void Sweep(BaseEventData data)
    {
        GameManager.character.LoseSpeed(Time.deltaTime * 5);
    }
}
