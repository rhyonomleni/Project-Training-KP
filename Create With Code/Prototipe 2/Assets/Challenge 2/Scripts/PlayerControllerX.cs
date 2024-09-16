using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float jedaWaktu = 3;
    private float waktu = 0;
    void Start(){
        waktu = jedaWaktu;
    }
    // Update is called once per frame
    void Update()
    {
        waktu += Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && waktu > jedaWaktu)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            waktu = 0;
        }
    }
}
