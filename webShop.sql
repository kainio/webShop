CREATE DATABASE webShop
go
USE webShop
go
CREATE TABLE utilisateurs(iduti int primary key identity(1,1), username varchar(100),motpasse varchar(100), nom varchar(100));
CREATE TABLE produits(idprod int primary key identity(1,1), nomprod varchar(100), description varchar(250),prix_uni float,photo varchar(100) default null);
CREATE TABLE commandes(idcomm int primary key identity(1,1), iduti int foreign key references utilisateurs(iduti));
CREATE TABLE lineitems(idprod int foreign key references produits(idprod), iduti int references utilisateurs(iduti), idcomm int default null foreign key references commandes(idcomm),primary key (idprod,iduti), quantité int);
go
INSERT INTO utilisateurs VALUES ('test1', 'test','soufiane');
INSERT INTO utilisateurs VALUES ('test2', 'test','mohcine');
INSERT INTO utilisateurs VALUES ('test3', 'test','houssam');
go
INSERT INTO produits VALUES ('T-shirt Special hero','Un t-shirt pour un super hero',200,'Content/Images/green-t-shirt_925x.jpg');
INSERT INTO produits VALUES ('T-shirt rouge','Ce T-shirt va vous rendre le plus beau des oiseaux',50,'Content/Images/red-t-shirt_925x.jpg');
INSERT INTO produits VALUES ('T-shirt pour femme','un beau produit pour une belle princess',130,'Content/Images/ladies-white-t-shirt_925x.jpg');
INSERT INTO produits VALUES ('T-shirt casual femme','Regardez moi je suis la',330,'Content/Images/womens-red-t-shirt_925x.jpg');
INSERT INTO produits VALUES ('T-shirt du travail pour femme','un Commancer votre journée de travail tranquille',90,'Content/Images/striped-t-shirt_925x.jpg');
go

