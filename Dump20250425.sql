-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: chiclighting
-- ------------------------------------------------------
-- Server version	8.0.34

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20240628035725_DbInit','6.0.31'),('20240628084650_InsertCategory','6.0.31'),('20240628085449_InsertFeedback','6.0.31'),('20240628090540_InsertOrderStatus','6.0.31'),('20240628091648_InsertPayment','6.0.31'),('20240628092115_InsertProductStatus','6.0.31'),('20240628092532_InsertProductStatuses','6.0.31'),('20240628125930_InsertProduct','6.0.31'),('20240628131944_InsertProduct2','6.0.31'),('20240629032304_UpdateModel','6.0.31'),('20240629065823_InsertRole','6.0.31'),('20240630095843_UpdateUser','6.0.31'),('20240711125536_EditCartItem','6.0.31'),('20240718085424_AddImage','6.0.31'),('20240718085646_UpdateImage','6.0.31'),('20240718085932_InsertImage','6.0.31'),('20240719143523_InsertImage2','6.0.31'),('20240719145900_InserImage3','6.0.31'),('20240721024722_UpdateImage1','6.0.31'),('20240721083509_EditUserAndRate','6.0.31'),('20240722090329_UpdateRate','6.0.31'),('20240729140621_EditCreateAt','6.0.31'),('20240907033041_InsertPayment1','6.0.31'),('20241130022504_RemoveTitle','6.0.31');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroleclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
INSERT INTO `aspnetroles` VALUES ('8a04f98c-96e4-4897-9699-f51efc35f708','User','USER','019a72d7-7ab4-41af-83f7-9a388c5a05ed'),('c576485b-1a1d-4c7a-ab1c-a7e75539d90f','Admin','ADMIN','846cdab3-c482-4ca3-932a-0b4565b7ee38');
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ClaimValue` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderKey` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
INSERT INTO `aspnetuserlogins` VALUES ('Google','104548995247689387489','Google','769b9ab1-93c7-4181-ad69-1824d68a0ecc');
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
INSERT INTO `aspnetuserroles` VALUES ('1f99a247-9b5c-495f-97d8-63010ff10a14','8a04f98c-96e4-4897-9699-f51efc35f708'),('32ff1339-733b-4741-b2d5-ab43c7fbc8e0','8a04f98c-96e4-4897-9699-f51efc35f708'),('769b9ab1-93c7-4181-ad69-1824d68a0ecc','8a04f98c-96e4-4897-9699-f51efc35f708'),('c6b0c0d2-5bd0-40f2-8342-159e24719a89','c576485b-1a1d-4c7a-ab1c-a7e75539d90f');
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusers` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `FirstName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Address` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `SecurityStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumber` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('1f99a247-9b5c-495f-97d8-63010ff10a14','Nguyễn','Sơn','Bac Ninh','hoangson12345','HOANGSON12345','sonhoang10112003@gmail.com','SONHOANG10112003@GMAIL.COM',1,'AQAAAAEAACcQAAAAECnpx13A9qivhIJ9MPQ3TE4nfKgt+WtnHZmwH06eDrFsQTaPzE6pgD/Rc0JCTAzVCA==','POT6QNM3Y6FUV3BG6LIBAUPJA5UAT654','d9630fe1-7156-47e0-9fa0-60c2e5c459c1',NULL,0,0,NULL,1,0),('32ff1339-733b-4741-b2d5-ab43c7fbc8e0','Nguyễn','Sơn','Bac Ninh','hoangson123','HOANGSON123','sonnguyen10112003@gmail.com','SONNGUYEN10112003@GMAIL.COM',1,'AQAAAAEAACcQAAAAEORJachbO5Sm3lB0J989UjbHxHgAppN38YT/CN5A9lVnI0ZUdioTiG18A/5TL+OY1A==','MF6WG67NDZV6UZAUPOLZ2MRKS7HTYXDK','f8220442-42bc-4e21-b827-9e567a80c754',NULL,0,0,NULL,1,0),('769b9ab1-93c7-4181-ad69-1824d68a0ecc','Sơn','Nguyễn Đức Hoàng','Not Provided','sonnguyen10112003@gmail.com','SONNGUYEN10112003@GMAIL.COM','sonnguyen10112003@gmail.com','SONNGUYEN10112003@GMAIL.COM',0,NULL,'ST6JWIE63ZUX6UQU6QTR2DJSQ6I5LQRG','ec1da260-47e8-4d2b-a46f-68ca531c4d2e',NULL,0,0,NULL,1,0),('c6b0c0d2-5bd0-40f2-8342-159e24719a89','Admin','Chic & Lighting','Viet Nam','admin','ADMIN','chicandlighting@gmail.com','CHICANDLIGHTING@GMAIL.COM',1,'AQAAAAEAACcQAAAAEK/mXI8BQmwjbRaWkyPYBMuuhZh3mV2kWgVH6D8AAhv/vX33IFalP/MSv5mVFTBQ2Q==','FFKCJYWZGZCF72WQHS6LWGMKVZ73PLUW','9256492d-207f-4eaa-8391-81805ea5f538',NULL,0,0,NULL,1,0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cartitems`
--

DROP TABLE IF EXISTS `cartitems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cartitems` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CartId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Quantity` int NOT NULL DEFAULT '0',
  `CreateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreateAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `UpdateAt` datetime(6) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT '0',
  `Price` double NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `IX_CartItems_CartId` (`CartId`),
  KEY `IX_CartItems_ProductId` (`ProductId`),
  CONSTRAINT `FK_CartItems_Carts_CartId` FOREIGN KEY (`CartId`) REFERENCES `carts` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_CartItems_Products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `products` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cartitems`
--

LOCK TABLES `cartitems` WRITE;
/*!40000 ALTER TABLE `cartitems` DISABLE KEYS */;
INSERT INTO `cartitems` VALUES ('0ceaa7f4-b88f-479a-9fda-c215ec797d0a','72fa72f6-b749-42c5-b7e5-a2ba76b350ef','ddee4fc4-432b-4856-82e6-276e1908528f',1,NULL,NULL,'2024-09-14 17:26:33.020017',NULL,1,299),('12b43790-b48f-49d2-b7a2-c2e2a9c8da6d','74e506a1-1f49-421e-ad15-f71baeec814f','ddee4fc4-432b-4856-82e6-276e1908528f',1,NULL,NULL,'2024-07-27 21:05:27.965929',NULL,0,199),('179bf97b-09bb-42b2-9a9a-5441bd9d39a4','7922de92-55f6-457c-83fa-9b7cc2774537','ddee4fc4-432b-4856-82e6-276e1908528f',1,NULL,NULL,'2024-07-25 14:24:15.335126',NULL,0,249),('18ea4868-8f60-4200-94e2-24334b89e95b','04fc938d-73d3-42cb-a002-3a7049f723bd','fe0265ad-44b1-4616-a810-e3735be732f5',2,NULL,NULL,'2024-07-16 22:21:02.384420',NULL,0,298),('26119fa4-2d97-402d-be15-d6659f4ee541','7922de92-55f6-457c-83fa-9b7cc2774537','ddee4fc4-432b-4856-82e6-276e1908528f',1,NULL,NULL,'2024-09-04 20:42:42.432600',NULL,0,249),('2a388e53-8ee2-439d-bdb3-3b24e1cea263','7922de92-55f6-457c-83fa-9b7cc2774537','fe0265ad-44b1-4616-a810-e3735be732f5',3,NULL,NULL,'2024-07-16 22:20:41.567023',NULL,0,747),('472417cc-8196-4686-8f1c-761ee26c977d','72fa72f6-b749-42c5-b7e5-a2ba76b350ef','ddee4fc4-432b-4856-82e6-276e1908528f',1,NULL,NULL,'2024-09-06 21:49:55.843172',NULL,0,299),('4fb3aee9-21f8-4109-a5a7-b081f5718e45','6f6b4552-05b1-4167-a1ef-9c7e70e6c785','fe0265ad-44b1-4616-a810-e3735be732f5',3,NULL,NULL,'2024-07-12 20:16:17.655516',NULL,0,1107),('5efad96c-1ed1-4215-a8a8-2db7af6735ed','bbb37448-6f10-4cf5-ab3d-68a569e64f2b','ddee4fc4-432b-4856-82e6-276e1908528f',1,NULL,NULL,'2024-12-06 10:38:32.409399',NULL,1,191),('67a5e2a6-524e-4de0-9e85-89bfc4060492','14e3cb59-5c26-40f7-8821-5e2278ecb72c','ddee4fc4-432b-4856-82e6-276e1908528f',1,NULL,NULL,'2024-09-08 09:18:45.989396',NULL,0,399),('7c9cd230-fd9c-477f-bfd3-6ea3d2eed91b','30b14517-c0d3-4742-83d5-39fec4daeafd','ddee4fc4-432b-4856-82e6-276e1908528f',1,NULL,NULL,'2024-09-08 09:46:15.610545',NULL,0,200),('8277c452-0479-46e3-8ed8-de20c61cc8f1','72fa72f6-b749-42c5-b7e5-a2ba76b350ef','ddee4fc4-432b-4856-82e6-276e1908528f',2,NULL,NULL,'2024-09-04 20:42:56.082342',NULL,0,598),('95271d75-57b3-4824-ae4d-3175ade8d6f0','5e433b33-230a-40e3-a59e-63d63c73bb8d','ddee4fc4-432b-4856-82e6-276e1908528f',1,NULL,NULL,'2024-09-05 20:22:13.443170',NULL,0,369),('a5532ee5-45c1-4d05-b481-7381cebb7710','14e3cb59-5c26-40f7-8821-5e2278ecb72c','fe0265ad-44b1-4616-a810-e3735be732f5',1,NULL,NULL,'2024-07-12 20:16:49.728938',NULL,0,399),('f6138fab-0883-4142-8b21-c79177ff6eb2','74e506a1-1f49-421e-ad15-f71baeec814f','4ae17992-24c7-4fcb-a71f-7251669f0335',1,NULL,NULL,'2024-09-21 18:53:09.814216',NULL,1,199),('f7203ef4-97fc-49b8-8808-e354839f9c4b','74e506a1-1f49-421e-ad15-f71baeec814f','ddee4fc4-432b-4856-82e6-276e1908528f',1,NULL,NULL,'2024-09-07 10:56:01.667201',NULL,0,199);
/*!40000 ALTER TABLE `cartitems` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `carts`
--

DROP TABLE IF EXISTS `carts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `carts` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreateAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `UpdateAt` datetime(6) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `IX_Carts_UserId` (`UserId`),
  CONSTRAINT `FK_Carts_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `carts`
--

LOCK TABLES `carts` WRITE;
/*!40000 ALTER TABLE `carts` DISABLE KEYS */;
INSERT INTO `carts` VALUES ('2e068f41-85d6-4c89-93bd-b66ada84f8a5','c6b0c0d2-5bd0-40f2-8342-159e24719a89',NULL,NULL,'2024-12-01 20:21:37.454444',NULL,1),('4ae17992-24c7-4fcb-a71f-7251669f0335','769b9ab1-93c7-4181-ad69-1824d68a0ecc',NULL,NULL,'2024-09-21 18:43:36.013380',NULL,1),('ddee4fc4-432b-4856-82e6-276e1908528f','32ff1339-733b-4741-b2d5-ab43c7fbc8e0',NULL,NULL,'2024-07-11 20:54:39.448684',NULL,1),('fe0265ad-44b1-4616-a810-e3735be732f5','1f99a247-9b5c-495f-97d8-63010ff10a14',NULL,NULL,'2024-07-11 20:05:51.884699',NULL,1);
/*!40000 ALTER TABLE `carts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreateAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `UpdateAt` datetime(6) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES ('34e52e29-54d9-4f16-9648-98cb40e8984b','Fan','Stay cool and stylish with our range of ceiling fans. From modern designs to classic styles, our collection offers the perfect blend of comfort and elegance. Enhance any room\'s ambiance while keeping the air flowing smoothly. Discover the ideal fan for your space today.','Admin',NULL,'2024-06-28 15:53:12.000000',NULL,1),('71fac351-b7d7-4647-8345-05adc57a60a4','Accents','Elevate your space with our curated selection of home accents. From decorative vases to stylish throw pillows, our collection offers the perfect finishing touches to any room. Add personality and charm to your home decor effortlessly. Explore our range of accents and transform your space today.','Admin',NULL,'2024-06-28 15:53:12.000000',NULL,1),('e063fa2c-4037-45c1-a91d-357b7b0ee36e','Ceiling','Discover chic ceiling lights to elevate your space. Explore modern designs and timeless classics for a touch of elegance in any room.','Admin',NULL,'2024-06-28 15:53:12.000000',NULL,1),('e1ebd017-8c14-4bc6-bac5-65267de96d03','Wall','Add warmth and style to your walls with our stunning wall lights. From sleek sconces to elegant fixtures, our collection offers the perfect blend of form and function. Illuminate your space with ease and sophistication. Explore our selection now and brighten up your home with effortless elegance.','Admin',NULL,'2024-06-28 15:53:12.000000',NULL,1),('e5fb9115-8259-4d8d-a4b1-6d8ab1d981dd','Outdoor','Light up your outdoor spaces with style. Explore our collection of durable and elegant outdoor lights today!','Admin',NULL,'2024-06-28 15:53:12.000000',NULL,1),('f0c60493-103b-4454-80fb-5699c2f0cf08','Lamp','Illuminate your space with our exquisite lamps. From elegant table lamps to sleek floor lamps, our collection offers timeless designs and superior craftsmanship. Enhance any room with warm, inviting light and stylish accents. Explore our selection now and bring effortless elegance to your home.','Admin',NULL,'2024-06-28 15:53:12.000000',NULL,1);
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `feedbacks`
--

