using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthBarControlScript : MonoBehaviour
{
    public Material Mat;
    Renderer rend;
    float counter;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Unlit/CustomShader2");

        //StartCoroutine(TestCoroutine());
    }

    private IEnumerator TestCoroutine()
    {
        while (true)
        {
            counter += .01f;
            if (counter > 1f)
                counter = 0f;
            var health = ((1f - counter) % 1f);
            rend.material.SetFloat("_Health", health);
            yield return new WaitForSeconds(.05f);
        }
    }
}
