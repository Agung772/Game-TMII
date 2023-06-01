using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Item : MonoBehaviour
{
    public ItemData itemData;

    public Image iconItem;

    public void SetItem()
    {
        if (itemData.namaItem != "")
        {
            TasUI tasUI = FindObjectOfType<TasUI>();

            //itemUI.namaBarangText.text = itemData.namaItem;
            tasUI.namaBarangText.text = gameObject.name;
            tasUI.deskripsiBarangText.text = itemData.deskripsiItem;

            tasUI.logoItem.sprite = GetComponent<Image>().sprite;
        }
        else
        {
            UIManager.instance.SpawnNotif("Carilah barang yang dapat di koleksi!");
        }

    }
}
