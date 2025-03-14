IF DB_ID('PROGETTO2802') IS NULL
CREATE DATABASE PROGETTO2802;

USE PROGETTO2802;

CREATE TABLE Anagrafica (
    idAnagrafica INT IDENTITY(1,1) NOT NULL PRIMARY KEY , 
    Cognome NVARCHAR(50) NOT NULL,
    Nome NVARCHAR(50) NOT NULL,
    Indirizzo NVARCHAR(100),
    Città NVARCHAR(50),
    CAP NVARCHAR(5),
    Cod_Fisc CHAR(16) NOT NULL
);


CREATE TABLE TipoViolazione (
    idViolazione INT IDENTITY(1,1) NOT NULL PRIMARY KEY , 
    Descrizione NVARCHAR(255) NOT NULL
);


CREATE TABLE Verbale (
    idVerbale INT IDENTITY(1,1) NOT NULL PRIMARY KEY ,
    DataViolazione DATE NOT NULL,
    IndirizzoViolazione NVARCHAR(100),
    NominativoAgente NVARCHAR(100),
    DataTrascrizioneVerbale DATE NOT NULL,
    Importo DECIMAL(10,2) NOT NULL,
    DecurtamentoPunti INT,
    idAnagrafica INT, 
    idViolazione INT,
    FOREIGN KEY (idAnagrafica) REFERENCES Anagrafica (idAnagrafica),  
    FOREIGN KEY (idViolazione) REFERENCES TipoViolazione(idViolazione)  
);


INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Città, CAP, Cod_Fisc)
VALUES 
('Rossi', 'Mario', 'Via Roma, 10', 'Milano', '20100', 'RSSMRA80A01F205Z'),
('Bianchi', 'Luigi', 'Via Garibaldi, 5', 'Torino', '10121', 'BNCLGU85M01L219Z'),
('Verdi', 'Francesca', 'Via Manzoni, 18', 'Roma', '00184', 'VRDFNC90A41H501U'),
('Esposito', 'Giovanni', 'Via Dante, 22', 'Napoli', '80100', 'SPSGNN75C01F839Z'),
('Ferrari', 'Anna', 'Viale Europa, 3', 'Firenze', '50100', 'FRRNNN82T41G702W'),
('Russo', 'Carlo', 'Piazza Duomo, 5', 'Milano', '20100', 'RSSCRL60M01G273U'),
('Mariani', 'Elena', 'Via della Libertà, 45', 'Bologna', '40100', 'MRNLNE85P41B987X'),
('Conti', 'Michele', 'Via Mazzini, 50', 'Genova', '16121', 'CNTMHL74D01F839P'),
('De Luca', 'Alessandro', 'Via Verdi, 32', 'Venezia', '30100', 'DLCALS85M10C343N'),
('Gallo', 'Giulia', 'Via Milano, 14', 'Torino', '10121', 'GLLGLA79L41F205S'),
('Fontana', 'Luca', 'Via Vittorio Veneto, 9', 'Roma', '00184', 'FNTLUC88H01H501F'),
('Barbieri', 'Sofia', 'Via Emilia, 22', 'Bologna', '40100', 'BRBSOF90C51D548V'),
('Lombardi', 'Marco', 'Corso Italia, 18', 'Milano', '20100', 'LMBMRC85P01Z404V'),
('Ricci', 'Alessia', 'Via Garibaldi, 25', 'Milano', '20100', 'RCCLSS87S41G702Y'),
('Martini', 'Federico', 'Via dei Mille, 12', 'Bergamo', '06121', 'MRTFRC80A41E689N'),
('Costa', 'Lorenzo', 'Via dei Tigli, 7', 'Milano', '20100', 'CSTLRN78M41Z404Q'),
('Greco', 'Valentina', 'Piazza San Marco, 3', 'Milano', '20100', 'GRCVNT90T41L219J');

INSERT INTO Anagrafica (Cognome, Nome, Indirizzo, Città, CAP, Cod_Fisc)
VALUES 
('Mancuso', 'Salvatore', 'Via Libertà, 12', 'Palermo', '90100', 'MNCSVT85M01G273X'),
('Sorrentino', 'Giovanni', 'Via Notarbartolo, 20', 'Palermo', '90100', 'SRRGNN78H01H501F'),
('Di Marco', 'Caterina', 'Via Roma, 33', 'Palermo', '90100', 'DMRCTR90L41B157S'),
('Orlando', 'Andrea', 'Piazza Politeama, 8', 'Palermo', '90100', 'RLNDRN85C51G273Y'),
('Caruso', 'Giorgia', 'Via Principe di Belmonte, 15', 'Palermo', '90100', 'CRSGRG82T41F205Y'),
('Rizzo', 'Antonio', 'Via Lincoln, 19', 'Palermo', '90100', 'RZZNTN79M41G273N'),
('Ferraro', 'Paola', 'Via Ruggero Settimo, 40', 'Palermo', '90100', 'FRRPAL87A01Z404J'),
('Randazzo', 'Dario', 'Corso Calatafimi, 25', 'Palermo', '90100', 'RNDLDR88C51G273K');

