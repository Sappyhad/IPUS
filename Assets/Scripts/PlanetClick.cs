using System.Collections;
using UnityEngine;

public class PlanetClick : MonoBehaviour
{
    public AnimationCurve animation;
    public float animationDuration;
    public Transform targetTransform;
    public Transform camera;
    public GameObject uiPanel; // Przypisz panel UI do tej zmiennej w inspektorze
    bool nextPosition;
    private bool continueScript = true; // Dodana flaga kontrolna

    private const float Tolerance = 0.1f;
    private const float PanelCloseDelay = 3.0f; // Czas (w sekundach) przed zamknięciem panelu

    void Start()
    {
        ResetScript(); // Wywołaj metodę ResetScript na starcie gry
    }

    // Metoda resetująca skrypt do początkowego stanu
    private void ResetScript()
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
                    // Kliknięto na tym obiekcie, więc wykonaj resztę kodu
                    nextPosition = true;
                }
            }
        }

        if (nextPosition && continueScript)
        {
            camera.LookAt(transform.position);
            ChangeCameraPosition(targetTransform);

            // Aktywuj panel UI, jeśli nie jest już aktywowany
            if (uiPanel != null && !uiPanel.activeSelf)
            {
                uiPanel.SetActive(true);
            }
        }
    }

    public void ChangeCameraPosition(Transform targetTransform)
    {
        camera.position = Vector3.Lerp(camera.position, targetTransform.position, Time.deltaTime / animationDuration);

        // Jeśli osiągnięto docelową pozycję z tolerancją, nie trzeba czekać na pełne zamknięcie panelu
        if (Vector3.SqrMagnitude(camera.position - targetTransform.position) < Tolerance * Tolerance)
        {
            ShowUIPanel();
        }
    }

    private void ShowUIPanel()
    {
        // Tutaj możesz umieścić logikę otwierania panelu lub pozostawić puste, jeśli panel ma pozostać otwarty
        StartCoroutine(ClosePanelAfterDelay());
    }

    private IEnumerator ClosePanelAfterDelay()
    {
        // Oczekaj przez określony czas, a następnie zamknij panel
        yield return new WaitForSeconds(PanelCloseDelay);

        // Sprawdź, czy panel UI jest nadal aktywny (unika migania przy szybkim przełączaniu)
        if (uiPanel != null && uiPanel.activeSelf)
        {
            uiPanel.SetActive(false);
        }    
    }

    // Metoda wywoływana po kliknięciu przycisku "Close" w BriefInfoPanel
    public void OnCloseBriefInfoButtonClick()
    {
        // Zatrzymaj skrypt
        continueScript = false;

        // Zresetuj skrypt
        ResetScript();

        // Schowaj panel BriefInfoPanel
        if (uiPanel != null)
        {
            uiPanel.SetActive(false);
        }
    }
}

