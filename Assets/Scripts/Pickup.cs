using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {    

    public GameObject pickupPrefab;
    public GameObject floor;
    public GameObject dangerPrefab;

    private int pickupAmount = 20;
    private int dangerAmount = 5;    

    void Start () {
        createObjects(pickupAmount, pickupPrefab);
        createObjects(dangerAmount, dangerPrefab);
	}

    private void createObjects(int amount, GameObject objectType) {
        System.Random random = new System.Random();
        for (int i = 0; i < amount; i++) {
            GameObject created = Instantiate(objectType);
            created.transform.position = randomPosition(random);
            created.transform.parent = floor.transform;
        }
    }

    private Vector3 randomPosition(System.Random random) {
        float positionZ = (float)(random.NextDouble() * 16.0) - 8.0f;
        float positionX = (float)(random.NextDouble() * 16.0) - 8.0f;
        return new Vector3(positionX, 0.5f, positionZ);
    }

}
