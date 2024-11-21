using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck1 : MonoBehaviour
{
    public Mari mari;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Tilemap")
        {
            mari.isground = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Tilemap")
        {
            mari.isground=false;
        }
    }
}