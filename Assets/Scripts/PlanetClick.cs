using System.Collections;
using UnityEngine;

public class PlanetClick : MonoBehaviour
{
    public AnimationCurve animation;
    public float animationDuration;
    public Transform targetTransform;
    public Transform camera;
    public GameObject uiPanel; // Przypisz panel UI do tej zmiennej w inspektorze
    public GameObject Big_UI_Panel;
    bool nextPosition;
    private bool continueScript = true; // Dodana flaga kontrolna

    public GameObject briefInfoPanelPrefab;
    private GameObject currentBriefInfoPanel;

    private const float Tolerance = 0.1f;
    private const float PanelCloseDelay = 3.0f; // Czas (w sekundach) przed zamknięciem panelu

    public GameObject MainWindow;
    public InfoFull BriefInfoPanelObj;

    public PanelController panelController;

    public CloseBriefButton closeButtonScript;


    void Start()
    {
        panelController = GetComponent<PanelController>();
        // if (panelController != null)
        // {
        //     panelController.SetPlanetClickReference(this);
        // }
        
        ResetScript(); // Wywołaj metodę ResetScript na starcie gry
    }

    // Metoda resetująca skrypt do początkowego stanu
    public void ResetScript()
    {
        nextPosition = false;

        // Ukryj panel UI na starcie gry
        if (uiPanel != null)
        {
            uiPanel.SetActive(false);
        }

        // Ustaw flagę continueScript na true
        continueScript = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Sprawdź, czy lewy przycisk myszy został kliknięty
        if (Input.GetMouseButtonDown(0) && continueScript)
        {
            // Rzuć promień od kamery do punktu, w którym kliknięto myszą
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Sprawdź, czy promień uderza w obiekt
            if (Physics.Raycast(ray, out hit))
            {
                // Sprawdź, czy uderzony obiekt to ten, który chcesz obsłużyć
                if (hit.collider.gameObject == this.gameObject)
                {
                    HasBeenPushed();
                }
            }
        }

        if (nextPosition && continueScript)
        {
            camera.LookAt(transform.position);
            ChangeCameraPosition(targetTransform);

        }
    }

    public void ChangeCameraPosition(Transform targetTransform)
    {

        
        camera.position = Vector3.Lerp(camera.position, targetTransform.position, Time.deltaTime / animationDuration);

        // if (Vector3.SqrMagnitude(camera.position - targetTransform.position) < Tolerance * Tolerance)
        // {
        //     ShowUIPanel();
        // }
    }

    // private void ShowUIPanel()
    // {
    //     StartCoroutine(ClosePanelAfterDelay());
    // }

    // private IEnumerator ClosePanelAfterDelay()
    // {
    //     // Oczekaj przez jakiś czas i zamknij panel
    //     yield return new WaitForSeconds(PanelCloseDelay);

    //     // Sprawdź, czy panel UI jest nadal aktywny
    //     if (uiPanel != null && uiPanel.activeSelf)
    //     {
    //         uiPanel.SetActive(false);
    //     }    
    // }

    public void HasBeenPushed(){
        nextPosition = true;
        closeButtonScript.SetFocus(this.gameObject);
        uiPanel.SetActive(true);
        MainWindow.SetActive(false);
        BriefInfoPanelObj.DisplayPlanetInfoBrief(GetComponent<PlanetInfo>());
        Big_UI_Panel.GetComponent<PanelController>().SetPlanetInfo(GetComponent<PlanetInfo>());
    }

    // Metoda wywoływana po kliknięciu przycisku "X" w BriefInfoPanel
    public void OnCloseBriefInfoButtonClick()
    {
        // Zatrzymaj skrypt
        // Zatrzymaj skrypt
        continueScript = false;

        // Zresetuj skrypt
        ResetScript();

        // Schowaj panel BriefInfoPanel
        if (uiPanel != null)
        {
            uiPanel.SetActive(false);
            MainWindow.SetActive(true);
        }

        
    }
}

