using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HubungkanTitik_StartDot : MonoBehaviour
{
    public int codeDot;

    [SerializeField] SpriteRenderer dotImage;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] HubungkanTitik_DotPos dotPos;

    Vector3 mousePos, startMousePos;

    bool useLine;
    bool finish;
    private void Start()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, new Vector3(transform.position.x, transform.position.y, 0));
        lineRenderer.SetPosition(1, new Vector3(transform.position.x, transform.position.y, 0));

        dotPos.startDot = this;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && useLine && !finish)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(1, new Vector3(mousePos.x, mousePos.y, 0));

            dotPos.transform.position = lineRenderer.GetPosition(1);
        }
    }
    private void OnMouseDown()
    {
        startMousePos = Input.mousePosition - GetMousePos();

        useLine = true;
    }
    private void OnMouseUp()
    {
        useLine = false;

        if (dotPos.benar)
        {
            lineRenderer.SetPosition(1, new Vector3(dotPos.endDot.transform.position.x, dotPos.endDot.transform.position.y, 0));
            finish = true;

            var color = dotPos.endDot.dotImage.color;
            dotImage.color = color;
            lineRenderer.startColor = color;
            lineRenderer.endColor = color;
        }
        else if (dotPos.salah)
        {
            lineRenderer.SetPosition(1, new Vector3(transform.position.x, transform.position.y, 0));
        }
        else
        {
            lineRenderer.SetPosition(1, new Vector3(transform.position.x, transform.position.y, 0));
        }
    }
    Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
}
