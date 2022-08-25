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
        worldPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5f));

        Debug.Log(worldPos);
        lineRenderer.enabled = true;
        Vector3[] linePos = new Vector3[]
        {
            transform.position,
            new Vector3(-worldPos.x, transform.position.y, (worldPos.z - transform.position.z))
        };
        lineRenderer.SetPositions(linePos);
    }
}