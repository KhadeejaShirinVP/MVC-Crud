create database Company1
 create table Employee
 (
 EmpID int primary key ,
 EmpName varchar(100),
 Emp_Email varchar(100)
 )

 select * from Employee
 
 insert into Employee values (1,'khadeeja shirin','khadeeja001@gamil.com')

 ---------------------------------------------------------------------
 sp_helptext InsertData
 create proc InsertData(
						@EmpID INT,
						@EmpName VARCHAR(100),
						@Emp_Email varchar(100)
						)
AS
BEGIN
			INSERT INTO Employee
					(EmpID,EmpName,Emp_Email)
			VALUES
					(@EmpID,@EmpName,@Emp_Email)
END
select * from Employee

exec InsertData 2,'Kallyan','kallyan23@gmail.com'
------------------------------------------------------------------

--update
create proc UpdateEmployee
@EmpID int,
@EmpName varchar (100),
@Emp_Email varchar(100)
as
begin
	update Employee set EmpName=@EmpName,Emp_Email=@Emp_Email where EmpID=@EmpID;
END

-----------------------------------------------------------------------------------

create proc DeleteDetails
@EmpID int,
@EmpName varchar (100),
@Emp_Email varchar(100)
as
begin
	delete from Employee where EmpID=@EmpID
end

