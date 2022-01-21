# Adding in Authentication to EntityFramework Web API Project

## 1. Create new login record and hash customer password with MD5

### 1.1. APIAuthority Table Before

![Auth-Table-Before](./img/apiAuth_table_empty.png)

### 1.2. Create Login

![Create-Login](./img/create_login.png)

### 1.3. APIAuthority Table After

![Auth-Table-After](./img/apiAuth-Table-After.png)

## 2. Login Customer

### 2.1. Select Bearer Token on Postman Authorization

![Token](./img/bearer_token.png)

### 2.2. Login Failed

![Login-Fail](./img/login_fail.png)

### 2.3. Successful login for customer

![Login-Success](./img/login_success.png)
