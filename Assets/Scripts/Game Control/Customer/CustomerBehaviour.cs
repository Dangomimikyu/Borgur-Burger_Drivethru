using System.Runtime.InteropServices;
using UnityEngine;

public class CustomerBehaviour : MonoBehaviour
{
    [Header("Customer info")]
    [SerializeField]
    private Order myOrder;
    [SerializeField]
    private float patience;

    [Header("UI")]
    [SerializeField]
    private GameObject angry1;
    private GameObject angry2;

    private void Start()
    {
        angry1.SetActive(false);
        angry2.SetActive(false);

        myOrder = GetComponentInParent<OrderGenerator>().CreateOrder();
    }


}
