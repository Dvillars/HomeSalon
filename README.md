# __*HairSalon*__
#### __*By: Derek Villars*__

### *Setup/Installation Requirements:*
 After Cloning this repository to your computer you need to open the index.html file and the website should open up in your browser.

in SQLCMD:

    1> CREATE DATABASE hair_salon
    2> GO
    1> USE DATABASE hair_salon
    2> GO
    1> CREATE TABLE stylists
    2> (
    3> id int IDENTITY(1,1),
    4> name VARCHAR(255)
    5> )
    6> GO
    1> CREATE TABLE clients
    2> (
    3> id int IDENTITY(1,1),
    4> name VARCHAR(255),
    5> stylist_id int
    6> )
    7> GO

### __*Specifications:*__

1. it will be able to see a list of all our stylists.
  - see figure 2
- it will be able to select a stylist, see their details, and see a list of all clients that belong to that stylist.
   - if Joey was clicked (figure 3)
- it will add new stylists to our system when they are hired.
  - __input:__ Bill
  - Bill added (figure 4)
- it will be able to add new clients to a specific stylist.
  - __input:__ Dan
  - Dan added (figure 5)
- it will be able to update a client's name.
  - __input:__ Dan to Danny
  - Danny added (figure 6)
- it will be able to delete a client if they no longer visit our salon.
  - __input:__ Frank left
  - Frank removed (figure 7)

### __Example Data:__
Client Examples (figure 1)

| Client Id | Name  | Stylists Id |
| --------- | ----- | ----------- |
| 1         | Bob   | 2           |
| 2         | Keven | 1           |
| 3         | Jill  | 3           |
| 4         | Emma  | 2           |
| 5         | Frank | 3           |

Stylists Examples (figure 2)

| Stylists Id | Name |
| ----------- | ---- |
| 1           | Will |
| 2           | Joey |
| 3           | John |

if Joey was clicked (figure 3)

| Joey's Clients |
| -------------- |
| Bob            |
| Emma           |

Bill added (figure 4)

| Stylists Id | Name |
| ----------- | ---- |
| 1           | Will |
| 2           | Joey |
| 3           | John |
| 4           | Bill |

Dan added (figure 5)

| Client Id | Name  | Stylists Id |
| --------- | ----- | ----------- |
| 1         | Bob   | 2           |
| 2         | Keven | 1           |
| 3         | Jill  | 3           |
| 4         | Emma  | 2           |
| 5         | Frank | 3           |
| 6         | Dan   | 1           |

Dan to Danny (figure 6)

| Client Id | Name  | Stylists Id |
| --------- | ----- | ----------- |
| 1         | Bob   | 2           |
| 2         | Keven | 1           |
| 3         | Jill  | 3           |
| 4         | Emma  | 2           |
| 5         | Frank | 3           |
| 6         | Danny | 1           |

Dan to Danny (figure 7)

| Client Id | Name  | Stylists Id |
| --------- | ----- | ----------- |
| 1         | Bob   | 2           |
| 2         | Keven | 1           |
| 3         | Jill  | 3           |
| 4         | Emma  | 2           |
| 6         | Danny | 1           |

### *Support and Contact:*
If you have any questions for me or have any problems, please email me at derekvillars@yahoo.com.

Copyright (c) 2017 __Derek Villars__
