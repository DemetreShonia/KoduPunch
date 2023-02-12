using UnityEngine;

public class ScreenChecker : MonoBehaviour
{
    Vector3 _mousePos;
    private void Update()
    {
        CheckInput();
    }
    void CheckInput()
    {
        _mousePos = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
           CheckQuarters();
        }
    }
    void CheckQuarters()
    {
        if (_mousePos.x < Screen.width / 2 && _mousePos.y < Screen.height / 2)
        {
            Debug.Log("Mouse click detected in bottom-left");
        }
        else if (_mousePos.x >= Screen.width / 2 && _mousePos.y < Screen.height / 2)
        {
            Debug.Log("Mouse click detected in bottom-right");
        }
        else if (_mousePos.x < Screen.width / 2 && _mousePos.y >= Screen.height / 2)
        {
            Debug.Log("Mouse click detected in top-left");
        }
        else if (_mousePos.x >= Screen.width / 2 && _mousePos.y >= Screen.height / 2)
        {
            Debug.Log("Mouse click detected in top-right");
        }
    }
}
