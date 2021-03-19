
# Show Category

Returns a Category with the given id.

**URL** : `/api/v{:apiVersion}/categories/:id`

**URL Parameters** : `id=[integer]`

**Method** : `GET`

**Authorization** : `Bearer Token`


## Success Response

**Code** : `200 OK`

**Content Example** :

```json
{
    "id": 1,
    "name": "Phone"
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
            "description": "Category not found for parameters {id=111}."
        }
    ]
}
```
