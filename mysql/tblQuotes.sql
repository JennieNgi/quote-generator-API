-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Oct 22, 2019 at 02:17 AM
-- Server version: 5.6.35
-- PHP Version: 7.1.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sean_dotnetcoreSamples`
--

-- --------------------------------------------------------

--
-- Table structure for table `tblQuotes`
--

CREATE TABLE `tblQuotes` (
  `id` int(11) NOT NULL,
  `author` varchar(100) NOT NULL,
  `quote` text NOT NULL,
  `permalink` varchar(100) DEFAULT NULL,
  `image` varchar(100) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblQuotes`
--
INSERT INTO `tblQuotes` (`id`, `author`, `quote`, `permalink`, `image`) VALUES
(1, "Bill Sempf", "QA Engineer walks into a bar. Orders a beer. Orders 0 beers. Orders 999999999 beers. Orders a lizard. Orders -1 beers. Orders a sfdeljknesv.","http://quotes.stormconsultancy.co.uk/quotes/44", "image1.gif"),
(2, "Phil Karlton", "There are only two hard things in Computer Science: cache invalidation, naming things and off-by-one errors.","http://quotes.stormconsultancy.co.uk/quotes/43", "image2.gif"),
(5, "Jeff Atwood", "In software, we rarely have meaningful requirements. Even if we do, the only measure of success that matters is whether our solution solves the customer\u2019s shifting idea of what their problem is.", "http://quotes.stormconsultancy.co.uk/quotes/42", "image3.jpg"),
(7, "Robert Sewell","If Java had true garbage collection, most programs would delete themselves upon execution.","http://quotes.stormconsultancy.co.uk/quotes/41","image4.png"),
(8, "Bjarne Stroustrup", "In C++ it\u2019s harder to shoot yourself in the foot, but when you do, you blow off your whole leg.", "http://quotes.stormconsultancy.co.uk/quotes/39", "image5.png"),
(10, "Alan Kay","Most software today is very much like an Egyptian pyramid with millions of bricks piled on top of each other, with no structural integrity, but just done by brute force and thousands of slaves.","http://quotes.stormconsultancy.co.uk/quotes/38","image6.png"),
(12, "Larry DeLuca", "I\u2019ve noticed lately that the paranoid fear of computers becoming intelligent and taking over the world has almost entirely disappeared from the common culture.  Near as I can tell, this coincides with the release of MS-DOS.","http://quotes.stormconsultancy.co.uk/quotes/37","image7.png"),
(14,"Mark Gibbs","No matter how slick the demo is in rehearsal, when you do it in front of a live audience, the probability of a flawless presentation is inversely proportional to the number of people watching, raised to the power of the amount of money involved.","http://quotes.stormconsultancy.co.uk/quotes/36","image8.png"),
(15,"Henry Petroski","The most amazing achievement of the computer software industry is its continuing cancellation of the steady and staggering gains made by the computer hardware industry.","http://quotes.stormconsultancy.co.uk/quotes/35","image9.png"),
(16,"Jeremy S. Anderson","There are two major products that come out of Berkeley: LSD and UNIX.  We don\u2019t believe this to be a coincidence.","http://quotes.stormconsultancy.co.uk/quotes/34","image10.png");

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tblQuotes`
--
ALTER TABLE `tblQuotes`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tblQuotes`
--
ALTER TABLE `tblQuotes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
