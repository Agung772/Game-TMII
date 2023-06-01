using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevmodeUI : MonoBehaviour
{
    public void AddKoin()
    {
        DataGame.instance.AddKoin(10000);
    }

    public void AddTiket()
    {
        DataGame.instance.AddTiket(5);
    }
}
