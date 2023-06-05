using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(1);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }        
        
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            DataGame.instance.SaveItem("Item 0");
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            DataGame.instance.SaveItem("Item 1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            DataGame.instance.SaveItem("Item 2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            DataGame.instance.SaveItem("Item 3");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            DataGame.instance.SaveItem("Item 4");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            DataGame.instance.SaveItem("Item 5");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            DataGame.instance.SaveItem("Item 6");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            DataGame.instance.SaveItem("Item 7");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            DataGame.instance.SaveItem("Item 8");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            DataGame.instance.SaveItem("Item 9");
        }

        UIManager.instance.DevmodeUI();


    }
}
