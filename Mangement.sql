create database Management;
use Management;

drop table if exists Account;
create table Account(
Account_ID int not null auto_increment,
StaffID varchar(20),
userlevel varchar(20),
Username varchar(50),
Passwords varchar(50),
AccountName varchar(50),
primary key (Account_ID));

alter table Account auto_increment = 1567458960;

insert into Account (StaffID,userlevel,Username,Passwords,AccountName)
values(1234567890,'Cashier','Cashier','Cashier','Borbe, Charlie'),
(1234567891,'Admin','admin','admin','Borbe, Charlie'),
(1234567892,'Receptionist','recep','recep','Borbe, Charlie');



select * from Account;


drop table if exists Products;
create table Products(
Product_ID int not null auto_increment,
Prod_desc varchar(100),
Prod_Category varchar(50),
Quantity int,
Price double,
primary key (Product_ID));

alter table products auto_increment = 185867594;

insert into Products (Prod_desc,Prod_Category,Quantity,Price)
values('Alpo Adult beef liver and vegies','Dog Food',50,300.00),
('Alpo Adult littles','Dog Food',100,320.00),
('Alpo fillet mignon','Dog Food',100,120.00),
('Cesar Beef','Dog Food',100,85.00),
('cesar beef and liver','Dog Food',100,85.00),
('cosi milk','Dog Food',100,130.00),
('Eukunuba adult','Dog Food',100,600.00),
('friskies kitten','Dog Food',100,335.00),
('frieskies meaty grills','Dog Food',100,335.00),
('gravy train chix','Dog Food',100,85.00),
('pedigree King of meat','Dog Food',100,100.00),
('pet one puppy can','Dog Food',100,80.00),
('rc adult beauty can','Dog Food',100,125.00),
('SD Active lonevity','Dog Food',100,970.00),
('whiskas ocean fish','Dog Food',100,335.00),
('holistic adult','Dog Food',100,2120.00),
('optima beef meal','Dog Food',100,1750.00),
('beefpro adult','Dog Food',100,2300.00),
('vitality classic','Dog Food',100,180.00),
('value meal','Dog Food',100,135.00);

insert into Products (Prod_desc,Prod_Category,Quantity,Price)
values('Bearing Dry powder (deodorant)','Sanitary',50,340.00),
('Bearing F1 All breeds oranges','Sanitary',50,435.00),
('Bearing f3 long hair green','Sanitary',50,435.00),
('Bearing f5 smelly hair red','Sanitary',50,435.00),
('Bearing white hair','Sanitary',50,435.00),
('Bearing small bread ping','Sanitary',50,435.00),
('Cordinal Blue Diamond','Sanitary',50,220.00),
('Cordinal Reoderizing','Sanitary',50,250.00),
('Aloi slicker brush large','Sanitary',50,550.00),
('catzone lavender','Sanitary',50,550.00),
('charles diaper (small)','Sanitary',50,40.00),
('charles diaper (large)','Sanitary',50,50.00),
('charles diaper (xlarge)','Sanitary',50,60.00),
('charles diaper(xsmall)','Sanitary',50,70.00),
('collar with bell (xsmall)','Sanitary',50,30.00),
('collar with bell (small)','Sanitary',50,150.00),
('collar with bell (medium)','Sanitary',50,200.00),
('collar with bell (large)','Sanitary',50,250.00),
('collar with bell (xlarge)','Sanitary',50,350.00),
('dog socks (small)','Sanitary',50,290.00),
('dog socks (medium)','Sanitary',50,350.00),
('dog socks (large)','Sanitary',50,450.00),
('dog socks (xlarge)','Sanitary',50,600.00);

insert into Products (Prod_desc,Prod_Category,Quantity,Price)
values('Arowfresh tootpaste','Health',50,300.00),
('broncure','Health',50,270.00),
('dextro-c','Health',50,180.00),
('doggymin syrup','Health',50,295.00),
('Dr-Clauders ear care','Health',50,410.00),
('footling spot (large) x box','Health',50,1360.00),
('footling spot (medium) x box','Health',50,1310.00),
('footling spot (small) x box','Health',50,1230.00),
('footling spot (large) x pc','Health',50,490.00),
('footling spot (medium) x pc','Health',50,460.00),
('footling spot (small) x pc','Health',50,460.00);

