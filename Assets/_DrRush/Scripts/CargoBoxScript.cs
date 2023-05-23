using UnityEngine;

namespace _DrRush.Scripts
{
    public class CargoBoxScript : MonoBehaviour
    {
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
                _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
                Instantiate(effect, other.gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
                MeshRenderer mesh = other.gameObject.GetComponent<MeshRenderer>();
                mesh.material.color = Color.green;
                if (teleport.TryGetComponent<ParticleSystemRenderer>(out ParticleSystemRenderer particle) && teleport.TryGetComponent<CustomTeleporter>(out CustomTeleporter teleporter))
                {
                    particle.enabled = true;
                    teleporter.enabled = true;
                }
                
                
            }
        }
    }
}