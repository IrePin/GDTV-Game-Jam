using _DrRush.Scripts.FMOD;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _DrRush.Scripts.UI
{
    public class PointHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {

        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            FmodAudioManager.Instance.InitializeButtonClick();
        }

        public void OnPointerExit(PointerEventData pointerEventData)
        {

        }
    }
}