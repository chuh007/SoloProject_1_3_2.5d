using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpenDice : MonoBehaviour
{
    [SerializeField] private Rigidbody _rbCompo;
    
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _rbCompo.AddForce(new Vector3(0, 10, 0),ForceMode.Impulse);
            _rbCompo.AddTorque(new Vector3(1, 1, 1), ForceMode.Impulse);
        }
    }
}
