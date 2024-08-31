using UnityEngine;

public class CursorFollower : MonoBehaviour
{
    public GameObject cursorPointPrefab; // Prefab pentru punctul care urmărește cursorul
    private GameObject currentCursorPoint; // Referință către instanța curentă a punctului

    void OnMouseEnter()
    {
        // Verificăm dacă punctul cursorului nu există și îl instantiem dacă nu există
        if (currentCursorPoint == null)
        {
            currentCursorPoint = Instantiate(cursorPointPrefab, transform.position, Quaternion.identity);
        }
    }

    void OnMouseOver()
    {
        // Actualizăm poziția punctului cursorului pentru a urmări poziția cursorului
        if (currentCursorPoint != null)
        {
            currentCursorPoint.transform.position = Input.mousePosition;
        }
    }

    void OnMouseExit()
    {
        // Distrugem punctul cursorului când cursorul părăsește obiectul
        if (currentCursorPoint != null)
        {
            Destroy(currentCursorPoint);
            currentCursorPoint = null;
        }
    }
}