DROP TABLE IF EXISTS `feedbacks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `feedbacks` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Comment` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Rate` smallint NOT NULL,
  `Email` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreateAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `UpdateAt` datetime(6) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `feedbacks`
--

LOCK TABLES `feedbacks` WRITE;
/*!40000 ALTER TABLE `feedbacks` DISABLE KEYS */;
INSERT INTO `feedbacks` VALUES ('4c19585b-fa2d-47eb-bddb-bfe738a19360','I bought the \'Modern LED Pendant Light\' for my kitchen remodel, and it exceeded my expectations. Not only does it provide excellent lighting, but its sleek design also complements the contemporary style of my kitchen perfectly. Very satisfied!',3,'michael@gmail.com','Michael','Admin',NULL,'2024-06-28 16:00:40.000000',NULL,1),('4c249d87-4f13-4304-b7e7-d75aa773570b','I recently purchased the \'Elegant Crystal Chandelier\' from Chic and Lighting, and I\'m absolutely thrilled with it! The quality is top-notch, and it adds a touch of glamour to my dining room. Highly recommend!',3,'sarah@gmail.com','Sarah','Admin',NULL,'2024-06-28 16:00:40.000000',NULL,1),('cf700fc8-409f-4dd4-8415-85dee8278844','I\'ve been searching for the perfect bedside lamps for ages, and I finally found them at Chic and Lighting! The \'Vintage Glass Table Lamps\' I purchased are stunning and add a cozy ambiance to my bedroom. Great selection and fast shipping!',3,'emily@gmail.com','Emily','Admin',NULL,'2024-06-28 16:00:40.000000',NULL,1);
/*!40000 ALTER TABLE `feedbacks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `images`
--

DROP TABLE IF EXISTS `images`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `images` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Path` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreateAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `UpdateAt` datetime(6) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL,
  `IsAvatar` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `IX_Images_ProductId` (`ProductId`),
  CONSTRAINT `FK_Images_Products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `products` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `images`
--

