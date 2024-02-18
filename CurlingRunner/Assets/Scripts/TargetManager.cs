using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TargetManager : MonoBehaviour
{
    [SerializeField] Image imageComponent;
    [SerializeField] TMP_Text resultText;
    [SerializeField] List<Sprite> ranks;

    public void SetImage(Sprite image)
    {
        imageComponent.sprite = image;
    }

    public Sprite GetSprite()
    {
        return imageComponent.sprite;
    }

    public void FindResult()
    {
        string result = GameManager.character.GetResult();
        resultText.text = result;
        Sprite resultingTrophy = GetTrophy(result);
        SetImage(resultingTrophy);
    }

    Sprite GetTrophy(string result)
    {
        foreach(Sprite trophy in ranks)
        {
            if(result == trophy.name)
            {
                return trophy;
            }
        }

        return null;
    }
}
