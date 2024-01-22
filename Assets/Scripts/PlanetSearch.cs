// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;

// public class PlanetSearch : MonoBehaviour
// {
//     public TMP_InputField searchInputField;
//     public TMP_Text searchResultsText;
//     public List<PlanetInfo> allPlanets;

//     private void Start()
//     {
//         // Pobierz wszystkie obiekty PlanetInfo w scenie
//         allPlanets = new List<PlanetInfo>(FindObjectsOfType<PlanetInfo>());
//     }

//     public void SearchPlanets()
//     {
//         // Wyszukaj planety po nazwie
//         string searchText = searchInputField.text.ToLower();
//         List<string> searchResults = new List<string>();

//         foreach (PlanetInfo planet in allPlanets)
//         {
//             // Zmień warunek, aby sprawdzić, czy nazwa zaczyna się od wpisanej litery
//             if (planet.planetName.ToLower().StartsWith(searchText))
//             {
//                 searchResults.Add(planet.planetName);
//             }
//         }

//         // Wyświetl wyniki w UI tylko jeśli pole wyszukiwania nie jest puste
//         if (!string.IsNullOrEmpty(searchText))
//         {
//             DisplaySearchResults(searchResults);
//         }
//         else
//         {
//             // Jeśli pole wyszukiwania jest puste, ukryj wyniki
//             searchResultsText.text = "";
//         }
//     }

//     private void DisplaySearchResults(List<string> results)
//     {
//         // Konkatenacja wyników
//         string resultsText = "Search Results:\n";

//         foreach (string result in results)
//         {
//             resultsText += "- " + result + "\n";
//         }

//         searchResultsText.text = resultsText;
//     }
// }

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlanetSearch : MonoBehaviour
{
    public TMP_InputField searchInputField;
    public Transform resultsPanel;
    public GameObject resultButtonPrefab;

    private List<PlanetInfo> allPlanets;
    private List<GameObject> resultButtons;

    private void Start()
    {
        allPlanets = new List<PlanetInfo>(FindObjectsOfType<PlanetInfo>());
        resultButtons = new List<GameObject>();

        // Ukryj pierwotny przycisk (Prefab)
        resultButtonPrefab.SetActive(false);
    }

    public void SearchPlanets()
{
    ClearResultButtons();

    string searchText = searchInputField.text.ToLower();

    // Sprawdź, czy pole wejściowe jest puste
    if (string.IsNullOrEmpty(searchText))
    {
        return; // Jeśli puste, przerwij proces wyszukiwania
    }

    foreach (PlanetInfo planet in allPlanets)
    {
        if (planet.planetName.ToLower().StartsWith(searchText))
        {
            GameObject resultButton = Instantiate(resultButtonPrefab, resultsPanel);
            resultButtons.Add(resultButton);

            TextMeshProUGUI buttonText = resultButton.GetComponentInChildren<TextMeshProUGUI>();

            if (buttonText != null)
            {
                buttonText.text = planet.planetName;
            }

            Button buttonComponent = resultButton.GetComponent<Button>();

            if (buttonComponent != null)
            {
                buttonComponent.onClick.AddListener(() => OnResultButtonClick(planet));
            }

            resultButton.SetActive(true);
            resultButtonPrefab.SetActive(false);
        }
    }
}

    private void OnResultButtonClick(PlanetInfo planet)
    {
        Debug.Log("Clicked on planet: " + planet.planetName);
    }

    private void ClearResultButtons()
    {
        foreach (GameObject button in resultButtons)
        {
            Destroy(button);
        }

        resultButtons.Clear();
    }
}

