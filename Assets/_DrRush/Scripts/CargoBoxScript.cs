using _DrRush.Scripts.FMOD;
using FMODUnity;
using UnityEngine;

namespace _DrRush.Scripts
{
    public class CargoBoxScript : MonoBehaviour
    {
        [SerializeField] private EventReference explosion;
        [SerializeField] private GameObject effect;
        [SerializeField] private GameObject teleport;
        private Rigidbody _rigidbody;
        private Color[] _colors;
        
        
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            //_colors = Color.Lerp(Color.red, Color.green);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _rigidbody.isKinematic = false;
                _rigidbody.useGravity = true;
            }

            if (other.CompareTag("Button"))
            {
                teleport.gameObject.SetActive(true);
                _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                Instantiate(effect, other.gameObject.transform.position, Quaternion.identity);
                FmodAudioManager.Instance.InitializeExplosion();
                Destroy(gameObject);
                MeshRenderer mesh = other.gameObject.GetComponent<MeshRenderer>();
                mesh.material.color = Color.green;
                if (teleport.TryGetComponent<ParticleSystemRenderer>(out ParticleSystemRenderer particle))
                {
                    particle.enabled = true;
                }
            }
        }
    }
}