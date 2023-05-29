using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using STOP_MODE = FMOD.Studio.STOP_MODE;

namespace _DrRush.Scripts.FMOD
{
    public class FmodAudioManager : MonoBehaviour
    {
            public static FmodAudioManager Instance;
        
            public EventInstance PlayerFootsteps { get; private set; }
            
            private EventInstance _ost;
            
            private EventInstance _teleportation;
            
            private EventInstance _activeTeleport;
            
            private EventInstance _buttonClick;
            
            private EventInstance _playButtonClick;
            
            private EventInstance _climb;
        
            private EventInstance _elShieldOn;

            private EventInstance _explosion;
            
            private EventInstance _pistolFire;
            
            private EventInstance _rocketBoost;
            
            private EventInstance _rocketLaunch;
            
            private EventInstance _badDream;
            
            public FmodEvents events;
            [SerializeField] private StudioBankLoader bankLoaderPrefab;
            private StudioBankLoader _bank;
            
            private void Awake()
            {
                if (Instance == null)
                {
                    Instance = this;
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
                if (Instance == this)
                {
                    Debug.Log($"Clear instance OnDestroy {gameObject.name}");
                    Instance = null;
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
            public void SetMusicArea(MusicArea area)
            {
                //ambience.setParameterByName("AMBIENCE", (float)area);
                _ost.setParameterByName("MusicArea", (float)area);
                Debug.Log(area);
            }
            
            public void InitializeTeleportation()
            {
                _teleportation = CreateInstance(events.Teleportation);
                _teleportation.start();
            }
            
            public void InitializeButtonClick()
            {
                _buttonClick = CreateInstance(events.ButtonClick);
                _buttonClick.start();
            }
            
            public void InitializePlayButtonClick()
            {
                _playButtonClick = CreateInstance(events.PlayButtonClick);
                _playButtonClick.start();
            }
            
            public void InitializeClimb()
            {
                _climb = CreateInstance(events.Climb);
                _climb.start();
            }
            
            public void InitializeElShieldOn()
            {
                _elShieldOn = CreateInstance(events.ElShieldOn);
                _elShieldOn.start();
            }
            
            public void InitializeExplosion()
            {
                _explosion = CreateInstance(events.Explosion);
                _explosion.start();
            }
            
            public void InitializePistolFire()
            {
                _pistolFire = CreateInstance(events.PistolFire);
                _pistolFire.start();
            }
            
            public void InitializeRocketBoost()
            {
                _rocketBoost = CreateInstance(events.RocketBoost);
                _rocketBoost.start();
            }
            
            public void InitializeRocketLaunch()
            {
                _rocketLaunch = CreateInstance(events.RocketLaunch);
                _rocketLaunch.start();
            }

            public void StopRocketBoost()
            {
                _rocketBoost.stop(STOP_MODE.IMMEDIATE);
            }
            
            public void InitializeBadDream()
            {
                _badDream = CreateInstance(events.BadDream);
                _badDream.start();
            }
    }
}
