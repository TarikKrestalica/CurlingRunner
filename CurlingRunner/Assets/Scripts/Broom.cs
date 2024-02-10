using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour
{
    private bool clicked;

    private void Start()
    {
        clicked = false;
    }

    public bool ContactWithBroom()
    {
        return clicked;
    }

    public void SetContactWithBroom(bool toggle)
    {
        clicked = toggle;
    }

    public void ApplyRotationToBall(float value)
    {
        if(GameManager.ball.GetCurrentSpeed() < 0)
        {
            return;
        }

        Vector3 curPosition = this.transform.parent.position;
        curPosition.y -= Time.deltaTime * value;
        this.transform.parent.position = curPosition;
        
    }

}
