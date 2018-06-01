drop table JobPostions;
drop table ITCompanies;
drop table Users;

create table JobPostions (
	id int identity(1,1) primary key,
	name varchar(50)
);

insert into JobPostions (name) values
	('Junior'), ('Middle'), ('Senior'), ('PM');

create table ITCompanies (
	id int identity(1,1) primary key,
	name varchar(50)
);
 
insert into ITCompanies (name) values
	('Softserve'), ('Epam'), ('Luxosoft');


create table Users(
	id int identity(1,1),
	name varchar(50),
	surname varchar(50),
	positionId int foreign key references JobPostions(id),
	email varchar(50),
	companyId int foreign key references ITCompanies(id)
);

insert into Users (name, surname, positionId, email, companyId) values 
	('John', 'Smith', 3, 'john@gmail.com', 1),
	('Andrew', 'Jason', 1, 'andrew@gmail.com', 2),
	('Mykhailo', 'Ivanov', 2, 'ivanov@gmail.com', 3);


select * from ITCompanies;




