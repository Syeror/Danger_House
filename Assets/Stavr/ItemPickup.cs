using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab; // ������ �������, ������� ����� �����������
    [SerializeField] private float pickupDistance = 2f; // ���������� �� ������� ����� ��������� �������
    public TMP_Text NumbersKeysTMP;
    public int AllKeys;
    [Range(0, 4)]
    public int Keys = 0;



    private void Update()
    {
        // ���������, ���� �� ������� � ������� ��������
        Collider[] colliders = Physics.OverlapSphere(transform.position, pickupDistance);

        // ���������� ��� ������� � ������� ��������
        foreach (Collider collider in colliders)
        {
            // ���������, �������� �� ������ �����������
            PickableItem pickableItem = collider.GetComponent<PickableItem>();
            if (pickableItem != null)
            {
                // ��������� �������
                PickItem(pickableItem);
                break; // ��������� ����, ��� ��� ������� ��� ��������
            }
        }
    }
   
    private void PickItem(PickableItem pickableItem)
    {
        // ���������� ������, ������� ��� ��������
        Destroy(pickableItem.gameObject);
        Keys++;
        NumbersKeysTMP.text = Keys.ToString();

        if (Keys == 4)
        {
            SceneManager.LoadScene(2);
        }
        // ������� ����� ������ ������� � ������� ������
        //Instantiate(itemPrefab, transform.position, transform.rotation);

        // ��������� ��������, ��������� � �������� �������� (��������, �������� ��� � ���������)
        // ...
    }

 

   
}

