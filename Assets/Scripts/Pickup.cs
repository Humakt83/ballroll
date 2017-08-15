using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {    

    public GameObject pickupPrefab;
    public GameObject floor;
    public GameObject dangerPrefab;

    private readonly int pickupAmount = 15;
    private readonly int dangerAmount = 5;
    private readonly float proximityDistance = 0.25f;
    private readonly float proximityDistanceToOrigin = 1.2f;

    void Start () {
        CreateObjects(dangerAmount, dangerPrefab);
        CreateObjects(pickupAmount, pickupPrefab);
	}

    private void CreateObjects(int amount, GameObject objectType) {
        System.Random random = new System.Random();
        for (int i = 0; i < amount; i++) {
            GameObject created = Instantiate(objectType);
            created.transform.position = GetRandomPositionThatDoesNotCollide(random);
            created.transform.parent = floor.transform;
        }
    }

    private Vector3 GetRandomPositionThatDoesNotCollide(System.Random random) {
        Vector3 position = RandomPosition(random);
        if (CollidesWithAnother(position) || TooCloseToOrigin(position)) {
            return GetRandomPositionThatDoesNotCollide(random);
        }
        return position;
    }

    private bool TooCloseToOrigin(Vector3 position) {
        return ArePositionsClose(position, new Vector3(0.0f, 0.0f, 0.0f), proximityDistanceToOrigin);
    }

    private Vector3 RandomPosition(System.Random random) {
        float positionZ = (float)(random.NextDouble() * 16.0) - 8.0f;
        float positionX = (float)(random.NextDouble() * 16.0) - 8.0f;
        return new Vector3(positionX, 0.5f, positionZ);
    }

    private bool CollidesWithAnother(Vector3 position) {
        bool pickupCollides = new List<GameObject>(GameObject.FindGameObjectsWithTag("Pickup"))
            .Find(x => ArePositionsClose(position, x.transform.position, proximityDistance)
            ) != null;
        bool dangerCollides = new List<GameObject>(GameObject.FindGameObjectsWithTag("Danger"))
            .Find(x => ArePositionsClose(position, x.transform.position, proximityDistance)
            ) != null;
        return pickupCollides || dangerCollides;
    }

    private bool ArePositionsClose(Vector3 position, Vector3 another, float proximityDistance) {
        return Mathf.Abs((Mathf.Abs(position.x) + Mathf.Abs(position.z)) - (Mathf.Abs(another.x) + Mathf.Abs(another.z))) <= proximityDistance;
    }

}
