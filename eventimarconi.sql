-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Creato il: Set 13, 2026 alle 21:54
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
  `codicePartecipazione` char(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `iscritto` tinyint(1) NOT NULL DEFAULT '0',
  `pagato` tinyint(1) DEFAULT NULL,
  `partecipato` tinyint(1) NOT NULL DEFAULT '0',
  `attivitaID` int NOT NULL,
  `classeID` char(3) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `studenteID` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `aderire`
--

INSERT INTO `aderire` (`IDaderire`, `codicePartecipazione`, `iscritto`, `pagato`, `partecipato`, `attivitaID`, `classeID`, `studenteID`) VALUES
(1, '', 1, 0, 1, 4, '5BM', 2),
(2, '', 1, 0, 0, 5, '5BM', 2),
(3, '', 1, 0, 0, 6, '5BM', 2),
(4, '', 1, 0, 0, 7, '5BM', 2),
(5, '', 1, 0, 0, 1, '5BM', 2),
(6, '', 1, 0, 0, 2, '5BM', 2),
(7, '', 1, 0, 0, 3, '5BM', 2);

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

--
-- Dump dei dati per la tabella `attivita`
--

INSERT INTO `attivita` (`ID`, `titolo`, `testo`, `ordine`, `dalle`, `alle`, `eventoID`) VALUES
(1, 'donazioni di birre', 'vieni', 1, '08:00:04', '09:00:04', 2),
(2, 'brindisi', 'evvai', 2, '09:00:00', '10:00:00', 2),
(3, 'gran bevuta insieme ai prof', '', 3, '10:00:00', '11:00:00', 2),
(4, 'lezione di nuoto', '', 1, '08:00:02', '10:00:02', 3),
(5, 'ricreazione', 'pausa dopo la lezione impegnativa', 2, '10:00:00', '10:30:00', 3),
(6, 'gara di nuoto', 'vediam chi vince', 3, '10:30:00', '11:30:00', 3),
(7, 'celebrazioni', 'chi ha vinto??', 4, '11:30:00', '13:00:00', 3);

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

--
-- Dump dei dati per la tabella `classi`
--

INSERT INTO `classi` (`sigla`, `aula`, `anno`, `sezione`, `indirizzoID`) VALUES
('2AM', '1-04', 2, 'AM', 3),
('3CP', '5-11', 1, 'CP', 2),
('4DM', '3-02', 4, 'DM', 5),
('5BM', '2-12', 5, 'BM', 1);

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
  `prezzo` decimal(10,0) DEFAULT NULL,
  `adminID` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `eventi`
--

INSERT INTO `eventi` (`ID`, `nome`, `descrizione`, `dal`, `al`, `prezzo`, `adminID`) VALUES
(2, 'festa della birra', 'aura birret', '2026-09-13', '2026-09-13', NULL, 3),
(3, 'piscina', 'grande assemblea d\'istituto in piscina', '2026-09-25', '2026-09-25', NULL, 3);

-- --------------------------------------------------------

--
-- Struttura della tabella `indirizzi`
--

CREATE TABLE `indirizzi` (
  `ID` int NOT NULL,
  `nome` varchar(30) COLLATE utf8mb4_general_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `indirizzi`
--

INSERT INTO `indirizzi` (`ID`, `nome`) VALUES
(1, 'informatica'),
(2, 'moda'),
(3, 'meccatronica'),
(4, 'meccanica'),
(5, 'elettronica');

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
  `matricola` char(7) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL,
  `rappresentanteClasse` tinyint(1) DEFAULT NULL,
  `rappresentanteIstituto` tinyint(1) DEFAULT NULL,
  `ruolo` char(1) COLLATE utf8mb4_general_ci NOT NULL,
  `classeID` char(3) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dump dei dati per la tabella `utenti`
--

INSERT INTO `utenti` (`ID`, `nome`, `cognome`, `username`, `password`, `matricola`, `rappresentanteClasse`, `rappresentanteIstituto`, `ruolo`, `classeID`) VALUES
(2, 'Amir', 'Ghouzlani', 'amirxghz', 'Amir0246!gh', 'st10859', 0, 0, 'S', '5BM'),
(3, 'Admin', '', 'admin', 'admin123', NULL, 0, 0, 'A', NULL),
(4, 'diego', 'cappelloni', 'diegocap', 'diegocap', 'st24639', 1, 0, 'S', '5BM'),
(5, 'diego', 'stanziano', 'diegosta', 'diegosta', 'st28608', 1, 1, 'S', '5BM'),
(6, 'diego', 'd\'amico', 'diegoda', 'diegoda', 'st89592', 0, 0, 'S', '5BM'),
(7, 'francesco', 'yang', 'yanghi', 'yanhi123', 'st05850', 0, 0, 'A', NULL);

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
  MODIFY `IDaderire` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT per la tabella `attivita`
--
ALTER TABLE `attivita`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT per la tabella `eventi`
--
ALTER TABLE `eventi`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT per la tabella `indirizzi`
--
ALTER TABLE `indirizzi`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT per la tabella `utenti`
--
ALTER TABLE `utenti`
  MODIFY `ID` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

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
