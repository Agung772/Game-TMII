using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool ground;

    private void OnTriggerEnter(Collider other)
    {
        ground = true;
    }

    private void OnTriggerExit(Collider other)
    {
        ground = false;
    }
}
