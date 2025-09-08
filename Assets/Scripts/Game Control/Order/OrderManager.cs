using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private SpriteRenderer currOrder;
    [SerializeField]
    private SpriteRenderer nextOrder;



    private Queue<Order> cookingQueue;
    private Queue<Order> readyQueue;

    private void Update()
    {

    }
}
