using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoatSpawner : MonoBehaviour {
    public float intervalBetweenSpawns;
    public GameObject boatPrefab;
    private float _checker = 0f;
    private void FixedUpdate() {
        _checker += Time.deltaTime;

        if (_checker >= intervalBetweenSpawns) {
            _checker = 0;
            GameObject go = Instantiate(boatPrefab, this.transform);
            var zVariation = Random.Range(2, 4);
            var _y = CheckYPosition(zVariation, go);
            go.transform.position = new Vector3(-Camera.main.rect.width - 15, _y, zVariation);
        }
    }

    private float CheckYPosition(int zVariation, GameObject go) {
        if (go.GetComponent<SpriteRenderer>().sprite.name == "Idle_Producer_Net_boat") {
            if (zVariation == 2) {
                return 0f;
            }

            if (zVariation == 3) {
                return 1.5f;
            }

            if (zVariation == 4) {
                return 1.7f;
            }
        }
        else if (go.GetComponent<SpriteRenderer>().sprite.name == "Idle_Producer_Rod_boat") {
            if (zVariation == 2) {
                return -1.2f;
            }

            if (zVariation == 3) {
                return 0.2f;
            }

            if (zVariation == 4) {
                return 0.4f;
            }
        }
        else if (go.GetComponent<SpriteRenderer>().sprite.name == "Idle_Producer_spear_boat") {
            if (zVariation == 2) {
                return -0.65f;
            }

            if (zVariation == 3) {
                return 2.4f;
            }

            if (zVariation == 4) {
                return 2.4f;
            }
        }
        return -1000f;
    }
}