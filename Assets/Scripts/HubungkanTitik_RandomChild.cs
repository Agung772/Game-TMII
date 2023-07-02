using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubungkanTitik_RandomChild : MonoBehaviour
{
    int random;
    [SerializeField] bool[] randomBool;

    [SerializeField] Vector3[] v3Awal;

    private void Awake()
    {
        randomBool = new bool[transform.childCount];
        v3Awal = new Vector3[transform.childCount];
        GameObject[] tempChild = new GameObject[transform.childCount];


        for (int i = 0; i < tempChild.Length; i++)
        {
            v3Awal[i] = transform.GetChild(i).position;
        }

        for (int i = 0; i < tempChild.Length; i++)
        {
            RandomInt();
            transform.GetChild(i).position = v3Awal[random];
        }

        void RandomInt()
        {
            int tempRandom = Random.Range(0, tempChild.Length);

            for (int i = 0; i < tempChild.Length; i++)
            {
                if (!randomBool[i] && tempRandom == i)
                {
                    randomBool[i] = true;
                    random = tempRandom;
                    break;
                }
                else if (randomBool[i] && tempRandom == i)
                {
                    RandomInt();
                }
            }

        }
    }
}
