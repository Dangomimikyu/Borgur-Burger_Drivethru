using UnityEngine;

public class OrderGenerator : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField]
    private Sprite burgerOnly;
    [SerializeField]
    private Sprite friesOnly;
    [SerializeField]
    private Sprite drinkOnly;
    [SerializeField]
    private Sprite burgerFries;
    [SerializeField]
    private Sprite burgerDrink;
    [SerializeField]
    private Sprite friesDrink;
    [SerializeField]
    private Sprite fullSet;

    [Header("Cook times")]
    [SerializeField]
    private float BurgerTime = 3f;
    [SerializeField]
    private float FriesTime = 1.5f;
    [SerializeField]
    private float DrinkTime = 1f;
    [SerializeField]
    private float FullSetTime = 4.5f;

    public Order CreateOrder()
    {
        int r = (int)(Random.value * 10) % 7;
        Order ret = new Order();

        switch (r)
        {
            case 0: // burger only
                ret.sprite = burgerOnly;
                ret.cookTime = BurgerTime;
                break;
            case 1: // fries only
                ret.sprite = friesOnly;
                ret.cookTime = FriesTime;
                break;
            case 2: // drink only
                ret.sprite= drinkOnly;
                ret.cookTime = DrinkTime;
                break;
            case 3: // burger + fries
                ret.sprite = burgerFries;
                ret.cookTime = BurgerTime + FriesTime;
                break;
            case 4: // burger + drink
                ret.sprite = burgerDrink;
                ret.cookTime = BurgerTime + DrinkTime;
                break;
            case 5: // fries + drink
                ret.sprite = friesDrink;
                ret.cookTime = FriesTime + DrinkTime;
                break;
            case 6: // all
                ret.sprite = fullSet;
                ret.cookTime = FullSetTime;
                break;
            default:
                Debug.LogWarning("Invalid order r generated");
                break;
        }

        return ret;
    }
}
