# ToNoAvail

Availity Tech Assignment

## Question 4

You are tasked to write a checker that validates the parentheses of a LISP
code. Write a program which takes in a string as an input and returns true if all the parentheses in the
string are properly closed and nested.

### 4 Results

- [Source](https://github.com/ImaginaryDevelopment/ToNoAvail/blob/master/src/xorsize/Parens.cs)
- [Sample Output](https://github.com/ImaginaryDevelopment/ToNoAvail/blob/master/outputs/ParensOutput.JPG)

## Question 5

Coding exercise (using Angular, React, or a JavaScript framework of your choice): Healthcare providers
request to be part of the Availity system. Create a registration user interface so healthcare providers can
electronically join Availity. The following data points should be collected:

- First and Last Name
- NPI number
- Business Address
- Telephone Number
- Email address

### 5 Results

- [Source](https://github.com/ImaginaryDevelopment/ToNoAvail/tree/master/src/iwantmymvc)
- [MainFile](https://github.com/ImaginaryDevelopment/ToNoAvail/blob/master/src/iwantmymvc/ClientApp/src/components/Registration.js)
- [Output Sample](https://github.com/ImaginaryDevelopment/ToNoAvail/blob/master/outputs/Registration.JPG)

## Question 6

Coding exercise (using C#): Availity receives enrollment files from various benefits management and
enrollment solutions (I.e. HR platforms, payroll platforms).  Most of these files are typically in EDI format.
However, there are some files in CSV format.  For the files in CSV format, write a program that will read
the content of the file and separate enrollees by insurance company in its own file. Additionally, sort the
contents of each file by last and first name (ascending).  Lastly, if there are duplicate User Ids for the
same Insurance Company, then only the record with the highest version should be included. The
following data points are included in the file:

- User Id (string)
- First and Last Name (string)
- Version (integer)
- Insurance Company (string)

### 6 Results

- [Source](https://github.com/ImaginaryDevelopment/ToNoAvail/tree/master/src/xorsize)
  - [MainFile](https://github.com/ImaginaryDevelopment/ToNoAvail/blob/master/src/xorsize/HealthCsv.cs)
- [Output Sample 1](https://github.com/ImaginaryDevelopment/ToNoAvail/blob/master/outputs/DedupeOutput.JPG)
- [Output Sample 2](https://github.com/ImaginaryDevelopment/ToNoAvail/blob/master/outputs/Sorted.JPG)

## Question 7

- a. Write a SQL query that will produce a reverse-sorted list (alphabetically by name) of customers (first and last names) whose last name begins with the letter ‘S.’
  - [Sql](https://github.com/ImaginaryDevelopment/ToNoAvail/blob/master/outputs/sql-a.sql)
- b. Write a SQL query that will show the total value of all orders each customer has placed in the past six months. Any customer without any orders should show a $0 value.
  - [Sql](https://github.com/ImaginaryDevelopment/ToNoAvail/blob/master/outputs/sql-b.sql)
- c. Amend the query from the previous question to only show those customers who have a total order
value of more than $100 and less than $500 in the past six months.
  - [Sql](https://github.com/ImaginaryDevelopment/ToNoAvail/blob/master/outputs/sql-c.sql)