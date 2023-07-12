using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarisBilangan_Content : MonoBehaviour
{
    public static BarisBilangan_Content instance;

    public BarisBilangan_Tempat[] tempat;
    public bool bla = true;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        FalseDelay();
    }

    private void OnValidate()
    {
        tempat = new BarisBilangan_Tempat[transform.childCount];
        for (int i = 0; i < tempat.Length; i++)
        {
            tempat[i] = transform.GetChild(i).GetComponent<BarisBilangan_Tempat>();
        }
    }


    public void FalseDelay()
    {
        for (int i = 0; i < tempat.Length; i++)
        {
            tempat[i].delayParent.SetActive(false);
        }
    }

}
