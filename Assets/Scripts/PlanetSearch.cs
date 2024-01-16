using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlanetSearch : MonoBehaviour
{
    public TMP_InputField searchInputField;
    public TMP_Text searchResultsText;
    public List<PlanetInfo> allPlanets;

    private void Start()
    {
        // Inicjalizacja listy planet
        allPlanets = new List<PlanetInfo>(FindObjectsOfType<PlanetInfo>());
    }

    public void SearchPlanets()
    {
        // Wyszukaj planety po nazwie
        string searchText = searchInputField.text.ToLower();
        List<string> searchResults = new List<string>();

        foreach (PlanetInfo planet in allPlanets)
        {
            if (planet.planetName.ToLower().Contains(searchText))
            {
                searchResults.Add(planet.planetName);
            }
        }

        // Wyświetl wyniki w UI
        DisplaySearchResults(searchResults);
    }

    private void DisplaySearchResults(List<string> results)
    {
        // Konkatenacja wyników
        string resultsText = "Search Results:\n";

        foreach (string result in results)
        {
            resultsText += "- " + result + "\n";
        }

        // Wyświetl wyniki w UI
        searchResultsText.text = resultsText;
    }
}
