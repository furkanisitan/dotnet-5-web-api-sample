
# Update Product

Updates the Product.

**URL** : `/api/v{:apiVersion}/products/:id`

**URL Parameters** : `id=[integer]`

**Method** : `PUT`

**Authorization** : `Bearer Token`

**Permissions required** : User must have the role of `admin` or `employee`.

**Data Example**

```json
{
    "categoryId": 1,
    "unitsInStock": 103,
    "unitPrice": 3784.00,
    "name": "Vestel Venus Updated"
}
```

## Success Response

**Code** : `204 NO CONTENT`

## Error Responses

**Code** : `400 BAD REQUEST`

**Content** : 
```json
{
    "errors": [
        {
            "code": "ValidationError",
            "description": "'Name' must not be empty."
        },
        {
            "code": "ValidationError",
            "description": "'Category Id' must not be empty."
        },
        {
            "code": "ValidationError",
            "description": "'Category Id' must be greater than '0'."
        },
        {
            "code": "ValidationError",
            "description": "'Unit Price' must be greater than or equal to '0'."
        },
        {
            "code": "ValidationError",
            "description": "'Units In Stock' must be greater than or equal to '0'."
        }
    ]
}
```

### Or

**Code** : `409 CONFLICT`

**Content** : 
```json
{
    "errors": [
        {
            "code": "DuplicateError",
            "description": "Name must be unique. RejectedValue: 'General Mobile'"
        }
    ]
}
```

**Code** : `404 CONFLICT`

**Content** : 
```json
{
    "errors": [
        {
            "code": "ConflictError",
            "description": "FOREIGN KEY constraint: 'CategoryId' could not be found."
        }
    ]
}
```

### Or

**Code** : `403 FORBIDDEN`
