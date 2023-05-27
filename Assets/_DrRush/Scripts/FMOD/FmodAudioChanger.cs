using UnityEngine;

namespace _DrRush.Scripts.FMOD
{
    public class FmodAudioChanger : MonoBehaviour
    {
        [Header("Area")]
        [SerializeField] private MusicArea _area;

        private void Start()
        {
            FmodAudioManager.instance.SetMusicArea(_area);
            Debug.Log($"[AudioChanger] Set music area {_area}");
        }
    }
}