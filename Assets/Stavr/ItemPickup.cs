using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private GameObject itemPrefab; // Префаб объекта, который будет подбираться
    [SerializeField] private float pickupDistance = 2f; // Расстояние на котором можно подобрать предмет
    public TextMeshProUGUI NumbersKeysTMP;
    public int AllKeys;
    [Range(1, 4)]
    public int Keys = 1;


    private void Update()
    {
        // Проверяем, есть ли объекты в радиусе действия
        Collider[] colliders = Physics.OverlapSphere(transform.position, pickupDistance);

        // Перебираем все объекты в радиусе действия
        foreach (Collider collider in colliders)
        {
            // Проверяем, является ли объект подбираемым
            PickableItem pickableItem = collider.GetComponent<PickableItem>();
            if (pickableItem != null)
            {
                // Подбираем предмет
                PickItem(pickableItem);
                break; // Прерываем цикл, так как предмет уже подобран
            }
        }
    }
   
    private void PickItem(PickableItem pickableItem)
    {
        // Уничтожаем объект, который был подобран
        Destroy(pickableItem.gameObject);

        NumbersKeysTMP.text = Keys.ToString();
        Keys++;
        if (Keys == 5)
        {
            SceneManager.LoadScene(2);
        }
        // Создаем новый объект префаба в позиции игрока
        Instantiate(itemPrefab, transform.position, transform.rotation);

        // Выполняем действия, связанные с подбором предмета (например, добавить его в инвентарь)
        // ...
    }

 

   
}

