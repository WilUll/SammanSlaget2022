using System;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private Vector3 screenPos;
    private Vector3 worldPos;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void DrawLine(Vector3 mousePos)
    {
        worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 5f));

        lineRenderer.enabled = true;
        Vector3[] linePos = new Vector3[]
        {
            transform.position,
            new Vector3(transform.position.x - (transform.position.x + worldPos.x), transform.position.y, transform.position.z + (transform.position.z - worldPos.z))
        };
        lineRenderer.SetPositions(linePos);
    }
}