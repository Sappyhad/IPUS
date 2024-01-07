// using UnityEngine;

// public class PlanetOrbit : MonoBehaviour
// {
//     public Transform sun;
//     public float RotationSpeed = 10f;

//     private Rigidbody rb;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//         rb.useGravity = false; // Wyłącz grawitację, ponieważ używamy siły do poruszania obiektu
//     }

//     void FixedUpdate()
//     {
//         // Oblicz wektor od obiektu do słońca
//         Vector3 toSun = sun.position - transform.position;

//         // Wyświetl informacje o odległości i wektorze siły
//         Debug.Log("Odległość do słońca: " + Vector3.Distance(transform.position, sun.position));
//         Debug.DrawRay(transform.position, toSun.normalized * 5f, Color.red); // Wizualizacja wektora siły

//         // Oblicz siłę grawitacyjną zgodnie z prawem powszechnego ciążenia Newtona
//         // F = G * ((m1*m2)/r^2)
//         float gravitationalForce = 6.674f * Mathf.Pow(10, -11) * ((rb.mass * sun.GetComponent<Rigidbody>().mass) / toSun.sqrMagnitude);
//         Debug.Log("Siła grawitacyjna obliczenia = " + gravitationalForce);

//         // Dodaj siłę skierowaną do słońca
//         rb.AddForce(toSun.normalized * gravitationalForce);

//         // Obracaj obiekt wokół osi pionowej (opcjonalne, aby obiekt był zawsze zwrócony w kierunku słońca)
//         transform.Rotate(Vector3.up, RotationSpeed * Time.fixedDeltaTime);
//     }
// }

using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    public Transform sun;
    public float RotationSpeed = 10f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Wyłącz grawitację, ponieważ używamy siły do poruszania obiektu
    }

    void FixedUpdate()
    {
        Vector3 toSun = sun.position - transform.position;
        Debug.Log("toSun = " + toSun);
        float gravitationalForce = 6.674f * Mathf.Pow(10, -11) * ((rb.mass * sun.GetComponent<Rigidbody>().mass) / toSun.sqrMagnitude);
        rb.AddForce(toSun.normalized * gravitationalForce);

        transform.Rotate(Vector3.up, RotationSpeed * Time.fixedDeltaTime);
    }
}