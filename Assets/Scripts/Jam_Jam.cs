using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Jam_Jam : MonoBehaviour
{
    [Range(0, 12)] public int jam;
    [Range(0, 60)] public int menit;


    [SerializeField] Transform jarumPendek;
    [SerializeField] Transform jarumPanjang;

    [SerializeField] TextMeshProUGUI jamText;

    private void OnValidate()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (jam <= 0 && menit < 0)
        {
            jam = 0;
            menit = 0;
            return;
        }

        if (menit >= 60)
        {
            jam++;
            menit = 0;
        }
        if (menit < 0 && jam > 0)
        {
            jam--;
            menit = 55;
        }

        jarumPendek.eulerAngles = new Vector3(0, 180, (jam * 30) + (menit * 15 / 30));
        jarumPanjang.eulerAngles = new Vector3(0, 180, menit * 6);

        float jamTemp = Mathf.FloorToInt(jam % 12);
        float menitTemp = Mathf.FloorToInt(menit % 60);
        jamText.text = string.Format("{0:00}:{1:00}", jamTemp, menitTemp);
    }
}
