using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject loadingScreenUI;
    public Image loadingBar;
    public TextMeshProUGUI loadingText;

    [Space]
    public GameObject notifPrefab;

    [Space]
    [SerializeField]
    GameObject howtoplayUI;

    [Space]
    [SerializeField]
    GameObject devmodeUI;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void PindahScene(string value)
    {
        StartCoroutine(SceneCoroutine());
        IEnumerator SceneCoroutine()
        {
            loadingScreenUI.SetActive(true);
            loadingScreenUI.GetComponent<Animator>().SetTrigger("Start");
            loadingScreenUI.GetComponent<LoadingScreen>().StartRandom();

            loadingBar.fillAmount = 0;
            loadingText.text = 0 + "%";

            yield return new WaitForSeconds(2);

            var loadScene = SceneManager.LoadSceneAsync(value);
            loadScene.allowSceneActivation = false;

            while (!loadScene.isDone)
            {
                float loading = loadScene.progress / 0.9f;
                loadingBar.fillAmount = loading;
                loadingText.text = (loading * 100).ToString("F0") + "%";

                if (loading >= 1)
                {
                    yield return new WaitForSeconds(2);
                    loadScene.allowSceneActivation = true;
                    loadingScreenUI.GetComponent<Animator>().SetTrigger("Exit");
                    print("Selesai pindah scene");

                }
                yield return null;
            }
        }
    }

    public void SpawnNotif(string text)
    {

        Notif already = FindObjectOfType<Notif>();
        if (already != null)
        {
            Destroy(already.gameObject);
        }

        GameObject temp = Instantiate(notifPrefab, transform.GetChild(0).transform.GetChild(0).transform);
        temp.GetComponent<Notif>().notifText.text = text;
        Destroy(temp, 3);
    }

    bool howtoplay;
    public void Howtoplay()
    {
        if (!howtoplay)
        {
            howtoplay = true;
            howtoplayUI.SetActive(true);
        }
        else if (howtoplay)
        {
            howtoplay = false;
            howtoplayUI.SetActive(false);
        }
    }

    public float resetTime, countClickDevmode;
    public void DevmodeUI()
    {
        if (resetTime > 0) resetTime -= Time.deltaTime;
        if (resetTime <= 0) countClickDevmode = 0;
        if (Input.GetKeyDown(KeyCode.Return))
        {
            resetTime = 1;
            countClickDevmode += 1;
            if (countClickDevmode == 10)
            {
                devmodeUI.SetActive(true);
            }
        }

    }
}
