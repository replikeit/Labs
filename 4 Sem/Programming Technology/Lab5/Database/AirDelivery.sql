BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS `PaymentSpans` (
	`ID`	integer NOT NULL,
	`StartingDate`	integer NOT NULL,
	`EndingDate`	integer NOT NULL,
	`Sum`	integer NOT NULL,
	CONSTRAINT `PaymentSpans_pk` PRIMARY KEY(`ID`)
);
CREATE TABLE IF NOT EXISTS `Helicopters` (
	`ID`	integer NOT NULL,
	`HelicopterBrands_ID`	integer NOT NULL,
	`CreationDate`	integer NOT NULL,
	`CarryingCapacity`	integer NOT NULL,
	`LastOverhaulDate`	integer NOT NULL,
	`FlightResource`	integer NOT NULL,
	CONSTRAINT `Helicopters_HelicopterBrands` FOREIGN KEY(`HelicopterBrands_ID`) REFERENCES `HelicopterBrands`(`ID`),
	CONSTRAINT `Helicopters_pk` PRIMARY KEY(`ID`)
);
INSERT INTO `Helicopters` VALUES (1,2,20000211,3500,20200210,1000);
INSERT INTO `Helicopters` VALUES (2,3,20011105,2700,20190901,700);
INSERT INTO `Helicopters` VALUES (3,4,20100515,4000,20200102,1200);
INSERT INTO `Helicopters` VALUES (4,1,20050701,3100,20180107,300);
CREATE TABLE IF NOT EXISTS `HelicopterBrands` (
	`ID`	integer NOT NULL,
	`Title`	text NOT NULL,
	CONSTRAINT `HelicopterBrands_pk` PRIMARY KEY(`ID`)
);
INSERT INTO `HelicopterBrands` VALUES (1,'Airbus');
INSERT INTO `HelicopterBrands` VALUES (2,'AgustaWestland');
INSERT INTO `HelicopterBrands` VALUES (3,'Bell Helicopter');
INSERT INTO `HelicopterBrands` VALUES (4,'Sikorsky Helicopters');
CREATE TABLE IF NOT EXISTS `Flights` (
	`ID`	integer NOT NULL,
	`Helicopters_ID`	integer NOT NULL,
	`FlightTypes_ID`	integer NOT NULL,
	`Date`	integer NOT NULL,
	`CargoWeight`	integer NOT NULL,
	`PeopleCount`	integer NOT NULL,
	`Duration`	integer NOT NULL,
	`Cost`	integer NOT NULL,
	CONSTRAINT `Flights_Helicopters` FOREIGN KEY(`Helicopters_ID`) REFERENCES `Helicopters`(`ID`),
	CONSTRAINT `Flights_FlightTypes` FOREIGN KEY(`FlightTypes_ID`) REFERENCES `FlightTypes`(`ID`),
	CONSTRAINT `Flights_pk` PRIMARY KEY(`ID`)
);
INSERT INTO `Flights` VALUES (1,1,1,20170301,2000,2,5,2000);
INSERT INTO `Flights` VALUES (2,2,2,20170702,1500,1,12,3000);
INSERT INTO `Flights` VALUES (3,3,1,20170928,1000,2,4,2500);
INSERT INTO `Flights` VALUES (4,4,1,20190515,2700,0,8,1500);
INSERT INTO `Flights` VALUES (5,1,2,20190516,2000,2,6,2700);
INSERT INTO `Flights` VALUES (6,2,1,20150723,1500,5,2,4000);
INSERT INTO `Flights` VALUES (7,3,1,20160205,400,1,2,5000);
INSERT INTO `Flights` VALUES (8,4,2,20160314,700,6,4,2000);
INSERT INTO `Flights` VALUES (9,1,1,20170714,2500,1,7,6000);
INSERT INTO `Flights` VALUES (10,2,1,20180307,1300,8,3,1200);
CREATE TABLE IF NOT EXISTS `FlightTypes` (
	`ID`	integer NOT NULL,
	`Title`	text NOT NULL,
	`PaymentPercentage`	integer NOT NULL,
	CONSTRAINT `FlightTypes_pk` PRIMARY KEY(`ID`)
);
INSERT INTO `FlightTypes` VALUES (1,'Normal',5);
INSERT INTO `FlightTypes` VALUES (2,'Special',10);
CREATE TABLE IF NOT EXISTS `CrewPositions` (
	`ID`	integer NOT NULL,
	`Title`	text NOT NULL,
	CONSTRAINT `CrewPositions_pk` PRIMARY KEY(`ID`)
);
INSERT INTO `CrewPositions` VALUES (1,'SquadLeader');
INSERT INTO `CrewPositions` VALUES (2,'CrewMember');
CREATE TABLE IF NOT EXISTS `CrewMembers` (
	`ID`	integer NOT NULL,
	`CrewPositions_ID`	integer NOT NULL,
	`Helicopters_ID`	integer,
	`SecondName`	text NOT NULL,
	`WorkExperience`	integer NOT NULL,
	`Address`	text NOT NULL,
	`BirthYear`	integer NOT NULL,
	`Login`	text NOT NULL UNIQUE,
	`Password`	text NOT NULL,
	CONSTRAINT `CrewMembers_Helicopters` FOREIGN KEY(`Helicopters_ID`) REFERENCES `Helicopters`(`ID`),
	CONSTRAINT `CrewMembers_CrewPositions` FOREIGN KEY(`CrewPositions_ID`) REFERENCES `CrewPositions`(`ID`),
	CONSTRAINT `CrewMembers_pk` PRIMARY KEY(`ID`)
);
INSERT INTO `CrewMembers` VALUES (1,1,NULL,'Clark',2000,'2722  Romano Street',19890615,'log1','pas1');
INSERT INTO `CrewMembers` VALUES (2,1,NULL,'Ross',1500,'4837  Goodwin Avenue',19910519,'log2','pas2');
INSERT INTO `CrewMembers` VALUES (3,1,NULL,'Moore',3000,'1931  Ford Street',19940822,'log3','pas3');
INSERT INTO `CrewMembers` VALUES (4,2,1,'Jackson',200,'3209  Nickel Road',19931003,'log4','pas4');
INSERT INTO `CrewMembers` VALUES (5,2,1,'Martinez',300,'3330  Mercer Street',19950712,'log5','pas5');
INSERT INTO `CrewMembers` VALUES (6,2,1,'Reed',600,'1420  Peaceful Lane',19900730,'log6','pas6');
INSERT INTO `CrewMembers` VALUES (7,2,2,'Alexander',400,'1173  School Street',19950221,'log7','pas7');
INSERT INTO `CrewMembers` VALUES (8,2,2,'Cooper',700,'3787  Benson Park Drive',19950811,'log8','pas8');
INSERT INTO `CrewMembers` VALUES (9,2,2,'Gray',900,'3546  Gnatty Creek Road',19960719,'log9','pas9');
INSERT INTO `CrewMembers` VALUES (10,2,3,'Barnes',550,'1817  West Side Avenue',19961002,'log10','pas10');
INSERT INTO `CrewMembers` VALUES (11,2,3,'Baker',700,'2378  Traction Street',19891001,'log11','pas11');
INSERT INTO `CrewMembers` VALUES (12,2,3,'Garcia',350,'3660  Layman Avenue',19920322,'log12','pas12');
INSERT INTO `CrewMembers` VALUES (13,2,4,'Parker',270,'2428  Ridge Road',19930412,'log13','pas13');
INSERT INTO `CrewMembers` VALUES (14,2,4,'James',500,'4840  Bedford Street',19931209,'log14','pas14');
INSERT INTO `CrewMembers` VALUES (15,2,4,'Harris',900,'4944  Maxwell Farm Road',19950604,'log15','pas15');
COMMIT;
