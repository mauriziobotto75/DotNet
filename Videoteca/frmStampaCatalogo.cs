// Query di Stampa del catalogo completo 
// Aggiungere la gestione del database
SELECT
    v.titolo,
    g.genere,
    v.regista,
    p.produttore,
    v.annoproduzione
FROM tbvideo v
INNER JOIN tbgeneri g
      ON g.idgenere=v.ksgenere
LEFT JOIN tbproduttori p
      ON p.idproduttore=v.ksproduttore
ORDER BY v.titolo
