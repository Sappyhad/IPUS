using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public float normalMovementSpeed = 5f;
    public float fastMovementSpeed = 10f;

    private bool isRotating = false;
    private Vector3 lastMousePosition;

    void Update()
    {
        // Sprawdź, czy użytkownik naciska i przytrzymuje prawy przycisk myszy
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
            lastMousePosition = Input.mousePosition;
        }

        // Sprawdź, czy użytkownik zwalnia prawy przycisk myszy
        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }

        // Obracaj kamerę tylko wtedy, gdy użytkownik przytrzymuje prawy przycisk myszy
        if (isRotating)
        {
            RotateCamera();
        }

        // Poruszaj się za pomocą WSAD
        MoveCharacter();
    }

    void RotateCamera()
    {
        // Oblicz różnicę w pozycji myszy od ostatniego klatki
        Vector3 deltaMouse = Input.mousePosition - lastMousePosition;

        // Oblicz kąty obrotu w osiach X i Y
        float rotationX = deltaMouse.y * rotationSpeed;
        float rotationY = -deltaMouse.x * rotationSpeed;

        // Obróć kamerę w zależności od ruchu myszy
        transform.Rotate(Vector3.right, rotationX, Space.Self);
        transform.Rotate(Vector3.up, rotationY, Space.World);

        // Zapisz bieżącą pozycję myszy do użycia w następnej klatce
        lastMousePosition = Input.mousePosition;
    }

    void MoveCharacter()
    {
        // Poruszaj postacią tylko wtedy, gdy nie obracam kamery
        if (!isRotating)
        {
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");

            // Sprawdź, czy klawisz Shift jest wciśnięty
            float currentMovementSpeed = Input.GetKey(KeyCode.LeftShift) ? fastMovementSpeed : normalMovementSpeed;

            // Oblicz wektor ruchu
            Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement).normalized;

            // Przesuń postać
            transform.Translate(movement * currentMovementSpeed * Time.deltaTime, Space.Self);
        }
    }
}
