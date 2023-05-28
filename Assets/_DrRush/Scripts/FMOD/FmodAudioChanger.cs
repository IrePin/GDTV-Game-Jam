using UnityEngine;
using UnityEngine.Serialization;

namespace _DrRush.Scripts.FMOD
{
    public class FmodAudioChanger : MonoBehaviour
    {
        [Header("Area")]
        [SerializeField] private MusicArea area;

        private void Start()
        {
            FmodAudioManager.Instance.SetMusicArea(area);
            Debug.Log($"[AudioChanger] Set music area {area}");
        }
    }
}