insert into Products (Prod_desc,Prod_Category,Quantity,Price)
values('bearing jerky BBQ','Treats',50,150.00),
('Calcium milk bone','Treats',50,50.00),
('dentastix green tea','Treats',50,95.00),
('grawlers cheese','Treats',50,60.00),
('grawlers chicken','Treats',50,60.00),
('grawlers bacon','Treats',50,60.00),
('grawlers beef','Treats',50,60.00),
('Gummy stick small','Treats',50,10.00),
('gummy bone','Treats',50,10.00),
('knotted bone','Treats',50,15.00);

select * from Products;

drop table if exists Category;
create table Category(
Category_ID int not null auto_increment,
Prod_Category varchar(50),
primary key (Category_ID));

insert into Category (Category_ID,Prod_Category)
values(1,'All'),
(2,'Dog Food'),
(3,'Sanitary'),
(4,'Health'),
(5,'Treats');


drop table if exists Staffs;
create table Staffs(
StaffID int not null auto_increment,
Firstname varchar(50),
Lastname varchar(50),
age int,
address varchar(1000),
userlevel varchar(20),
contactno varchar(20),
primary key (StaffID));

alter table Staffs auto_increment = 1234567890;

insert into Staffs (Firstname,Lastname,age,address,userlevel,contactno)
values('Charlie','Borbe',18, 'Laspinas City','Admin','09567718655'),
('Charlie','Borbe',18, 'Laspinas City','Receptionist','09567718655'),
('Charlie','Borbe',18, 'Laspinas City','Cashier','09567718655'), 
('Charlie','Borbe',18, 'Laspinas City','Staff','09567718655'),
('Justine','Gonzalve',18, 'Laspinas City','Staff','09567718655'),
('Babylyn','Libay',18, 'Laspinas City','Staff','09567718655'),
('Joel','Negro',18, 'Laspinas City','Staff','09567718655');

drop table if exists StaffLevel;
create table StaffLevel(
userlevel_ID int not null auto_increment,
userlevel varchar(50),
primary key (userlevel_ID));

insert into StaffLevel (userlevel_ID,userlevel)
values(1,'Staff'),
(2,'Admin'),
(3,'Cashier');

drop table if exists Services;
create table Services(
Services_ID int not null auto_increment,
Service_desc varchar(100),
Service_Category varchar(50),
Price double,
primary key (Services_ID));

alter table Services auto_increment = 173842001;

insert into Services(Service_desc,Service_Category,Price)
values('Expert Groom Package x Small','Package',500),
('Expert Groom Package x Medium','Package',650),
('Expert Groom Package x Large ','Package',850),
('Paw Trim','Ala Carte Services',100),
('Nail Trim','Ala Carte Services',100),
('Ear Cleaning','Ala Carte Services',100),
('Bath and Blowdry x Small','Ala Carte Services',250),
('Bath and Blowdry x Medium','Ala Carte Services',450),
('Bath and Blowdry x Large','Ala Carte Services',650),
('Toothbrush x Small','Add-On Services',250),
('Toothbrush x Medium','Add-On Services',450),
('Toothbrush x Large','Add-On Services',650),
('MilkBath x Small','Add-On Services',250),
('MilkBath x Medium','Add-On Services',450),
('MilkBath x Large','Add-On Services',650),
('AntiFlea & Tick Treatment x Small','Add-On Services',250),
('AntiFlea & Tick Treatment x Medium','Add-On Services',450),
('AntiFlea & Tick Treatment x Large','Add-On Services',650),
('Dog Hair Spa & Massage x Small','Add-On Services',250),
('Dog Hair Spa & Massage x Medium','Add-On Services',450),
('Dog Hair Spa & Massage x Large','Add-On Services',650),
('Anal Sac x Small','Add-On Services',100),
('Anal Sac x Medium','Add-On Services',150),
('Anal Sac x Large','Add-On Services',200),
('Organic Hairdye(Head) x Small','Add-On Services',700),
('Organic Hairdye(Head) x Medium','Add-On Services',700),
('Organic Hairdye(Head) x Large','Add-On Services',700),
('Organic Hairdye(Tails) x Small','Add-On Services',700),
('Organic Hairdye(Tails) x Medium','Add-On Services',700),
('Organic Hairdye(Tails) x Large','Add-On Services',700),
('Organic Hairdye(Ears) x Small','Add-On Services',700),
('Organic Hairdye(Ears) x Medium','Add-On Services',700),
('Organic Hairdye(Ears) x Large','Add-On Services',700),
('Organic Hairdye(Head & Ears) x Small','Add-On Services',1200),
('Organic Hairdye(Head & Ears) x Medium','Add-On Services',1200),
('Organic Hairdye(Head & Ears) x Large','Add-On Services',1200),
('Organic Hairdye(Torso) x Small','Add-On Services',2000),
('Organic Hairdye(Torso) x Medium','Add-On Services',3000),
('Organic Hairdye(Torso) x Large','Add-On Services',4000),
('Organic Hairdye(WholeBody) x Small','Add-On Services',3000),
('Organic Hairdye(WholeBody) x Medium','Add-On Services',4000),
('Organic Hairdye(WholeBody) x Large','Add-On Services',5000);

