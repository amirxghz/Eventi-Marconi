-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Creato il: Ago 30, 2026 alle 21:12
-- Versione del server: 8.2.0
-- Versione PHP: 8.3.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `eventimarconi`
--

-- --------------------------------------------------------

--
-- Struttura della tabella `aderire`
--

CREATE TABLE `aderire` (
  `IDaderire` int NOT NULL,
  `iscritto` tinyint(1) NOT NULL DEFAULT '0',
  `autorizzato` tinyint(1) NOT NULL DEFAULT '0',
  `pagato` tinyint(1) DEFAULT NULL,
  `partecipato` tinyint(1) NOT NULL DEFAULT '0',
  `attivitaID` int NOT NULL,
  `classeID` char(3) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `studenteID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struttura della tabella `attivita`
--

CREATE TABLE `attivita` (
  `ID` int NOT NULL,
  `titolo` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `testo` varchar(250) COLLATE utf8mb4_general_ci NOT NULL,
  `ordine` tinyint NOT NULL,
  `dalle` time NOT NULL,
  `alle` time NOT NULL,
  `eventoID` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struttura della tabella `classi`
--

CREATE TABLE `classi` (
  `sigla` char(3) COLLATE utf8mb4_general_ci NOT NULL,
  `aula` varchar(4) COLLATE utf8mb4_general_ci NOT NULL,
  `anno` tinyint(1) NOT NULL,
  `sezione` char(2) COLLATE utf8mb4_general_ci NOT NULL,
  `indirizzoID` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struttura della tabella `eventi`
--

CREATE TABLE `eventi` (
  `ID` int NOT NULL,
  `nome` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `descrizione` varchar(250) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `dal` date NOT NULL,
  `al` date NOT NULL,
  `adminID` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struttura della tabella `indirizzi`
--

CREATE TABLE `indirizzi` (
  `ID` int NOT NULL,
  `nome` varchar(30) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struttura della tabella `utenti`
--

CREATE TABLE `utenti` (
  `ID` int NOT NULL,
  `nome` varchar(30) COLLATE utf8mb4_general_ci NOT NULL,
  `cognome` varchar(30) COLLATE utf8mb4_general_ci NOT NULL,
  `username` varchar(30) COLLATE utf8mb4_general_ci NOT NULL,
  `password` varchar(30) COLLATE utf8mb4_general_ci NOT NULL,
  `matricola` char(8) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `rappresentanteClasse` tinyint(1) DEFAULT NULL,
  `rappresentanteIstituto` tinyint(1) DEFAULT NULL,
  `ruolo` char(1) COLLATE utf8mb4_general_ci NOT NULL,
  `classeID` char(3) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indici per le tabelle scaricate
--

--
-- Indici per le tabelle `aderire`
--
ALTER TABLE `aderire`
  ADD PRIMARY KEY (`IDaderire`),
  ADD UNIQUE KEY `unicita_adesione` (`attivitaID`,`classeID`,`studenteID`),
  ADD KEY `classeID` (`classeID`),
  ADD KEY `studenteID` (`studenteID`);

--
-- Indici per le tabelle `attivita`
--
ALTER TABLE `attivita`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `eventoID` (`eventoID`);

--
-- Indici per le tabelle `classi`
--
ALTER TABLE `classi`
  ADD PRIMARY KEY (`sigla`),
  ADD KEY `indirizzoID` (`indirizzoID`);

--
-- Indici per le tabelle `eventi`
--
ALTER TABLE `eventi`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `nome` (`nome`),
  ADD KEY `adminID` (`adminID`);

--
-- Indici per le tabelle `indirizzi`
--
ALTER TABLE `indirizzi`
  ADD PRIMARY KEY (`ID`);

--
-- Indici per le tabelle `utenti`
--
ALTER TABLE `utenti`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `matricola` (`matricola`),
  ADD KEY `classeID` (`classeID`);

--
-- AUTO_INCREMENT per le tabelle scaricate
--

--
-- AUTO_INCREMENT per la tabella `aderire`
--
ALTER TABLE `aderire`
  MODIFY `IDaderire` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT per la tabella `attivita`
--
ALTER TABLE `attivita`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT per la tabella `eventi`
--
ALTER TABLE `eventi`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT per la tabella `indirizzi`
--
ALTER TABLE `indirizzi`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT per la tabella `utenti`
--
ALTER TABLE `utenti`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT;

--
-- Limiti per le tabelle scaricate
--

--
-- Limiti per la tabella `aderire`
--
ALTER TABLE `aderire`
  ADD CONSTRAINT `aderire_attivita` FOREIGN KEY (`attivitaID`) REFERENCES `attivita` (`ID`) ON DELETE RESTRICT ON UPDATE CASCADE,
  ADD CONSTRAINT `aderire_classi` FOREIGN KEY (`classeID`) REFERENCES `classi` (`sigla`) ON DELETE RESTRICT ON UPDATE CASCADE,
  ADD CONSTRAINT `aderire_studente` FOREIGN KEY (`studenteID`) REFERENCES `utenti` (`ID`) ON DELETE RESTRICT ON UPDATE CASCADE;

--
-- Limiti per la tabella `attivita`
--
ALTER TABLE `attivita`
  ADD CONSTRAINT `attivita_eventi` FOREIGN KEY (`eventoID`) REFERENCES `eventi` (`ID`) ON DELETE RESTRICT ON UPDATE CASCADE;

--
-- Limiti per la tabella `classi`
--
ALTER TABLE `classi`
  ADD CONSTRAINT `classi_indirizzi` FOREIGN KEY (`indirizzoID`) REFERENCES `indirizzi` (`ID`) ON DELETE RESTRICT ON UPDATE CASCADE;

--
-- Limiti per la tabella `eventi`
--
ALTER TABLE `eventi`
  ADD CONSTRAINT `eventi_admin` FOREIGN KEY (`adminID`) REFERENCES `utenti` (`ID`) ON DELETE RESTRICT ON UPDATE CASCADE;

--
-- Limiti per la tabella `utenti`
--
ALTER TABLE `utenti`
  ADD CONSTRAINT `utenti_classi` FOREIGN KEY (`classeID`) REFERENCES `classi` (`sigla`) ON DELETE RESTRICT ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
