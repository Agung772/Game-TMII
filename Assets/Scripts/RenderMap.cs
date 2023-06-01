using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderMap : MonoBehaviour
{
    public static RenderMap instance;

    [SerializeField] Vector3 posisiAwal;

    [SerializeField] float positionX;
    [SerializeField] float positionY;
    [SerializeField] float positionZ;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        transform.parent = null;

        posisiAwal = transform.position;

        positionX = posisiAwal.x;
        positionY = posisiAwal.y;
        positionZ = posisiAwal.z;

        gameObject.SetActive(false);
    }

    private void Update()
    {
        float rangeX = posisiAwal.x - transform.position.x;
        float rangeY = posisiAwal.y - transform.position.y;
        float rangeZ = posisiAwal.z - transform.position.z;

        //Input Scroll
        if (transform.position.y <= posisiAwal.y)
        {
            positionY -= Input.mouseScrollDelta.y * 1;
        }

        //Input Axis Mouse
        if (Input.GetMouseButton(0))
        {
            positionX -= Input.GetAxis("Mouse X") * 3;
            positionZ -= Input.GetAxis("Mouse Y") * 3;
        }
        positionY = Mathf.Clamp(positionY, posisiAwal.y - 100, posisiAwal.y);

        positionX = Mathf.Clamp(positionX, posisiAwal.x - rangeY * 0.6f, posisiAwal.x + rangeY * 0.6f);
        positionZ = Mathf.Clamp(positionZ, posisiAwal.z - rangeY * 0.6f, posisiAwal.z + rangeY * 0.6f);

        transform.position = new Vector3(positionX, positionY, positionZ);
    }
}
