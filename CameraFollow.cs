using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CameraFollow : MonoBehaviour
{
    public Transform cris;
    public Transform mari;
    public Vector3 offset = new Vector3(0, 6, 20); // Offset centralizado

    private void FixedUpdate()
    {
        if (cris == null && mari != null)
        {
            Vector3 targetPosition = mari.position + offset; // Segue apenas mari
            targetPosition.x = Mathf.Clamp(targetPosition.x, -9f, 9f);
            targetPosition.y = Mathf.Clamp(targetPosition.y, -5f, 5f);
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);
        }
        else if (mari == null && cris != null)
        {
            Vector3 targetPosition = cris.position + offset; // Segue apenas cris
            targetPosition.x = Mathf.Clamp(targetPosition.x, -9f, 9f);
            targetPosition.y = Mathf.Clamp(targetPosition.y, -5f, 5f);
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);
        }
        else if (cris != null && mari != null)
        {
            Vector3 averagePosition = (cris.position + mari.position) / 2 + offset;
            averagePosition.x = Mathf.Clamp(averagePosition.x, -9f, 9f);
            averagePosition.y = Mathf.Clamp(averagePosition.y, -5f, 5f);
            transform.position = Vector3.Lerp(transform.position, averagePosition, 0.1f);
        }
    }
}
