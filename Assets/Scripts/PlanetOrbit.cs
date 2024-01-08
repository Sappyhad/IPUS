using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float orbitSpeed = 1f;
    public Transform sun;

    private float angle = 0f;

    private void Start()
    {
        
        if (sun == null)
        {
            // Przypisz zmienną sun ręcznie, jeśli nie została przypisana w inspektorze
            sun = GameObject.Find("Sun").transform; // Zastąp "Sun" nazwą obiektu słońca w hierarchii
            if (sun == null)
            {
                Debug.LogError("Nie znaleziono obiektu słońca.");
                return;
            }
        }
    }

    private void Update()
    {
        RotateAroundOwnAxis();
        OrbitAroundSun();
    }

   private void RotateAroundOwnAxis()
    {
        Debug.Log("Rotating around own axis");
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    private void OrbitAroundSun()
    {
        float xPos = Mathf.Sin(angle);
        float zPos = Mathf.Cos(angle);

        transform.localPosition = new Vector3(xPos, 0f, zPos);

        angle += orbitSpeed * Time.deltaTime;
    }
}
