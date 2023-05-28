using _DrRush.Scripts.FMOD;
using UnityEngine;

namespace _DrRush.Scripts.UI
{
    public class ButtonSounds : MonoBehaviour
    {
   
        public void PlayButtonClick()
        {
            FmodAudioManager.Instance.InitializePlayButtonClick();
        }
        public void ButtonsClick()
        {
            FmodAudioManager.Instance.InitializeButtonClick();
        }
    }
}