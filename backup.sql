-- MySqlBackup.NET 2.0.9.2
-- Dump Time: 2017-09-23 13:09:20
-- --------------------------------------
-- Server version 10.1.26-MariaDB mariadb.org binary distribution


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES latin1 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of account
-- 

DROP TABLE IF EXISTS `account`;
CREATE TABLE IF NOT EXISTS `account` (
  `Account_ID` int(11) NOT NULL AUTO_INCREMENT,
  `StaffID` varchar(20) DEFAULT NULL,
  `userlevel` varchar(20) DEFAULT NULL,
  `Username` varchar(50) DEFAULT NULL,
  `Passwords` varchar(50) DEFAULT NULL,
  `AccountName` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Account_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=1567458963 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table account
-- 

/*!40000 ALTER TABLE `account` DISABLE KEYS */;
INSERT INTO `account`(`Account_ID`,`StaffID`,`userlevel`,`Username`,`Passwords`,`AccountName`) VALUES
(1567458960,'1234567890','Cashier','Cashier','Cashier','Borbe, Charlie'),
(1567458961,'1234567891','Admin','admin','admin','Borbe, Charlie'),
(1567458962,'1234567892','Receptionist','recep','recep','Borbe, Charlie');
/*!40000 ALTER TABLE `account` ENABLE KEYS */;

-- 
-- Definition of acty
-- 

DROP TABLE IF EXISTS `acty`;
CREATE TABLE IF NOT EXISTS `acty` (
  `ActId` int(11) NOT NULL AUTO_INCREMENT,
  `AccountName` varchar(50) DEFAULT NULL,
  `userlevel` varchar(50) DEFAULT NULL,
  `ActName` varchar(100) DEFAULT NULL,
  `ActDesc` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ActId`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table acty
-- 

/*!40000 ALTER TABLE `acty` DISABLE KEYS */;
INSERT INTO `acty`(`ActId`,`AccountName`,`userlevel`,`ActName`,`ActDesc`) VALUES
(1,'label4','label5','Add Products','yyyyyyy'),
(2,'label4','label5','Update Product','yyyyyyy'),
(3,'label4','label5','Update Product','sadasd'),
(4,'label4','label5','Update Product','sadasd'),
(5,'Borbe,Charlie','Admin','Update Services','Bath and Blowdry x Small'),
(6,'Borbe,Charlie','Admin','Add Customer','babylyn');
/*!40000 ALTER TABLE `acty` ENABLE KEYS */;

-- 
-- Definition of category
-- 

DROP TABLE IF EXISTS `category`;
CREATE TABLE IF NOT EXISTS `category` (
  `Category_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Prod_Category` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Category_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table category
-- 

/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category`(`Category_ID`,`Prod_Category`) VALUES
(1,'All'),
(2,'Dog Food'),
(3,'Sanitary'),
(4,'Health'),
(5,'Treats');
/*!40000 ALTER TABLE `category` ENABLE KEYS */;

-- 
-- Definition of customer
-- 

DROP TABLE IF EXISTS `customer`;
CREATE TABLE IF NOT EXISTS `customer` (
  `Customer_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Customer_Name` varchar(50) DEFAULT NULL,
  `Pet_Name` varchar(50) DEFAULT NULL,
  `Breed` varchar(100) DEFAULT NULL,
  `Contact_No` varchar(100) DEFAULT NULL,
  `Email_Address` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Customer_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=1785496825 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table customer
-- 

/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer`(`Customer_ID`,`Customer_Name`,`Pet_Name`,`Breed`,`Contact_No`,`Email_Address`) VALUES
(1785496823,'Charlie Borbe','Butchoy','Siberian Husky','09567718655','charlieborbs18@gmail.com'),
(1785496824,'babylyn','asdasda','asdasd','122132','asdasdasd');
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;

-- 
-- Definition of login
-- 

DROP TABLE IF EXISTS `login`;
CREATE TABLE IF NOT EXISTS `login` (
  `Login_ID` int(11) NOT NULL AUTO_INCREMENT,
  `AccountName` varchar(50) DEFAULT NULL,
  `login_username` varchar(50) DEFAULT NULL,
  `login_pass` varchar(50) DEFAULT NULL,
  `userlevel` varchar(25) DEFAULT NULL,
  `DateTimeIn` varchar(50) DEFAULT NULL,
  `StaffID` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Login_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table login
-- 

/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login`(`Login_ID`,`AccountName`,`login_username`,`login_pass`,`userlevel`,`DateTimeIn`,`StaffID`) VALUES
(1,'Borbe, Charlie','admin','admin','Admin','9/23/2017 3:22:02 AM','1567458961'),
(2,'Borbe, Charlie','recep','recep','Receptionist','9/23/2017 3:22:19 AM','1567458962'),
(3,'Borbe, Charlie','Cashier','Cashier','Cashier','9/23/2017 3:22:34 AM','1567458960'),
(4,'Borbe, Charlie','Cashier','Cashier','Cashier','9/23/2017 3:24:18 AM','1567458960'),
(5,'Borbe, Charlie','Cashier','Cashier','Cashier','9/23/2017 3:30:21 AM','1567458960'),
(6,'Borbe, Charlie','Cashier','Cashier','Cashier','9/23/2017 3:32:09 AM','1567458960'),
(7,'Borbe, Charlie','admin','admin','Admin','9/23/2017 3:39:30 AM','1567458961'),
(8,'Borbe, Charlie','admin','admin','Admin','9/23/2017 3:40:32 AM','1567458961'),
(9,'Borbe, Charlie','admin','admin','Admin','9/23/2017 3:41:29 AM','1567458961'),
(10,'Borbe, Charlie','admin','admin','Admin','9/23/2017 3:42:50 AM','1567458961'),
(11,'Borbe, Charlie','admin','admin','Admin','9/23/2017 3:47:09 AM','1567458961'),
(12,'Borbe, Charlie','admin','admin','Admin','9/23/2017 5:06:19 AM','1567458961'),
(13,'Borbe, Charlie','admin','admin','Admin','9/23/2017 5:18:43 AM','1567458961'),
(14,'Borbe, Charlie','admin','admin','Admin','9/23/2017 1:00:50 PM','1567458961');
/*!40000 ALTER TABLE `login` ENABLE KEYS */;

-- 
-- Definition of products
-- 

DROP TABLE IF EXISTS `products`;
CREATE TABLE IF NOT EXISTS `products` (
  `Product_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Prod_desc` varchar(100) DEFAULT NULL,
  `Prod_Category` varchar(50) DEFAULT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `Price` double DEFAULT NULL,
  `Discount` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`Product_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=185867660 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table products
-- 

/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products`(`Product_ID`,`Prod_desc`,`Prod_Category`,`Quantity`,`Price`,`Discount`) VALUES
(185867594,'Alpo Adult beef liver and vegies','Dog Food',50,300,0),
(185867595,'Alpo Adult littles','Dog Food',100,320,0),
(185867596,'Alpo fillet mignon','Dog Food',100,120,0),
(185867597,'Cesar Beef','Dog Food',100,85,0),
(185867598,'cesar beef and liver','Dog Food',100,85,0),
(185867599,'cosi milk','Dog Food',100,130,0),
(185867600,'Eukunuba adult','Dog Food',100,600,0),
(185867601,'friskies kitten','Dog Food',100,335,0),
(185867602,'frieskies meaty grills','Dog Food',96,335,0),
(185867603,'gravy train chix','Dog Food',99,85,0),
(185867604,'pedigree King of meat','Dog Food',100,100,0),
(185867605,'pet one puppy can','Dog Food',100,80,0),
(185867606,'rc adult beauty can','Dog Food',100,125,0),
(185867607,'SD Active lonevity','Dog Food',100,970,0),
(185867608,'whiskas ocean fish','Dog Food',100,335,0),
(185867609,'holistic adult','Dog Food',99,2120,0),
(185867610,'optima beef meal','Dog Food',99,1750,0),
(185867611,'beefpro adult','Dog Food',100,2300,0),
(185867612,'vitality classic','Dog Food',100,180,0),
(185867613,'value meal','Dog Food',100,135,0),
(185867614,'Bearing Dry powder (deodorant)','Sanitary',50,340,0),
(185867615,'Bearing F1 All breeds oranges','Sanitary',50,435,0),
(185867616,'Bearing f3 long hair green','Sanitary',50,435,0),
(185867617,'Bearing f5 smelly hair red','Sanitary',50,435,0),
(185867618,'Bearing white hair','Sanitary',50,435,0),
(185867619,'Bearing small bread ping','Sanitary',50,435,0),
(185867620,'Cordinal Blue Diamond','Sanitary',50,220,0),
(185867621,'Cordinal Reoderizing','Sanitary',50,250,0),
(185867622,'Aloi slicker brush large','Sanitary',50,550,0),
(185867623,'catzone lavender','Sanitary',50,550,0),
(185867624,'charles diaper (small)','Sanitary',50,40,0),
(185867625,'charles diaper (large)','Sanitary',50,50,0),
(185867626,'charles diaper (xlarge)','Sanitary',50,60,0),
(185867627,'charles diaper(xsmall)','Sanitary',50,70,0),
(185867628,'collar with bell (xsmall)','Sanitary',50,30,0),
(185867629,'collar with bell (small)','Sanitary',50,150,0),
(185867630,'collar with bell (medium)','Sanitary',50,200,0),
(185867631,'collar with bell (large)','Sanitary',50,250,0),
(185867632,'collar with bell (xlarge)','Sanitary',50,350,0),
(185867633,'dog socks (small)','Sanitary',50,290,0),
(185867634,'dog socks (medium)','Sanitary',50,350,0),
(185867635,'dog socks (large)','Sanitary',50,450,0),
(185867636,'dog socks (xlarge)','Sanitary',50,600,0),
(185867637,'Arowfresh tootpaste','Health',50,300,0),
(185867638,'broncure','Health',50,270,0),
(185867639,'dextro-c','Health',50,180,0),
(185867640,'doggymin syrup','Health',50,295,0),
(185867641,'Dr-Clauders ear care','Health',50,410,0),
(185867642,'footling spot (large) x box','Health',50,1360,0),
(185867643,'footling spot (medium) x box','Health',50,1310,0),
(185867644,'footling spot (small) x box','Health',50,1230,0),
(185867645,'footling spot (large) x pc','Health',50,490,0),
(185867646,'footling spot (medium) x pc','Health',50,460,0),
(185867647,'footling spot (small) x pc','Health',50,460,0),
(185867648,'bearing jerky BBQ','Treats',50,150,0),
(185867649,'Calcium milk bone','Treats',50,50,0),
(185867650,'dentastix green tea','Treats',50,95,0),
(185867651,'grawlers cheese','Treats',50,60,0),
(185867652,'grawlers chicken','Treats',50,60,0),
(185867653,'grawlers bacon','Treats',50,60,0),
(185867654,'grawlers beef','Treats',50,60,0),
(185867655,'Gummy stick small','Treats',50,10,0),
(185867656,'gummy bone','Treats',50,10,0),
(185867657,'knotted bone','Treats',50,15,0),
(185867658,'sadasd','Dog Food',59,150,0),
(185867659,'yyyyyyy','Dog Food',3,150,0);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;

-- 
-- Definition of returnitem
-- 

DROP TABLE IF EXISTS `returnitem`;
CREATE TABLE IF NOT EXISTS `returnitem` (
  `Return_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Product_ID` int(11) DEFAULT NULL,
  `Prod_desc` varchar(100) DEFAULT NULL,
  `Prod_Category` varchar(50) DEFAULT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `Price` double DEFAULT NULL,
  `return_date` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Return_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table returnitem
-- 

/*!40000 ALTER TABLE `returnitem` DISABLE KEYS */;

/*!40000 ALTER TABLE `returnitem` ENABLE KEYS */;

-- 
-- Definition of roomreservation
-- 

DROP TABLE IF EXISTS `roomreservation`;
CREATE TABLE IF NOT EXISTS `roomreservation` (
  `Reserve_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Room_Name` varchar(100) DEFAULT NULL,
  `Room_Type` varchar(100) DEFAULT NULL,
  `Customer_Name` varchar(50) DEFAULT NULL,
  `Pet_Name` varchar(50) DEFAULT NULL,
  `Breed` varchar(50) DEFAULT NULL,
  `Contact_Details` varchar(100) DEFAULT NULL,
  `Date_Reserved` varchar(100) DEFAULT NULL,
  `TimeArrival` datetime(6) DEFAULT NULL,
  `No_Days` varchar(10) DEFAULT NULL,
  `AccountName` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Reserve_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table roomreservation
-- 

/*!40000 ALTER TABLE `roomreservation` DISABLE KEYS */;
INSERT INTO `roomreservation`(`Reserve_ID`,`Room_Name`,`Room_Type`,`Customer_Name`,`Pet_Name`,`Breed`,`Contact_Details`,`Date_Reserved`,`TimeArrival`,`No_Days`,`AccountName`) VALUES
(1,'R4','Regular','Charlie Borbe','Butchoy','Siberian Husky','09567718655','September 23,2017',NULL,NULL,'Borbe, Charlie'),
(2,'R12','Regular','Charlie Borbe','Butchoy','Siberian Husky','09567718655','September 23,2017',NULL,NULL,'Borbe, Charlie');
/*!40000 ALTER TABLE `roomreservation` ENABLE KEYS */;

-- 
-- Definition of rooms
-- 

DROP TABLE IF EXISTS `rooms`;
CREATE TABLE IF NOT EXISTS `rooms` (
  `Room_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Room_Name` varchar(50) DEFAULT NULL,
  `Room_Type` varchar(50) DEFAULT NULL,
  `Room_Status` varchar(50) DEFAULT NULL,
  `CheckInDateTime` varchar(100) DEFAULT NULL,
  `CheckOutDateTime` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Room_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=1225893503 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table rooms
-- 

/*!40000 ALTER TABLE `rooms` DISABLE KEYS */;
INSERT INTO `rooms`(`Room_ID`,`Room_Name`,`Room_Type`,`Room_Status`,`CheckInDateTime`,`CheckOutDateTime`) VALUES
(1225893471,'R1','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893472,'R2','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893473,'R3','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893474,'R4','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893475,'R5','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893476,'R6','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893477,'R7','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893478,'R8','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893479,'R9','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893480,'R10','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893481,'R11','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893482,'R12','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893483,'R13','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893484,'R14','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893485,'R15','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893486,'R16','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893487,'R16','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893488,'R17','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893489,'R18','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893490,'R19','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893491,'R20','Regular','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893492,'S1','Private Suite','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893493,'S2','Private Suite','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893494,'S3','Private Suite','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893495,'S4','Private Suite','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893496,'S5','Private Suite','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893497,'S6','Private Suite','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893498,'S7','Private Suite','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893499,'S8','Private Suite','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893500,'S9','Private Suite','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893501,'S10','Private Suite','Available',NULL,'December 31, 2999 12:59 PM'),
(1225893502,'R1','Regular','Available','3000-12-30 01:01:01','3000-12-30 01:01:01');
/*!40000 ALTER TABLE `rooms` ENABLE KEYS */;

-- 
-- Definition of serviceregistration
-- 

DROP TABLE IF EXISTS `serviceregistration`;
CREATE TABLE IF NOT EXISTS `serviceregistration` (
  `SRegister_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Customer_Name` varchar(50) DEFAULT NULL,
  `Pet_Name` varchar(50) DEFAULT NULL,
  `Breed` varchar(50) DEFAULT NULL,
  `Contact_Details` varchar(100) DEFAULT NULL,
  `Service_desc` varchar(100) DEFAULT NULL,
  `Service_Category` varchar(100) DEFAULT NULL,
  `GroomerName` varchar(100) DEFAULT NULL,
  `AccountName` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`SRegister_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table serviceregistration
-- 

/*!40000 ALTER TABLE `serviceregistration` DISABLE KEYS */;

/*!40000 ALTER TABLE `serviceregistration` ENABLE KEYS */;

-- 
-- Definition of services
-- 

DROP TABLE IF EXISTS `services`;
CREATE TABLE IF NOT EXISTS `services` (
  `Services_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Service_desc` varchar(100) DEFAULT NULL,
  `Service_Category` varchar(50) DEFAULT NULL,
  `Price` double DEFAULT NULL,
  PRIMARY KEY (`Services_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=173842043 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table services
-- 

/*!40000 ALTER TABLE `services` DISABLE KEYS */;
INSERT INTO `services`(`Services_ID`,`Service_desc`,`Service_Category`,`Price`) VALUES
(173842001,'Expert Groom Package x Small','Package',500),
(173842002,'Expert Groom Package x Medium','Package',650),
(173842003,'Expert Groom Package x Large ','Package',850),
(173842004,'Paw Trim','Ala Carte Services',100),
(173842005,'Nail Trim','Ala Carte Services',100),
(173842006,'Ear Cleaning','Ala Carte Services',100),
(173842007,'Bath and Blowdry x Small','Ala Carte Services',300),
(173842008,'Bath and Blowdry x Medium','Ala Carte Services',450),
(173842009,'Bath and Blowdry x Large','Ala Carte Services',650),
(173842010,'Toothbrush x Small','Add-On Services',250),
(173842011,'Toothbrush x Medium','Add-On Services',450),
(173842012,'Toothbrush x Large','Add-On Services',650),
(173842013,'MilkBath x Small','Add-On Services',250),
(173842014,'MilkBath x Medium','Add-On Services',450),
(173842015,'MilkBath x Large','Add-On Services',650),
(173842016,'AntiFlea & Tick Treatment x Small','Add-On Services',250),
(173842017,'AntiFlea & Tick Treatment x Medium','Add-On Services',450),
(173842018,'AntiFlea & Tick Treatment x Large','Add-On Services',650),
(173842019,'Dog Hair Spa & Massage x Small','Add-On Services',250),
(173842020,'Dog Hair Spa & Massage x Medium','Add-On Services',450),
(173842021,'Dog Hair Spa & Massage x Large','Add-On Services',650),
(173842022,'Anal Sac x Small','Add-On Services',100),
(173842023,'Anal Sac x Medium','Add-On Services',150),
(173842024,'Anal Sac x Large','Add-On Services',200),
(173842025,'Organic Hairdye(Head) x Small','Add-On Services',700),
(173842026,'Organic Hairdye(Head) x Medium','Add-On Services',700),
(173842027,'Organic Hairdye(Head) x Large','Add-On Services',700),
(173842028,'Organic Hairdye(Tails) x Small','Add-On Services',700),
(173842029,'Organic Hairdye(Tails) x Medium','Add-On Services',700),
(173842030,'Organic Hairdye(Tails) x Large','Add-On Services',700),
(173842031,'Organic Hairdye(Ears) x Small','Add-On Services',700),
(173842032,'Organic Hairdye(Ears) x Medium','Add-On Services',700),
(173842033,'Organic Hairdye(Ears) x Large','Add-On Services',700),
(173842034,'Organic Hairdye(Head & Ears) x Small','Add-On Services',1200),
(173842035,'Organic Hairdye(Head & Ears) x Medium','Add-On Services',1200),
(173842036,'Organic Hairdye(Head & Ears) x Large','Add-On Services',1200),
(173842037,'Organic Hairdye(Torso) x Small','Add-On Services',2000),
(173842038,'Organic Hairdye(Torso) x Medium','Add-On Services',3000),
(173842039,'Organic Hairdye(Torso) x Large','Add-On Services',4000),
(173842040,'Organic Hairdye(WholeBody) x Small','Add-On Services',3000),
(173842041,'Organic Hairdye(WholeBody) x Medium','Add-On Services',4000),
(173842042,'Organic Hairdye(WholeBody) x Large','Add-On Services',5000);
/*!40000 ALTER TABLE `services` ENABLE KEYS */;

-- 
-- Definition of stafflevel
-- 

DROP TABLE IF EXISTS `stafflevel`;
CREATE TABLE IF NOT EXISTS `stafflevel` (
  `userlevel_ID` int(11) NOT NULL AUTO_INCREMENT,
  `userlevel` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`userlevel_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table stafflevel
-- 

/*!40000 ALTER TABLE `stafflevel` DISABLE KEYS */;
INSERT INTO `stafflevel`(`userlevel_ID`,`userlevel`) VALUES
(1,'Staff'),
(2,'Admin'),
(3,'Cashier');
/*!40000 ALTER TABLE `stafflevel` ENABLE KEYS */;

-- 
-- Definition of staffs
-- 

DROP TABLE IF EXISTS `staffs`;
CREATE TABLE IF NOT EXISTS `staffs` (
  `StaffID` int(11) NOT NULL AUTO_INCREMENT,
  `Firstname` varchar(50) DEFAULT NULL,
  `Lastname` varchar(50) DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `address` varchar(1000) DEFAULT NULL,
  `userlevel` varchar(20) DEFAULT NULL,
  `contactno` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`StaffID`)
) ENGINE=InnoDB AUTO_INCREMENT=1234567897 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table staffs
-- 

/*!40000 ALTER TABLE `staffs` DISABLE KEYS */;
INSERT INTO `staffs`(`StaffID`,`Firstname`,`Lastname`,`age`,`address`,`userlevel`,`contactno`) VALUES
(1234567890,'Charlie','Borbe',18,'Laspinas City','Admin','09567718655'),
(1234567891,'Charlie','Borbe',18,'Laspinas City','Receptionist','09567718655'),
(1234567892,'Charlie','Borbe',18,'Laspinas City','Cashier','09567718655'),
(1234567893,'Charlie','Borbe',18,'Laspinas City','Staff','09567718655'),
(1234567894,'Justine','Gonzalve',18,'Laspinas City','Staff','09567718655'),
(1234567895,'Babylyn','Libay',18,'Laspinas City','Staff','09567718655'),
(1234567896,'Joel','Negro',18,'Laspinas City','Staff','09567718655');
/*!40000 ALTER TABLE `staffs` ENABLE KEYS */;

-- 
-- Definition of taxrecord
-- 

DROP TABLE IF EXISTS `taxrecord`;
CREATE TABLE IF NOT EXISTS `taxrecord` (
  `TAXID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `InvoiceNo` varchar(50) NOT NULL DEFAULT '',
  `VatAmount` double NOT NULL DEFAULT '0',
  `TDate` varchar(45) NOT NULL DEFAULT '',
  PRIMARY KEY (`TAXID`)
) ENGINE=InnoDB AUTO_INCREMENT=1222222227 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table taxrecord
-- 

/*!40000 ALTER TABLE `taxrecord` DISABLE KEYS */;
INSERT INTO `taxrecord`(`TAXID`,`InvoiceNo`,`VatAmount`,`TDate`) VALUES
(1222222222,'1045238584',566.4,'September 06, 2017'),
(1222222223,'1000050435',10.2,'September 23, 2017'),
(1222222224,'1000050436',210,'September 23, 2017'),
(1222222225,'1000050437',254.4,'September 23, 2017'),
(1222222226,'1000050438',40.2,'September 23, 2017');
/*!40000 ALTER TABLE `taxrecord` ENABLE KEYS */;

-- 
-- Definition of test
-- 

DROP TABLE IF EXISTS `test`;
CREATE TABLE IF NOT EXISTS `test` (
  `TestID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `InvoiceNo` varchar(50) NOT NULL DEFAULT '',
  `VatAmount` double NOT NULL DEFAULT '0',
  `TDate` varchar(45) NOT NULL DEFAULT '',
  PRIMARY KEY (`TestID`)
) ENGINE=InnoDB AUTO_INCREMENT=1222222223 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table test
-- 

/*!40000 ALTER TABLE `test` DISABLE KEYS */;
INSERT INTO `test`(`TestID`,`InvoiceNo`,`VatAmount`,`TDate`) VALUES
(1222222222,'1045238584',20,'September 06, 2017');
/*!40000 ALTER TABLE `test` ENABLE KEYS */;

-- 
-- Definition of transactiondetails
-- 

DROP TABLE IF EXISTS `transactiondetails`;
CREATE TABLE IF NOT EXISTS `transactiondetails` (
  `TDetailNo` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `InvoiceNo` varchar(50) NOT NULL DEFAULT '',
  `Product_ID` int(10) unsigned NOT NULL DEFAULT '0',
  `Prod_desc` varchar(100) DEFAULT NULL,
  `UnitPrice` double NOT NULL DEFAULT '0',
  `Quantity` double NOT NULL DEFAULT '0',
  `Price` double NOT NULL DEFAULT '0',
  `Discount` double NOT NULL DEFAULT '0',
  `transaction_type` varchar(50) DEFAULT NULL,
  `Customer_Name` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`TDetailNo`)
) ENGINE=InnoDB AUTO_INCREMENT=1000000010 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table transactiondetails
-- 

/*!40000 ALTER TABLE `transactiondetails` DISABLE KEYS */;
INSERT INTO `transactiondetails`(`TDetailNo`,`InvoiceNo`,`Product_ID`,`Prod_desc`,`UnitPrice`,`Quantity`,`Price`,`Discount`,`transaction_type`,`Customer_Name`) VALUES
(1000000000,'1000050432',185867597,'Cesar Beef',200,1,200,0,'Products','Charlie Borbe'),
(1000000001,'1000050433',185867598,'Cesar Beef',200,1,200,0,'Services','Charlie Borbe'),
(1000000002,'1000050434',185867598,'Cesar Beef',200,1,200,0,'Rooms','Charlie Borbe'),
(1000000003,'1000050435',185867603,'gravy train chix',85,1,85,0,NULL,NULL),
(1000000004,'1000050436',185867610,'optima beef meal',1750,1,1750,0,NULL,NULL),
(1000000005,'1000050437',185867609,'holistic adult',2120,1,2120,0,NULL,NULL),
(1000000006,'1000050438',185867602,'frieskies meaty grills',335,1,335,0,NULL,NULL),
(1000000007,'1000050439',185867602,'frieskies meaty grills',335,1,335,0,NULL,NULL),
(1000000008,'1000050440',185867602,'frieskies meaty grills',335,1,335,0,NULL,NULL),
(1000000009,'1000050441',185867602,'frieskies meaty grills',335,1,335,0,NULL,NULL);
/*!40000 ALTER TABLE `transactiondetails` ENABLE KEYS */;

-- 
-- Definition of transactions
-- 

DROP TABLE IF EXISTS `transactions`;
CREATE TABLE IF NOT EXISTS `transactions` (
  `InvoiceNo` int(11) NOT NULL AUTO_INCREMENT,
  `TDate` varchar(45) NOT NULL DEFAULT '',
  `TTime` varchar(45) NOT NULL DEFAULT '',
  `NonVatTotal` double NOT NULL DEFAULT '0',
  `VatAmount` double NOT NULL DEFAULT '0',
  `TotalAmount` varchar(45) NOT NULL DEFAULT '',
  `CashPaid` varchar(45) NOT NULL DEFAULT '',
  `ChangeReceive` varchar(45) NOT NULL DEFAULT '',
  `StaffID` int(11) NOT NULL DEFAULT '0',
  `TStatus` int(10) unsigned NOT NULL DEFAULT '0',
  PRIMARY KEY (`InvoiceNo`)
) ENGINE=InnoDB AUTO_INCREMENT=1000050438 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table transactions
-- 

/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
INSERT INTO `transactions`(`InvoiceNo`,`TDate`,`TTime`,`NonVatTotal`,`VatAmount`,`TotalAmount`,`CashPaid`,`ChangeReceive`,`StaffID`,`TStatus`) VALUES
(1000050432,'September 20,2017','01:18 AM',172,28,'200.00','250.00','50.00',1234567890,0),
(1000050437,'September 23, 2017','03:30 AM',1865.6,254.4,'2120','2200.00','80.00',0,0);
/*!40000 ALTER TABLE `transactions` ENABLE KEYS */;

-- 
-- Definition of vatsetting
-- 

DROP TABLE IF EXISTS `vatsetting`;
CREATE TABLE IF NOT EXISTS `vatsetting` (
  `VatID` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `VatPercent` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`VatID`)
) ENGINE=InnoDB AUTO_INCREMENT=1000100001 DEFAULT CHARSET=latin1;

-- 
-- Dumping data for table vatsetting
-- 

/*!40000 ALTER TABLE `vatsetting` DISABLE KEYS */;
INSERT INTO `vatsetting`(`VatID`,`VatPercent`) VALUES
(1000100000,'0.12');
/*!40000 ALTER TABLE `vatsetting` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2017-09-23 13:09:20
-- Total time: 0:0:0:0:569 (d:h:m:s:ms)
