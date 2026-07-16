// Query di visualizzazione video in prestito  
// Aggiungere tutta la gestione del database
SELECT
    c.cliente,
    v.titolo,
    f.formato,
    m.datanoleggio
FROM tbmovvideo m
INNER JOIN tbclienti c
    ON c.idcliente = m.kscliente
INNER JOIN tbvideo v
    ON v.idvideo = m.ksvideo
INNER JOIN tbformati f
    ON f.idformato = m.ksformato
WHERE m.datareso IS NULL
ORDER BY c.cliente
