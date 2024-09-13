using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Variabel untuk mengatur kecepatan rotasi
    [SerializeField] private float rotationSpeed = 360f; // Derajat per detik
    [SerializeField] private float cycleDuration = 30f; // Durasi siklus (dalam detik)
    
    private float currentTime = 0f;

    void Update()
    {
        // Hitung kecepatan rotasi berdasarkan siklus durasi
        float rotationPerFrame = rotationSpeed * Time.deltaTime;

        // Rotasi berdasarkan waktu siklus
        currentTime += Time.deltaTime;
        float timeFraction = currentTime / cycleDuration;
        
        // Batasi agar currentTime tidak lebih dari durasi siklus
        if (currentTime > cycleDuration)
        {
            currentTime = 0f;
        }

        // Rotasi Directional Light di sumbu X
        transform.Rotate(Vector3.right, rotationPerFrame * timeFraction);
    }
}
