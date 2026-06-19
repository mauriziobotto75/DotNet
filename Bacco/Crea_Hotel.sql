USE Hotel;
 CREATE TABLE Clienti (
    Id INT IDENTITY PRIMARY KEY,
    Nome NVARCHAR(50),
    Cognome NVARCHAR(50),
    Email NVARCHAR(100),
    Telefono NVARCHAR(20),
    Documento NVARCHAR(50)
);
CREATE TABLE Camere (
    Id INT IDENTITY PRIMARY KEY,
    Numero NVARCHAR(10),
    Tipo NVARCHAR(50), -- singola, doppia
    Prezzo DECIMAL(10,2),
    Stato NVARCHAR(20) -- libera, occupata
);
CREATE TABLE Prenotazioni (
    Id INT IDENTITY PRIMARY KEY,
    ClienteId INT,
    CameraId INT,
    DataArrivo DATE,
    DataPartenza DATE,

    FOREIGN KEY (ClienteId) REFERENCES Clienti(Id),
    FOREIGN KEY (CameraId) REFERENCES Camere(Id)
);
CREATE TABLE Comande (
    Id INT IDENTITY PRIMARY KEY,
    ClienteId INT,
    CameraId INT,
    Data DATETIME,
    Stato NVARCHAR(20), -- aperta, chiusa

    FOREIGN KEY (ClienteId) REFERENCES Clienti(Id),
    FOREIGN KEY (CameraId) REFERENCES Camere(Id)
);
CREATE TABLE ComandeDettagli (
    Id INT IDENTITY PRIMARY KEY,
    ComandaId INT,
    Descrizione NVARCHAR(100),
    Quantita INT,
    Prezzo DECIMAL(10,2),

    FOREIGN KEY (ComandaId) REFERENCES Comande(Id)
);
CREATE TABLE Pagamenti (
    Id INT IDENTITY PRIMARY KEY,
    ComandaId INT,
    Totale DECIMAL(10,2),
    Sconto DECIMAL(5,2),
    Netto DECIMAL(10,2),
    Contanti DECIMAL(10,2),
    Carta DECIMAL(10,2),
    Resto DECIMAL(10,2),

    FOREIGN KEY (ComandaId) REFERENCES Comande(Id)
);
CREATE TABLE Listini (
    Id INT IDENTITY PRIMARY KEY,
    TipoCamera NVARCHAR(50),
    DataInizio DATE,
    DataFine DATE,
    Prezzo DECIMAL(10,2)
);
CREATE TABLE Agenzie (
    Id INT IDENTITY PRIMARY KEY,
    Nome NVARCHAR(100)
);
CREATE TABLE Allotment (
    Id INT IDENTITY PRIMARY KEY,
    AgenziaId INT,
    CameraId INT,
    DataInizio DATE,
    DataFine DATE,
    Disponibilita INT,

    FOREIGN KEY (AgenziaId) REFERENCES Agenzie(Id),
    FOREIGN KEY (CameraId) REFERENCES Camere(Id)
);
