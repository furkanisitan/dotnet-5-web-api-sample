
# Create Product

Creates a new Product.

**URL** : `/api/v{:apiVersion}/products`

**Method** : `POST`

**Authorization** : `Bearer Token`

**Permissions required** : User must have the role of `admin` or `employee`.

**Data Example**

```json
{
    "name": "Sinbo",
    "categoryId": 3,
    "unitPrice": 228,
    "unitsInStock": 76
}
```

## Success Response

**Code** : `201 CREATED`

**Content Example** :

```json
{
    "id": 9,
    "categoryId": 3,
    "unitsInStock": 76,
    "unitPrice": 228,
    "name": "Sinbo"
}
```

**Header Examples** :

* **Location**: `http://localhost:5010/api/v1/Products/9`

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
            "description": "Name must be unique. RejectedValue: 'Simfer'"
        }
    ]
}
```

### Or

**Code** : `403 FORBIDDEN`
