-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 07 Sie 2024, 10:55
-- Wersja serwera: 10.4.27-MariaDB
-- Wersja PHP: 8.0.25

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `builducpu1`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `chlodzenie`
--

CREATE TABLE `chlodzenie` (
  `Nr` int(11) NOT NULL,
  `kompatybilnosc_id` int(11) DEFAULT NULL,
  `Producent` varchar(50) NOT NULL,
  `Model` varchar(50) NOT NULL,
  `Cena` decimal(10,2) NOT NULL,
  `Wydajnosc` varchar(100) NOT NULL,
  `Kompatybilnosc` varchar(255) NOT NULL,
  `Dostepnosc` enum('Tak','Nie') NOT NULL,
  `Gwarancja` varchar(50) NOT NULL,
  `Dodatkowe_funkcje` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Zrzut danych tabeli `chlodzenie`
--

INSERT INTO `chlodzenie` (`Nr`, `kompatybilnosc_id`, `Producent`, `Model`, `Cena`, `Wydajnosc`, `Kompatybilnosc`, `Dostepnosc`, `Gwarancja`, `Dodatkowe_funkcje`) VALUES
(1, 1, 'ENDORFY', 'Fera 5 Black', '149.00', '250 - 1800 obr./min\r\n', '2066,2011-3,2011,1700,1366,1200,1156,1155,1150,775,AM5,AM4,AM3+,AM2+,FM2+,FM1\r\n', 'Tak', '6 lat', NULL),
(2, 1, 'be quiet!', 'Shadow Rock 3', '245.00', 'do 1600 obr./min\r\n', '2066,2011-3,2011,1700,1200,1155,1151,1150,AM5,AM4\r\n', 'Tak', '3 lata', NULL),
(3, 3, 'Corsair', 'iCUE H115i', '729.00', '252 - 1800 obr./min\r\n', '2066,2011,1700,1366,1200,1156,1155,1151,1150,AM5,AM4,sTR4,sTRX4\r\n', 'Tak', '5 lat', 'Zestaw montażowy backplate Intel & AMD\r\n'),
(4, 3, 'Noctua', 'NH-D15', '499.00', '300 - 1500 obr./min\r\n\r\n', '2066,2011-3,2011,1700,1200,1156,1155,1150,1151,AM5,AM4,AM3+,AM2+,FM2+\r\n', 'Tak', '6 lat', 'Zestaw montażowy backplate Intel & AMD\r\n'),
(5, 2, 'ENDORFY', 'Navis F280', '559.00', '\"250 - 1800 obr./min\"\r\n', '2066,2011-3,2011,1700,1200,1156,1155,1150,1151,AM5,AM4\r\n', 'Tak', '3 lata', 'Kontroler Nano-Reset ARGB\r\n');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `dyski_twarde`
--

CREATE TABLE `dyski_twarde` (
  `Nr` int(11) NOT NULL,
  `kompatybilnosc_id` int(11) NOT NULL,
  `Producent` varchar(50) NOT NULL,
  `Model` varchar(50) NOT NULL,
  `Cena` decimal(10,2) NOT NULL,
  `Wydajnosc` varchar(100) NOT NULL,
  `Kompatybilnosc` varchar(255) NOT NULL,
  `Dostepnosc` enum('Tak','Nie') NOT NULL,
  `Gwarancja` varchar(50) NOT NULL,
  `Dodatkowe_funkcje` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Zrzut danych tabeli `dyski_twarde`
--

INSERT INTO `dyski_twarde` (`Nr`, `kompatybilnosc_id`, `Producent`, `Model`, `Cena`, `Wydajnosc`, `Kompatybilnosc`, `Dostepnosc`, `Gwarancja`, `Dodatkowe_funkcje`) VALUES
(1, 3, 'WD', 'SN580 1TB', '295.00', '4150 MB/s, 4150 MB/s\r\n', 'PCIe NVMe 4.0 x4', 'Tak', '5 lat', NULL),
(2, 2, 'Kingston', 'KC3000 2TB', '679.00', '7000 MB/s, 7000 MB/s', 'PCIe NVMe 4.0 x4', 'Tak', '5 lat', NULL),
(3, 1, 'Seagate', 'FireCuda 530 1TB', '489.00', '7300 MB/s, 6000 MB/s', 'PCIe NVMe 4.0 x4', 'Tak', '5 lat', 'Seagate Rescue Services (usługi odzyskiwania danych)'),
(4, 1, 'Kingston', 'KC600 1TB', '449.00', '550 MB/s, 520 MB/s', '2,5\" SATA', 'Tak', '5 lat', NULL),
(5, 3, 'Samsung', '990 Pro 4TB', '1999.00', '7450 MB/s, 6900 MB/s', 'PCIe NVMe 4.0 x4', 'Tak', '5 lat', 'Technologia TRIMTechnologia S.M.A.R.T');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `gotowe_zestawy`
--

CREATE TABLE `gotowe_zestawy` (
  `Nr` int(11) NOT NULL,
  `Sekcja` varchar(50) NOT NULL,
  `chlodzenie_id` int(11) DEFAULT NULL,
  `dyski_twarde_id` int(11) DEFAULT NULL,
  `karty_graficzne_id` int(11) DEFAULT NULL,
  `obudowy_id` int(11) DEFAULT NULL,
  `pamieci_ram_id` int(11) DEFAULT NULL,
  `plyty_glowne_id` int(11) DEFAULT NULL,
  `procesory_id` int(11) DEFAULT NULL,
  `zasilacze_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Zrzut danych tabeli `gotowe_zestawy`
--

INSERT INTO `gotowe_zestawy` (`Nr`, `Sekcja`, `chlodzenie_id`, `dyski_twarde_id`, `karty_graficzne_id`, `obudowy_id`, `pamieci_ram_id`, `plyty_glowne_id`, `procesory_id`, `zasilacze_id`) VALUES
(1, 'Gry', NULL, 1, 1, 1, 1, 2, 3, 1),
(2, 'Gry', 1, 2, 3, 1, 2, 1, 3, 3),
(3, 'Gry', 4, 4, 4, 3, 3, 4, 6, 3),
(4, 'Gry', 5, 2, 2, 5, 5, 5, 7, 4),
(5, 'Programowanie', 2, 1, NULL, 1, 3, 3, 6, 1),
(6, 'Grafika', 1, 2, 3, 2, 3, 3, 5, 6),
(7, 'Grafika', 4, 5, 5, 3, 3, 3, 6, 3),
(8, 'Biuro', NULL, 1, NULL, 1, 1, 2, 3, 1),
(9, 'Dom', 1, 1, 1, 1, 1, 6, 1, 1);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `karty_graficzne`
--

CREATE TABLE `karty_graficzne` (
  `Nr` int(11) NOT NULL,
  `kompatybilnosc_id` int(11) DEFAULT NULL,
  `Producent` varchar(50) NOT NULL,
  `Model` varchar(50) NOT NULL,
  `Cena` decimal(10,2) NOT NULL,
  `Wydajnosc` varchar(100) NOT NULL,
  `Kompatybilnosc` varchar(50) NOT NULL,
  `Dostepnosc` enum('Tak','Nie') NOT NULL,
  `Gwarancja` varchar(50) NOT NULL,
  `Dodatkowe_funkcje` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Zrzut danych tabeli `karty_graficzne`
--

INSERT INTO `karty_graficzne` (`Nr`, `kompatybilnosc_id`, `Producent`, `Model`, `Cena`, `Wydajnosc`, `Kompatybilnosc`, `Dostepnosc`, `Gwarancja`, `Dodatkowe_funkcje`) VALUES
(1, 3, 'AMD', 'Gigabyte Radeon RX 6600 EAGLE', '979.00', '8GB VRAM, 2491 MHz\r\n', 'PCIe 4.0', 'Tak', '3 lata', 'AMD FSR 3\r\n'),
(2, 3, 'NVIDIA', 'MSI RTX 4090 SUPRIM X', '8699.00', '24GB VRAM, 2520 MHz', 'PCIe 4.0', 'Tak', '3 lata', 'RT'),
(3, 1, 'NVIDIA', 'MSI RTX 4060 Ventus 2X', '1269.00', '8GB VRAM, 2490 MHz\r\n', 'PCIe 4.0', 'Tak', '3 lata', 'Nvidia DLSS 3.5\r\n'),
(4, 2, 'AMD', 'Gigabyte RX 7700 XT Gaming', '2529.00', '12GB VRAM, 2276 MHz', 'PCIe 4.0', 'Tak', '3 lata ', 'AMD FSR 3'),
(5, 2, 'NVIDIA', 'Gigabyte GeForce RTX 4070 Ti EAGLE', '3299.00', '12GB VRAM, 2625 MHz', 'PCIe 4.0', 'Tak', '3 lata', 'Nvidia DLSS 3.5');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `kompatybilnosc`
--

CREATE TABLE `kompatybilnosc` (
  `id` int(11) NOT NULL,
  `nazwa` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Zrzut danych tabeli `kompatybilnosc`
--

INSERT INTO `kompatybilnosc` (`id`, `nazwa`) VALUES
(1, 'AMD4'),
(2, 'AMD5'),
(3, 'INTEL');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `obudowy`
--

CREATE TABLE `obudowy` (
  `Nr` int(11) NOT NULL,
  `kompatybilnosc_id` int(11) DEFAULT NULL,
  `Producent` varchar(50) NOT NULL,
  `Model` varchar(50) NOT NULL,
  `Cena` decimal(10,2) NOT NULL,
  `Wydajnosc` varchar(50) NOT NULL,
  `Kompatybilnosc` varchar(100) NOT NULL,
  `Dostepnosc` enum('Tak','Nie') NOT NULL,
  `Gwarancja` varchar(50) NOT NULL,
  `Dodatkowe_funkcje` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Zrzut danych tabeli `obudowy`
--

INSERT INTO `obudowy` (`Nr`, `kompatybilnosc_id`, `Producent`, `Model`, `Cena`, `Wydajnosc`, `Kompatybilnosc`, `Dostepnosc`, `Gwarancja`, `Dodatkowe_funkcje`) VALUES
(1, 1, 'Cooler Master', 'Q300L V2', '329.00', 'Mini Tower', '\"microATX Mini-ITX\"', 'Tak', '2 lata', 'System aranżowania kabli'),
(2, 2, 'NZXT', 'H5 FLOW', '569.00', 'Middle Tower', 'ATX, microATX, Mini-ITX', 'Tak', '2 lata', 'System aranżowania kabli'),
(3, 2, 'Corsair', '7000D', '999.00', 'Full Tower', '\"ATX, Mini-ITX\"\r\n', 'Tak', '2 lata', 'Panel boczny w formie drzwi'),
(4, 3, 'Fractal', 'TG Clear Tint', '429.00', 'Middle Tower', 'ATX, m-ATX, Mini-ITX\r\n', 'Tak', '2 lata', 'Kontroler / hub wentylatorów'),
(5, 3, 'Fractal', 'Meshify 2', '1049.00', 'Full Tower', '\"ATX, m-ATX, Mini-ITX, EATX, EEATX, SSI CEB, SSI EEB, Mini-ITX\"\r\n', 'Tak', '2 lata', 'Wyjmowana klatka HDD');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `pamieci_ram`
--

CREATE TABLE `pamieci_ram` (
  `Nr` int(11) NOT NULL,
  `kompatybilnosc_id` int(11) DEFAULT NULL,
  `Producent` varchar(50) NOT NULL,
  `Model` varchar(50) NOT NULL,
  `Cena` decimal(10,2) NOT NULL,
  `Wydajnosc` varchar(100) NOT NULL,
  `Kompatybilnosc` varchar(50) NOT NULL,
  `Dostepnosc` enum('Tak','Nie') NOT NULL,
  `Gwarancja` varchar(50) NOT NULL,
  `Dodatkowe_funkcje` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Zrzut danych tabeli `pamieci_ram`
--

INSERT INTO `pamieci_ram` (`Nr`, `kompatybilnosc_id`, `Producent`, `Model`, `Cena`, `Wydajnosc`, `Kompatybilnosc`, `Dostepnosc`, `Gwarancja`, `Dodatkowe_funkcje`) VALUES
(1, 3, 'GOODRAM', 'PRO Deep Black', '190.00', '16GB, 3600 MHz', 'DDR4, dual channel', 'Tak', 'dożywotnia (gwarancja producenta)', NULL),
(2, 1, 'GOODRAM', 'IRDM', '309.00', '32GB, 3200 MHz', 'DDR4, dual channel', 'Tak', 'dożywotnia (gwarancja producenta)', NULL),
(3, 2, 'GOODRAM', 'IRDM BLACK V SILVER', '549.00', '32GB, 6400 MHz ', 'DDR5, dual channel', 'Tak', 'dożywotnia (gwarancja producenta)', NULL),
(4, 2, 'G.SKILL', 'Trident Z5 RGB', '619.00', '32GB, 6400 MHz', 'DDR5, dual channel', 'Tak', 'dożywotnia (gwarancja producenta)', 'RGB'),
(5, 3, 'Kingston', 'Renegade RGB', '1059.00', '32GB, 7200 MHz', 'DDR5, dual channel', 'Nie', 'dożywotnia (gwarancja producenta)', 'RGB');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `plyty_glowne`
--

CREATE TABLE `plyty_glowne` (
  `Nr` int(11) NOT NULL,
  `kompatybilnosc_id` int(11) DEFAULT NULL,
  `Producent` varchar(50) NOT NULL,
  `Model` varchar(50) NOT NULL,
  `Cena` decimal(10,2) NOT NULL,
  `Rozmiar` varchar(50) NOT NULL,
  `Kompatybilnosc` varchar(100) NOT NULL,
  `Dostepnosc` enum('Tak','Nie') NOT NULL,
  `Gwarancja` varchar(50) NOT NULL,
  `Dodatkowe_funkcje` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Zrzut danych tabeli `plyty_glowne`
--

INSERT INTO `plyty_glowne` (`Nr`, `kompatybilnosc_id`, `Producent`, `Model`, `Cena`, `Rozmiar`, `Kompatybilnosc`, `Dostepnosc`, `Gwarancja`, `Dodatkowe_funkcje`) VALUES
(1, 1, 'Gigabyte', 'B550M AORUS ELITE', '479.00', 'mATX', 'AM4, DDR4\r\n', 'Tak', '3 lata', 'No compability with AMD Ryzen 5 3400G i AMD Ryzen 3 3200G\r\n'),
(2, 1, 'Gigabyte', 'B550M DS3H', '403.00', 'mATX', 'AM4, DDR4\r\n', 'Tak', '3 lata', 'Kompatybilność z procesorami AMD Zen 2\r\n'),
(3, 2, 'ASRock', 'B650M-HDV/M.2', '517.00', 'mATX', 'AM5, DDR5\r\n', 'Nie', '3 lata ', 'AMD CrossFireX\r\n'),
(4, 2, 'Gigabyte', 'B650 EAGLE AX', '739.00', 'mATX', 'AM5, DDR5\r\n', 'Tak', '3 lata', 'Antena Wi-Fi 2.4/5 GHz\r\n'),
(5, 3, 'ASUS', 'ROG MAXIMUS Z790', '3305.00', 'ATX', 'Socket 1700, DDR5\r\n', 'Tak', '3 lata', '\"Pendrive ze sterownikami\r\nAntena Wi-Fi 2.4/5 GHz - 1 szt.\"\r\n'),
(6, 3, 'ASRock', 'B660M Pro RS', '511.00', 'mATX', 'Socket 1700, DDR4\r\n', 'Tak', '3 lata', '\"Podświetlenie LED\r\nWake-On-LAN\"\r\n');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `procesory`
--

CREATE TABLE `procesory` (
  `Nr` int(11) NOT NULL,
  `kompatybilnosc_id` int(11) DEFAULT NULL,
  `Producent` varchar(50) NOT NULL,
  `Model` varchar(50) NOT NULL,
  `Cena` decimal(10,2) NOT NULL,
  `Wydajnosc` varchar(100) NOT NULL,
  `Kompatybilnosc` varchar(50) NOT NULL,
  `Dostepnosc` enum('Tak','Nie') NOT NULL,
  `Gwarancja` varchar(50) NOT NULL,
  `Dodatkowe_funkcje` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Zrzut danych tabeli `procesory`
--

INSERT INTO `procesory` (`Nr`, `kompatybilnosc_id`, `Producent`, `Model`, `Cena`, `Wydajnosc`, `Kompatybilnosc`, `Dostepnosc`, `Gwarancja`, `Dodatkowe_funkcje`) VALUES
(1, 3, 'Intel', 'i3-12100F', '369.00', '4 rdzeni, 3.3-4.3 GHz', 'Socket 1700', 'Tak', '3 lata', NULL),
(2, 1, 'AMD', 'Ryzen 5 5600G', '569.00', '6 rdzeni, 3.9-4.4 GHz', 'AM4', 'Tak', '3 lata', ''),
(3, 1, 'AMD', 'Ryzen 5 5600', '519.00', '6 rdzeni, 3.5-4.4 GHz', 'AM4', 'Tak', '3 lata ', NULL),
(4, 3, 'Intel', 'i5-12400F', '509.00', '6 rdzeni, 2.5-4.4 GHz', 'Socket 1700', 'Tak', '3 lata', '6 rdzeni(performance)\r\n'),
(5, 2, 'AMD', 'Ryzen 5 7600', '879.00', '6 rdzeni, 3.8-5.1 GHz', 'AM5', 'Tak', '3 lata', NULL),
(6, 2, 'AMD', 'Ryzen 7 7800X3D', '1599.00', '8 rdzeni, 4.2-5.0 GHz', 'AM5', 'Tak', '3 lata', 'AMD 3D V-Cache'),
(7, 3, 'Intel', 'i9-14900K', '2799.00', '24 rdzeni, 3.2-6.0 GHz', 'Socket 1700', 'Tak', '3 lata', '8 rdzeni Performance 16 rdzeni Efficient\r\n');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `zasilacze`
--

CREATE TABLE `zasilacze` (
  `Nr` int(11) NOT NULL,
  `kompatybilnosc_id` int(11) DEFAULT NULL,
  `Producent` varchar(50) NOT NULL,
  `Model` varchar(50) NOT NULL,
  `Cena` decimal(10,2) NOT NULL,
  `Wydajnosc` varchar(100) NOT NULL,
  `Kompatybilnosc` varchar(50) NOT NULL,
  `Dostepnosc` enum('Tak','Nie') NOT NULL,
  `Gwarancja` varchar(50) NOT NULL,
  `Dodatkowe_funkcje` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Zrzut danych tabeli `zasilacze`
--

INSERT INTO `zasilacze` (`Nr`, `kompatybilnosc_id`, `Producent`, `Model`, `Cena`, `Wydajnosc`, `Kompatybilnosc`, `Dostepnosc`, `Gwarancja`, `Dodatkowe_funkcje`) VALUES
(1, 3, 'Deepcool', 'PK550D', '219.00', '550 W, 80+ Bronze', 'ATX', 'Tak', '5 lat', NULL),
(2, 1, 'Corsair', 'CX650', '289.00', '650 W, 80+ Bronze', 'ATX', 'Tak', '3 lata', NULL),
(3, 2, 'EVGA', 'SuperNOVA', '649.00', '750 W, 80+ Gold', 'ATX, modular', 'Nie', '2 lata', NULL),
(4, 3, 'Corsair', 'PK550D', '939.00', '1000 W, 80+ Gold', 'ATX 3.0, modular', 'Tak', '10 lat', NULL),
(5, 1, 'Cooler Master', 'MWE BRONZE V2', '269.00', '550 W, 80+ Bronze', 'ATX, modular', 'Nie', '5 lat', NULL),
(6, 2, 'Cooler Master', 'MWE GOLD-V2', '449.00', '750 W, 80+ Gold', 'ATX, modular', 'Tak', '5 lat', NULL);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `chlodzenie`
--
ALTER TABLE `chlodzenie`
  ADD PRIMARY KEY (`Nr`),
  ADD KEY `kompatybilnosc_id` (`kompatybilnosc_id`);

--
-- Indeksy dla tabeli `dyski_twarde`
--
ALTER TABLE `dyski_twarde`
  ADD PRIMARY KEY (`Nr`),
  ADD KEY `kompatybilnosc_id` (`kompatybilnosc_id`);

--
-- Indeksy dla tabeli `gotowe_zestawy`
--
ALTER TABLE `gotowe_zestawy`
  ADD PRIMARY KEY (`Nr`),
  ADD KEY `chlodzenie_id` (`chlodzenie_id`),
  ADD KEY `dyski_twarde_id` (`dyski_twarde_id`),
  ADD KEY `karty_graficzne_id` (`karty_graficzne_id`),
  ADD KEY `obudowy_id` (`obudowy_id`),
  ADD KEY `pamieci_ram_id` (`pamieci_ram_id`),
  ADD KEY `plyty_glowne_id` (`plyty_glowne_id`),
  ADD KEY `procesory_id` (`procesory_id`),
  ADD KEY `zasilacze_id` (`zasilacze_id`);

--
-- Indeksy dla tabeli `karty_graficzne`
--
ALTER TABLE `karty_graficzne`
  ADD PRIMARY KEY (`Nr`),
  ADD KEY `kompatybilnosc_id` (`kompatybilnosc_id`);

--
-- Indeksy dla tabeli `kompatybilnosc`
--
ALTER TABLE `kompatybilnosc`
  ADD PRIMARY KEY (`id`);

--
-- Indeksy dla tabeli `obudowy`
--
ALTER TABLE `obudowy`
  ADD PRIMARY KEY (`Nr`),
  ADD KEY `kompatybilnosc_id` (`kompatybilnosc_id`);

--
-- Indeksy dla tabeli `pamieci_ram`
--
ALTER TABLE `pamieci_ram`
  ADD PRIMARY KEY (`Nr`),
  ADD KEY `kompatybilnosc_id` (`kompatybilnosc_id`);

--
-- Indeksy dla tabeli `plyty_glowne`
--
ALTER TABLE `plyty_glowne`
  ADD PRIMARY KEY (`Nr`),
  ADD KEY `kompatybilnosc_id` (`kompatybilnosc_id`);

--
-- Indeksy dla tabeli `procesory`
--
ALTER TABLE `procesory`
  ADD PRIMARY KEY (`Nr`),
  ADD KEY `kompatybilnosc_id` (`kompatybilnosc_id`);

--
-- Indeksy dla tabeli `zasilacze`
--
ALTER TABLE `zasilacze`
  ADD PRIMARY KEY (`Nr`),
  ADD KEY `kompatybilnosc_id` (`kompatybilnosc_id`);

--
-- AUTO_INCREMENT dla zrzuconych tabel
--

--
-- AUTO_INCREMENT dla tabeli `chlodzenie`
--
ALTER TABLE `chlodzenie`
  MODIFY `Nr` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT dla tabeli `dyski_twarde`
--
ALTER TABLE `dyski_twarde`
  MODIFY `Nr` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT dla tabeli `gotowe_zestawy`
--
ALTER TABLE `gotowe_zestawy`
  MODIFY `Nr` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT dla tabeli `karty_graficzne`
--
ALTER TABLE `karty_graficzne`
  MODIFY `Nr` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT dla tabeli `kompatybilnosc`
--
ALTER TABLE `kompatybilnosc`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT dla tabeli `obudowy`
--
ALTER TABLE `obudowy`
  MODIFY `Nr` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT dla tabeli `pamieci_ram`
--
ALTER TABLE `pamieci_ram`
  MODIFY `Nr` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT dla tabeli `plyty_glowne`
--
ALTER TABLE `plyty_glowne`
  MODIFY `Nr` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT dla tabeli `procesory`
--
ALTER TABLE `procesory`
  MODIFY `Nr` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT dla tabeli `zasilacze`
--
ALTER TABLE `zasilacze`
  MODIFY `Nr` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `chlodzenie`
--
ALTER TABLE `chlodzenie`
  ADD CONSTRAINT `chlodzenie_ibfk_1` FOREIGN KEY (`kompatybilnosc_id`) REFERENCES `kompatybilnosc` (`id`);

--
-- Ograniczenia dla tabeli `dyski_twarde`
--
ALTER TABLE `dyski_twarde`
  ADD CONSTRAINT `dyski_twarde_ibfk_1` FOREIGN KEY (`kompatybilnosc_id`) REFERENCES `kompatybilnosc` (`id`);

--
-- Ograniczenia dla tabeli `gotowe_zestawy`
--
ALTER TABLE `gotowe_zestawy`
  ADD CONSTRAINT `gotowe_zestawy_ibfk_1` FOREIGN KEY (`chlodzenie_id`) REFERENCES `chlodzenie` (`Nr`),
  ADD CONSTRAINT `gotowe_zestawy_ibfk_2` FOREIGN KEY (`dyski_twarde_id`) REFERENCES `dyski_twarde` (`Nr`),
  ADD CONSTRAINT `gotowe_zestawy_ibfk_3` FOREIGN KEY (`karty_graficzne_id`) REFERENCES `karty_graficzne` (`Nr`),
  ADD CONSTRAINT `gotowe_zestawy_ibfk_4` FOREIGN KEY (`obudowy_id`) REFERENCES `obudowy` (`Nr`),
  ADD CONSTRAINT `gotowe_zestawy_ibfk_5` FOREIGN KEY (`pamieci_ram_id`) REFERENCES `pamieci_ram` (`Nr`),
  ADD CONSTRAINT `gotowe_zestawy_ibfk_6` FOREIGN KEY (`plyty_glowne_id`) REFERENCES `plyty_glowne` (`Nr`),
  ADD CONSTRAINT `gotowe_zestawy_ibfk_7` FOREIGN KEY (`procesory_id`) REFERENCES `procesory` (`Nr`),
  ADD CONSTRAINT `gotowe_zestawy_ibfk_8` FOREIGN KEY (`zasilacze_id`) REFERENCES `zasilacze` (`Nr`);

--
-- Ograniczenia dla tabeli `karty_graficzne`
--
ALTER TABLE `karty_graficzne`
  ADD CONSTRAINT `karty_graficzne_ibfk_1` FOREIGN KEY (`kompatybilnosc_id`) REFERENCES `kompatybilnosc` (`id`);

--
-- Ograniczenia dla tabeli `obudowy`
--
ALTER TABLE `obudowy`
  ADD CONSTRAINT `obudowy_ibfk_1` FOREIGN KEY (`kompatybilnosc_id`) REFERENCES `kompatybilnosc` (`id`);

--
-- Ograniczenia dla tabeli `pamieci_ram`
--
ALTER TABLE `pamieci_ram`
  ADD CONSTRAINT `pamieci_ram_ibfk_1` FOREIGN KEY (`kompatybilnosc_id`) REFERENCES `kompatybilnosc` (`id`);

--
-- Ograniczenia dla tabeli `plyty_glowne`
--
ALTER TABLE `plyty_glowne`
  ADD CONSTRAINT `plyty_glowne_ibfk_1` FOREIGN KEY (`kompatybilnosc_id`) REFERENCES `kompatybilnosc` (`id`);

--
-- Ograniczenia dla tabeli `procesory`
--
ALTER TABLE `procesory`
  ADD CONSTRAINT `procesory_ibfk_1` FOREIGN KEY (`kompatybilnosc_id`) REFERENCES `kompatybilnosc` (`id`);

--
-- Ograniczenia dla tabeli `zasilacze`
--
ALTER TABLE `zasilacze`
  ADD CONSTRAINT `zasilacze_ibfk_1` FOREIGN KEY (`kompatybilnosc_id`) REFERENCES `kompatybilnosc` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