drop table if exists acty;
create table acty (
ActId int not null auto_increment,
AccountName varchar(50),
userlevel varchar(50),
ActName varchar(100),
ActDesc varchar(100),
primary key (ActId));

drop table if exists LOGIN;
create table LOGIN(
Login_ID int not null auto_increment,
AccountName varchar(50),
login_username varchar(50),
login_pass varchar(50),
userlevel varchar(10),
DateTimeIn varchar(50),
StaffID varchar(50),
primary key (Login_ID));

drop table if exists Rooms;
create table Rooms(
Room_ID int not null auto_increment,
Room_Name varchar(50),
Room_Type varchar(50),
Room_Status varchar(50),
CheckInDateTime varchar(100),
CheckOutDateTime varchar(100),
primary key (Room_ID));

alter table Rooms auto_increment = 1225893471;

insert into Rooms (Room_Name,Room_Type,Room_Status,CheckOutDateTime)
values('R1','Regular','Available','December 31, 2999 12:59 PM'),
('R2','Regular','Available','December 31, 2999 12:59 PM'),
('R3','Regular','Available','December 31, 2999 12:59 PM'),
('R4','Regular','Available','December 31, 2999 12:59 PM'),
('R5','Regular','Available','December 31, 2999 12:59 PM'),
('R6','Regular','Available','December 31, 2999 12:59 PM'),
('R7','Regular','Available','December 31, 2999 12:59 PM'),
('R8','Regular','Available','December 31, 2999 12:59 PM'),
('R9','Regular','Available','December 31, 2999 12:59 PM'),
('R10','Regular','Available','December 31, 2999 12:59 PM'),
('R11','Regular','Available','December 31, 2999 12:59 PM'),
('R12','Regular','Available','December 31, 2999 12:59 PM'),
('R13','Regular','Available','December 31, 2999 12:59 PM'),
('R14','Regular','Available','December 31, 2999 12:59 PM'),
('R15','Regular','Available','December 31, 2999 12:59 PM'),
('R16','Regular','Available','December 31, 2999 12:59 PM'),
('R16','Regular','Available','December 31, 2999 12:59 PM'),
('R17','Regular','Available','December 31, 2999 12:59 PM'),
('R18','Regular','Available','December 31, 2999 12:59 PM'),
('R19','Regular','Available','December 31, 2999 12:59 PM'),
('R20','Regular','Available','December 31, 2999 12:59 PM'),
('S1','Private Suite','Available','December 31, 2999 12:59 PM'),
('S2','Private Suite','Available','December 31, 2999 12:59 PM'),
('S3','Private Suite','Available','December 31, 2999 12:59 PM'),
('S4','Private Suite','Available','December 31, 2999 12:59 PM'),
('S5','Private Suite','Available','December 31, 2999 12:59 PM'),
('S6','Private Suite','Available','December 31, 2999 12:59 PM'),
('S7','Private Suite','Available','December 31, 2999 12:59 PM'),
('S8','Private Suite','Available','December 31, 2999 12:59 PM'),
('S9','Private Suite','Available','December 31, 2999 12:59 PM'),
('S10','Private Suite','Available','December 31, 2999 12:59 PM');


