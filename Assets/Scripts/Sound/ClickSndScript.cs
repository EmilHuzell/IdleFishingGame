using UnityEngine;

public class ClickSndScript : MonoBehaviour {
    public float pitchMin, pitchMax; 
        
    public void PitchVariation() {
        var pitch = Random.Range(pitchMin, pitchMax);
        GetComponent<AudioSource>().pitch = pitch;
    }
}
