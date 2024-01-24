using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject briefInfoPanel;
    public GameObject allInfoPanel;
    public GameObject searchPanel;
    public GameObject MainWindow;
    public GameObject PauseMenu;
    public InfoFull AllInfoPanelObj;

    private PlanetInfo planetInfo;

    private PlanetClick planetClick;

    // public delegate void CloseBriefInfoPanelAction();
    // public static event CloseBriefInfoPanelAction OnCloseBriefInfoPanel;

    public void SetPlanetInfo(PlanetInfo new_planetInfo){
        planetInfo = new_planetInfo;
    }

    // public void SetPlanetClickReference(PlanetClick pc)
    // {
    //     if (pc != null)
    //     {
    //         OnCloseBriefInfoPanel += pc.OnCloseBriefInfoButtonClick;
    //     }
    // }


    void Start()
    {   
        // Na początku ukryj briefInfoPanel
        briefInfoPanel.SetActive(false);

        // Na początku ukryj AllInfoPanel
        allInfoPanel.SetActive(false);

        // Na początku ukryj searchPanel
        searchPanel.SetActive(false);

        // Main Window Buttons Visibility
        MainWindow.SetActive(true);

        PauseMenu.SetActive(false);

        planetClick = GetComponent<PlanetClick>();
    }

    public void OnPauseMenuButtonClick(){
        if (PauseMenu != null)
        {
            // Pokaż panel AllInfoPanel
            PauseMenu.SetActive(true);

            // Wyłącz wydoczność Main window buttons
            MainWindow.SetActive(false);
        }
    }

    public void OnResumeButtonClick(){
        if (MainWindow != null)
        {
            // Pokaż panel AllInfoPanel
            PauseMenu.SetActive(false);

            // Wyłącz wydoczność Main window buttons
            MainWindow.SetActive(true);
        }
    }

    public void OnQuitButtonClick(){

        // Wyjdź gry (tylko w buildzie; w edytorze nie działa)
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
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

            if (AllInfoPanelObj != null)
            {
                AllInfoPanelObj.DisplayPlanetInfoAll(planetInfo);
            }
        }
    }

    // Metoda wywoływana po kliknięciu przycisku SearchButton
    public void OnSearchButtonClick()
    {
        // Sprawdź, czy oba panele są przypisane
        if (searchPanel != null)
        {
            // Pokaż panel AllInfoPanel
            searchPanel.SetActive(true);

            // Wyłącz wydoczność Main window buttons
            MainWindow.SetActive(false);
        }
    }

    // Metoda wywoływana po kliknięciu przycisku "X" w BriefInfoPanel
    public void OnCloseBriefInfoButtonClickFromPlanetClick()
    {  

            // Sprawdź, czy panel BriefInfoPanel jest przypisany
            if (briefInfoPanel != null)
            {
                // Schowaj panel BriefInfoPanel
                briefInfoPanel.SetActive(false);
                MainWindow.SetActive(true);
            }

    }

    // Metoda wywoływana po kliknięciu przycisku "X" w AllInfoPanel
    public void OnCloseAllInfoButtonClick()
    {   
        // Sprawdź, czy panel AllInfoPanel jest przypisany
        if (allInfoPanel != null)
        {
            // Schowaj panel AllInfoPanel
            allInfoPanel.SetActive(false);
            MainWindow.SetActive(true);
        }
    }

    // Metoda wywoływana po kliknięciu przycisku "X" w searchPanel
    public void OnCloseSearchPanelClick()
    {   if (briefInfoPanel == null){
        // Sprawdź, czy panel searchPanel jest przypisany
            if (searchPanel != null)
            {
                // Schowaj panel searchPanel
                searchPanel.SetActive(false);

                MainWindow.SetActive(true);
            }
        }
        else {
            if (searchPanel != null)
            {
                // Schowaj panel searchPanel
                searchPanel.SetActive(false);
            }
        }
    }
}
