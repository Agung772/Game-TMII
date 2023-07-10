using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarisBilangan_UI : MonoBehaviour
{
    public static BarisBilangan_UI instance;

    public GameObject content;

    private void Awake()
    {
        instance = this;
    }
}
