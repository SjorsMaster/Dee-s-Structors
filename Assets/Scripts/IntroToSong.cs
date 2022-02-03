using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroToSong : MonoBehaviour
{
    [SerializeField]
    AudioSource _src;
    [SerializeField]
    AudioClip _song, _intro;
    [SerializeField]
    bool _loopAfter;

    void Update()
    {
        if (!_src.isPlaying && _src.clip == _intro) {
            _src.clip = _song;
            _src.loop = _loopAfter;
            _src.Play();
            Destroy(this);
        }
    }
}
