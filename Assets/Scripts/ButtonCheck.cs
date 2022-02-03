using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCheck : MonoBehaviour
{
    [SerializeField]
    GameObject _checker,_bullethole;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "playerHand")
        {
            _checker.GetComponent<CheckHeight>().ActivateWith(_bullethole.GetComponent<Shoot>()._ballCount,0);
        }
    }
}
