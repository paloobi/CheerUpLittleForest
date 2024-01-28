using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CritterScript : MonoBehaviour
{
    public ParticleSystem tears;
    public ParticleSystem hahas;

    public bool IsHappy;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (IsHappy && tears.isEmitting && !hahas.isPlaying) {
            tears.Clear();
            tears.Stop();
            hahas.Play();
        }

        // ALTERNATIVE APPROACH:
        // if is happy AND wasnt happy last frame
            // switch particles
            // set wasnt happy last frame to false
    }

}
