# .NET 5.0 Web API Sample

An example RESTful API with .NET 5.0

- applicationUrl: `http://localhost:5010`
- apiVersion: `1.0 (or 1)`

## Public Endpoints

Public endpoints require no Authentication.

* [Login](docs/auth/login.md) : `POST /api/v{:apiVersion}/login/`

## Endpoints that require Authentication

Private endpoints require a valid Token to be included in the header of the request.

### Category related

* [Show Categories](docs/category/show-categories.md) : `GET /api/v{:apiVersion}/categories`
* [Show Category](docs/category/show-category.md) : `GET /api/v{:apiVersion}/categories/:id`
* [Show Products of Category](docs/category/show-products-of-category.md) : `GET /api/v{:apiVersion}/categories/:id/products`
* [Create Category](docs/category/create-category.md) : `POST /api/v{:apiVersion}/categories`
* [Update Category](docs/category/update-category.md) : `PUT /api/v{:apiVersion}/categories/:id`
* [Delete Category](docs/category/delete-category.md) : `DELETE /api/v{:apiVersion}/categories/:id`

### Product related

* [Show Products](docs/product/show-products.md) : `GET /api/v{:apiVersion}/products`
* [Show Product](docs/product/show-product.md) : `GET /api/v{:apiVersion}/products/:id`
* [Create Product](docs/product/create-product.md) : `POST /api/v{:apiVersion}/products`
* [Update Product](docs/product/update-product.md) : `PUT /api/v{:apiVersion}/products/:id`
* [Delete Product](docs/product/delete-product.md) : `DELETE /api/v{:apiVersion}/products/:id`

## Author

**Furkan Işıtan**

* [github/furkanisitan](https://github.com/furkanisitan)
