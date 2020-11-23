using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAnimal : MonoBehaviour
{
    public AudioClip sound;
    private void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            AudioSource.PlayClipAtPoint(sound,transform.position,1f);
        }
    }
}
