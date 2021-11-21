using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGlowController : MonoBehaviour
{
    Material mat;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time = Mathf.Clamp01(time - Time.unscaledDeltaTime * 2);
            mat.SetFloat("_LerpVal", 1 - time);
        }
    }

    public void Glow()
    {
        mat.color = Color.white;
        time = 1;
    }

    public void UnGlow()
    {
        time = 0;
    }

    public void Heal()
    {
        mat.color = Color.green;
        time = 1;
    }
}