insert into Rooms (Room_Name,Room_Type,Room_Status,CheckInDateTime,CheckOutDateTime)
values('R1','Regular','Available','3000-12-30 01:01:01','3000-12-30 01:01:01');


drop table if exists Customer;
create table Customer(
Customer_ID int not null auto_increment,
Customer_Name varchar(50),
Pet_Name varchar(50),
Breed varchar(100),
Contact_No varchar(100),
Email_Address varchar(100),
primary key (Customer_ID));

alter table Customer auto_increment = 1785496823;

insert into Customer (Customer_Name,Pet_Name,Breed,Contact_No,Email_Address)
values('Charlie Borbe','Butchoy','Siberian Husky','09567718655','charlieborbs18@gmail.com');


drop table if exists RoomReservation;
create table RoomReservation(
Reserve_ID int not null auto_increment,
Room_Name varchar(100) ,
Room_Type varchar(100),
Customer_Name varchar(50),
Pet_Name varchar(50),
Breed varchar(50),
Contact_Details varchar(100),
Date_Reserved varchar(100),
TimeArrival datetime(6),
No_Days varchar(10),
AccountName varchar(100),
primary key (Reserve_ID));


drop table if exists ServiceRegistration;
create table ServiceRegistration(
SRegister_ID int not null auto_increment,
Customer_Name varchar(50),
Pet_Name varchar(50),
Breed varchar(50),
Contact_Details varchar(100),
Service_desc varchar(100) ,
Service_Category varchar(100),
GroomerName varchar(100),
AccountName varchar(100),
primary key (SRegister_ID));
















DROP TABLE IF EXISTS Payment;
create table Payment(
Payment_No int not null auto_increment,
InvoiceNo varchar(20),
Cash double,
TotalAmount double,
PChange double,
primary key (Payment_No));


DROP TABLE IF EXISTS transactions;
CREATE TABLE transactions (
  InvoiceNo int NOT NULL auto_increment,
  TDate varchar(45) NOT NULL default '',
  TTime varchar(45) NOT NULL default '',
  NonVatTotal double NOT NULL default '0',
  VatAmount double NOT NULL default '0',
  TotalAmount varchar(45) NOT NULL default '',
  StaffID int(11) NOT NULL default '0',
  TStatus int(10) unsigned NOT NULL default '0',
  PRIMARY KEY  (InvoiceNo));
  
alter table transactions auto_increment = 1145238540;

insert into transactions (NonVatTotal,VatAmount,TotalAmount,StaffID)
values(172.00,28.00,200.00,1234567890);

delete from transactions where InvoiceNo = 1145238540;

DROP TABLE IF EXISTS transactiondetails;
CREATE TABLE transactiondetails (
  TDetailNo int(10) unsigned NOT NULL auto_increment,
  InvoiceNo varchar(50) NOT NULL default '',
  Product_ID int(10) unsigned NOT NULL default '0',
  Prod_desc varchar(100),
  UnitPrice double NOT NULL default '0',
  Quantity double NOT NULL default '0',
  Price double NOT NULL default '0',
  Discount double NOT NULL default '0',
  PRIMARY KEY  (TDetailNo)) ;
  
  alter table transactiondetails auto_increment = 1000050432;

insert into transactiondetails (InvoiceNo,Product_ID,Prod_desc,UnitPrice,Price,Quantity,Discount)
values(1045238561,'185867597','Cesar Beef',85,85,1,0);

DROP TABLE IF EXISTS vatsetting;
CREATE TABLE vatsetting (
  VatID int(10) unsigned NOT NULL auto_increment,
  VatPercent double NOT NULL default '0',
  PRIMARY KEY  (`VatID`));
  

  
 
  
  