LOCK TABLES `images` WRITE;
/*!40000 ALTER TABLE `images` DISABLE KEYS */;
INSERT INTO `images` VALUES ('028b1410-1efb-4bf9-844d-f4956258cab3','/img/lightType/f5.jpg','30b14517-c0d3-4742-83d5-39fec4daeafd','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('02c7e930-e784-4f86-b5fc-b5a580c97c1f','/img/lightType/CinqWhtMultiTprHolderLrgAV2SHF22.jpg','1e896f08-4f7c-41bb-b99e-172512fe1969','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('03b50991-06c5-46c8-94f4-0b4adddc051c','/img/lightType/od2.jpg','02642c36-c769-417b-9322-cae0c3d7dcaa','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('0a4d2815-cc08-4d82-8317-aac058707c5a','/img/lightType/RIOBF2.jpg','74e506a1-1f49-421e-ad15-f71baeec814f','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('0aacc1c5-ef5e-43ee-b142-596012908a57','/img/lightType/20241130_092939_tankup.png','dfadfb7e-99be-41ec-8d40-666cfeb6d0c3',NULL,NULL,'2024-11-30 09:29:39.188384',NULL,1,0),('0bcb57bc-95e2-4d1d-8db1-e9031b683612','/img/lightType/LedaPldNklArtcltngSconceROF22.jpg','288da92c-3a1a-4903-b097-015d8e4a48aa','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('0be8728e-af6a-45a2-8cab-a5d41f47894e','/img/lightType/BrioBlackenedBrsPndntROF22.jpg','27383f42-3cd9-4d91-ac3a-2a179de53873','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('0cc839ad-4e0b-4b9e-9c5a-2aee16eea590','/img/lightType/BrioPlhdBrsArtcltngScncAVSHF22-2_540x.jpg','ab01fffc-e002-43ad-9815-395b37c48acc','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('0d9659a3-bda6-46b5-922e-6400b3075423','/img/lightType/RIOBF.jpg','74e506a1-1f49-421e-ad15-f71baeec814f','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('0f0ae11e-b1c7-4b1b-a54c-d491b9ea9e15','/img/lightType/ECP.jpg','5e433b33-230a-40e3-a59e-63d63c73bb8d','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('101fb93f-afde-4429-ac10-5e2500bd3901','/img/lightType/w14.jpg','288da92c-3a1a-4903-b097-015d8e4a48aa','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('1024cde0-9b40-4681-b33c-aa57470b98cb','/img/lightType/BrioBlackenedBrsPndntSSF22.jpg','27383f42-3cd9-4d91-ac3a-2a179de53873','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('15b8ce7d-5854-4500-866d-981ca18370e3','/img/lightType/CCDW.jpg','753af533-e33a-4560-8463-ec6c9b748b72','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('15ef2f23-a50c-4af9-87d3-9af81d0c6566','/img/lightType/ha11.jpg','6bd47120-4b30-47c5-9c67-4a5b1f99fe44','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('164f93e1-dec2-4273-aaaf-f48f26c2ae2b','/img/lightType/f2.jpg','76afac8c-c2e8-4c8b-9651-b79a8cdd0c86','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('16e111fe-5db7-4574-a8e1-c3017788e62e','/img/lightType/f1.jpg','17e342f3-0fd5-4205-803c-00d4b63e20d6','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('189221c4-cd8d-4675-b42c-20e2df661b49','/img/lightType/GrazianoTrvtnScncInNOtdrAV4SHF22.jpg','02642c36-c769-417b-9322-cae0c3d7dcaa','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('1ec4989d-4c72-4248-8a89-56c39a91b5d1','/img/lightType/EPBATL1.jpg','6f6b4552-05b1-4167-a1ef-9c7e70e6c785','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('1eefec2f-57bf-4932-b87c-ce42a648ecfa','/img/lightType/CopaTrdRttnFlshMountsGrpFHF22.jpg','ab58309e-5353-4080-bd19-ce97898d6c6f','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('210d986b-446f-465e-97a8-2c604affa5f4','/img/lightType/HBV.jpg','58fabfc6-a788-46a7-86da-2a3fbc05eb62','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('224b19ae-12dd-4fef-b827-ba862008080b','/img/lightType/DLC1.jpg','39960a88-0770-4ec3-bb2c-675dc9b1dd36','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('267aea4b-1d6a-4d50-b67e-c61f5d99e571','/img/lightType/w13.jpg','59cd9506-46d6-4537-b103-c60897458212','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('2797b5eb-a762-4a5a-8463-12678621e055','/img/lightType/LWPL1.jpg','21885b0f-91c1-4cd5-ac2f-e1fd14200bec','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('2a0da77e-b05f-4cb4-9c8e-9fea09b6d266','/img/lightType/od4.jpg','04fc938d-73d3-42cb-a002-3a7049f723bd','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('2a7d223a-1a08-4abf-8f62-167ea4916210','/img/lightType/RIOBF1.jpg','74e506a1-1f49-421e-ad15-f71baeec814f','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('2edc2b32-df6e-4867-b44d-26f79aa12f8a','/img/lightType/cl7.jpg','2d121d76-58bc-4393-afa8-e0d6d69c55ba','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('330cbd90-3539-4fd6-bdb6-c936e21b141b','/img/lightType/l4.jpg','d9b348f0-3a32-499f-aadf-6e81f88840b8','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('333839f4-0570-4894-947d-dd5f685d8328','/img/lightType/BBTL2.jpg','7922de92-55f6-457c-83fa-9b7cc2774537','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('33ea2ee8-bbea-45ff-95bf-5f10d507e6dc','/img/lightType/NMW.jpg','6bd47120-4b30-47c5-9c67-4a5b1f99fe44','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('386debfe-3548-45c8-bc46-7af94778b65e','/img/lightType/LedaPldBrsArtcltngSconceAV2SHF22.jpg','59cd9506-46d6-4537-b103-c60897458212','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('387d141b-0dbd-4d8a-b293-de3fcc03bc52','/img/lightType/GrazianoGryTrvrtnWllScncAV2SHF23.jpg','62374205-246c-4262-9063-9679393db1ed','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('3ae6cfab-39ac-4575-807a-84fef53bd3a7','/img/lightType/LedaPldBrsArtcltngSconceAVSHF22.jpg','59cd9506-46d6-4537-b103-c60897458212','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('3c11900a-51e1-48e6-9509-e3d8193a706d','/img/lightType/LWPL2.jpg','21885b0f-91c1-4cd5-ac2f-e1fd14200bec','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('3e0dac6f-5d22-4a94-9820-dac91b11ed3c','/img/lightType/EPBATL2.jpg','6f6b4552-05b1-4167-a1ef-9c7e70e6c785','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('3e296723-0b52-4e8f-aa02-0fa68a919724','/img/lightType/CB2FA22_43A_V1.jpg','6dfad5b1-bddb-448b-9f73-1afcbf381d2c','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('3f77ec5a-5b16-4eeb-9e38-b424e09e55f1','/img/lightType/HBBC1.jpg','76afac8c-c2e8-4c8b-9651-b79a8cdd0c86','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('3ff46bd4-8daa-4ab3-b370-d992f6f4e7a4','/img/lightType/w6.jpg','68f58a8d-ed1d-4067-8d96-2986b1fc497a','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('41fa3092-30d3-4888-994d-fba6cbf04fb3','/img/lightType/HammeredBrsShllwPendantROF22.jpg','86a3b3ff-0d98-41ef-a4ac-d5a453679866','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('4248fab1-59f7-4b3b-beaa-44a31a40e891','/img/lightType/DLC2.jpg','39960a88-0770-4ec3-bb2c-675dc9b1dd36','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('429f0329-013d-4ff2-8c03-7f336ee812d0','/img/lightType/cl10.jpg','21885b0f-91c1-4cd5-ac2f-e1fd14200bec','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('436fa33f-43b7-487d-a1d6-615692d308a5','/img/lightType/WHCF1.jpg','17e342f3-0fd5-4205-803c-00d4b63e20d6','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('470ccf39-2f37-4b7a-938a-b1e60c94d044','/img/lightType/HBBC2.jpg','76afac8c-c2e8-4c8b-9651-b79a8cdd0c86','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('49cf142e-6f32-480e-991e-af7b56ba3f12','/img/lightType/SPBTL2.jpg','8e39f85e-2d67-43c5-a12b-e55e2e2e869e','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('4f9104a3-7199-4f40-8875-e8875bf8b7fc','/img/lightType/WHCF3.jpg','17e342f3-0fd5-4205-803c-00d4b63e20d6','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('5325ea19-b8a6-477e-8fd7-1c20515a994f','/img/lightType/CB2FA22_32A_V1_SconceGlow_1x1.jpg','02642c36-c769-417b-9322-cae0c3d7dcaa','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('586b7c73-da41-40ab-ac29-51ee6950d5f1','/img/lightType/PH5B.jpg','c14af4e6-d573-431b-a7df-cac65f5244b5','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('58ba0875-82b0-483c-8bdb-e4c4b9a6bac3','/img/lightType/l3.jpg','7922de92-55f6-457c-83fa-9b7cc2774537','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('59ea225f-d885-4a85-89e9-7138d0c5b837','/img/lightType/w8.jpg','753af533-e33a-4560-8463-ec6c9b748b72','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('5a0245c4-e7ea-4ee4-8396-1e3e47e488ba','/img/lightType/CCDW2.jpg','753af533-e33a-4560-8463-ec6c9b748b72','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('5c33ea6c-6806-48dc-ad51-382fa36ddcc9','/img/lightType/CB2HOL23_BRYNN_09_897.jpg','6dfad5b1-bddb-448b-9f73-1afcbf381d2c','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('5d6fc6b7-ad7a-4b8d-a2fd-cb873116bc29','/img/lightType/od5.jpg','b69f253d-09f5-4c44-9d95-e7357ffd9d24','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('5d904e4b-c656-4659-aac8-d4be1b5731b1','/img/lightType/KDHakkaRattanPendantROF21.jpg','2d121d76-58bc-4393-afa8-e0d6d69c55ba','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('5ff6bbf3-dc43-4d43-9a6f-53f0103c052b','/img/lightType/cl2.jpg','27383f42-3cd9-4d91-ac3a-2a179de53873','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('62ce88a8-2f36-445c-aca6-7f487208cd72','/img/lightType/w3.jpg','09c63539-a410-44ab-8c42-fd55f48e23ad','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('67fe5054-bb75-4a00-b313-50431ab520fd','/img/lightType/f9.jpg','bbb37448-6f10-4cf5-ab3d-68a569e64f2b','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('6bca0546-8b52-483b-a487-53a9acee1176','/img/lightType/FMIB1_6_11zon.jpg','cd99f939-f57e-4b0d-9913-6ab8d7f63ad1','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('6bf1be19-5a55-4533-b1e4-a404063b1034','/img/lightType/ha2.jpg','449cd2ab-7112-4cfe-bff5-7bf3ec9aa8d4','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('6c2449be-e153-4b1a-afa5-c9d8b56aacba','/img/lightType/ha1.jpg','1872538a-71d2-412a-9986-daf12f711ea2','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('6c3087ec-6c72-4839-a61d-2ede4cd44981','/img/lightType/CCDW1.jpg','753af533-e33a-4560-8463-ec6c9b748b72','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('6de3a4f0-210d-4cc3-9d27-5f78a211c32e','/img/lightType/DLC.jpg','39960a88-0770-4ec3-bb2c-675dc9b1dd36','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('6e3a11cf-e2e1-4de3-9b49-53f489b5cacd','/img/lightType/od1.jpg','72fa72f6-b749-42c5-b7e5-a2ba76b350ef','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('6e57cb66-f6a7-49f2-b426-9e02c6329bd6','/img/lightType/AldusIvNPldBrsArtlngScncROF22.jpg','2de7e612-602c-47d3-b038-2d16db00acdc','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('6fe9f6bc-af1b-46c3-9ba4-e4cce42e0046','/img/lightType/Exposior017BlkPendantAV3SHF22.jpg','72fa72f6-b749-42c5-b7e5-a2ba76b350ef','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('70e000db-214d-49bc-934d-29bd0fc2f2ea','/img/lightType/cl8.jpg','86a3b3ff-0d98-41ef-a4ac-d5a453679866','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('7109a571-a34d-462c-9625-dfbc05fb49f1','/img/lightType/BBTL1.jpg','7922de92-55f6-457c-83fa-9b7cc2774537','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('71139783-b47b-43cb-b689-ae1ee624c924','/img/lightType/Exposior017BlkPendantAVSHF22.jpg','72fa72f6-b749-42c5-b7e5-a2ba76b350ef','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('7157daf2-db4a-439d-ae40-13fb9b3ce276','/img/lightType/CB2FA24_23A_Hero.jpg','02642c36-c769-417b-9322-cae0c3d7dcaa','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('7201bf5a-2dee-411f-a06f-000eb3f3a90e','/img/lightType/BTTC.jpg','449cd2ab-7112-4cfe-bff5-7bf3ec9aa8d4','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('74a70051-391a-4864-84b1-b9630085caba','/img/lightType/CB2FA21_KD_6C_1521_OC21_1x1.jpg','2d121d76-58bc-4393-afa8-e0d6d69c55ba','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('74ddeedd-8417-4871-b8be-fe6605dd94c0','/img/lightType/20241130_094128_Screenshot 2024-07-10 150120.png','f7471c9a-8cad-4876-981e-1075cbb19c85',NULL,NULL,'2024-11-30 09:41:28.135486',NULL,1,1),('75ad7282-c2b2-43d4-b727-df3f3960214e','/img/lightType/HammeredBrsShllwPendantSSF22.jpg','86a3b3ff-0d98-41ef-a4ac-d5a453679866','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('7640efb9-6a70-4aab-94d1-976b3bb887ff','/img/lightType/BBBA1.jpg','68f58a8d-ed1d-4067-8d96-2986b1fc497a','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('78c92287-a781-417c-a31d-36e26315c359','/img/lightType/f4.jpg','1b5fbe83-a758-488b-99b8-8144489106d1','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('7a995782-1b67-41c3-b00e-12be6938cd03','/img/lightType/BrioPolishedBrsPndntSSF22_10_11zon.jpg','d31784c2-21f9-4737-af38-8c7d51741410','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('7c4cf855-d92e-409d-ac80-1884e3482a7f','/img/lightType/SBBTL3.jpg','14e3cb59-5c26-40f7-8821-5e2278ecb72c','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('7d7c379e-a218-418c-bfad-5b2aa9f1ee66','/img/lightType/f3.jpg','c14af4e6-d573-431b-a7df-cac65f5244b5','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('7fea8a2c-deef-4513-8cd0-2196dec5b606','/img/lightType/TwistedTprCndlS2WrmWhtSHF21_4_11zon.jpg','ac3c23d3-c271-4870-9ffc-6fd2663bf8d2','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('83c97206-08ab-4abb-bc5e-93831b63a0df','/img/lightType/CB2HOL22_05C_V1.jpg','26feb3c1-25fb-4e3a-86ab-3e0378de261f','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('844a5d95-ccfd-4504-927e-2200a8f0dce3','/img/lightType/LWPL.jpg','21885b0f-91c1-4cd5-ac2f-e1fd14200bec','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('85703932-17ff-4400-8c53-e3bb0bab6cec','/img/lightType/AldusBkNPldBrsArtlngScncROF22.jpg','09c63539-a410-44ab-8c42-fd55f48e23ad','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('87f8a770-a13f-49b8-9da6-1e0042a6c650','/img/lightType/cl9.jpg','26feb3c1-25fb-4e3a-86ab-3e0378de261f','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('8a5f893e-f16c-432b-9270-043438318f69','/img/lightType/CinqWhtMultiTprHolderLrgSHF22.jpg','1e896f08-4f7c-41bb-b99e-172512fe1969','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('8a60af2e-b7f5-4c43-8251-f77482662416','/img/lightType/l5.jpg','f931aa1c-3bb2-442a-9c55-61fb5f7e5044','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('8c300be3-03f2-4bcb-a518-179fe70780d1','/img/lightType/HBAW.jpg','bbb37448-6f10-4cf5-ab3d-68a569e64f2b','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('8ce46800-288a-48eb-964e-b9c8bf2b0f5d','/img/lightType/cl3.jpg','d31784c2-21f9-4737-af38-8c7d51741410','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('8df7ec43-83a4-45bc-9d7a-9785734fc2f8','/img/lightType/20241130_092939_star.png','dfadfb7e-99be-41ec-8d40-666cfeb6d0c3',NULL,NULL,'2024-11-30 09:29:39.171783',NULL,1,0),('8e2b0e4b-167b-4287-95ba-60e8d58b9966','/img/lightType/20241201_204227_tải xuống (1).jpg','7466d67c-fd85-4ec5-a1b2-7763e7a34926',NULL,NULL,'2024-12-01 20:42:27.265720',NULL,0,1),('8e63e4db-db9e-48e6-8683-6e3cc56a3602','/img/lightType/w4.jpg','2de7e612-602c-47d3-b038-2d16db00acdc','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('8e9f2362-f092-42df-b33e-80776f27924e','/img/lightType/RondaIndoorOutdoorScncsGrpFHF22.jpg','04fc938d-73d3-42cb-a002-3a7049f723bd','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('8fb4d307-b172-4ff6-9884-671a5d34cf05','/img/lightType/GrazianoGryTrvrtnWllScncAVSHF23.jpg','62374205-246c-4262-9063-9679393db1ed','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('90676ed1-3bda-44ad-ab1e-a743cdec0a69','/img/lightType/TwistedTprCndlS2WrmWhtROF21_3_11zon.jpg','ac3c23d3-c271-4870-9ffc-6fd2663bf8d2','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('944dd4a0-ba3b-467d-aa08-6bd45bff2599','/img/lightType/ha8.jpg','58fabfc6-a788-46a7-86da-2a3fbc05eb62','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('94c4a312-1fbe-4ad7-bfc2-ccf5740cb158','/img/lightType/MCF2.jpg','1b5fbe83-a758-488b-99b8-8144489106d1','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('9502c42b-46c5-41ea-8c1b-c565a607df0e','/img/lightType/CopaTrdNatRttnFlshMountAVSHF22.jpg','ab58309e-5353-4080-bd19-ce97898d6c6f','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('95e98e1c-71c6-487f-aa3c-9743b1477eed','/img/lightType/Exposior017BlkPendantSSF22.jpg','72fa72f6-b749-42c5-b7e5-a2ba76b350ef','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('9744d2e0-115d-4d09-b7ba-b5cd9fe7c804','/img/lightType/BrixBlkGldnMrblIncnsBrnrAVSHF22.jpg','b672dcd9-f5c1-4730-bd76-3e6a22b155ae','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('98297ee1-23f6-42bb-9b9f-4eaa8a56bc73','/img/lightType/l2.jpg','8e39f85e-2d67-43c5-a12b-e55e2e2e869e','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('997ea8cd-c190-4394-9006-2fd116fbf476','/img/lightType/HBW2.jpg','30b14517-c0d3-4742-83d5-39fec4daeafd','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('99a7dcef-3bb3-483c-9ee2-26dc8324df7a','/img/lightType/HammeredBrsShllwPendantAVSHF22.jpg','86a3b3ff-0d98-41ef-a4ac-d5a453679866','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('9be1c29d-ebcf-4f31-b4f1-bd877c58ee6a','/img/lightType/FMIB2_7_11zon.jpg','cd99f939-f57e-4b0d-9913-6ab8d7f63ad1','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('9d46b05c-5d33-46e9-9c3e-5214b5274ecf','/img/lightType/WHCF2.jpg','17e342f3-0fd5-4205-803c-00d4b63e20d6','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('9d46eac0-a83a-441a-8999-0e5e65186159','/img/lightType/ha6.jpg','39960a88-0770-4ec3-bb2c-675dc9b1dd36','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('9e1adb41-aa4b-40df-902b-df8f7cc355db','/img/lightType/BrioPolishedBrsPndntROF22_9_11zon.jpg','d31784c2-21f9-4737-af38-8c7d51741410','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('9e87792e-d968-4ab3-bd7c-88172db16fc8','/img/lightType/l7.jpg','f4b4c15e-2a22-4e43-8331-c3bdbbe286c6','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('9ee43789-4737-4264-8257-5858d54ff6dc','/img/lightType/LedaPldNklArtcltngSconceAV2SHF22.jpg','288da92c-3a1a-4903-b097-015d8e4a48aa','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('a1e5219a-bc8e-4e8d-9e35-cfc48f775dc1','/img/lightType/BBTL.jpg','7922de92-55f6-457c-83fa-9b7cc2774537','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('a3707c47-d8f7-4d37-8be1-779f9ab5147b','/img/lightType/LustroGlassHurricaneGroupAVFHF22.jpg','6dfad5b1-bddb-448b-9f73-1afcbf381d2c','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('a3d792a0-e1b2-44de-acef-900a4c9dc096','/img/lightType/20241130_094128_Screenshot 2024-07-10 150215.png','f7471c9a-8cad-4876-981e-1075cbb19c85',NULL,NULL,'2024-11-30 09:41:28.224777',NULL,1,0),('a4549064-f161-4bc4-bb22-0ed9e3451fba','/img/lightType/cl4.jpg','ab58309e-5353-4080-bd19-ce97898d6c6f','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('a6e6ac3f-6607-40c6-b1b0-380b17e9f2a4','/img/lightType/FMIB_5_11zon.jpg','cd99f939-f57e-4b0d-9913-6ab8d7f63ad1','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('a8ca4a21-f179-465c-b82d-b90367e10946','/img/lightType/ha4.jpg','1e896f08-4f7c-41bb-b99e-172512fe1969','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('abc183f9-914b-457a-8baf-820bb979b354','/img/lightType/CopaTrdNatRttnFlshMountROF22.jpg','ab58309e-5353-4080-bd19-ce97898d6c6f','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('aef018db-0775-4774-bd34-372bedd44233','/img/lightType/SPBTL1.jpg','8e39f85e-2d67-43c5-a12b-e55e2e2e869e','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('b1f472f1-1274-4bb8-950c-f146f292ebf8','/img/lightType/HBBC.jpg','76afac8c-c2e8-4c8b-9651-b79a8cdd0c86','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('b342681e-a8d2-4436-bb9f-504cdff7c1ea','/img/lightType/SPBTL.jpg','8e39f85e-2d67-43c5-a12b-e55e2e2e869e','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('b46c4458-6a7a-4617-bd3f-393462aaaa62','/img/lightType/ha7.jpg','cd99f939-f57e-4b0d-9913-6ab8d7f63ad1','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('b4871daf-0165-497e-8545-0f9ff88c7e81','/img/lightType/20241201_204227_tải xuống.jpg','7466d67c-fd85-4ec5-a1b2-7763e7a34926',NULL,NULL,'2024-12-01 20:42:27.339900',NULL,0,0),('b972f8d0-2603-44f6-856c-07960485dfd2','/img/lightType/BrioBlackenedBrsPndntAVSHF22.jpg','27383f42-3cd9-4d91-ac3a-2a179de53873','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('bbad8969-0560-47e4-afdc-88e2341d1173','/img/lightType/SBBTL2.jpg','14e3cb59-5c26-40f7-8821-5e2278ecb72c','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('bd263170-21a8-4e6f-8ae3-57bb8cda425f','/img/lightType/CB2HOL22_01A_V5_New.jpg','09c63539-a410-44ab-8c42-fd55f48e23ad','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('bd5b64d1-f9ed-45ba-8d05-1ebfd2fd7494','/img/lightType/20241202_144623_tải xuống (1).jpg','7466d67c-fd85-4ec5-a1b2-7763e7a34926',NULL,NULL,'2024-12-02 14:46:23.060690',NULL,1,1),('bd9b75da-8e73-45e4-b050-2a44dbdcaf6a','/img/lightType/HBW.jpg','30b14517-c0d3-4742-83d5-39fec4daeafd','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('bfefb8f3-99e4-4520-89b3-20d4300d70ec','/img/lightType/l8.jpg','6f6b4552-05b1-4167-a1ef-9c7e70e6c785','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('c5682dd5-2a66-44ec-9590-0aac5accfb96','/img/lightType/l1.jpg','14e3cb59-5c26-40f7-8821-5e2278ecb72c','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('c8c4c154-5604-4372-ba78-b527917c8d5c','/img/lightType/w7.jpg','ab01fffc-e002-43ad-9815-395b37c48acc','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('c9d13386-b0c2-44fc-a669-9c6495251843','/img/lightType/LaminaPlshdBrsPendantROF22.jpg','26feb3c1-25fb-4e3a-86ab-3e0378de261f','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('cbd48ba4-a904-4058-9a9c-37fbb87a08cb','/img/lightType/MCF1.jpg','1b5fbe83-a758-488b-99b8-8144489106d1','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('cbd92c65-7ade-473a-9988-dbce862e2100','/img/lightType/ha10.jpg','6dfad5b1-bddb-448b-9f73-1afcbf381d2c','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('cd723eb3-d174-49e4-a273-09ccf6b6e40c','/img/lightType/CB2FA22_04A_Hero.jpg','26feb3c1-25fb-4e3a-86ab-3e0378de261f','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('cdfdcef7-7468-4647-af5d-90603f5819c8','/img/lightType/ha3.jpg','b672dcd9-f5c1-4730-bd76-3e6a22b155ae','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('ce159149-af18-421a-93ad-dc6a42b390ea','/img/lightType/RondaMttBkInNOutdrScncAV3SHF22.jpg','04fc938d-73d3-42cb-a002-3a7049f723bd','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('ce42b3b0-abe6-41bb-b2d8-6f025da4376d','/img/lightType/HBV1.jpg','58fabfc6-a788-46a7-86da-2a3fbc05eb62','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('ce866cdc-6c24-431a-91a9-42ce1b622e00','/img/lightType/CB2FA22_22A_Hero.jpg','2de7e612-602c-47d3-b038-2d16db00acdc','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('cf0a8b39-4f3e-41ad-ba19-1f5917f1625d','/img/lightType/20241202_144623_tải xuống (2).jpg','7466d67c-fd85-4ec5-a1b2-7763e7a34926',NULL,NULL,'2024-12-02 14:46:23.113262',NULL,1,0),('cf0f0e11-4257-4a51-8c5b-1063a218a400','/img/lightType/cl19.jpg','ef263f57-39e4-4349-b9d7-46ab5b37cd3d','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('d0614ac5-f235-4f4f-9f14-0017c33c36e7','/img/lightType/BrioPlhdBrsArtcltngScncROF22-2_540x.jpg','ab01fffc-e002-43ad-9815-395b37c48acc','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('d06fc310-8ce4-4a61-8039-070ae9535031','/img/lightType/20241130_094128_Screenshot 2024-07-10 150235.png','f7471c9a-8cad-4876-981e-1075cbb19c85',NULL,NULL,'2024-11-30 09:41:28.240699',NULL,1,0),('d0b9c5d7-72f8-480f-beb6-ff2441792a27','/img/lightType/MCF.jpg','1b5fbe83-a758-488b-99b8-8144489106d1','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('d5f3a053-3292-48a6-b08a-8f0fe9e03721','/img/lightType/RondaMttBkInNOutdrScncAVSHF22.jpg','04fc938d-73d3-42cb-a002-3a7049f723bd','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('d66c38f4-c3b9-467d-9fa9-c0d663f258cb','/img/lightType/l6.jpg','5e433b33-230a-40e3-a59e-63d63c73bb8d','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('d6736f3c-adc8-43f9-b94f-fdd6cc1f04c2','/img/lightType/LedaPldBrsArtcltngSconceROF22.jpg','59cd9506-46d6-4537-b103-c60897458212','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('d7a0b192-3222-4716-bb61-65a12b6653eb','/img/lightType/TwistedTprCndlS2WrmWhtAVSHF21_2_11zon.jpg','ac3c23d3-c271-4870-9ffc-6fd2663bf8d2','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('d82dd31b-e97b-4d12-89a6-5597ac3c0f61','/img/lightType/CB2SP23_21A_Hero_1_11zon.jpg','ac3c23d3-c271-4870-9ffc-6fd2663bf8d2','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('da849a2c-6714-47af-90b9-4c8e73d3bdd8','/img/lightType/cl18.jpg','8a169ec7-5f9f-462d-994a-cf6acb4741e8','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('ddb707b2-ce26-4e14-ad37-1e3e1c23731b','/img/lightType/GrazianoGryTrvrtnWllScncROF23.jpg','62374205-246c-4262-9063-9679393db1ed','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('de23d8e4-59df-4cd1-a030-3de2470f2dc8','/img/lightType/SBBTL1.jpg','14e3cb59-5c26-40f7-8821-5e2278ecb72c','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('de688605-46bb-4f85-a3dd-452f36b688dd','/img/lightType/HBAW1.jpg','bbb37448-6f10-4cf5-ab3d-68a569e64f2b','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('e1cb49f2-c37a-4bfa-b2fb-e5d5b089e0e8','/img/lightType/GrazianoGryTrvrtnWllScncSHF23.jpg','62374205-246c-4262-9063-9679393db1ed','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('e2e28157-97ff-4fd1-bc74-178651792055','/img/lightType/AldusBkNPldBrsArtlngScncAVSHF22.jpg','09c63539-a410-44ab-8c42-fd55f48e23ad','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('e2e45ddb-6937-4b87-9a9b-bf2c0d8dba90','/img/lightType/20241202_144623_tải xuống.jpg','7466d67c-fd85-4ec5-a1b2-7763e7a34926',NULL,NULL,'2024-12-02 14:46:23.120728',NULL,1,0),('e403243f-3c3f-4efc-a197-856556162e56','/img/lightType/AldusIvNPldBrsArtlngScncROF22.jpg','2de7e612-602c-47d3-b038-2d16db00acdc','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('e56f16be-75f6-4ee9-a196-136a328e4b8b','/img/lightType/od3.jpg','74e506a1-1f49-421e-ad15-f71baeec814f','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,1),('e9500965-fa64-4499-a8d1-a3c208a8adc0','/img/lightType/EPBWTL.jpg','6f6b4552-05b1-4167-a1ef-9c7e70e6c785','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('ed96cbc5-d718-42fa-9843-ab82b2f308a5','/img/lightType/BrioPlhdBrsArtcltngScncAV2SHF22-2_540x.jpg','ab01fffc-e002-43ad-9815-395b37c48acc','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('f63ad2c2-62c3-4fcf-a102-a19bba743392','/img/lightType/LedaPldNklArtcltngSconceAVSHF22.jpg','288da92c-3a1a-4903-b097-015d8e4a48aa','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('f8a7c854-73e3-47d7-9019-b2cb4232d534','/img/lightType/BBBA.jpg','68f58a8d-ed1d-4067-8d96-2986b1fc497a','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('fa0964a0-033d-496a-8f51-bb30a4df0c5a','/img/lightType/20241201_212227_1365208.webp','7466d67c-fd85-4ec5-a1b2-7763e7a34926',NULL,NULL,'2024-12-01 21:22:27.944386',NULL,0,1),('fa6613b8-ac7d-4fcc-826e-1973a5effe4e','/img/lightType/HBW1.jpg','30b14517-c0d3-4742-83d5-39fec4daeafd','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('fa9750e0-a829-44e5-aa13-258f05747b29','/img/lightType/KDHakkaRattanPendantAVSHF21.jpg','2d121d76-58bc-4393-afa8-e0d6d69c55ba','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('faecbab0-3924-46bd-add0-bbb44e31f0df','/img/lightType/20241201_204227_tải xuống (2).jpg','7466d67c-fd85-4ec5-a1b2-7763e7a34926',NULL,NULL,'2024-12-01 20:42:27.331324',NULL,0,0),('fb322c16-bba8-4775-b798-483fcb08d250','/img/lightType/20241130_092939_shovel.png','dfadfb7e-99be-41ec-8d40-666cfeb6d0c3',NULL,NULL,'2024-11-30 09:29:39.090055',NULL,1,1),('fb7ea89f-26c1-405a-b79b-fe3c45367d0c','/img/lightType/BrixBlkGldnMrblIncnsBrnrAV2SHF22.jpg','b672dcd9-f5c1-4730-bd76-3e6a22b155ae','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('fd5605db-a615-45e8-b41b-35c8dde27f99','/img/lightType/BrioPolishedBrsPndntAVSHF22_8_11zon.jpg','d31784c2-21f9-4737-af38-8c7d51741410','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0),('fde52e61-2550-4929-8d08-ed62e509d37c','/img/lightType/convert-1440x960-BallCandlesS2AVSHF22.jpg','1872538a-71d2-412a-9986-daf12f711ea2','Admin',NULL,'2024-04-02 10:19:54.000000',NULL,1,0);
/*!40000 ALTER TABLE `images` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderdetails`
--

DROP TABLE IF EXISTS `orderdetails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderdetails` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `OrderId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Quantity` int NOT NULL DEFAULT '0',
  `Price` double NOT NULL DEFAULT '0',
  `CreateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreateAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `UpdateAt` datetime(6) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `IX_OrderDetails_OrderId` (`OrderId`),
  KEY `IX_OrderDetails_ProductId` (`ProductId`),
  CONSTRAINT `FK_OrderDetails_Orders_OrderId` FOREIGN KEY (`OrderId`) REFERENCES `orders` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_OrderDetails_Products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `products` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderdetails`
--

LOCK TABLES `orderdetails` WRITE;
/*!40000 ALTER TABLE `orderdetails` DISABLE KEYS */;
INSERT INTO `orderdetails` VALUES ('02ed6404-683f-4224-80d5-39319dcbf3a1','7922de92-55f6-457c-83fa-9b7cc2774537','b0eee6ac-3f32-4e13-bdf7-60eeb101f7d6',1,249,'hoangson123',NULL,'2024-07-25 14:28:23.591235',NULL,1),('07643e10-b5fd-4c45-85ab-2994a9ebcd4e','7922de92-55f6-457c-83fa-9b7cc2774537','5dbcb0a5-8cbd-462b-98ba-9d93ae7357df',1,249,'hoangson123',NULL,'2024-09-04 20:43:33.770376',NULL,1),('17db0212-3878-48a9-9978-0bda40a6b821','30b14517-c0d3-4742-83d5-39fec4daeafd','1b59be96-cc34-48ba-9c88-59c932725e9a',1,200,'hoangson123',NULL,'2024-09-08 09:47:18.535026',NULL,1),('1fe1fbee-2785-4cf3-bfa4-f261707b4e82','74e506a1-1f49-421e-ad15-f71baeec814f','a74fb269-dfc9-4d70-8f8e-e946296f3eb7',1,199,'hoangson123',NULL,'2024-09-08 09:14:22.029188',NULL,1),('393c81be-57fe-43c0-835d-79c9635b7748','5e433b33-230a-40e3-a59e-63d63c73bb8d','124ca3cf-96f2-4f58-b854-828d8f429fd6',1,369,'hoangson123',NULL,'2024-09-06 21:59:27.357958',NULL,1),('457c611c-cd1b-4e04-bbae-0c073d1b6be4','72fa72f6-b749-42c5-b7e5-a2ba76b350ef','5dbcb0a5-8cbd-462b-98ba-9d93ae7357df',2,598,'hoangson123',NULL,'2024-09-04 20:43:33.778835',NULL,1),('50e38c78-a831-4153-9c0d-f32e2194a8e4','14e3cb59-5c26-40f7-8821-5e2278ecb72c','4f725b32-437c-42e6-8295-9e04f370fda3',1,399,'hoangson12345',NULL,'2024-07-16 20:53:37.538981',NULL,1),('60a23ac2-8070-4c31-91df-afe040cb62c0','04fc938d-73d3-42cb-a002-3a7049f723bd','0c0e57b1-667b-4176-abe5-ec901cc21fc9',2,298,'hoangson12345',NULL,'2024-07-16 22:21:55.089904',NULL,1),('780eefa1-f103-494f-951b-9a73afed19b9','6f6b4552-05b1-4167-a1ef-9c7e70e6c785','4f725b32-437c-42e6-8295-9e04f370fda3',3,1107,'hoangson12345',NULL,'2024-07-16 20:53:37.451026',NULL,1),('887595b4-98ac-4895-a95f-6c6101f48a74','74e506a1-1f49-421e-ad15-f71baeec814f','1cc168cc-2470-4253-9677-27f1a0a3d110',1,199,'hoangson123',NULL,'2024-09-08 09:14:21.691755',NULL,1),('bb86a299-bb09-47e2-b590-e4f023312072','74e506a1-1f49-421e-ad15-f71baeec814f','53c1ecbd-6390-4cdf-a3a9-aefe5e0a3720',1,199,'hoangson123',NULL,'2024-09-04 20:40:30.204987',NULL,1),('c2daea17-bc54-469c-b838-092c89b2fca4','72fa72f6-b749-42c5-b7e5-a2ba76b350ef','124ca3cf-96f2-4f58-b854-828d8f429fd6',1,299,'hoangson123',NULL,'2024-09-06 21:59:27.300725',NULL,1),('d014f190-71af-44c1-b24d-66d143864fa2','7922de92-55f6-457c-83fa-9b7cc2774537','0c0e57b1-667b-4176-abe5-ec901cc21fc9',3,747,'hoangson12345',NULL,'2024-07-16 22:21:55.124975',NULL,1),('e924b568-07b4-428a-bd18-b244cfabca26','14e3cb59-5c26-40f7-8821-5e2278ecb72c','908c69bf-d1cc-4840-b9bd-48d8d7dbd2e9',1,399,'hoangson123',NULL,'2024-09-08 09:35:02.713036',NULL,1);
/*!40000 ALTER TABLE `orderdetails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `OrderStatusId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Notes` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Firstname` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `LastName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Address` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Phone` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreateAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `UpdateAt` datetime(6) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `IX_Orders_OrderStatusId` (`OrderStatusId`),
  KEY `IX_Orders_UserId` (`UserId`),
  CONSTRAINT `FK_Orders_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Orders_OrderStatuses_OrderStatusId` FOREIGN KEY (`OrderStatusId`) REFERENCES `orderstatuses` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES ('0c0e57b1-667b-4176-abe5-ec901cc21fc9','1f99a247-9b5c-495f-97d8-63010ff10a14','bf743d61-89b8-44de-bfeb-519a9d3862e3','Ok','Nguyễn','Hoang Son','Bac Ninh','0926539328','hoangson12345',NULL,'2024-07-16 22:21:55.045225',NULL,1),('124ca3cf-96f2-4f58-b854-828d8f429fd6','32ff1339-733b-4741-b2d5-ab43c7fbc8e0','4412aa27-7b3c-4ec1-a587-f9b53356d366','Giao gio hanh chinh','Nguyễn','Hoang Son','Yen Phong Bac Ninh','0926539328','hoangson123',NULL,'2024-09-06 21:59:27.004190',NULL,1),('1b59be96-cc34-48ba-9c88-59c932725e9a','32ff1339-733b-4741-b2d5-ab43c7fbc8e0','5aa7c952-1a7a-4111-9068-2705ae82af2a','Giao gio hanh chinh','Nguyễn Duc','Hoang Son','Thi Tran Cho','0926539328','hoangson123',NULL,'2024-09-08 09:47:18.460788',NULL,1),('1cc168cc-2470-4253-9677-27f1a0a3d110','32ff1339-733b-4741-b2d5-ab43c7fbc8e0','19a5fd3c-7e94-4802-91b7-27e81249a44a','Giao gio hanh chinh','Nguyễn','Hoang Son','Yen Phong Bac Ninh Viet Nam','0926539328','hoangson123',NULL,'2024-09-08 09:14:21.281619',NULL,1),('4f725b32-437c-42e6-8295-9e04f370fda3','1f99a247-9b5c-495f-97d8-63010ff10a14','5aa7c952-1a7a-4111-9068-2705ae82af2a','none','Nguyễn','Sơn','Bac Ninh','0926539328','hoangson12345',NULL,'2024-07-16 20:53:37.099068',NULL,1),('53c1ecbd-6390-4cdf-a3a9-aefe5e0a3720','32ff1339-733b-4741-b2d5-ab43c7fbc8e0','5aa7c952-1a7a-4111-9068-2705ae82af2a','Ok','Nguyễn','Hoang Son','Bac Ninh','0926539328','hoangson123',NULL,'2024-09-04 20:40:29.779581',NULL,1),('5dbcb0a5-8cbd-462b-98ba-9d93ae7357df','32ff1339-733b-4741-b2d5-ab43c7fbc8e0','5aa7c952-1a7a-4111-9068-2705ae82af2a','Ok','Nguyễn','Hoang Son','Yen Phong','0926539328','hoangson123',NULL,'2024-09-04 20:43:33.750220',NULL,1),('908c69bf-d1cc-4840-b9bd-48d8d7dbd2e9','32ff1339-733b-4741-b2d5-ab43c7fbc8e0','5aa7c952-1a7a-4111-9068-2705ae82af2a','Giao gio hanh chinh','Nguyễn Duc','Hoang Son','Yen Phong Bac Ninh Viet Nam','0926539328','hoangson123',NULL,'2024-09-08 09:35:02.312479',NULL,1),('a74fb269-dfc9-4d70-8f8e-e946296f3eb7','32ff1339-733b-4741-b2d5-ab43c7fbc8e0','a62b249e-330c-4748-b327-845591b9a91b','Giao gio hanh chinh','Nguyễn','Hoang Son','Yen Phong Bac Ninh Viet Nam','0926539328','hoangson123',NULL,'2024-09-08 09:14:22.017925',NULL,1),('b0eee6ac-3f32-4e13-bdf7-60eeb101f7d6','32ff1339-733b-4741-b2d5-ab43c7fbc8e0','bf743d61-89b8-44de-bfeb-519a9d3862e3','Ok','Nguyễn','Hoang Son','Bac Ninh','0926539328','hoangson123',NULL,'2024-07-25 14:28:23.287250',NULL,1);
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orderstatuses`
--

DROP TABLE IF EXISTS `orderstatuses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orderstatuses` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Bootstapicon` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreateAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `UpdateAt` datetime(6) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orderstatuses`
--

LOCK TABLES `orderstatuses` WRITE;
/*!40000 ALTER TABLE `orderstatuses` DISABLE KEYS */;
INSERT INTO `orderstatuses` VALUES ('19a5fd3c-7e94-4802-91b7-27e81249a44a','Canceled','bi bi-box-seam','Admin',NULL,'2024-06-28 16:13:36.000000',NULL,1),('4412aa27-7b3c-4ec1-a587-f9b53356d366','Wait for delivery','bi bi-hourglass','Admin',NULL,'2024-06-28 16:13:36.000000',NULL,1),('5aa7c952-1a7a-4111-9068-2705ae82af2a','Wait for confirmation','bi bi-clock','Admin',NULL,'2024-06-28 16:13:36.000000',NULL,1),('a62b249e-330c-4748-b327-845591b9a91b','Shipping','bi bi-truck','Admin',NULL,'2024-06-28 16:13:36.000000',NULL,1),('bf743d61-89b8-44de-bfeb-519a9d3862e3','Accomplished','bi bi-calendar2-check','Admin',NULL,'2024-06-28 16:13:36.000000',NULL,1);
/*!40000 ALTER TABLE `orderstatuses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payments`
--

DROP TABLE IF EXISTS `payments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payments` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreateAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `UpdateAt` datetime(6) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payments`
--

LOCK TABLES `payments` WRITE;
/*!40000 ALTER TABLE `payments` DISABLE KEYS */;
INSERT INTO `payments` VALUES ('196bf10b-662b-4e89-ab22-d359484bcaa9','Pay at shop','Admin',NULL,'2024-06-28 16:19:27.000000',NULL,1),('1a40000e-fced-4a6d-98b0-7d056a3d9cd0','Online banking (Paypal)','Admin',NULL,'2024-09-07 10:31:29.000000',NULL,1),('2a346f50-6385-4164-ae44-91cb972ad888','Online Banking (VnPay)','Admin',NULL,'2024-06-28 16:19:27.000000',NULL,1),('ddfb04e3-5bef-407e-9bb1-a1beb62366ff','COD','Admin',NULL,'2024-06-28 16:19:27.000000',NULL,1);
/*!40000 ALTER TABLE `payments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `products` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Price` double NOT NULL,
  `CategoryId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Quantity` int NOT NULL,
  `ProductStatusId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Saleprice` double DEFAULT NULL,
  `CreateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreateAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `UpdateAt` datetime(6) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `IX_Products_CategoryId` (`CategoryId`),
  KEY `IX_Products_ProductStatusId` (`ProductStatusId`),
  CONSTRAINT `FK_Products_Categories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `categories` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Products_ProductStatuses_ProductStatusId` FOREIGN KEY (`ProductStatusId`) REFERENCES `productstatuses` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES ('02642c36-c769-417b-9322-cae0c3d7dcaa','Graziano Indoor/Outdoor Travertine Wall Sconce',299,'e5fb9115-8259-4d8d-a4b1-6d8ab1d981dd','Studio Anansi\'s indoor/outdoor wall sconce is carved from a single piece of travertine for a clean, uncomplicated design that softly scatters light. Lightly polished to unify its tone, each sconce will have subtle differences that render it uniquely beautiful.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('04fc938d-73d3-42cb-a002-3a7049f723bd','Ronda Indoor/Outdoor Matte Black Wall Sconce',149,'e5fb9115-8259-4d8d-a4b1-6d8ab1d981dd','Deco-inspired sconce by Studio Anansi is stylish in matte black. Opaline glass shade diffuses light beautifully, making this a sophisticated choice for bathrooms, patios and entryways.',8,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('09c63539-a410-44ab-8c42-fd55f48e23ad','Aldus Black and Polished Brass Articulating Wall Sconce',229,'e1ebd017-8c14-4bc6-bac5-65267de96d03','Wall sconce by Berlin-based design studio hettler.tüllmann provides essential task lighting in style. Articulating arm in polished unlacquered brass allows for precise positioning and, over time, will develop a rich patina. Adjustable brass shade has a powdercoated matte black finish and is held in place by a brass ring for a sophisticated and decidedly continental silhouette.',8,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('14e3cb59-5c26-40f7-8821-5e2278ecb72c','Soporte Blackened Brass Table Lamp',399,'f0c60493-103b-4454-80fb-5699c2f0cf08','Brass table lamp shows up in style with its oil-blackened finish and shiny brass edging. Simplistic in shape with bracketed detailing along its center rod. Topped with an ivory leather shade to round out the visual interest-enough to make it a statement all its own. Learn about Ceci Thompson on our blog.',8,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('17e342f3-0fd5-4205-803c-00d4b63e20d6','Portage Bay 50252 Hugger 52\" Brushed Nickel West Hill Ceiling Fan with Bowl Light Kit',98.92,'34e52e29-54d9-4f16-9648-98cb40e8984b','The Portage Bay brand is a famous name chosen by many customers around the world. With a beautiful, luxurious design, the Portage Bay 50252 Hugger 52\" Brushed Nickel West Hill Ceiling Fan with Bowl Light Kit is the perfect choice if you are looking to buy one for yourself.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('1872538a-71d2-412a-9986-daf12f711ea2','Ball Candles Set of 2',12.95,'71fac351-b7d7-4647-8345-05adc57a60a4','White ball candle flickers soft light in any setting. Candle fits perfectly inside the Bassa hurricane candle holder. Set of two.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('1b5fbe83-a758-488b-99b8-8144489106d1','Minka Ceiling Fan Co. Aeroflo 52-in Distressed Koa Blades Integrated LED ',219.98,'34e52e29-54d9-4f16-9648-98cb40e8984b','Sleek, smooth and sensational. The Koa finish Minka-Aire LED Ceiling Fan comes ready to serve all of your indoor cooling needs. With a swift 52 inch blade sweep, the LED Ceiling Fan quietly circulates three Koa blades with seamless fluidity. The fan also provides an LED down light for additional luminance with energy and cost-saving value. Distressed Koa Finish ceiling fan from the Aeroflo collection features 3 koa Finish blades Mounts to flat or sloped ceilings with 6-in L down rod included',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('1e896f08-4f7c-41bb-b99e-172512fe1969','Cinq Large Multi White Taper Candle Holder',199,'71fac351-b7d7-4647-8345-05adc57a60a4','Matte white multi taper candle holder takes the term \"sculptural\" to new heights. Unique shape supports nine taper candles for a glow with artistic edge.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('21885b0f-91c1-4cd5-ac2f-e1fd14200bec','Lani White Pendant Light',449,'e063fa2c-4037-45c1-a91d-357b7b0ee36e','White pendant light by London-based Studio Anansi casts a glow in monochromatic form. Iron is finished by hand with a plaster-like texture for a simple statement that easily elevates a space.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('26feb3c1-25fb-4e3a-86ab-3e0378de261f','Lamina Polished Brass Pendant Light',449,'e063fa2c-4037-45c1-a91d-357b7b0ee36e','Inspired by Austrian design, delicate pendant light by VUUE looks like a vintage treasure. Unlacquered polished brass canopy and rods hold two sizes of textured glass discs that seem to bloom each time the light switches on.',12,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('27383f42-3cd9-4d91-ac3a-2a179de53873','Brio Blackened Brass Pendant Light',399,'e063fa2c-4037-45c1-a91d-357b7b0ee36e','Drawing on Italian modernist influences, counterweight pendant light by Studio Anansi strikes the right aesthetic balance. Slightly oversized shade directs light downward—an especially useful choice for positioning above countertops—while the tapered handle enhances the silhouette. Brass with a blackened finish and shiny brass edging, it\'s a seriously stylish choice.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('288da92c-3a1a-4903-b097-015d8e4a48aa','Leda Polished Nickel Articulating Wall Sconce',199,'e1ebd017-8c14-4bc6-bac5-65267de96d03','Swing-arm articulating wall sconce by hettler.tüllmann has an adjustable shade and arm, enabling easy movement next to the bed or near a workspace. Adorned with a polished nickel finish similar to chrome, its swanlike form complements a range of interior styles.',10,'183913c1-404e-46af-bde2-fd03ac3faf05',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('2d121d76-58bc-4393-afa8-e0d6d69c55ba','Hakka Conical Rattan Pendant Light',400,'e063fa2c-4037-45c1-a91d-357b7b0ee36e','Inspired by traditional fish traps from the early 1900s, Kravitz Design rattan pendant light mixes materials to elegant effect. Woven rattan shade with walnut wood trim and oversized finial cast an organic glow from above. Solid brass details on the canopy and interior add a fine finish.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('2de7e612-602c-47d3-b038-2d16db00acdc','Aldus Ivory and Polished Brass Articulating Wall Sconce',229,'e1ebd017-8c14-4bc6-bac5-65267de96d03','Wall sconce by Berlin-based design studio hettler.tüllmann provides essential task lighting in style. Articulating arm in polished unlacquered brass allows for precise positioning and, over time, will develop a rich patina. Adjustable brass shade has a powdercoated ivory finish and is held in place by a brass ring for a sophisticated—and decidedly continental—silhouette.',10,'183913c1-404e-46af-bde2-fd03ac3faf05',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('30b14517-c0d3-4742-83d5-39fec4daeafd','Harbor Breeze Waveport 52-in Aged Bronze with Brown Blades LED Indoor/Outdoor',200,'34e52e29-54d9-4f16-9648-98cb40e8984b','The Harbor Breeze Waveport ceiling fan features palm leaf shaped blades and frosted glass. Crafted from quality materials, this fan is damp rated and durable so you can enjoy this fan on an enclosed patio or porch year round.',9,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('39960a88-0770-4ec3-bb2c-675dc9b1dd36','Dreamer in London Scented Candle',59,'71fac351-b7d7-4647-8345-05adc57a60a4','As a Harlem-raised vaudeville performer, a DREAMER breaks the stereotypes of the Victorian Era Stage.  The essence of cedarwood along with the sweet twist of violet and vanilla transports us to London. Aida, the Queen of the Cakewalk, is invited to perform for King Edward VII and choreographs a connection between the pond that extends far beyond the arts.  ',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('449cd2ab-7112-4cfe-bff5-7bf3ec9aa8d4','Black Twisted Taper Candles Set of 2',4.95,'71fac351-b7d7-4647-8345-05adc57a60a4','Modern dipped twisted tapers in dramatic black flicker soft light in any setting. Quality throughout, it\'s solid color all the way to the wick.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('58fabfc6-a788-46a7-86da-2a3fbc05eb62','Hinge Bronze Vase',99,'71fac351-b7d7-4647-8345-05adc57a60a4','Unique square body and a warm bronze finish give this cast aluminum vase a modern appeal. Accented with hinge details on each corner, bronze vase is stunning on its own or with blooms. CB2 exclusive.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('59cd9506-46d6-4537-b103-c60897458212','Leda Polished Brass Articulating Wall Sconce',199,'e1ebd017-8c14-4bc6-bac5-65267de96d03','Swing-arm articulating wall sconce by hettler.tüllmann has an adjustable shade and arm, enabling easy movement next to the bed or near a workspace. Its swanlike form complements a range of interior styles; brass will develop a beautiful patina over time.',10,'183913c1-404e-46af-bde2-fd03ac3faf05',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('5e433b33-230a-40e3-a59e-63d63c73bb8d','Crinkle Polished Brass Table Lamp',369,'f0c60493-103b-4454-80fb-5699c2f0cf08','A modern furniture and home decor retailer known for its stylish and on-trend products. The Crinkle Polished Brass Table Lamp adds a touch of glamour and sophistication to any room while providing functional lighting.\n\n\n\n\n\n\n',8,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('62374205-246c-4262-9063-9679393db1ed','Graziano Indoor/Outdoor Dark Grey Travertine Wall Sconce',299,'e1ebd017-8c14-4bc6-bac5-65267de96d03','Studio Anansi\'s indoor/outdoor sconce is carved from a single piece of dark grey travertine for a clean, Brutalist-inspired design that softly scatters light. Lightly polished to unify its tone, each sconce will have subtle differences that render it uniquely beautiful.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('68f58a8d-ed1d-4067-8d96-2986b1fc497a','Brio Blackened Brass Articulating Wall Sconce',269,'e1ebd017-8c14-4bc6-bac5-65267de96d03','Drawing on Italian modernist influences, counterweight wall sconce by Studio Anansi strikes the right aesthetic balance. Slightly oversized brass shade directs light downward—an especially useful choice for reading and other tasks—while the tapered arm enhances the silhouette and allows for easy adjustment. In blackened brass, it\'s a seriously stylish choice.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('6bd47120-4b30-47c5-9c67-4a5b1f99fe44','Notch Mango Wood Pillar Candle Holders',59,'71fac351-b7d7-4647-8345-05adc57a60a4','From minimalist taper candle holders to statement-making candelabras, discover the perfect modern candle holder to elevate your decor. Shop from a variety of styles including pillar, tealight, votive, hurricane, wall sconces, and candelabras.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('6dfad5b1-bddb-448b-9f73-1afcbf381d2c','Lustro Smoked Glass Hurricane Candle Holders',65,'71fac351-b7d7-4647-8345-05adc57a60a4','Polished to perfection, smoked glass hurricanes illuminate from within. Cut glass details offer a unique silhouette while the smoked tones in the glass beautifully blend for an ombre effect.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('6f6b4552-05b1-4167-a1ef-9c7e70e6c785','Exposior Polished Brass and Walnut Table Lamp',369,'f0c60493-103b-4454-80fb-5699c2f0cf08','Exposior Polished Brass and Walnut Table Lamp exemplifies the brand\'s commitment to modern design and quality craftsmanship. This lamp is sure to enhance any room with its sophisticated style and warm illumination.\n\n\n\n\n\n\n',7,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('72fa72f6-b749-42c5-b7e5-a2ba76b350ef','Exposior Indoor/Outdoor Black Pendant Light Model 017',299,'e5fb9115-8259-4d8d-a4b1-6d8ab1d981dd','Matte black pendant light debuted as part of Paul McCobb\'s second series of lighting, first introduced in 1952 and just as stunning today. Iron shade and caged design holds an opaque opaline glass shade, emphasizing the timeless forms and considered ideology typical of Paul McCobb. Each major component is a custom design unique to Paul McCobb lighting.',7,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('7466d67c-fd85-4ec5-a1b2-7763e7a34926','test223454234 hehe',600,'f0c60493-103b-4454-80fb-5699c2f0cf08','laptop 123wtert',20,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',0,NULL,NULL,'2024-12-01 20:42:26.846474',NULL,1),('74e506a1-1f49-421e-ad15-f71baeec814f','Ronda Indoor/Outdoor Black Flush Mount Light',199,'e5fb9115-8259-4d8d-a4b1-6d8ab1d981dd','Ronda Indoor/Outdoor Black Flush Mount Light is an excellent choice for those seeking a stylish, durable, and versatile lighting solution that can enhance various areas of their home, both inside and out.',7,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('753af533-e33a-4560-8463-ec6c9b748b72','Cypress Champagne Double Wall Sconce',379,'e1ebd017-8c14-4bc6-bac5-65267de96d03','An Italian-inspired take on the classic wall sconce from Balutto Associati. Thin polished champagne poles and ivory enamel shades rotate to distribute light in any direction you need. The tulip silhouette adds a vintage touch. Part of our Cypress lighting collection.',17,'601489af-b93d-4b0a-b353-e14f243ab8e2',179,NULL,'admin','2024-04-02 10:19:54.000000','2024-05-15 15:28:35.000000',1),('76afac8c-c2e8-4c8b-9651-b79a8cdd0c86','Harbor Breeze Brushed Nickel Ceiling Fan with Light with Remote',80,'34e52e29-54d9-4f16-9648-98cb40e8984b','Make a statement with this beautifully designed contemporary ceiling fan. This fan features an LED light kit to provide brilliant illumination and years of cost efficient and maintenance free enjoyment. This fan may be mounted as a close mount for standard or lower ceiling, or with included downrod for vaulted or higher ceilings.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('7922de92-55f6-457c-83fa-9b7cc2774537','Beau Black Table Lamp',249,'f0c60493-103b-4454-80fb-5699c2f0cf08','A clean, minimalist design. It has a matte black base with two linear rods that lead to a crisp white linen shade and its diffuser. The straightforward silhouette makes it easy to live with and love.',5,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('86a3b3ff-0d98-41ef-a4ac-d5a453679866','Hammered Brass Shallow Dome Pendant Light',399,'e063fa2c-4037-45c1-a91d-357b7b0ee36e','Hammered by hand, brass pendant light mixes metallic tones to gorgeous effect. Shade exterior is plated with warm brass; inside, textured silver foil shimmers as it reflects light downward to the table, bar or counter.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('8a169ec7-5f9f-462d-994a-cf6acb4741e8','Brighton Tapered Brass Pendant Light',499,'e063fa2c-4037-45c1-a91d-357b7b0ee36e','A slightly oversized shade that directs light downward, making it a useful choice for positioning above countertops. The tapered handle enhances its silhouette.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('8e39f85e-2d67-43c5-a12b-e55e2e2e869e','Soporte Polished Brass Table Lamp',399,'f0c60493-103b-4454-80fb-5699c2f0cf08','Brass table lamp shows up in style with its simplistic shape, polished finish and bracketed detailing along its center rod. Topped with an ivory leather shade to round out the visual interest-enough to make it a statement all its own. Learn about Ceci Thompson on our blog.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('ab01fffc-e002-43ad-9815-395b37c48acc','Brio Polished Brass Articulating Wall Sconce',269,'e1ebd017-8c14-4bc6-bac5-65267de96d03','Drawing on Italian modernist influences, counterweight wall sconce by Studio Anansi strikes the right aesthetic balance. Slightly oversized brass shade directs light downward—an especially useful choice for reading and other tasks—while the tapered arm enhances the silhouette and allows for easy adjustment. In brass that will develop a patina with age, it\'s a seriously stylish choice.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('ab58309e-5353-4080-bd19-ce97898d6c6f','Copa Tiered Natural Rattan Pendant Light',499,'e063fa2c-4037-45c1-a91d-357b7b0ee36e','A mix of disparate materials creates unexpected harmony in flush mount light by Nicholas Obeid. Natural rattan, woven by hand into a conical shape, conceals the interior while allowing light to cast dramatic shadows; brass frame adds warmth and will develop a gorgeous patina over time.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('ac3c23d3-c271-4870-9ffc-6fd2663bf8d2','White Twisted Taper Candles Set of 2',4.95,'71fac351-b7d7-4647-8345-05adc57a60a4','Modern dipped twisted tapers in warm white flicker soft light in any setting. Quality throughout, it\'s solid color all the way to the wick.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('b672dcd9-f5c1-4730-bd76-3e6a22b155ae','Brix Golden Black Marble Incense Burner',39.95,'71fac351-b7d7-4647-8345-05adc57a60a4','The interlocking, mosaic-like pattern of black golden marble makes for a simple yet stunning incense burner. Simply place the incense in the brass ball and it will burn at the perfect angle. Also ideal for burning palo santo. ',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('b69f253d-09f5-4c44-9d95-e7357ffd9d24','Ronda Indoor/Outdoor Polished Brass Flush Mount Light',199,'e5fb9115-8259-4d8d-a4b1-6d8ab1d981dd','Deco-inspired sconce by Studio Anansi is stylish in matte black. Opaline glass shade diffuses light beautifully, making this a sophisticated choice for bathrooms, patios and entryways.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('bbb37448-6f10-4cf5-ab3d-68a569e64f2b','Harbor Breeze Armitage 52-in White with White/Washed Oak Blades LED Indoor Flush Mount',191,'34e52e29-54d9-4f16-9648-98cb40e8984b','Low profile design to be mounted flush with the ceiling where more walk-through space is needed. Easy-to-use pull chains are included for quick adjustments to the 3 speed settings and on/off light control',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('c14af4e6-d573-431b-a7df-cac65f5244b5','Prominence Home 50853 Benton Hugger/Low Profile Ceiling Fan, 52” Matte Black/Gray Cedar Blades',191,'34e52e29-54d9-4f16-9648-98cb40e8984b','Get the look you\'ve always wanted with a state-of-the-art, Prominence Home ceiling fan. Our ceiling fans are designed with our customers in mind. Each fan provides high quality with quiet performance. We have the right style for any room. Why ceiling fans ceiling fans save energy both in summer and winter months and offer aesthetic enhancement to any room decor. Our remote ceiling fans offer the ultimate in comfort. All Prominence Home fans are backed by a limited lifetime warranty. Whatever your needs, there are many fine options from Prominence Home. Angle Mounted - NO.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('cd99f939-f57e-4b0d-9913-6ab8d7f63ad1','Falcon Metal Incense Burner',69.95,'71fac351-b7d7-4647-8345-05adc57a60a4','Incense burner by Lawson-Fenning swoops in to scent a room. Crafted by artisans in India, the creation of each piece involves casting and welding aluminum, then manually finishing the details. An incense cone fits underneath the removable top, but this bird of prey also works as décor when perched on shelves and bookcases.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('d31784c2-21f9-4737-af38-8c7d51741410','Brio Polished Brass Pendant Light',399,'e063fa2c-4037-45c1-a91d-357b7b0ee36e','Drawing on Italian modernist influences, counterweight pendant light by Studio Anansi strikes the right aesthetic balance. Slightly oversized shade directs light downward (an especially useful choice for positioning above countertops) while the tapered handle enhances the silhouette. Fabricated from polished unlacquered brass, its finish will develop a beautiful patina over time.',9,'601489af-b93d-4b0a-b353-e14f243ab8e2',299,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('d9b348f0-3a32-499f-aadf-6e81f88840b8','Beau Polished Brass Table Lamp',249,'f0c60493-103b-4454-80fb-5699c2f0cf08','A clean, minimalist design. It has a matte black base with two linear rods that lead to a crisp white linen shade and its diffuser. The straightforward silhouette makes it easy to live with and love.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('dfadfb7e-99be-41ec-8d40-666cfeb6d0c3','test',400,'34e52e29-54d9-4f16-9648-98cb40e8984b','test product',30,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',0,NULL,NULL,'2024-11-30 09:29:38.689727',NULL,0),('ef263f57-39e4-4349-b9d7-46ab5b37cd3d','Brighton Tapered Polished Stainless Steel Pendant Light 2',499,'e063fa2c-4037-45c1-a91d-357b7b0ee36e','Shop modern pendant lighting, chandeliers and hanging light fixtures for the kitchen, dining room, entryway and more. From sleek black kitchen island pendant lights to classic gold dining room chandeliers find the best modern pendant lights for every room your home.',10,'601489af-b93d-4b0a-b353-e14f243ab8e2',199,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('f4b4c15e-2a22-4e43-8331-c3bdbbe286c6','Eleonora Marble Table Lamp',999,'f0c60493-103b-4454-80fb-5699c2f0cf08','Statement table lamp by Studio Anansi balances a shade made of Turkish lilac marble atop a spherical black base. Each shade is carved from a solid piece of marble, then honed and finished by hand, allowing light to illuminate its magnificent veining. This versatile postmodern silhouette looks daring atop nightstands, tables and desks. Each lamp will be unique due to the activity inherent to natural stone.',7,'601489af-b93d-4b0a-b353-e14f243ab8e2',799,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1),('f7471c9a-8cad-4876-981e-1075cbb19c85','test22',1000,'e1ebd017-8c14-4bc6-bac5-65267de96d03','teeeeeeeeeeeeeeeeeeeeeeeest',5,'183913c1-404e-46af-bde2-fd03ac3faf05',0,NULL,NULL,'2024-11-30 09:41:27.754405',NULL,0),('f931aa1c-3bb2-442a-9c55-61fb5f7e5044','Bianca Marble Table Lamp',269,'f0c60493-103b-4454-80fb-5699c2f0cf08','Simple in form and daring in adornment, table lamp incorporates elevated materials throughout. Active Italian Arabescato Corchia marble features purple and white tones and neatly carved edges. On top, ivory linen shade looks graceful with well-placed pleats, making this a lamp that deserves prominent display. Each piece will vary due to the inherent activity of marble.',10,'097a3a3f-6e30-4131-aaa5-b7da5ebc6871',NULL,NULL,NULL,'2024-04-02 10:19:54.000000',NULL,1);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productstatuses`
--

DROP TABLE IF EXISTS `productstatuses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productstatuses` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `CreateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreateAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `UpdateAt` datetime(6) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productstatuses`
--

LOCK TABLES `productstatuses` WRITE;
/*!40000 ALTER TABLE `productstatuses` DISABLE KEYS */;
INSERT INTO `productstatuses` VALUES ('097a3a3f-6e30-4131-aaa5-b7da5ebc6871','avaiable','Admin',NULL,'2024-06-28 16:25:58.000000',NULL,1),('183913c1-404e-46af-bde2-fd03ac3faf05','bestseller','Admin',NULL,'2024-06-28 16:25:58.000000',NULL,1),('601489af-b93d-4b0a-b353-e14f243ab8e2','sale','Admin',NULL,'2024-06-28 16:25:58.000000',NULL,1),('8e35e978-1f09-4047-8503-2c9b897415f3','outofstock','Admin',NULL,'2024-06-28 16:25:58.000000',NULL,1);
/*!40000 ALTER TABLE `productstatuses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rates`
--

DROP TABLE IF EXISTS `rates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `rates` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `UserId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `ProductId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Star` smallint NOT NULL,
  `CreateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreateAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `UpdateAt` datetime(6) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT '0',
  `Comment` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  PRIMARY KEY (`Id`),
  KEY `IX_Rates_ProductId` (`ProductId`),
  KEY `IX_Rates_UserId` (`UserId`),
  CONSTRAINT `FK_Rates_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Rates_Products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `products` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rates`
--

LOCK TABLES `rates` WRITE;
/*!40000 ALTER TABLE `rates` DISABLE KEYS */;
INSERT INTO `rates` VALUES ('7b0bfe66-5c90-4d1b-9bb6-46340dc770e4','1f99a247-9b5c-495f-97d8-63010ff10a14','7922de92-55f6-457c-83fa-9b7cc2774537',3,NULL,NULL,'2024-07-24 09:34:50.051436',NULL,1,'Very good'),('83b7a421-f34a-4ef4-aa97-f2affd7829e3','32ff1339-733b-4741-b2d5-ab43c7fbc8e0','7922de92-55f6-457c-83fa-9b7cc2774537',2,NULL,NULL,'2024-07-25 14:30:51.581672',NULL,1,'Beautiful lamp');
/*!40000 ALTER TABLE `rates` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transactions`
--

DROP TABLE IF EXISTS `transactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transactions` (
  `Id` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `OrderId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `PaymentId` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Total` double NOT NULL DEFAULT '0',
  `CreateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `UpdateBy` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreateAt` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00.000000',
  `UpdateAt` datetime(6) DEFAULT NULL,
  `IsActive` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `IX_Transactions_OrderId` (`OrderId`),
  KEY `IX_Transactions_PaymentId` (`PaymentId`),
  CONSTRAINT `FK_Transactions_Orders_OrderId` FOREIGN KEY (`OrderId`) REFERENCES `orders` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Transactions_Payments_PaymentId` FOREIGN KEY (`PaymentId`) REFERENCES `payments` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
INSERT INTO `transactions` VALUES ('03324063-0a34-4792-870a-446e48e4d785','908c69bf-d1cc-4840-b9bd-48d8d7dbd2e9','1a40000e-fced-4a6d-98b0-7d056a3d9cd0',399,'hoangson123',NULL,'2024-09-08 09:35:02.772245',NULL,1),('3ab82c25-8f7e-436e-96bd-0684ff5eceeb','a74fb269-dfc9-4d70-8f8e-e946296f3eb7','2a346f50-6385-4164-ae44-91cb972ad888',199,'hoangson123',NULL,'2024-09-08 09:14:22.038170',NULL,1),('600107c9-b300-4c17-97a0-9c19629475dc','4f725b32-437c-42e6-8295-9e04f370fda3','ddfb04e3-5bef-407e-9bb1-a1beb62366ff',1506,'hoangson12345',NULL,'2024-07-16 20:53:37.547493',NULL,1),('69951a7a-d3a9-487b-811a-0aa677b4218c','1cc168cc-2470-4253-9677-27f1a0a3d110','2a346f50-6385-4164-ae44-91cb972ad888',199,'hoangson123',NULL,'2024-09-08 09:14:21.751470',NULL,1),('74a223d5-7682-46f0-b80e-79f515ea6ca3','0c0e57b1-667b-4176-abe5-ec901cc21fc9','196bf10b-662b-4e89-ab22-d359484bcaa9',1045,'hoangson12345',NULL,'2024-07-16 22:21:55.132106',NULL,1),('81565ede-f50e-4d4b-a19a-22a8c7579648','124ca3cf-96f2-4f58-b854-828d8f429fd6','2a346f50-6385-4164-ae44-91cb972ad888',668,'hoangson123',NULL,'2024-09-06 21:59:27.364718',NULL,1),('87ed024e-be41-47c8-a4fa-930950040141','1b59be96-cc34-48ba-9c88-59c932725e9a','1a40000e-fced-4a6d-98b0-7d056a3d9cd0',200,'hoangson123',NULL,'2024-09-08 09:47:18.579818',NULL,1),('c32e3f82-f16e-47ab-837c-21dce079055f','b0eee6ac-3f32-4e13-bdf7-60eeb101f7d6','196bf10b-662b-4e89-ab22-d359484bcaa9',249,'hoangson123',NULL,'2024-07-25 14:28:23.633802',NULL,1),('e96ea7e3-16c7-4744-a6a1-5b07bd2b27c2','53c1ecbd-6390-4cdf-a3a9-aefe5e0a3720','2a346f50-6385-4164-ae44-91cb972ad888',199,'hoangson123',NULL,'2024-09-04 20:40:30.253406',NULL,1),('fca35776-dee5-40cb-b44b-3faa91db2850','5dbcb0a5-8cbd-462b-98ba-9d93ae7357df','2a346f50-6385-4164-ae44-91cb972ad888',847,'hoangson123',NULL,'2024-09-04 20:43:33.788376',NULL,1);
/*!40000 ALTER TABLE `transactions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'chiclighting'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-04-25 22:08:12
