using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab; // ������ �������, ������� ����� �����������
    [SerializeField] private float pickupDistance = 2f; // ���������� �� ������� ����� ��������� �������

  

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

        // ������� ����� ������ ������� � ������� ������
        Instantiate(itemPrefab, transform.position, transform.rotation);

        // ��������� ��������, ��������� � �������� �������� (��������, �������� ��� � ���������)
        // ...
    }
}
