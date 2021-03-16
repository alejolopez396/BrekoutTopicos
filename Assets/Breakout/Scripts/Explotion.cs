using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion : MonoBehaviour
{

    [SerializeField] AudioClip explotioSfx;

    void Start()
    {
        AudioController audioController = FindObjectOfType<AudioController>();
        audioController.PlaySfx(explotioSfx);
    }

   
}
