using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedTracker : MonoBehaviour
{
    [SerializeField] TMP_Text text;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.character.GetSpeed() < 0)
            return;

        text.text = "Speed: " + Math.Round(GameManager.character.GetSpeed(), 2);
    }
}
