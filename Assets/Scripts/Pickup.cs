using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {    

    public GameObject pickupPrefab;
    public GameObject floor;

    private int pickupAmount = 20;

    void Start () {
        System.Random random = new System.Random();
		for (int i = 0; i < pickupAmount; i++) {
            GameObject pickup = Instantiate(pickupPrefab);
            pickup.transform.position = randomPosition(random);            
            pickup.transform.parent = floor.transform;
        }
	}

    private Vector3 randomPosition(System.Random random) {
        float positionZ = (float)(random.NextDouble() * 16.0) - 8.0f;
        float positionX = (float)(random.NextDouble() * 16.0) - 8.0f;
        return new Vector3(positionX, 0.5f, positionZ);
    }

}
