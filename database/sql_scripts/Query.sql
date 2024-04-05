INSERT INTO competidores (nome,sexo,temperaturamediacorpo,peso,altura)
VALUES
    ('Larissa','F',35.5,65.7,1.61),
    ('Vinicius','M',36.5,83.7,1.91),
    ('Fulano','M',37.5,93.7,1.71);

select * from competidores;

select * from pistacorrida;

select * from historicocorrida;

drop sequence id_corredor;
drop sequence id_historico;
drop sequence id_pista;

drop table historicocorrida;
drop table pistacorrida;
drop table competidores;

delete from competidores;