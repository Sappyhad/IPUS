using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject briefInfoPanel;
    public GameObject allInfoPanel;

    void Start()
    {
        // Na początku ukryj briefInfoPanel
        briefInfoPanel.SetActive(false);
        // Na początku ukryj AllInfoPanel
        allInfoPanel.SetActive(false);
    }

    // Metoda wywoływana po kliknięciu przycisku "See More"
    public void OnSeeMoreButtonClick()
    {
        // Sprawdź, czy oba panele są przypisane
        if (briefInfoPanel != null && allInfoPanel != null)
        {
            // Schowaj panel BriefInfoPanel
            briefInfoPanel.SetActive(false);

            // Pokaż panel AllInfoPanel
            allInfoPanel.SetActive(true);
        }
    }

    // Metoda wywoływana po kliknięciu przycisku "Close" w BriefInfoPanel
    public void OnCloseBriefInfoButtonClick()
    {   
        // Sprawdź, czy panel BriefInfoPanel jest przypisany
        if (briefInfoPanel != null)
        {
            // Schowaj panel BriefInfoPanel
            briefInfoPanel.SetActive(false);
        }
    }

    public void OnCloseAllInfoButtonClick()
    {   
        // Sprawdź, czy panel AllInfoPanel jest przypisany
        if (allInfoPanel != null)
        {
            // Schowaj panel AllInfoPanel
            allInfoPanel.SetActive(false);
        }
    }
}
