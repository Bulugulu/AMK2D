using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    public AudioSource btn_1;
    public AudioSource btn_2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void btn1play () {
        btn_1.Play();
    }
    
    public void btn2play () {
        btn_2.Play();
    }
}
