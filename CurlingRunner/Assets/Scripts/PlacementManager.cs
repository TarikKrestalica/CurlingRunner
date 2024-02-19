using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementManager : MonoBehaviour
{
    private static string resultingPlace = ""; 
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (GameManager.character.GetSpeed() < 0)
            return;

        if (collision.gameObject.tag != "WhiteLevel" && collision.gameObject.tag != "BlueLevel" && collision.gameObject.tag != "RedLevel" && collision.gameObject.tag != "BullsEye")
            return;

        if (collision.gameObject.tag == "WhiteLevel" || collision.gameObject.tag == "BlueLevel")
        {
            SetResultingPlace("Bronze");
        }
        else if (collision.gameObject.tag == "RedLevel")
        {
            SetResultingPlace("Silver");
        }
        else if (collision.gameObject.tag == "BullsEye")
        {
            SetResultingPlace("Gold");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GameManager.character.GetSpeed() < 0)
            return;

        if (collision.gameObject.tag == "WhiteLevel")
        {
            SetResultingPlace("Participation Trophy");
        }
    }

    public static string GetResultingPlace()
    {
        return resultingPlace;
    }

    public static void SetResultingPlace(string place)
    {
        resultingPlace = place;
    }


}
