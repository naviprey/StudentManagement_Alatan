-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 03, 2025 at 07:31 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `studentinfodb`
--

-- --------------------------------------------------------

--
-- Table structure for table `coursetb`
--

CREATE TABLE `coursetb` (
  `courseId` int(11) NOT NULL,
  `courseName` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `coursetb`
--

INSERT INTO `coursetb` (`courseId`, `courseName`) VALUES
(1, 'IT'),
(2, 'BSBA'),
(3, 'ABEL'),
(4, 'BPA');

-- --------------------------------------------------------

--
-- Table structure for table `studentrecordtb`
--

CREATE TABLE `studentrecordtb` (
  `studentId` int(11) NOT NULL,
  `firstName` varchar(250) DEFAULT NULL,
  `lastName` varchar(250) DEFAULT NULL,
  `middleName` varchar(250) DEFAULT NULL,
  `houseNo` int(11) DEFAULT NULL,
  `brgyName` varchar(250) DEFAULT NULL,
  `municipality` varchar(250) DEFAULT NULL,
  `province` varchar(250) DEFAULT NULL,
  `region` varchar(250) DEFAULT NULL,
  `country` varchar(250) DEFAULT NULL,
  `birthdate` varchar(250) DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `studContactNo` varchar(250) DEFAULT NULL,
  `emailAddress` varchar(250) DEFAULT NULL,
  `guardianFirstName` varchar(250) DEFAULT NULL,
  `guardianLastName` varchar(250) DEFAULT NULL,
  `hobbies` varchar(250) DEFAULT NULL,
  `nickname` varchar(250) DEFAULT NULL,
  `courseId` int(11) DEFAULT NULL,
  `yearId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `studentrecordtb`
--

INSERT INTO `studentrecordtb` (`studentId`, `firstName`, `lastName`, `middleName`, `houseNo`, `brgyName`, `municipality`, `province`, `region`, `country`, `birthdate`, `age`, `studContactNo`, `emailAddress`, `guardianFirstName`, `guardianLastName`, `hobbies`, `nickname`, `courseId`, `yearId`) VALUES
(1, 'Carl Ivan', 'Alatan', 'Aquino', 200, 'Tamaro', 'Bayambang', 'Pangasinan', 'region 1', 'Philippines', '06-30-2003', 21, '09427234332', 'carl@gmail.com', 'Lorie', 'Alatan', 'coding', 'navi', 1, 3),
(2, 'Izzle Shane', 'Junio', 'Calleja', 201, 'Tamaro', 'Bayambang', 'Pangasinan', 'region 1', 'Philippines', '12-12-2003', 21, '09237442331', 'izzle@gmail.com', 'tita', 'Junio', 'badminton', 'shane', 2, 3),
(3, 'Nabi Shan', 'Alatan', 'Junio', 201, 'Tamaro', 'Bayambang', 'Pangasinan', 'region 1', 'Philippines', '12-12-2003', 21, '09237442331', 'nabi@gmail.com', 'jojo', 'alatan', 'basketball', 'shane', 3, 1),
(4, 'Jojo', 'Aquino', 'Junio', 204, 'Tambac', 'Bayambang', 'Pangasinan', 'region 3', 'Philippines', '03-12-2005', 19, '09233242331', 'jojo@gmail.com', 'tito', 'Aquino', 'pingpong', 'jo', 4, 1),
(5, 'Joe', 'Bert', 'Junio', 205, 'Nalsian', 'Bayambang', 'Pangasinan', 'region 1', 'Philippines', '03-27-2003', 21, '09233242331', 'joe@gmail.com', 'Noeman', 'Aquino', 'Valorant', 'jo', 3, 2);

-- --------------------------------------------------------

--
-- Table structure for table `yeartb`
--

CREATE TABLE `yeartb` (
  `yearId` int(11) NOT NULL,
  `yearLvl` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `yeartb`
--

INSERT INTO `yeartb` (`yearId`, `yearLvl`) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `coursetb`
--
ALTER TABLE `coursetb`
  ADD PRIMARY KEY (`courseId`);

--
-- Indexes for table `studentrecordtb`
--
ALTER TABLE `studentrecordtb`
  ADD PRIMARY KEY (`studentId`),
  ADD KEY `yearId` (`yearId`),
  ADD KEY `studentrecordtb_ibfk_1` (`courseId`);

--
-- Indexes for table `yeartb`
--
ALTER TABLE `yeartb`
  ADD PRIMARY KEY (`yearId`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `studentrecordtb`
--
ALTER TABLE `studentrecordtb`
  ADD CONSTRAINT `fk_course` FOREIGN KEY (`courseId`) REFERENCES `coursetb` (`courseId`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `studentrecordtb_ibfk_1` FOREIGN KEY (`courseId`) REFERENCES `coursetb` (`courseId`),
  ADD CONSTRAINT `studentrecordtb_ibfk_2` FOREIGN KEY (`yearId`) REFERENCES `yeartb` (`yearId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