INSERT INTO TipoViolazione (Descrizione)
VALUES 
('Eccesso di velocità'),
('Parcheggio in zona vietata'),
('Passaggio con semaforo rosso'),
('Sosta fuori orario'),
('Transito in ZTL'),
('Guida Pericolosa'),
('Guida in stato di ebbrezza');

INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, idAnagrafica, idViolazione)
VALUES 
('2025-01-10', 'Via Roma, 10', 'Agente Rossi', '2025-01-11', 150.00, 3, 1, 1),
('2025-01-15', 'Via Garibaldi, 5', 'Agente Bianchi', '2025-01-16', 80.00, 0, 2, 2),
('2025-01-20', 'Via Manzoni, 18', 'Agente Verdi', '2025-01-21', 200.00, 5, 3, 3),
('2025-01-25', 'Via Dante, 22', 'Agente Esposito', '2025-01-26', 100.00, 2, 4, 4),
('2025-02-01', 'Viale Europa, 3', 'Agente Ferrari', '2025-02-02', 50.00, 1, 5, 2),
('2025-02-05', 'Piazza Duomo, 5', 'Agente Russo', '2025-02-06', 300.00, 10, 6, 5),
('2025-02-10', 'Via della Libertà, 45', 'Agente Mariani', '2025-02-11', 120.00, 0, 7, 1),
('2025-02-12', 'Via Mazzini, 50', 'Agente Conti', '2025-02-13', 180.00, 3, 8, 3),
('2025-02-18', 'Via Verdi, 32', 'Agente De Luca', '2025-02-19', 60.00, 0, 9, 2),
('2025-02-20', 'Via Milano, 14', 'Agente Gallo', '2025-02-21', 90.00, 1, 10, 4),
('2025-02-25', 'Via Vittorio Veneto, 9', 'Agente Fontana', '2025-02-26', 250.00, 5, 11, 5),
('2025-02-28', 'Via Emilia, 22', 'Agente Barbieri', '2025-03-01', 70.00, 1, 12, 6),
('2025-03-05', 'Corso Italia, 18', 'Agente Lombardi', '2025-03-06', 220.00, 4, 13, 1),
('2025-03-10', 'Via Garibaldi, 25', 'Agente Ricci', '2025-03-11', 150.00, 2, 14, 3),
('2025-03-12', 'Via dei Mille, 12', 'Agente Martini', '2025-03-13', 130.00, 2, 15, 2),
('2025-03-15', 'Via dei Tigli, 7', 'Agente Costa', '2025-03-16', 50.00, 0, 16, 4),
('2025-03-17', 'Piazza San Marco, 3', 'Agente Greco', '2025-03-18', 500.00, 10, 17, 7),
('2025-03-20', 'Via Roma, 10', 'Agente Rossi', '2025-03-21', 90.00, 1, 1, 3),
('2025-03-22', 'Via Garibaldi, 5', 'Agente Bianchi', '2025-03-23', 70.00, 0, 2, 2),
('2025-03-25', 'Via Manzoni, 18', 'Agente Verdi', '2025-03-26', 180.00, 3, 3, 6),
('2025-03-28', 'Via Dante, 22', 'Agente Esposito', '2025-03-29', 220.00, 5, 4, 1),
('2025-04-01', 'Viale Europa, 3', 'Agente Ferrari', '2025-04-02', 160.00, 4, 5, 7),
('2025-04-05', 'Piazza Duomo, 5', 'Agente Russo', '2025-04-06', 100.00, 2, 6, 3),
('2025-04-10', 'Via della Libertà, 45', 'Agente Mariani', '2025-04-11', 60.00, 0, 7, 4),
('2025-04-15', 'Via Mazzini, 50', 'Agente Conti', '2025-04-16', 120.00, 1, 8, 5);

INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, idAnagrafica, idViolazione)
VALUES 
('2009-02-10', 'Via Roma, 10', 'Agente Rossi', '2009-02-11', 180.00, 4, 1, 2),
('2009-02-20', 'Via Garibaldi, 5', 'Agente Bianchi', '2009-02-21', 120.00, 2, 2, 1),
('2009-03-05', 'Via Manzoni, 18', 'Agente Verdi', '2009-03-06', 200.00, 5, 3, 3),
('2009-03-12', 'Via Dante, 22', 'Agente Esposito', '2009-03-13', 80.00, 1, 4, 2),
('2009-03-22', 'Viale Europa, 3', 'Agente Ferrari', '2009-03-23', 90.00, 0, 5, 4),
('2009-04-01', 'Piazza Duomo, 5', 'Agente Russo', '2009-04-02', 250.00, 6, 6, 5);

INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti, idAnagrafica, idViolazione)
VALUES 

('2009-04-01', 'Piazza Duomo, 5', 'Agente Russo', '2009-04-02', 250.00, 6, 25, 5);

--QUERY ESERCIZIO--

--1
SELECT COUNT(*) AS TotVerbaliTrascritti FROM Verbale;

--2
SELECT A.Cognome, A.Nome, COUNT(V.idVerbale) AS VerbaliTrascritti
FROM Verbale V
INNER JOIN Anagrafica A ON V.idAnagrafica = A.idAnagrafica
GROUP BY A.Cognome, A.Nome
ORDER BY VerbaliTrascritti DESC;

--3
SELECT TV.Descrizione, COUNT(V.idVerbale) AS VerbaliTrascritti
FROM Verbale V
INNER JOIN TipoViolazione TV ON V.idViolazione = TV.idViolazione
GROUP BY TV.Descrizione
ORDER BY VerbaliTrascritti DESC;

--4
SELECT A.Cognome, A.Nome, SUM(V.DecurtamentoPunti) AS TotPuntiDecurtati
FROM Verbale V
INNER JOIN Anagrafica A ON V.idAnagrafica = A.idAnagrafica
GROUP BY A.Cognome, A.Nome
ORDER BY TotPuntiDecurtati DESC;

--5

SELECT A.Cognome, A.Nome, V.DataViolazione, V.IndirizzoViolazione, V.Importo, V.DecurtamentoPunti
FROM Anagrafica A
INNER JOIN Verbale V ON A.idAnagrafica = V.idAnagrafica
WHERE A.Città = 'Palermo';


--6
SELECT A.Cognome, A.Nome, A.Indirizzo, V.DataViolazione, V.Importo, V.DecurtamentoPunti
FROM Anagrafica A
INNER JOIN Verbale V ON A.idAnagrafica = V.idAnagrafica
WHERE V.DataViolazione BETWEEN '2009-02-01' AND '2009-07-31';

--7
SELECT A.Cognome, A.Nome, SUM(V.Importo) AS TotaleImporto
FROM Anagrafica A
INNER JOIN Verbale V ON A.idAnagrafica = V.idAnagrafica
GROUP BY A.Cognome, A.Nome, A.idAnagrafica
ORDER BY TotaleImporto DESC;

--8
SELECT Cognome, Nome, Indirizzo, Città, CAP, Cod_Fisc 
FROM Anagrafica
WHERE Città = 'Palermo';

--9
SELECT DataViolazione, Importo, DecurtamentoPunti
FROM Verbale
WHERE DataViolazione = '2025-02-28';

SELECT DataViolazione, Importo, DecurtamentoPunti
FROM Verbale
WHERE DataViolazione = '2025-03-10';

SELECT DataViolazione, Importo, DecurtamentoPunti
FROM Verbale
WHERE DataViolazione = '2025-03-12';



--10
SELECT NominativoAgente, COUNT(*) AS NumeroViolazioni
FROM Verbale
GROUP BY NominativoAgente
ORDER BY NumeroViolazioni DESC;

--11
SELECT A.Cognome, A.Nome, A.Indirizzo, V.DataViolazione, V.Importo, V.DecurtamentoPunti
FROM Verbale V
INNER JOIN Anagrafica A ON V.idAnagrafica = A.idAnagrafica
WHERE V.DecurtamentoPunti > 5;

--12
SELECT A.Cognome, A.Nome, A.Indirizzo, V.DataViolazione, V.Importo, V.DecurtamentoPunti
FROM Verbale V
INNER JOIN Anagrafica A ON V.idAnagrafica = A.idAnagrafica
WHERE V.Importo > 400;


--EXTRA

--13
SELECT V.NominativoAgente, COUNT(V.idVerbale) AS NumeroVerbali, SUM(V.Importo) AS ImportoTotale
FROM Verbale V
GROUP BY V.NominativoAgente;

--14
SELECT T.Descrizione AS TipoViolazione, AVG(V.Importo) AS MediaImporto
FROM Verbale V
INNER JOIN TipoViolazione T ON V.idViolazione = T.idViolazione
GROUP BY T.Descrizione;


