using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    public float OrbitRadius = 5f; // Promień orbity
    public Color orbitColor = Color.gray;
    public float lineWidth = 0.1f;
    public bool followObjectMovement = false; // Dodany parametr bool

    [Header("Drag and drop the object to follow")]
    public Transform objectToFollow; // Pole do przeciągnięcia obiektu, który ma być śledzony

    private LineRenderer orbitLine;

    void Start()
    {
        CreateOrbitLine();
    }

    void Update()
    {
        // Aktualizacja wizualizacji orbity
        UpdateOrbitLine();

        // Sprawdzenie, czy followObjectMovement jest włączone i obiekt do śledzenia nie jest nullem
        if (followObjectMovement && objectToFollow != null)
        {
            // Przesunięcie orbity zgodnie z położeniem obiektu
            transform.position = objectToFollow.position;
        }
    }

    void CreateOrbitLine()
    {
        // Tworzenie obiektu LineRenderer
        orbitLine = gameObject.AddComponent<LineRenderer>();
        orbitLine.positionCount = 360;
        orbitLine.useWorldSpace = false;
        orbitLine.widthMultiplier = lineWidth; // Grubość linii

        // Ustawienie koloru orbity
        orbitLine.material = new Material(Shader.Find("Sprites/Default"));
        orbitLine.material.color = orbitColor;

        // Inicjalizacja punktów orbity w płaszczyźnie XY
        UpdateOrbitLine();
    }

    void UpdateOrbitLine()
    {
        // Aktualizacja punktów orbity w płaszczyźnie XY
        for (int i = 0; i < 360; i++)
        {
            float radians = i * Mathf.Deg2Rad;
            float x = Mathf.Cos(radians) * OrbitRadius;
            float y = Mathf.Sin(radians) * OrbitRadius;

            orbitLine.SetPosition(i, new Vector3(x, 0, y));
        }

        // Ustawienie grubości linii
        orbitLine.startWidth = lineWidth;
        orbitLine.endWidth = lineWidth;
    }
}
