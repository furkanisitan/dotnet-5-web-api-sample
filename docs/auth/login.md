# Login

Creates a Token for a registered User.

**URL** :  `/api/v{:apiVersion}/auth/login`

**Method** : `POST`

**Data Example**

```json
{
    "username": "admin",
    "password": "1234"
}
```

## Success Response

**Code** : `200 OK`

**Content Example**

```json
{
    "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJhZG1pbkBnbWFpbC5jb20iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOlsiYWRtaW4iLCJ1c2VyIl0sIm5iZiI6MTYxNjE4MzUzMCwiZXhwIjoxNjE2MTg0NDMwLCJpc3MiOiJ3d3cuZnVya2FuaXNpdGFuLmNvbSIsImF1ZCI6Ind3dy5hdWRpZW5jZS5jb20ifQ.cVqY41hMewic2u2hFrFwfNR9-wGoTjAZ5TcemJuHE6o",
    "expiration": "2021-03-19T23:07:10.7744509+03:00"
}
```

## Error Response


**Code** : `401 UNAUTHORIZED`

**Content** :

```json
{
    "errors": [
        {
            "code": "AuthenticationError",
            "description": "Username or password is incorrect."
        }
    ]
}
```
