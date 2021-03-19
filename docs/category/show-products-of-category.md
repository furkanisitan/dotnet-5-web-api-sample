
# Show Products of Category

Returns a list of Products of Category.

**URL** : `/api/v{:apiVersion}/categories/:id/products`

**URL Parameters** : `id=[integer]`

**Method** : `GET`

**Authorization** : `Bearer Token`


## Success Response

**Code** : `200 OK`

**Content Example** :

```json
[
    {
        "id": 1,
        "categoryId": 1,
        "unitsInStock": 145,
        "unitPrice": 3600.00,
        "name": "Vestel Venus"
    },
    {
        "id": 2,
        "categoryId": 1,
        "unitsInStock": 101,
        "unitPrice": 3258.00,
        "name": "General Mobile"
    },
    {
        "id": 3,
        "categoryId": 1,
        "unitsInStock": 74,
        "unitPrice": 3542.00,
        "name": "Casper Via"
    }
]
```
