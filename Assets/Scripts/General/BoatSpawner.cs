using UnityEngine;
using Random = UnityEngine.Random;

public class BoatSpawner : MonoBehaviour {
    public float intervalBetweenSpawns;
    public float maxYvariation;
    public float minYvariation;
    public GameObject boatPrefab;
    public GameObject waves;
    private float _checker = 0f;
    private void FixedUpdate() {
        _checker += Time.deltaTime;

        if (_checker >= intervalBetweenSpawns) {
            _checker = 0;
            GameObject go = Instantiate(boatPrefab, waves.transform);
            var yVariation = Random.Range(minYvariation, maxYvariation);
            go.GetComponent<RectTransform>().localPosition = new Vector3(this.transform.localPosition.x, waves.transform.position.y + yVariation);
        }
    }
}