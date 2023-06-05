using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartuMemori_Kartu : MonoBehaviour
{
    public float codeKartu;
    public bool isDepan;
    public bool selesai;

    [SerializeField] Animator animator;

    public bool cooldown, check;
    public void SetKartu()
    {
        if (!cooldown && !check && !selesai)
        {
            cooldown = true;
            StartCoroutine(Coroutine());
            IEnumerator Coroutine()
            {
                if (!isDepan)
                {
                    isDepan = true;
                    animator.SetTrigger("Depan");

                    KartuMemori_Gameplay.instance.CekKartu(codeKartu, this);
                }
                else
                {
                    isDepan = false;
                    animator.SetTrigger("Belakang");
                    KartuMemori_Gameplay.instance.CekKartu(0, this);
                }
                yield return new WaitForSeconds(0.66f);
                cooldown = false;
            }
        }
    }

    public void SetKartuBelakang()
    {
        isDepan = false;
        animator.SetTrigger("Belakang");
    }
}
