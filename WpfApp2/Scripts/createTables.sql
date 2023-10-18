drop table Jezici;
drop table Skola;
drop table Korisnici;
drop table KorisnikovJezik;
drop table Cas;

create table Skola(
	schoolId int primary key identity(1,1),
	schoolName varchar(25), 
	isDeleted bit not null,
	Street varchar(50), 
	StreetNumber varchar(10),
	City varchar(50),
	Country varchar(50),
);

create table Jezici(
	languageId int primary key identity(1,1),
	languageName varchar(25),
	isDeleted bit not null
);

create table Korisnici(
	userId int primary key identity(1,1),
	email varchar(80),
	password varchar(50),
	firstName varchar(50),
	lastName varchar(50),
	jmbg varchar(15),
	GenderId varchar(15),
	UserType varchar(15),
	Street varchar(50), 
	StreetNumber varchar(10),
	City varchar(50),
	Country varchar(50),
	SchoolId int,
	isDeleted bit not null
	foreign key (SchoolId) references Skola(schoolId)
);

create table KorisnikovJezik(
	UserId int,
	LanguageId int,
	primary key (UserId, LanguageId),
	foreign key (UserId) references Korisnici(userId),
	foreign key (LanguageId) references Jezici(languageId)
);
create table Cas(
	classId int identity(1,1),
	className varchar(50),
	dateOfClass varchar(50),
	classTime varchar(50),
	statusId varchar(50),
	isDeleted bit not null,
	professorId int,
	studentId int,
	primary key(classId, professorId),
	foreign key (professorId) references Korisnici(userId),
	foreign key (studentId) references Korisnici(userId)
);

INSERT INTO Skola(schoolName,isDeleted,Street,StreetNumber,City,Country)
	values ('Knez Lazar',0,'Kneza Lazara','15','Lazarevac','Srbija');

INSERT INTO Skola(schoolName,isDeleted,Street,StreetNumber,City,Country)
	values ('Voka Savic',0,'Voke Savic','99','Novi Sad','Srbija');

INSERT INTO Skola(schoolName,isDeleted,Street,StreetNumber,City,Country)
	values ('FTN',0,'dositeja obradovica','9','Beograd','Srbija');

INSERT INTO Jezici(languageName,isDeleted) 
	values ('Norveski',0)

INSERT INTO Jezici(languageName,isDeleted) 
	values ('kineski',0)
select * from korisnici 
INSERT INTO Jezici(languageName,isDeleted) 
	values ('Italijanski',0)

INSERT INTO Korisnici(email, password, firstName, lastName, jmbg, GenderId, userType, Street, StreetNumber, City, Country, SchoolId, isDeleted)
    VALUES ('admin@gmail.com', 'admin1', 'admin', 'admin', 'admin', 'MUSKI', 'ADMINISTRATOR', 'Adminska', '4', 'Lazarevac', 'Srbija', 1, 0);

INSERT INTO Korisnici(email, password, firstName, lastName, jmbg, GenderId, userType, Street, StreetNumber, City, Country, SchoolId, isDeleted)
    VALUES ('profesor@gmail.com', 'admin1', 'admin', 'admin', 'admin', 'MUSKI', 'PROFESOR', 'Profesorska', '44', 'Novi Sad', 'Srbija', 1, 0);

INSERT INTO Korisnici(email, password, firstName, lastName, jmbg, GenderId, userType, Street, StreetNumber, City, Country, SchoolId, isDeleted)
    VALUES ('student@gmail.com', 'student1', 'student', 'student', 'student', 'MUSKI', 'STUDENT', 'studenska', '444', 'Beograd', 'Srbija', 1, 0);

INSERT INTO KorisnikovJezik(UserId,LanguageId)
	values (2,1);


INSERT INTO Cas(className,dateOfClass,classTime,statusId,isDeleted,professorId,studentId)
	values ('Engleski','06-06-2020','30','SLOBODAN',0,2,3)


update Cas set professorId='2' where className='Engleski'




INSERT INTO Jezici(languageName,isDeleted) 
	values ('Spanski',0)
INSERT INTO KorisnikovJezik(UserId,LanguageId)
	values (3,1);

INSERT INTO Cas(className,dateOfClass,classTime,statusId,isDeleted,professorId,studentId)
	values ('Majmunski','06-06-2020','30','SLOBODAN',0,3,3)

select * from Cas
select * from Korisnici
delete from Korisnici where userId='1008'

update Korisnici set SchoolId='1' ;
update Korisnici set firstName='profesor2' where userId='1008';