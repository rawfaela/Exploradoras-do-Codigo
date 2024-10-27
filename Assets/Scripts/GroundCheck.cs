using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public Cris cris;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Tilemap")
        {
            cris.isground = true;
            Debug.Log("cris tocando o chão!");
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Tilemap")
        {
            cris.isground = false;
            Debug.Log("O objeto filho saiu do contato com o chão!");
        }
    }

}