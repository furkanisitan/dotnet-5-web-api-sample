
# Create Category

Creates a new Category.

**URL** : `/api/v{:apiVersion}/categories`

**Method** : `POST`

**Authorization** : `Bearer Token`

**Permissions required** : User must have the role of `admin` or `employee`.

**Data Example**

```json
{
    "name": "Tablet"
}
```

## Success Response

**Code** : `201 CREATED`

**Content Example** :

```json
{
    "id": 4,
    "name": "Tablet"
}
```

**Header Examples** :

* **Location**: `http://localhost:5010/api/v1/Categories/4`

## Error Responses

**Code** : `400 BAD REQUEST`

**Content** : 
```json
{
    "errors": [
        {
            "code": "ValidationError",
            "description": "'Name' must not be empty."
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
            "description": "Name must be unique. RejectedValue: 'phone'"
        }
    ]
}
```

### Or

**Code** : `403 FORBIDDEN`
