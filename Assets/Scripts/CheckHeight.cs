using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckHeight : MonoBehaviour
{
    [SerializeField]
    int _count, _ran, _bulletsLeft;
    [SerializeField]
    bool _checked;

    [SerializeField]
    int _thresh = 1;

    [SerializeField]
    AudioSource _src;
    [SerializeField]

    AudioClip _win, _lose, _outstanding;

    public void ActivateWith(int points, int punishment)
    {
        if (!_checked)
        {
            gameObject.SetActive(true);
            _bulletsLeft = points;
            _count += punishment;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!_checked) _count++;
    }

    void Update()
    {
        if (!_checked && gameObject.activeSelf && _ran > 10f)
        {
            _checked = true;
            if (_src.loop)
            {
                _src.loop = false;
            }
            if (_count <= _thresh)
            {
                _src.clip = _win;

                if (_bulletsLeft > 0)
                    _src.clip = _outstanding;
            }
            else
            {
                _src.clip = _lose;
            }
            _src.Play();
        }
        if (_ran <= 10) _ran++;

        if (_checked && !_src.isPlaying)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + (_count <= 1 ? 1 : 0));
        }
    }
}
