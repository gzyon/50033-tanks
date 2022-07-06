using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour
{ 
    // public int numPowerups = 5;
    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(spawnPowerups());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("trigger with prefab");
        if (other.gameObject.CompareTag("Player")) {
            TankMovement.tankMovement.increaseSpeed();
            Destroy(gameObject);
        }
    }
}
