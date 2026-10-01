IF DB_ID(N'FashionUp') IS NULL
BEGIN
    CREATE DATABASE FashionUp;
END;
GO

USE FashionUp;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET ARITHABORT ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET NUMERIC_ROUNDABORT OFF;
GO

IF OBJECT_ID(N'dbo.Articles', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Articles
    (
        ArticleId       int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Articles PRIMARY KEY,
        ArticleCode     nvarchar(40) NOT NULL CONSTRAINT UQ_Articles_ArticleCode UNIQUE,
        Description     nvarchar(200) NOT NULL,
        Brand           nvarchar(80) NULL,
        Season          nvarchar(30) NULL,
        BaseSalePrice   decimal(18,2) NOT NULL CONSTRAINT DF_Articles_BaseSalePrice DEFAULT (0),
        IsActive        bit NOT NULL CONSTRAINT DF_Articles_IsActive DEFAULT (1),
        CreatedAt       datetime2(0) NOT NULL CONSTRAINT DF_Articles_CreatedAt DEFAULT (sysdatetime()),
        CONSTRAINT CK_Articles_BaseSalePrice CHECK (BaseSalePrice >= 0)
    );

    CREATE TABLE dbo.Sizes
    (
        SizeId       int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Sizes PRIMARY KEY,
        SizeGroup    nvarchar(40) NOT NULL,
        SizeCode     nvarchar(30) NOT NULL,
        SortOrder    int NOT NULL CONSTRAINT DF_Sizes_SortOrder DEFAULT (0),
        CONSTRAINT UQ_Sizes_Group_Code UNIQUE (SizeGroup, SizeCode)
    );

    CREATE TABLE dbo.Colors
    (
        ColorId      int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Colors PRIMARY KEY,
        ColorGroup   nvarchar(40) NOT NULL,
        ColorName    nvarchar(60) NOT NULL,
        ColorCode    nvarchar(20) NULL,
        CONSTRAINT UQ_Colors_Group_Name UNIQUE (ColorGroup, ColorName)
    );

    CREATE TABLE dbo.Variants
    (
        VariantId    int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Variants PRIMARY KEY,
        ArticleId    int NOT NULL,
        SizeId       int NULL,
        ColorId      int NULL,
        VariantCode  nvarchar(60) NOT NULL CONSTRAINT UQ_Variants_VariantCode UNIQUE,
        VariantKey   AS (concat(isnull(convert(varchar(12), SizeId), '0'), ':', isnull(convert(varchar(12), ColorId), '0'))) PERSISTED,
        IsActive     bit NOT NULL CONSTRAINT DF_Variants_IsActive DEFAULT (1),
        CONSTRAINT FK_Variants_Articles FOREIGN KEY (ArticleId) REFERENCES dbo.Articles (ArticleId),
        CONSTRAINT FK_Variants_Sizes FOREIGN KEY (SizeId) REFERENCES dbo.Sizes (SizeId),
        CONSTRAINT FK_Variants_Colors FOREIGN KEY (ColorId) REFERENCES dbo.Colors (ColorId),
        CONSTRAINT UQ_Variants_Article_VariantKey UNIQUE (ArticleId, VariantKey)
    );

    CREATE TABLE dbo.Parties
    (
        PartyId       int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Parties PRIMARY KEY,
        PartyCode     nvarchar(30) NOT NULL CONSTRAINT UQ_Parties_PartyCode UNIQUE,
        Role          char(1) NOT NULL,
        CompanyName   nvarchar(200) NOT NULL,
        TaxCode       nvarchar(30) NULL,
        Email         nvarchar(254) NULL,
        Phone         nvarchar(40) NULL,
        IsActive      bit NOT NULL CONSTRAINT DF_Parties_IsActive DEFAULT (1),
        CreatedAt     datetime2(0) NOT NULL CONSTRAINT DF_Parties_CreatedAt DEFAULT (sysdatetime()),
        CONSTRAINT CK_Parties_Role CHECK (Role IN ('C', 'F', 'E'))
    );

    CREATE TABLE dbo.Warehouses
    (
        WarehouseId    int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Warehouses PRIMARY KEY,
        WarehouseCode  nvarchar(20) NOT NULL CONSTRAINT UQ_Warehouses_WarehouseCode UNIQUE,
        WarehouseName  nvarchar(80) NOT NULL,
        IsActive       bit NOT NULL CONSTRAINT DF_Warehouses_IsActive DEFAULT (1)
    );

    CREATE TABLE dbo.Barcodes
    (
        BarcodeId    int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Barcodes PRIMARY KEY,
        VariantId    int NOT NULL,
        Barcode      nvarchar(80) NOT NULL CONSTRAINT UQ_Barcodes_Barcode UNIQUE,
        CreatedAt    datetime2(0) NOT NULL CONSTRAINT DF_Barcodes_CreatedAt DEFAULT (sysdatetime()),
        CONSTRAINT FK_Barcodes_Variants FOREIGN KEY (VariantId) REFERENCES dbo.Variants (VariantId)
    );

    CREATE TABLE dbo.PriceLists
    (
        PriceListId  int IDENTITY(1,1) NOT NULL CONSTRAINT PK_PriceLists PRIMARY KEY,
        ListName     nvarchar(80) NOT NULL CONSTRAINT UQ_PriceLists_ListName UNIQUE,
        CurrencyCode char(3) NOT NULL CONSTRAINT DF_PriceLists_CurrencyCode DEFAULT ('EUR'),
        ValidFrom    date NOT NULL CONSTRAINT DF_PriceLists_ValidFrom DEFAULT (convert(date, getdate())),
        ValidTo      date NULL,
        IsActive     bit NOT NULL CONSTRAINT DF_PriceLists_IsActive DEFAULT (1),
        CONSTRAINT CK_PriceLists_Validity CHECK (ValidTo IS NULL OR ValidTo >= ValidFrom)
    );

    CREATE TABLE dbo.PriceListLines
    (
        PriceListId  int NOT NULL,
        VariantId    int NOT NULL,
        UnitPrice    decimal(18,2) NOT NULL,
        CONSTRAINT PK_PriceListLines PRIMARY KEY (PriceListId, VariantId),
        CONSTRAINT FK_PriceListLines_PriceLists FOREIGN KEY (PriceListId) REFERENCES dbo.PriceLists (PriceListId),
        CONSTRAINT FK_PriceListLines_Variants FOREIGN KEY (VariantId) REFERENCES dbo.Variants (VariantId),
        CONSTRAINT CK_PriceListLines_UnitPrice CHECK (UnitPrice >= 0)
    );

    CREATE TABLE dbo.Documents
    (
        DocumentId    int IDENTITY(1,1) NOT NULL CONSTRAINT PK_Documents PRIMARY KEY,
        DocumentType  char(1) NOT NULL,
        DocumentNumber nvarchar(40) NOT NULL,
        DocumentDate  date NOT NULL,
        PartyId       int NOT NULL,
        WarehouseId   int NOT NULL,
        Status        char(1) NOT NULL CONSTRAINT DF_Documents_Status DEFAULT ('D'),
        CreatedAt     datetime2(0) NOT NULL CONSTRAINT DF_Documents_CreatedAt DEFAULT (sysdatetime()),
        PostedAt      datetime2(0) NULL,
        CONSTRAINT UQ_Documents_Type_Number UNIQUE (DocumentType, DocumentNumber),
        CONSTRAINT FK_Documents_Parties FOREIGN KEY (PartyId) REFERENCES dbo.Parties (PartyId),
        CONSTRAINT FK_Documents_Warehouses FOREIGN KEY (WarehouseId) REFERENCES dbo.Warehouses (WarehouseId),
        CONSTRAINT CK_Documents_Type CHECK (DocumentType IN ('V', 'A')),
        CONSTRAINT CK_Documents_Status CHECK (Status IN ('D', 'R')),
        CONSTRAINT CK_Documents_PostedAt CHECK ((Status = 'D' AND PostedAt IS NULL) OR (Status = 'R' AND PostedAt IS NOT NULL))
    );

    CREATE TABLE dbo.DocumentLines
    (
        DocumentLineId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_DocumentLines PRIMARY KEY,
        DocumentId     int NOT NULL,
        VariantId      int NOT NULL,
        Quantity       decimal(18,3) NOT NULL,
        UnitPrice      decimal(18,2) NOT NULL,
        CONSTRAINT FK_DocumentLines_Documents FOREIGN KEY (DocumentId) REFERENCES dbo.Documents (DocumentId),
        CONSTRAINT FK_DocumentLines_Variants FOREIGN KEY (VariantId) REFERENCES dbo.Variants (VariantId),
        CONSTRAINT CK_DocumentLines_Quantity CHECK (Quantity > 0),
        CONSTRAINT CK_DocumentLines_UnitPrice CHECK (UnitPrice >= 0)
    );

    CREATE TABLE dbo.Inventory
    (
        VariantId        int NOT NULL,
        WarehouseId      int NOT NULL,
        QuantityOnHand   decimal(18,3) NOT NULL CONSTRAINT DF_Inventory_Quantity DEFAULT (0),
        UpdatedAt        datetime2(0) NOT NULL CONSTRAINT DF_Inventory_UpdatedAt DEFAULT (sysdatetime()),
        CONSTRAINT PK_Inventory PRIMARY KEY (VariantId, WarehouseId),
        CONSTRAINT FK_Inventory_Variants FOREIGN KEY (VariantId) REFERENCES dbo.Variants (VariantId),
        CONSTRAINT FK_Inventory_Warehouses FOREIGN KEY (WarehouseId) REFERENCES dbo.Warehouses (WarehouseId),
        CONSTRAINT CK_Inventory_Quantity CHECK (QuantityOnHand >= 0)
    );

    CREATE TABLE dbo.StockMovements
    (
        StockMovementId  bigint IDENTITY(1,1) NOT NULL CONSTRAINT PK_StockMovements PRIMARY KEY,
        VariantId        int NOT NULL,
        WarehouseId      int NOT NULL,
        DocumentLineId   int NULL,
        MovementDate     datetime2(0) NOT NULL CONSTRAINT DF_StockMovements_MovementDate DEFAULT (sysdatetime()),
        QuantityDelta    decimal(18,3) NOT NULL,
        Reason           nvarchar(200) NOT NULL,
        CONSTRAINT FK_StockMovements_Variants FOREIGN KEY (VariantId) REFERENCES dbo.Variants (VariantId),
        CONSTRAINT FK_StockMovements_Warehouses FOREIGN KEY (WarehouseId) REFERENCES dbo.Warehouses (WarehouseId),
        CONSTRAINT FK_StockMovements_DocumentLines FOREIGN KEY (DocumentLineId) REFERENCES dbo.DocumentLines (DocumentLineId),
        CONSTRAINT CK_StockMovements_Quantity CHECK (QuantityDelta <> 0)
    );

    CREATE UNIQUE INDEX UX_StockMovements_DocumentLine
        ON dbo.StockMovements (DocumentLineId)
        WHERE DocumentLineId IS NOT NULL;

    CREATE INDEX IX_DocumentLines_DocumentId ON dbo.DocumentLines (DocumentId);
    CREATE INDEX IX_StockMovements_Variant_Warehouse_Date ON dbo.StockMovements (VariantId, WarehouseId, MovementDate);

    INSERT dbo.Warehouses (WarehouseCode, WarehouseName) VALUES (N'MAIN', N'Deposito principale');
END;
GO

CREATE OR ALTER VIEW dbo.v_VariantCatalog
AS
    SELECT
        v.VariantId,
        a.ArticleId,
        a.ArticleCode,
        a.Description AS ArticleDescription,
        a.Brand,
        a.Season,
        v.VariantCode,
        s.SizeCode AS SizeName,
        s.SortOrder AS SizeSortOrder,
        c.ColorName,
        a.BaseSalePrice,
        b.Barcode,
        v.IsActive
    FROM dbo.Variants AS v
    INNER JOIN dbo.Articles AS a ON a.ArticleId = v.ArticleId
    LEFT JOIN dbo.Sizes AS s ON s.SizeId = v.SizeId
    LEFT JOIN dbo.Colors AS c ON c.ColorId = v.ColorId
    OUTER APPLY
    (
        SELECT TOP (1) bc.Barcode
        FROM dbo.Barcodes AS bc
        WHERE bc.VariantId = v.VariantId
        ORDER BY bc.BarcodeId
    ) AS b;
GO

CREATE OR ALTER VIEW dbo.v_Stock
AS
    SELECT
        i.VariantId,
        a.ArticleCode,
        v.VariantCode,
        a.Description AS ArticleDescription,
        s.SizeCode AS SizeName,
        c.ColorName,
        w.WarehouseId,
        w.WarehouseName,
        ISNULL(i.QuantityOnHand, CONVERT(decimal(18,3), 0)) AS QuantityOnHand,
        i.UpdatedAt
    FROM dbo.Variants AS v
    INNER JOIN dbo.Articles AS a ON a.ArticleId = v.ArticleId
    CROSS JOIN dbo.Warehouses AS w
    LEFT JOIN dbo.Inventory AS i ON i.VariantId = v.VariantId AND i.WarehouseId = w.WarehouseId
    LEFT JOIN dbo.Sizes AS s ON s.SizeId = v.SizeId
    LEFT JOIN dbo.Colors AS c ON c.ColorId = v.ColorId;
GO

CREATE OR ALTER VIEW dbo.v_DocumentSummary
AS
    SELECT
        d.DocumentId,
        d.DocumentType,
        d.DocumentNumber,
        d.DocumentDate,
        p.CompanyName,
        d.Status,
        CONVERT(decimal(18,2), ISNULL(t.TotalAmount, 0)) AS TotalAmount
    FROM dbo.Documents AS d
    INNER JOIN dbo.Parties AS p ON p.PartyId = d.PartyId
    OUTER APPLY
    (
        SELECT SUM(CONVERT(decimal(28,5), dl.Quantity) * dl.UnitPrice) AS TotalAmount
        FROM dbo.DocumentLines AS dl
        WHERE dl.DocumentId = d.DocumentId
    ) AS t;
GO

CREATE OR ALTER VIEW dbo.v_SalesStatistics
AS
    SELECT
        CONVERT(char(7), d.DocumentDate, 126) AS SalesMonth,
        a.ArticleCode,
        a.Description AS ArticleDescription,
        v.VariantCode,
        s.SizeCode AS SizeName,
        c.ColorName,
        SUM(dl.Quantity) AS QuantitySold,
        CONVERT(decimal(18,2), SUM(CONVERT(decimal(28,5), dl.Quantity) * dl.UnitPrice)) AS SalesAmount
    FROM dbo.Documents AS d
    INNER JOIN dbo.DocumentLines AS dl ON dl.DocumentId = d.DocumentId
    INNER JOIN dbo.Variants AS v ON v.VariantId = dl.VariantId
    INNER JOIN dbo.Articles AS a ON a.ArticleId = v.ArticleId
    LEFT JOIN dbo.Sizes AS s ON s.SizeId = v.SizeId
    LEFT JOIN dbo.Colors AS c ON c.ColorId = v.ColorId
    WHERE d.DocumentType = 'V' AND d.Status = 'R'
    GROUP BY CONVERT(char(7), d.DocumentDate, 126), a.ArticleCode, a.Description, v.VariantCode, s.SizeCode, c.ColorName;
GO

CREATE OR ALTER PROCEDURE dbo.usp_CreateVariant
    @ArticleCode nvarchar(40),
    @VariantCode nvarchar(60),
    @SizeCode nvarchar(30) = NULL,
    @ColorName nvarchar(60) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @ArticleId int, @SizeId int = NULL, @ColorId int = NULL;

    BEGIN TRY
        BEGIN TRANSACTION;

        SELECT @ArticleId = ArticleId
        FROM dbo.Articles WITH (UPDLOCK, HOLDLOCK)
        WHERE ArticleCode = @ArticleCode AND IsActive = 1;

        IF @ArticleId IS NULL
            THROW 51001, 'Articolo padre inesistente o non attivo.', 1;

        IF NULLIF(LTRIM(RTRIM(@SizeCode)), N'') IS NOT NULL
        BEGIN
            SELECT @SizeId = SizeId FROM dbo.Sizes WITH (UPDLOCK, HOLDLOCK)
            WHERE SizeGroup = N'Standard' AND SizeCode = @SizeCode;

            IF @SizeId IS NULL
            BEGIN
                INSERT dbo.Sizes (SizeGroup, SizeCode) VALUES (N'Standard', @SizeCode);
                SET @SizeId = CONVERT(int, SCOPE_IDENTITY());
            END;
        END;

        IF NULLIF(LTRIM(RTRIM(@ColorName)), N'') IS NOT NULL
        BEGIN
            SELECT @ColorId = ColorId FROM dbo.Colors WITH (UPDLOCK, HOLDLOCK)
            WHERE ColorGroup = N'Standard' AND ColorName = @ColorName;

            IF @ColorId IS NULL
            BEGIN
                INSERT dbo.Colors (ColorGroup, ColorName) VALUES (N'Standard', @ColorName);
                SET @ColorId = CONVERT(int, SCOPE_IDENTITY());
            END;
        END;

        INSERT dbo.Variants (ArticleId, SizeId, ColorId, VariantCode)
        VALUES (@ArticleId, @SizeId, @ColorId, @VariantCode);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_AddDocumentLine
    @DocumentId int,
    @VariantId int,
    @Quantity decimal(18,3),
    @UnitPrice decimal(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRY
        BEGIN TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM dbo.Documents WITH (UPDLOCK, HOLDLOCK) WHERE DocumentId = @DocumentId AND Status = 'D')
            THROW 51002, 'Documento non trovato o non piu'' modificabile.', 1;
        IF NOT EXISTS (SELECT 1 FROM dbo.Variants WHERE VariantId = @VariantId AND IsActive = 1)
            THROW 51003, 'Variante inesistente o non attiva.', 1;
        IF @Quantity <= 0 OR @UnitPrice < 0
            THROW 51004, 'Quantita'' e prezzo non validi.', 1;

        INSERT dbo.DocumentLines (DocumentId, VariantId, Quantity, UnitPrice)
        VALUES (@DocumentId, @VariantId, @Quantity, @UnitPrice);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_PostDocument
    @DocumentId int
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @DocumentType char(1), @WarehouseId int, @Status char(1);
    DECLARE @VariantId int, @Quantity decimal(18,3), @Current decimal(18,3), @Delta decimal(18,3);
    DECLARE line_cursor CURSOR LOCAL FAST_FORWARD FOR
        SELECT VariantId, SUM(Quantity)
        FROM dbo.DocumentLines
        WHERE DocumentId = @DocumentId
        GROUP BY VariantId
        ORDER BY VariantId;

    BEGIN TRY
        BEGIN TRANSACTION;

        SELECT @DocumentType = DocumentType, @WarehouseId = WarehouseId, @Status = Status
        FROM dbo.Documents WITH (UPDLOCK, HOLDLOCK)
        WHERE DocumentId = @DocumentId;

        IF @DocumentType IS NULL
            THROW 51005, 'Documento non trovato.', 1;
        IF @Status <> 'D'
            THROW 51006, 'Il documento e'' gia'' stato registrato.', 1;
        IF NOT EXISTS (SELECT 1 FROM dbo.DocumentLines WHERE DocumentId = @DocumentId)
            THROW 51007, 'Aggiungere almeno una riga prima di registrare il documento.', 1;
        IF (@DocumentType = 'V' AND NOT EXISTS (SELECT 1 FROM dbo.Documents d JOIN dbo.Parties p ON p.PartyId = d.PartyId WHERE d.DocumentId = @DocumentId AND p.Role IN ('C', 'E')))
           OR (@DocumentType = 'A' AND NOT EXISTS (SELECT 1 FROM dbo.Documents d JOIN dbo.Parties p ON p.PartyId = d.PartyId WHERE d.DocumentId = @DocumentId AND p.Role IN ('F', 'E')))
            THROW 51008, 'Il ruolo cliente/fornitore non e'' coerente con il documento.', 1;

        OPEN line_cursor;
        FETCH NEXT FROM line_cursor INTO @VariantId, @Quantity;

        WHILE @@FETCH_STATUS = 0
        BEGIN
            SET @Current = NULL;
            SELECT @Current = QuantityOnHand
            FROM dbo.Inventory WITH (UPDLOCK, HOLDLOCK)
            WHERE VariantId = @VariantId AND WarehouseId = @WarehouseId;

            SET @Delta = CASE WHEN @DocumentType = 'A' THEN @Quantity ELSE -@Quantity END;
            IF @Current IS NULL
            BEGIN
                IF @Delta < 0
                    THROW 51009, 'Giacenza insufficiente per registrare la vendita.', 1;
                INSERT dbo.Inventory (VariantId, WarehouseId, QuantityOnHand)
                VALUES (@VariantId, @WarehouseId, @Delta);
            END
            ELSE
            BEGIN
                IF @Current + @Delta < 0
                    THROW 51009, 'Giacenza insufficiente per registrare la vendita.', 1;
                UPDATE dbo.Inventory
                SET QuantityOnHand = QuantityOnHand + @Delta, UpdatedAt = sysdatetime()
                WHERE VariantId = @VariantId AND WarehouseId = @WarehouseId;
            END;

            FETCH NEXT FROM line_cursor INTO @VariantId, @Quantity;
        END;

        CLOSE line_cursor;
        DEALLOCATE line_cursor;

        INSERT dbo.StockMovements (VariantId, WarehouseId, DocumentLineId, QuantityDelta, Reason)
        SELECT dl.VariantId, @WarehouseId, dl.DocumentLineId,
               CASE WHEN @DocumentType = 'A' THEN dl.Quantity ELSE -dl.Quantity END,
               CASE WHEN @DocumentType = 'A' THEN N'Carico da acquisto' ELSE N'Scarico da vendita' END
        FROM dbo.DocumentLines AS dl
        WHERE dl.DocumentId = @DocumentId;

        UPDATE dbo.Documents
        SET Status = 'R', PostedAt = sysdatetime()
        WHERE DocumentId = @DocumentId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF CURSOR_STATUS('local', 'line_cursor') >= 0 CLOSE line_cursor;
        IF CURSOR_STATUS('local', 'line_cursor') > -3 DEALLOCATE line_cursor;
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_AdjustStock
    @VariantId int,
    @WarehouseId int,
    @QuantityDelta decimal(18,3),
    @Reason nvarchar(200)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @Current decimal(18,3);
    IF @QuantityDelta = 0 THROW 51010, 'La rettifica deve essere diversa da zero.', 1;

    BEGIN TRY
        BEGIN TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM dbo.Variants WHERE VariantId = @VariantId AND IsActive = 1)
            THROW 51011, 'Variante inesistente o non attiva.', 1;
        IF NOT EXISTS (SELECT 1 FROM dbo.Warehouses WHERE WarehouseId = @WarehouseId AND IsActive = 1)
            THROW 51012, 'Deposito inesistente o non attivo.', 1;

        SET @Current = NULL;
        SELECT @Current = QuantityOnHand FROM dbo.Inventory WITH (UPDLOCK, HOLDLOCK)
        WHERE VariantId = @VariantId AND WarehouseId = @WarehouseId;

        IF @Current IS NULL
        BEGIN
            IF @QuantityDelta < 0 THROW 51013, 'Giacenza insufficiente per la rettifica.', 1;
            INSERT dbo.Inventory (VariantId, WarehouseId, QuantityOnHand)
            VALUES (@VariantId, @WarehouseId, @QuantityDelta);
        END
        ELSE
        BEGIN
            IF @Current + @QuantityDelta < 0 THROW 51013, 'Giacenza insufficiente per la rettifica.', 1;
            UPDATE dbo.Inventory
            SET QuantityOnHand = QuantityOnHand + @QuantityDelta, UpdatedAt = sysdatetime()
            WHERE VariantId = @VariantId AND WarehouseId = @WarehouseId;
        END;

        INSERT dbo.StockMovements (VariantId, WarehouseId, QuantityDelta, Reason)
        VALUES (@VariantId, @WarehouseId, @QuantityDelta, @Reason);
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_SetVariantPrice
    @PriceListId int,
    @VariantId int,
    @UnitPrice decimal(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    IF @UnitPrice < 0 THROW 51014, 'Il prezzo non puo'' essere negativo.', 1;

    BEGIN TRY
        BEGIN TRANSACTION;
        IF NOT EXISTS (SELECT 1 FROM dbo.PriceLists WITH (UPDLOCK, HOLDLOCK) WHERE PriceListId = @PriceListId AND IsActive = 1)
            THROW 51015, 'Listino inesistente o non attivo.', 1;
        IF NOT EXISTS (SELECT 1 FROM dbo.Variants WHERE VariantId = @VariantId AND IsActive = 1)
            THROW 51016, 'Variante inesistente o non attiva.', 1;

        UPDATE dbo.PriceListLines WITH (UPDLOCK, SERIALIZABLE)
        SET UnitPrice = @UnitPrice
        WHERE PriceListId = @PriceListId AND VariantId = @VariantId;
        IF @@ROWCOUNT = 0
            INSERT dbo.PriceListLines (PriceListId, VariantId, UnitPrice)
            VALUES (@PriceListId, @VariantId, @UnitPrice);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO

CREATE OR ALTER PROCEDURE dbo.usp_FindBarcode
    @Barcode nvarchar(80)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Barcode, ArticleCode, ArticleDescription, VariantCode, SizeName, ColorName
    FROM dbo.v_VariantCatalog
    WHERE Barcode = @Barcode;
END;
GO
