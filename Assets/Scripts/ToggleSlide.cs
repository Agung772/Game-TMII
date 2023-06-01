using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ToggleSlide : MonoBehaviour
{
    public bool isOn;

    [SerializeField]
    GameObject button;
    [SerializeField]
    Sprite trueToggle, falseToggle;

    public UnityEvent onSlide;
    private void Start()
    {
        button.GetComponent<Button>().onClick.AddListener(SetToggleSlide);
    }

    private void OnEnable()
    {
        Refresh();
    }
    public void SetToggleSlide()
    {
        onSlide.Invoke();

        if (!isOn)
        {
            isOn = true;
            button.GetComponent<Image>().sprite = trueToggle;
            GetComponent<Animator>().SetTrigger("True");
        }
        else
        {
            isOn = false;
            button.GetComponent<Image>().sprite = falseToggle;
            GetComponent<Animator>().SetTrigger("False");
        }
    }

    public void Refresh()
    {
        if (!isOn)
        {
            button.GetComponent<Image>().sprite = falseToggle;
            GetComponent<Animator>().SetTrigger("False");

        }
        else
        {
            button.GetComponent<Image>().sprite = trueToggle;
            GetComponent<Animator>().SetTrigger("True");
        }
        print("Refreshhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
    }
}
