--Database first Approach:
--Command for database table to generate db context with associate All C# class  
------------------------------------------------------------------------------------
--dotnet ef dbcontext scaffold "Server=RL-ST-LP\SQLEXPRESS;Database=CompanyDB;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -o Models --context AppDbContext --project ProjectName

--Need dependency: 
---------------------------------------
--Microsoft.EntityFrameworkCore.SqlServer
--Microsoft.EntityFrameworkCore.Design
--Microsoft.EntityFrameworkCore.Tools

--reference : --https://www.c-sharpcorner.com/article/crud-operations-in-asp-net-core-mvc-net-5-0/


--------------------------------------------------------------------------------------
Create database CompanyDB
go
use CompanyDB
go
CREATE TABLE [dbo].[Employees](
[EmployeeId] [int] IDENTITY(1,1) NOT NULL,
[Name] [varchar](50) NOT NULL,
[Address] [varchar](250) NULL,
[Designation] [varchar](50) NULL,
[Salary] [decimal](18, 0) NOT NULL,
[JoiningDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED
(
[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employees] ADD  DEFAULT (getdate()) FOR [JoiningDate]
GO

select * from  [dbo].[Employees]

Insert into Employees(Name, Address, Designation, Salary, JoiningDate) values('Rasel Kabir', 'Dhaka, Norda', 'Software engineer', 500, GETDATE())