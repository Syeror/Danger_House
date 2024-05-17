using UnityEngine;

public class SpotlightControl : MonoBehaviour
{
    public Light spotlight; // ������ �� Spot Light

    void Update()
    {
        // �������� ������� ������� F
        if (Input.GetKey(KeyCode.E))
        {
            // ��������� Spot Light
            spotlight.enabled = true;
        }
        else
        {
            // ���������� Spot Light
            spotlight.enabled = false;
        }
    }
}
