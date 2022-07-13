using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    bool isFade = true;
    float fade = 1;

    Material material;

    private void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (isFade == true)
        {
            fade -= 0.01f;

            if(fade <= 0f)
            {
                fade = 0f;
                DestroyGameObject();
            }

            material.SetFloat("_Alpha", fade);
        }
    }
}
