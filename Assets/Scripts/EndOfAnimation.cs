using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfAnimation : MonoBehaviour
{
    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
