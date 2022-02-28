# FirstVariant
ТЗ от компании "Пряники"

**При миграции БД будет добавлено несколько товаров и покупателей.**

# GET запросы:

Получить информациб о всех заказах:

**GET**: https://localhost:44306/api/Orders

Список товаров:

**GET**: https://localhost:44306/api/Orders/GoodsList

Список покупателей:

**GET**: https://localhost:44306/api/Orders/CustomersList

Получить информацию об определенном товаре({orderMasterId} - Номер заказа):

**GET**: https://localhost:44306/api/Orders/{orderMasterId}

# PATCH запросы:

Изменить кол-во товаров в заказе ({orderMasterId} = Номер заказа, {itemId} = Номер товара ):

**PATCH**: https://localhost:44306/api/Orders/{orderMasterId},{itemId}

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

# POST запросы:

Добавить заказ:

**POST**: https://localhost:44306/api/Orders/add

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

Добавить товар в заказ:

**POST**: https://localhost:44306/api/Orders/AddGoodInOrder

Пример JSON POST-формы для добавлениия товара в заказ:
``````````````````````````````````````````
{
  "orderDetailId": 0,
  "orderMasterId": 1,
  "goodItemId": 2,
  "quantity": 1
}
``````````````````````````````````````````

# DELETE запросы:

Удалить определенный товар из заказа({id} - номер заказа,{itemId} - номер товара):

**DELETE**: https://localhost:44306/api/Orders/{id},{itemId}

Удалить определенный заказ({id} - номер заказа):

**DELETE**: https://localhost:44306/api/Orders/{id}


# ABOUT

В Web-api интегрированно ПО для тестирования: - Swagger. На нем же и проходили основные тесты.

Также для теста можно использовать Postman и Insomnia.



