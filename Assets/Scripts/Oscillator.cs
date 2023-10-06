using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f);
    [SerializeField] float period = 2f;

    Vector3 startingPos;
    float movementFactor; // 0 for not moved, 1 for fully moved

    // Start is called before the first frame update
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) return;

        const float tau = Mathf.PI * 2;
        float cycles = Time.time / period; // Grows continually from 0
        float rawSinWave = Mathf.Sin(tau * cycles);

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset; 
    }
}
