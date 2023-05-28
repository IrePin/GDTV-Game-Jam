using _DrRush.Scripts.FMOD;
using FMODUnity;
using UnityEngine;

namespace _DrRush.Scripts
{
    public class Teleport : MonoBehaviour
    {
        
        [SerializeField] GameObject player;
        [SerializeField] private EventReference teleportation;
        [SerializeField] private SceneTransition sceneTransition;
        
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                FmodAudioManager.Instance.PlayOneShot(teleportation, transform.position);
            }
            DeactivateObject();
            sceneTransition.StartMainSceneTransition();
        }
        void DeactivateObject()
        {
            gameObject.SetActive(false);
        }
    }
}
