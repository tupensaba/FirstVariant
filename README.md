# FirstVariant
ТЗ от компании "Пряники"





Пример JSON POST-формы для добавления заказа:
`````````````````````````````````````````````
{
  "orderMasterId": 0,
  "orderNumberId": "string",
  "customerId": 3,
  "orderDetails": [
    {
      "orderDetailId": 0,
      "orderMasterId": 0,
      "goodItemId": 3,
      "quantity": 1
    },
    {
      "orderDetailId": 0,
      "orderMasterId": 0,
      "goodItemId": 2,
      "quantity": 2
    }
  ]
}
``````````````````````````````````````````````````
JSON форма для изменения количества товара в заказе:
```````````````````````````````````````````````
[
  {
    "path": "/quantity",
    "op": "replace",
    "value": 3
  }
]
```````````````````````````````````````````````
