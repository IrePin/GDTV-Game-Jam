using System.Collections;
using System.Collections.Generic;
using _DrRush.Scripts.FMOD;
using FMODUnity;
using UnityEngine;

public class BadDream : MonoBehaviour
{
    [SerializeField] private EventReference badDream;
    void Awake()
    {
        FmodAudioManager.Instance.InitializeBadDream();
    }
}
