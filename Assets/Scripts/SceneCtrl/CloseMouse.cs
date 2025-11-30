using UnityEngine;

public class CloseMouse : MonoBehaviour
{
    void Start()
    {
        // Ẩn chuột
        Cursor.visible = false;

        // Khóa chuột ở giữa màn hình
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Nếu bạn muốn mở lại chuột khi nhấn phím ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MouseToggle();
        }
    }

    void MouseToggle()
    {
        if (Cursor.visible)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }    

}
