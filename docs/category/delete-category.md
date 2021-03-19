
# Delete Category

Deletes the Category.

**URL** : `/api/v{:apiVersion}/categories/:id`

**URL Parameters** : `id=[integer]`

**Method** : `DELETE`

**Authorization** : `Bearer Token`

**Permissions required** : User must have the role of `admin`.

## Success Response

**Code** : `204 NO CONTENT`

## Error Responses

**Code** : `404 NOT FOUND`

**Content** : 
```json
{
    "errors": [
        {
            "code": "NotFoundError",
            "description": "Category not found for parameters {id=111}."
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
            "code": "ConflictError",
            "description": "FOREIGN KEY constraint: The primary key of this Category is using as a foreign key in 'Products' table."
        }
    ]
}
```

### Or

**Code** : `403 FORBIDDEN`
