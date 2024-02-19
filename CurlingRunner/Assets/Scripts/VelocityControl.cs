using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityControl : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (Mathf.Abs(this.gameObject.transform.rotation.z) > 0)
            {
                GameManager.character.AddSpeed(Time.deltaTime * Mathf.Abs(this.gameObject.transform.rotation.z));
            }
            else
            {
                GameManager.character.LoseSpeed(Time.deltaTime);
            }
        }
    }
}
