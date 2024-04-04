INSERT INTO competidores (nome,sexo,temperaturamediacorpo,peso,altura)
VALUES
    ('Larissa','F',35.5,65.7,1.61);

select * from competidores;

drop sequence id_corredor;
drop sequence id_historico;
drop sequence id_pista;

drop table historicocorrida;
drop table pistacorrida;
drop table competidores;

delete from competidores;