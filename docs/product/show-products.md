
# Show Products

Returns a list of Products.

**URL** : `/api/v{:apiVersion}/products`

**Method** : `GET`

**Authorization** : `Bearer Token`


## Success Response

**Code** : `200 OK`

**Content Example** :

```
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
    ...
]
```
