using FMODUnity;
using UnityEngine;

namespace _DrRush.Scripts.FMOD
{
    public class FmodEvents : MonoBehaviour
    {
        [field: Header("SFX")]
        [field: Header("footsteps")]
        [field: SerializeField] public EventReference footsteps { get; private set; }
        
        [field: SerializeField] public EventReference Ost { get; private set; }
    }
}
