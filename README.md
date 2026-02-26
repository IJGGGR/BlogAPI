# Blog Backend API - Project Overview

## Project Goal

Create a backend for blog applications:

- Support full CRUD operations
- All users to create account and login
- Deploy to Azure
- Uses SCRUM workflow concepts
- Introduces Azure DevOps practices

## Stack

- Backend will be in .NET 9, ASP.NET Core, EF Core, SQL Server
- Frontend will be in NextJS, TypeScript, Flowbite, Tailwind. Deploy with Vercel or Azure.

## Application Features

### User Capabilities

- Create an account
- Login
- Delete an account

### Blog Features

- View all published blog posts
- Filter blog posts
- Create new posts
- Edit existing posts
- Delete posts
- Publish/unpublish posts

### Pages (frontend connected to API)

- Create account page
- Blog view post page of published items
- Dashboard page (this is the profile page; will edit, delete, and publish/unpublish our blog posts)

#### Blog Page

- Display all publish blog items

#### Dashboard Page

- User profile page
- Create blog posts
- Edit blog posts
- Delete blog posts

## Project Folder Structure

### Controllers

#### UserController

Handles all users interactions.

Endpoints:

- Login
- Add user
- Update users
- Delete user

#### BlogController

Handles all blog operations.

Endpoints:

- (C) create blog item
- (R) get all blog items
- (R) get blog items by category
- (R) get blog items by tags
- (R) get blog items by date
- (R) get published blog items
- (U) update blog items
- (D) delete blog items
- (R) get blog items by user id

> Delete will be used for soft delete / publish logic

### Models

#### UserModel

```cs
int Id
string Username
string Salt
string Hash
```

#### BlogItemModel

```cs
int Id
int UserId
string PublisherName
string Title
string Image
string Description
string Date
string Category
string Tags
bool IsPublished
bool IsDeleted
```

Items Saved to our DB

We need a way to sign in with our username and password.

#### LoginModel

```cs
string Username
string Password
```

#### CreateAccountModel

```cs
string Username
string Password
```

#### PasswordModel

```cs
string Salt
string Hash
```

### Services

#### UserService

- GetUserByUsername
- Login
- AddUser
- UpdateUser
- DeleteUser

#### BlogItemService

- AddBlogItems
- GetAllBlogItems
- GetBlogItemsByCategory
- GetBlogItemsByTags
- GetBlogItemsByDate
- GetPublishedBlogItems
- UpdateBlogItems
- DeleteBlogItems
- GetUserById

#### PasswordService

- HashPassword
- VeryHashPassword
