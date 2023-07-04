using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusMinus_UI : MonoBehaviour
{
    public static PlusMinus_UI instance;

    public Transform bilanganBersusunParent;
    public GameObject bilanganBersusunPrefab;
    private void Awake()
    {
        instance = this;
    }
}
