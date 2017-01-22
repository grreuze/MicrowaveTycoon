using Kino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariationBloom : MonoBehaviour {

    Bloom bloom;
    bool increaseValue;

	// Use this for initialization
	void Start ()
    {
        bloom = GetComponent<Bloom>();
        StartCoroutine(BloomVariation());
	}
	

    IEnumerator BloomVariation()
    {
        while(true)
        {
            if (increaseValue) bloom.intensity += 0.005f;
            else bloom.intensity -= 0.005f;
            if(bloom.intensity >= 1 && increaseValue) increaseValue = false;
            else if (bloom.intensity <= 0 && !increaseValue) increaseValue = true;
            yield return null;
        }
    }
}
