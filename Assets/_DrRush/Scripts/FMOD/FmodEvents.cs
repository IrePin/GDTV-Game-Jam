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
        
        [field: Header("Teleportation")]
        [field: SerializeField] public EventReference Teleportation { get; private set; }
        [field: Header("ActiveTeleport")]
        [field: SerializeField] public EventReference ActiveTeleport { get; private set; }
        [field: Header("Climb")]
        [field: SerializeField] public EventReference Climb { get; private set; }
        
        [field: Header("ElShieldOn")]
        [field: SerializeField] public EventReference ElShieldOn { get; private set; }
        
        [field: Header("Explosion")]
        [field: SerializeField] public EventReference Explosion { get; private set; }
       
        [field: Header("Play Button Click")]
        [field: SerializeField] public EventReference PlayButtonClick { get; private set; }
        [field: Header("Buttons Click")]
        [field: SerializeField] public EventReference ButtonClick { get; private set; }
        
    }
}
