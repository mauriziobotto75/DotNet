-- Create Database DYNNER
CREATE DATABASE DYNNER;
GO

USE DYNNER;
GO

-- Create Tables
CREATE TABLE Sale (
    IdSala INT IDENTITY PRIMARY KEY,
    Nome VARCHAR(50),
    Descrizione VARCHAR(100)
);

CREATE TABLE Tavoli (
    IdTavolo INT IDENTITY PRIMARY KEY,
    IdSala INT,
    NumeroTavolo INT,
    Coperti INT,
    Stato VARCHAR(20), -- Libero, Occupato, Prenotato
    FOREIGN KEY (IdSala) REFERENCES Sale(IdSala)
);

CREATE TABLE Clienti (
    IdCliente INT IDENTITY PRIMARY KEY,
    Nome VARCHAR(50),
    Cognome VARCHAR(50),
    Telefono VARCHAR(20)
);

CREATE TABLE Prenotazioni (
    IdPrenotazione INT IDENTITY PRIMARY KEY,
    IdCliente INT,
    DataPrenotazione DATETIME,
    NumeroPersone INT,
    Note VARCHAR(200),
    FOREIGN KEY (IdCliente) REFERENCES Clienti(IdCliente)
);

CREATE TABLE Prenotazioni_Tavoli (
    Id INT IDENTITY PRIMARY KEY,
    IdPrenotazione INT,
    IdTavolo INT,
    FOREIGN KEY (IdPrenotazione) REFERENCES Prenotazioni(IdPrenotazione),
    FOREIGN KEY (IdTavolo) REFERENCES Tavoli(IdTavolo)
);

CREATE TABLE Prodotti (
    IdProdotto INT IDENTITY PRIMARY KEY,
    Nome VARCHAR(100),
    Categoria VARCHAR(50),
    Prezzo DECIMAL(10,2),
    Attivo BIT
);

CREATE TABLE Menu (
    IdMenu INT IDENTITY PRIMARY KEY,
    Nome VARCHAR(50),
    DataInizio DATE,
    DataFine DATE
);

CREATE TABLE Menu_Prodotti (
    Id INT IDENTITY PRIMARY KEY,
    IdMenu INT,
    IdProdotto INT,
    FOREIGN KEY (IdMenu) REFERENCES Menu(IdMenu),
    FOREIGN KEY (IdProdotto) REFERENCES Prodotti(IdProdotto)
);

CREATE TABLE Comande (
    IdComanda INT IDENTITY PRIMARY KEY,
    IdTavolo INT NULL,
    Tipo VARCHAR(20), -- Sala / TakeAway
    DataApertura DATETIME,
    Stato VARCHAR(20), -- Aperta, Chiusa, Pagata
    NomeTakeAway VARCHAR(50), -- se asporto
    FOREIGN KEY (IdTavolo) REFERENCES Tavoli(IdTavolo)
);

CREATE TABLE Comande_Dettaglio (
    IdDettaglio INT IDENTITY PRIMARY KEY,
    IdComanda INT,
    IdProdotto INT,
    Quantita INT,
    Prezzo DECIMAL(10,2),
    Note VARCHAR(200),
    FOREIGN KEY (IdComanda) REFERENCES Comande(IdComanda),
    FOREIGN KEY (IdProdotto) REFERENCES Prodotti(IdProdotto)
);

CREATE TABLE TipiPagamento (
    IdTipo INT IDENTITY PRIMARY KEY,
    Descrizione VARCHAR(50) -- Contanti, Carta, Ticket
);

CREATE TABLE Pagamenti (
    IdPagamento INT IDENTITY PRIMARY KEY,
    IdComanda INT,
    IdTipo INT,
    Importo DECIMAL(10,2),
    DataPagamento DATETIME,
    FOREIGN KEY (IdComanda) REFERENCES Comande(IdComanda),
    FOREIGN KEY (IdTipo) REFERENCES TipiPagamento(IdTipo)
);

CREATE TABLE TakeAway (
    IdTakeAway INT IDENTITY PRIMARY KEY,
    IdComanda INT,
    OrarioRitiro DATETIME,
    NomeCliente VARCHAR(50),
    FOREIGN KEY (IdComanda) REFERENCES Comande(IdComanda)
);

CREATE TABLE ReportGiornaliero (
    IdReport INT IDENTITY PRIMARY KEY,
    Data DATE,
    TotaleIncassi DECIMAL(10,2),
    NumeroComande INT
);

-- Create Indexes
CREATE INDEX IX_Comande_Data ON Comande(DataApertura);
CREATE INDEX IX_Prodotti_Nome ON Prodotti(Nome);
CREATE INDEX IX_Tavoli_Sala ON Tavoli(IdSala);
