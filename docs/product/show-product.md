
# Show Product

Returns a Product with the given id.

**URL** : `/api/v{:apiVersion}/products/:id`

**URL Parameters** : `id=[integer]`

**Method** : `GET`

**Authorization** : `Bearer Token`


## Success Response

**Code** : `200 OK`

**Content Example** :

```json
{
    "id": 6,
    "categoryId": 3,
    "unitsInStock": 389,
    "unitPrice": 142.00,
    "name": "Beko"
}
```

## Error Responses

**Code** : `404 NOT FOUND`

**Content** : 
```json
{
    "errors": [
        {
            "code": "NotFoundError",
            "description": "Product not found for parameters {id=111}."
        }
    ]
}
```
