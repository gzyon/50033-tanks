using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private void Awake() {
        // spawn 10 power ups
        spawnFromPooler(ObjectType.newLeaf);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnPowerups());
    }

    // Update is called once per frame
    void Update()
    {
    }

    void  spawnFromPooler(ObjectType i){
	// static method access
        GameObject item =  ObjectPooler.SharedInstance.GetPooledObject(i);
        if (item  !=  null){
            //set position, and other necessary states
            item.transform.position  =  new  Vector3(Random.Range(-30f, 30f), item.transform.position.y, Random.Range(-30f, 30f));
            item.SetActive(true);
        }
        else{
            Debug.Log("not enough items in the pool.");
        }
    }

    IEnumerator spawnPowerups() {
        for (int j =  0; j  <  9; j++) {
            Debug.Log(j);
            spawnFromPooler(ObjectType.newLeaf);
            yield return new WaitForSeconds(3);
        }
    }
}
