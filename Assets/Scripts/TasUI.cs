using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TasUI : MonoBehaviour
{
    public static TasUI instance;

    public TextMeshProUGUI namaBarangText, deskripsiBarangText;

    public Image logoItem;

    [SerializeField]
    Transform contentItem;

    public GameObject item;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        LoadItem();
        contentItem.GetChild(0).GetComponent<Item>().SetItem();
    }

    public void LoadItem()
    {
        int totalChild = 0;

        for (int i = 0; i < contentItem.childCount; i++)
        {
            Destroy(contentItem.GetChild(i).gameObject);
        }

        var listItem = DataGame.instance.listItem;
        for (int i = 0; i < listItem.itemDatas.Length; i++)
        {
            if (listItem.itemStored[i] != null)
            {
                for (int j = 0; j < listItem.itemDatas.Length; j++)
                {
                    if (listItem.itemStored[i] == listItem.itemDatas[j].namaItem)
                    {
                        GameObject temp = Instantiate(item, contentItem);

                        var itemTemp = temp.GetComponent<Item>();
                        itemTemp.itemData = listItem.itemDatas[j];

                        itemTemp.gameObject.name = itemTemp.itemData.namaItem;
                        itemTemp.iconItem.sprite = itemTemp.itemData.iconItem;

                        temp.transform.SetSiblingIndex(i);
                        totalChild++;
                        break;
                    }
                }
            }
        }


        print("total " + totalChild);
        for (int i = totalChild; i < listItem.itemDatas.Length; i++)
        {
            GameObject temp = Instantiate(item, contentItem);
            var itemTemp = temp.GetComponent<Item>();
            itemTemp.itemData = listItem.itemNull;

            itemTemp.gameObject.name = "ItemKosong";
            itemTemp.iconItem.sprite = itemTemp.itemData.iconItem;

        }
    }

    bool tasUI;
    public void SetTasUI()
    {
        if (!tasUI)
        {
            gameObject.SetActive(true);
            tasUI = true;
        }
        else
        {
            gameObject.SetActive(false);
            tasUI = false;
        }
    }
}
