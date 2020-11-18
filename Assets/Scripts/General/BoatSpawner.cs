using System;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoatSpawner : MonoBehaviour {
    public float intervalBetweenSpawns;
    public GameObject boatPrefab;
    public float netBoatSize;
    public float rodBoatSize;
    public float harpoonBoatSize;

    public float netBoatYLayer2, netBoatYLayer3, netBoatYLayer4;
    public float rodBoatYLayer2, rodBoatYLayer3, rodBoatYLayer4;
    public float harpoonBoatYLayer2, harpoonBoatYLayer3, harpoonBoatYLayer4;

    private float _checker = 0f;

    private void Start() {
        GameObject go = Instantiate(boatPrefab, this.transform);
        var zVariation = Random.Range(2, 4);
        var _y = CheckYPosition(zVariation, go);
        go.transform.position = new Vector3(-Camera.main.rect.width - 15, _y, zVariation);
    }

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
        if (go.GetComponent<SpriteRenderer>().sprite.name == "Idle_Producer_Net_boat_v2") {
            go.transform.localScale = new Vector3(netBoatSize, netBoatSize);
            if (zVariation == 2) {
                return netBoatYLayer2;
            }

            if (zVariation == 3) {
                return netBoatYLayer3;
            }

            if (zVariation == 4) {
                return netBoatYLayer4;
            }
        }
        else if (go.GetComponent<SpriteRenderer>().sprite.name == "Idle_Producer_Rod_boat") {
            go.transform.localScale = new Vector3(rodBoatSize, rodBoatSize);
            if (zVariation == 2) {
                return rodBoatYLayer2;
            }

            if (zVariation == 3) {
                return rodBoatYLayer3;
            }

            if (zVariation == 4) {
                return rodBoatYLayer4;
            }
        }
        else if (go.GetComponent<SpriteRenderer>().sprite.name == "Idle_Producer_spear_boat") {
            go.transform.localScale = new Vector3(harpoonBoatSize, harpoonBoatSize);
            if (zVariation == 2) {
                return harpoonBoatYLayer2;
            }

            if (zVariation == 3) {
                return harpoonBoatYLayer3;
            }

            if (zVariation == 4) {
                return harpoonBoatYLayer4;
            }
        }
        return -1000f;
    }
}