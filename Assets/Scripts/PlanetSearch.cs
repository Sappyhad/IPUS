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

    public List<GameObject> PlanetObjects;

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
        foreach (GameObject i in PlanetObjects){
            if (i.GetComponent<PlanetInfo>().planetName == planet.planetName){
                i.GetComponent<PlanetClick>().HasBeenPushed();
            }
        }
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

