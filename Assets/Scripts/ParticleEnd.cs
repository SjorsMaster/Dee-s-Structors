using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEnd : MonoBehaviour
{
    [SerializeField] [Tooltip("TEST")]
    ParticleSystem _ps;

    // Update is called once per frame
    void Update()
    {
        if (!_ps.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }
}
