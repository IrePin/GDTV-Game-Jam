using System;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
   
namespace _DrRush.Scripts.FMOD
{
    public class FmodAudioManager : MonoBehaviour
    {
         public static FmodAudioManager instance;
        
            public EventInstance PlayerFootsteps { get; private set; }
            
            private EventInstance _ost;
        
            public FmodEvents events;
            [SerializeField] private StudioBankLoader bankLoaderPrefab;
            private StudioBankLoader _bank;
            
            private void Awake()
            {
                if (instance == null)
                {
                    instance = this;
                    _bank = Instantiate(bankLoaderPrefab, transform);
                    InitializePlayerFootsteps();
                    DontDestroyOnLoad(gameObject);
                }
                else
                {
                    Destroy(gameObject);
                }

                //masterBus = RuntimeManager.GetBus("bus:/");
                //ambienceBus = RuntimeManager.GetBus("bus:/Ambience");
                //musicBus = RuntimeManager.GetBus("bus:/Music");
                //sfxBus = RuntimeManager.GetBus("bus:/Sfx");
            }

            private void Start()
            {
                InitializeOst(events.Ost);
            }

            private void OnDestroy()
            {
                if (instance == this)
                {
                    Debug.Log($"Clear instance OnDestroy {gameObject.name}");
                    instance = null;
                }
            }
            public void PlayOneShot(EventReference sound, Vector3 worldPosition)
            {
                RuntimeManager.PlayOneShot(sound, worldPosition);
            }
            
            public EventInstance CreateInstance(EventReference eventReference)
            {
                EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
                return eventInstance;
            }
            
            private void InitializePlayerFootsteps()
            {
                PlayerFootsteps = CreateInstance(events.footsteps);
            }
            
            public void InitializeOst(EventReference ostReference)
            {
                _ost = CreateInstance(ostReference);
                _ost.start();
            }
            public void SetMusicArea(MusicArea _area)
            {
                //ambience.setParameterByName("AMBIENCE", (float)area);
                _ost.setParameterByName("MusicArea", (float)_area);
            }
    }
}
