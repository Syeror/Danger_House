using UnityEngine;

public class SpotlightControl : MonoBehaviour
{
    public Light spotlight; // Ссылка на Spot Light

    void Update()
    {
        // Проверка нажатия клавиши F
        if (Input.GetKey(KeyCode.E))
        {
            // Включение Spot Light
            spotlight.enabled = true;
        }
        else
        {
            // Выключение Spot Light
            spotlight.enabled = false;
        }
    }
}
