using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Metagame_PilihSubTema : MonoBehaviour
{
    [SerializeField] GameObject templateUI;
    [SerializeField] Transform parentSpawn;
    public void Set(string[] namaSubtema,string[] namaMinigame)
    {

        //Delete child lama
        for(int i = 0; i < parentSpawn.childCount; i++)
        {
            if (i != 0)
            {
                Destroy(parentSpawn.GetChild(i).gameObject);
            }
        }

        gameObject.SetActive(true);



        for (int i = 0; i < namaMinigame.Length; i++)
        {
            GameObject tempSubtema = Instantiate(templateUI, parentSpawn);
            tempSubtema.GetComponent<Metagame_Subtema>().titleText.text = namaSubtema[i];
            tempSubtema.GetComponent<Metagame_Subtema>().namaScene = DataGame.instance.pulau + namaMinigame[i];
            tempSubtema.SetActive(true);
            print(DataGame.instance.pulau + namaMinigame[i]);
        }

        parentSpawn.GetChild(0).gameObject.SetActive(false);
    }




}
