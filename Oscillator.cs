// This Script moves an object smoothly from point a to point b back and forth

using UnityEngine;

public class Oscillator : MonoBehaviour
{
    const float tau = Mathf.PI * 2;

    [SerializeField] Vector3 movementVector; // wanted offset from 1st point
    [SerializeField] float period = 2f;

    Vector3 startingPos; // Point A
    float movementFactor; // Duration of movement

    void Start()
    {
        startingPos = transform.position;
    }

    void Update()
    {
        // period is 0, get out
        if (period <= Mathf.Epsilon) return; // to not compare to float
        float cycles = Time.time / period;
        float rawSinWave = Mathf.Sin(cycles * tau);
        movementFactor = (rawSinWave + 1f) / 2f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos - offset;
    }
}
