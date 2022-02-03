using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    Rigidbody _rb;
    [SerializeField] [Tooltip("TEST")]
    float _dissapearingThreshhold = .05f;
    [SerializeField] [Tooltip("TEST")]
    GameObject _particleSystem;
    [SerializeField] [Tooltip("TEST")]
    AudioClip _audioClip;

    [SerializeField] [Tooltip("TEST")]
    GameObject _storage, _checker;

    [SerializeField]
    bool _notAllowedToBreak;

    private void Start()
    {
        _rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // check if wall needs to dissapear
    private void OnCollisionEnter(Collision collision)
    {
        if (_rb.velocity.x >= _dissapearingThreshhold || _rb.velocity.y >= _dissapearingThreshhold || _rb.velocity.z >= _dissapearingThreshhold)
        {
            GameObject tmp = Instantiate(_particleSystem,transform.position,transform.rotation, _storage.transform);
            ParticleSystem ps = tmp.GetComponent<ParticleSystem>();
            AudioSource tmp2 = tmp.GetComponent<AudioSource>();

            var sh = ps.shape;
            var psr = tmp.GetComponent<ParticleSystemRenderer>();
            
            tmp2.clip = _audioClip;
            psr.material = gameObject.GetComponent<Renderer>().material;
            psr.trailMaterial = gameObject.GetComponent<Renderer>().material;
            sh.scale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
            tmp2.pitch = Random.Range(0.5f,1.5f);

            tmp2.Play();
            ps.Play();

            if(_notAllowedToBreak) _checker.GetComponent<CheckHeight>().ActivateWith(0, 100);

            Destroy(this.gameObject);
        }
    }
}
