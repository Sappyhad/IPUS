using UnityEngine;
using UnityEngine.UI;

public class PlanetInfo : MonoBehaviour
{
    public string planetName;
    public string planetInfo;

    void Start()
    {
        // Inicjalizacja informacji o planecie
        planetName = "Nazwa Planety";
        planetInfo = "Informacje o planecie...";
    }

    public void DisplayInformation()
    {
        // Wyświetlenie informacji w GUI (np. w panelu UI)
        Debug.Log("Nazwa: " + planetName + "\nInfo: " + planetInfo);
    }
}
