using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolaSuara_Bell : MonoBehaviour
{
    public int codeBell;

    [SerializeField] AudioClip suaraBell;
    [SerializeField] GameObject efectBunyi;

    public bool cooldown, check;
    public void ClickBell()
    {
        if (!cooldown && !check)
        {
            cooldown = true;
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                AudioManager.instance.SFXAudioSource.PlayOneShot(suaraBell);
                efectBunyi.SetActive(true);
                yield return new WaitForSeconds(2);
                efectBunyi.SetActive(false);
                cooldown = false;
            }
        }
    }

    public void StartBell()
    {
        StartCoroutine(Coroutine());
        IEnumerator Coroutine()
        {
            AudioManager.instance.SFXAudioSource.PlayOneShot(suaraBell);
            efectBunyi.SetActive(true);
            print("Bunyi " + gameObject.name);
            yield return new WaitForSeconds(2);
            efectBunyi.SetActive(false);

        }
    }
}
