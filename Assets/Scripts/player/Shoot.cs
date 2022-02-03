using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Shoot : MonoBehaviour
{
    [SerializeField]
    InputActionReference toggleRef = null;
    [SerializeField]
    InputActionReference _reset = null;

    [SerializeField]
    [Tooltip("TEST")]
    float _charge = 20f;
    [SerializeField]
    [Tooltip("TEST")]
    GameObject _bulletPrefab;
    [SerializeField]
    [Tooltip("TEST")]
    public int _ballCount = 5;
    [SerializeField]
    [Tooltip("TEST")]
    AudioSource _audioSource;

    [SerializeField]
    [Tooltip("TEST")]
    Text _bullets;

    private void Start()
    {
        _bullets.text = $"{_ballCount}";
        toggleRef.action.started += triggerPressed;
        _reset.action.started += restartLevel;
    }

    void restartLevel(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(0);
    }

    private void triggerPressed(InputAction.CallbackContext context)
    {
        ShootBall();
    }

    public void ShootBall()
    {
        if (_ballCount >= 1)
        {
            _audioSource.pitch = Random.Range(.5f, 1.5f);
            _audioSource.Play();
            _ballCount--;
            GameObject tmp = Instantiate(_bulletPrefab, this.transform.position, this.transform.rotation);
            tmp.GetComponent<Rigidbody>().AddForce(this.transform.forward * _charge);
            _bullets.text = $"{_ballCount}";
        }
    }


}
