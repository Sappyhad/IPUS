using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 2f;

    void Update()
    {
        // Odczyt wejścia gracza
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Tworzenie wektora kierunku z uwzględnieniem orientacji kamery
        Vector3 direction = CalculateMoveDirection(horizontal, vertical);

        // Odczyt myszki
        float mouseX = Input.GetAxis("Mouse X");

        // Obliczanie wektora przesunięcia i normalizacja
        Vector3 movement = direction * speed * Time.deltaTime;

        // Przesunięcie gracza
        transform.Translate(movement);

        // Obroty kamery przez ruch myszki
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);
    }

    Vector3 CalculateMoveDirection(float horizontal, float vertical)
    {
        // Pobierz kierunek patrzenia kamery
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        // Zresetuj y na 0 żeby ruch był płaski
        cameraForward.y = 0f;
        cameraRight.y = 0f;

        // Normalizacja wektorów
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Utwórz wektor ruchu z uwzględnieniem kierunku kamery
        Vector3 moveDirection = (cameraForward * vertical + cameraRight * horizontal).normalized;

        return moveDirection;
    }
}
