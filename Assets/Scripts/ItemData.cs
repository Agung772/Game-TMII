using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "ItemTas", menuName = "Scriptable Object/Item")]
public class ItemData : ScriptableObject
{
    public Sprite iconItem;
    public string namaItem, deskripsiItem;
}
