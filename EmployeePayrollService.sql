--UC1
create database payroll_service

use payroll_service

--UC2

create table employee_payroll
(
 id int identity(1,1) primary key,
 name varchar(100) not null,
 salary int not null,
 start_date date not null
)

--UC3

insert into employee_payroll values
('Joe',100000.0,'2020-01-03'),
('Finny',200000.0,'2019-10-13'),
('Mabel',300000.0,'2021-09-18')

--UC4

select * from employee_payroll

--UC5

select salary from employee_payroll where name = 'Joe'

select * from employee_payroll
where start_date between cast('2019-01-01' As date) and GETDATE()

--UC6

ALTER TABLE employee_payroll
ADD Gender char(2)

update employee_payroll set Gender = 'M' where name = 'Joe' or name = 'Finny'
update employee_payroll set Gender = 'F' where name = 'Mabel';

select * from employee_payroll

--UC7

select sum(salary) from employee_payroll where Gender='M' group by Gender;

select sum(salary) from employee_payroll  group by Gender;

select sum(salary) as 'totalSalary',Gender from employee_payroll group by Gender;

select avg(salary) as 'averageSalary',Gender from employee_payroll group by Gender;

select min(salary) as 'minimumSalary',Gender from employee_payroll group by Gender;

select max(salary) as 'maximumSalary',Gender from employee_payroll group by Gender;

select count(Gender) as 'male' from employee_payroll where Gender='M' 

select count(Gender) as 'female' from employee_payroll where Gender='F' 

select * from employee_payroll

--UC8

alter table employee_payroll add 
phone varchar(13),
department varchar(100) not null default 'CSE',
address varchar(250) not null default 'Bangalore'

select * from employee_payroll

--UC9

alter table employee_payroll add
basicPay float,
deduction float,
taxablePay float,
incomeTax float

select * from employee_payroll

--UC10

insert into employee_payroll values
('Terisa',700000.0,'2020-08-14','F','8734586245','sales','india',100.0,12000.0,2000.0,1233.0)

insert into employee_payroll values
('Terisa',500000.0,'2020-08-14','F','8723586245','Marketing','india',100.0,12000.0,2000.0,1233.0)

select * from employee_payroll where name='Terisa'


--UC11

create table Employee
(
emp_id int identity primary key,
name varchar(50),
startdate date,
gender char(1),
phone varchar(13),
address varchar(50),
)

create table Department
(
dept_id int identity primary key,
rooms int,
emp_id int FOREIGN KEY REFERENCES employee(emp_id)
)


create table Payroll
(
emp_id int FOREIGN KEY REFERENCES employee(emp_id),
basicpay money,
deduction money,
taxable_pay money,
income_tax money,
net_pay money,
)


create table Company
(
emp_id int foreign key references employee(emp_id),
company_name varchar(50),
)

create table EmployeeDepartment
(
emp_id int foreign key references employee(emp_id),
dept_id int foreign key references Department(dept_id),
)

select * from Employee
select * from Department
select * from Payroll
select * from Company
select * from EmployeeDepartment

update employee_payroll set basicPay = 1000 where name = 'Mabel'

select * from employee_payroll