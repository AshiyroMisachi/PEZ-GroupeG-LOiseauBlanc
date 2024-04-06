using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_BasketBall_Card : MonoBehaviour
{
    [SerializeField]
    private S_Interractible_CardCollection cardCollection;

    [SerializeField]
    private int cardNumber;

    [SerializeField]
    private int positionOrder;

    public int GetCardNumber()
    {
        return cardNumber;
    }

    public int GetPositionOrder()
    {
        return positionOrder;
    }

    public void SetPositionOrder(int newPositionOrder)
    {
        positionOrder = newPositionOrder;
    }

    public void OnMouseDown()
    {
        cardCollection.SelectCard(this);
    }
}
