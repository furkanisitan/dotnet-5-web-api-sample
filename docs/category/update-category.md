
# Update Category

Updates the Category.

**URL** : `/api/v{:apiVersion}/categories/:id`

**URL Parameters** : `id=[integer]`

**Method** : `PUT`

**Authorization** : `Bearer Token`

**Permissions required** : User must have the role of `admin` or `employee`.

**Data Example**

```json
{
    "name": "Phone Updated"
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
            "description": "Name must be unique. RejectedValue: 'computer'"
        }
    ]
}
```

### Or

**Code** : `403 FORBIDDEN`
