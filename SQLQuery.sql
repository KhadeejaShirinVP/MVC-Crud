Create database BOOKS_DB

create proc Book_AddOrEdit
@BookID INT,
@Title varchar (100),
@Author varchar(100),
@Price int
as
begin
		--set nocount on added to prevent extra result sets  from interfering wuth select statement.
		set nocount on;

		if @BookID=0
		begin
			insert  into [My-Books](Title,Author,Price)
			values (@Title,@Author,@Author)
		end 
		else
		begin
			update [My-Books]
			set
				Title=@Title,
				Author=@Author,
				Price=@Price
			where Book_ID=@BookID
		end
end
go

------------------------------------	

create proc Book_ViewAll
as
begin
		--set nocount on added to prevent  extra result sets from interfering with select statement
		set nocount on;

		select * from [My-Books]
end
go

--------------------------------------------------------------------------------------

create pro B