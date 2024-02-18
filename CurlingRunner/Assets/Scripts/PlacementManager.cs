using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    public static string resultingPlace = ""; 
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (GameManager.character.GetSpeed() > 0)
            return;

        if (collision.gameObject.tag != "WhiteLevel" && collision.gameObject.tag != "BlueLevel" && collision.gameObject.tag != "RedLevel" && collision.gameObject.tag != "BullsEye")
            return;

        if (collision.gameObject.tag == "WhiteLevel" || collision.gameObject.tag == "BlueLevel")
        {
            resultingPlace = "Bronze";
        }
        else if (collision.gameObject.tag == "RedLevel")
        {
            resultingPlace = "Silver";
        }
        else if (collision.gameObject.tag == "BullsEye")
        {
            resultingPlace = "Gold";
        }

        GameManager.character.SetResult(resultingPlace);
    }
}
