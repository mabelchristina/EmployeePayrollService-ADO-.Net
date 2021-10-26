use payroll_service


create procedure spGetAllemployee_payroll
As 
Begin try
select * from employee_payroll
end try
Begin catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH 

exec spGetAllemployee_payroll

exec spGetAllemployee_payroll

alter procedure spAddEmployeePayroll
(
@name varchar(250),
@salary int,
@start_date date)
As 
Begin try
insert into employee_payroll(name,salary,start_date)values(@name,@salary,@start_date)
end try
Begin catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH  


exec spAddEmployeePayroll
'Steve',5000,'2019-09-15'

create procedure spUpdateEmployeePayroll
(
@name varchar(20),
@basicPay money
)
As 
Begin try
update employee_payroll set basicPay=@basicPay where name=@name
end try
Begin catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH  

exec spUpdateEmployeePayroll
@basicPay=5000, @name='Mabel'

select * from employee_payroll

create procedure spRetrieveAllEmployeeForParticularRange
As 
Begin try
select * from employee_payroll where id between 1 and 6
end try
Begin catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH 

exec spRetrieveAllEmployeeForParticularRange

create procedure spSumOfSalaryOfMaleEmployee
As 
Begin try
select SUM(salary) As salary from employee_payroll where gender='M' group by gender;
end try
Begin catch
SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
END CATCH

exec spSumOfSalaryOfMaleEmployee