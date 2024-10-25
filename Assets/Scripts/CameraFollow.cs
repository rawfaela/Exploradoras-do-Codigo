using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CameraFollow : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public Vector3 offset = new Vector3(0, 6, 20); // Offset centralizado

    private void FixedUpdate()
    {
        Vector3 averagePosition = (player1.position + player2.position) / 2 + offset;
        averagePosition.x = Mathf.Clamp(averagePosition.x, -9f, 9f);
        averagePosition.y = Mathf.Clamp(averagePosition.y, -5f, 5f);
        transform.position = Vector3.Lerp(transform.position, averagePosition, 0.1f);

    }
}
