using UnityEngine;

namespace _DrRush.Scripts.FMOD
{
    public class FmodPlaySound : MonoBehaviour
    {
        public FMODUnity.EventReference eventReference;

        public void Play()
        {
            var playerState = FMODUnity.RuntimeManager.CreateInstance(eventReference);
            playerState.start();
        }
    }
}