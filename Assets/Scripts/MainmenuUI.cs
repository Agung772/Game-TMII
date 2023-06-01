using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainmenuUI : MonoBehaviour
{
    [SerializeField]
    Button
        newgameButton,
        loadgameButton,
        howtoplayButton,
        creditButton,
        quitButton;

    [SerializeField]
    GameObject settingUI, popupNewgame;

    private void Start()
    {
        newgameButton.onClick.AddListener(Newgame);
        loadgameButton.onClick.AddListener(Loadgame);
        howtoplayButton.onClick.AddListener(UIManager.instance.Howtoplay);

        quitButton.onClick.AddListener(Quit);
    }

    bool oneClick = false;
    void Newgame()
    {
        if (oneClick) return;

        if (DataGame.instance.nama == "")
        {
            UIManager.instance.PindahScene("Newgame");
            oneClick = true;
        }
        else
        {
            popupNewgame.SetActive(true);
        }

    }

    public void YesNewgame()
    {
        if (oneClick) return;
        UIManager.instance.PindahScene("Newgame");
        oneClick = true;
    }
    void Loadgame()
    {
        if (oneClick) return;

        if (DataGame.instance.nama == "")
        {
            UIManager.instance.SpawnNotif("Bikin profil terlebih dahulu");
        }
        else
        {
            //Cari scene terakhir kali login
            var dataGame = DataGame.instance;
            if (dataGame.pulau == "Sulawesi")
            {
                UIManager.instance.PindahScene("Sulawesi");
            }
            else if (dataGame.pulau == "Kalimantan")
            {
                UIManager.instance.PindahScene("Kalimantan");
            }
            else if (dataGame.pulau == "Jawa")
            {
                UIManager.instance.PindahScene("Jawa");
            }
            else if (dataGame.pulau == "Sumatera")
            {
                UIManager.instance.PindahScene("Sumatera");
            }
            else if (dataGame.pulau == "Papua")
            {
                UIManager.instance.PindahScene("Papua");
            }
            else
            {
                UIManager.instance.PindahScene("PilihPulau");
            }

            oneClick = true;
        }

    }
    void Credit()
    {
        if (oneClick) return;
        UIManager.instance.PindahScene("Newgame");
        oneClick = true;
    }
    void Quit()
    {
        if (oneClick) return;
        Application.Quit();
        oneClick = true;
    }

    bool setting;
    public void Setting()
    {
        if (!setting)
        {
            setting = true;
            settingUI.SetActive(true);
        }
        else if (setting)
        {
            setting = false;
            settingUI.SetActive(false);
        }
    }
}
