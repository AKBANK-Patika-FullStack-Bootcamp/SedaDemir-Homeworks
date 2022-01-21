# Adding in Authentication to EntityFramework Web API Project

### 1. Create new login record and hash customer password with MD5

**APIAuthority Table Before**

![Auth-Table-Before](./img/apiAuth_table_empty.png)

**Create Login**

![Create-Login](./img/create_login.png)

**APIAuthority Table After**

![Auth-Table-After](./img/apiAuth-Table-After.png)

### 2. Login Customer

**Select Bearer Token on Postman Authorization**

![Token](./img/bearer_token.png)

**Login Failed**

![Login-Fail](./img/login_fail.png)

**Successful login for customer**

![Login-Success](./img/login_success.png)
