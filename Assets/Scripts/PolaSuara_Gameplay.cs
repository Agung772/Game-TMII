using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PolaSuara_Gameplay : MonoBehaviour
{
    [System.Serializable]
    public struct Bell
    {
        public PolaSuara_Bell bell;
        public AudioClip clip;
    }

    [SerializeField] List<Bell> bell;


}
