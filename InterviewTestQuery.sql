Create Database InterviewTest
Go
Use InterviewTest
Go

if OBJECT_ID('Jobs') is not null
Drop table Jobs
Go

if OBJECT_ID('Locations') is not null
Drop table Locations
Go

if OBJECT_ID('Department') is not null
Drop table Department
Go

CREATE TABLE Locations
(
[Id] Numeric(10) Constraint pk_lid PRIMARY KEY Identity(1000,1),
[Title] Varchar(100) not null,
[City] Varchar(50) not null,
[State] Varchar(50) not null,
[Country] varchar(100) not null,
[zip] numeric(6)
)
Go

Set Identity_Insert Locations off

Create table Department
(
[Id] Numeric(10) Constraint pk_did PRIMARY KEY Identity(2000,1),
[title] varchar(100) not null
)
Go

Set Identity_Insert Department off

Create table Jobs(
[Id] Numeric(10) Constraint pk_jid PRIMARY KEY Identity(100,1),
[code] Varchar(8) not null,
[title] varchar(50) not null,
[description] varchar(100) not null,
[locationId] numeric(10) Constraint fk_lid References Locations(Id),
[departmentId] numeric(10) Constraint fk_did references Department(Id),
[postedDate] Date CONSTRAINT DF_pd DEFAULT GETDATE(),
[closedDate] Date constraint chk_cd check(closedDate >= GetDate()) not null
)
Go

insert  into Locations values('US Head Office','Baltimore','MD','United States',212022)
insert  into Locations values('India Head Office','Verna','Goa','India',403722)

insert into Department values('Software Development')
insert into Department values('Project Management')

select * from Locations

select * from Department