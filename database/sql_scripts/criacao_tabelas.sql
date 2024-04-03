create sequence id_corredor start 1;
create sequence id_pista start 1;
create sequence id_historico start 1;

create table Competidores (
    id int primary key default nextval('id_corredor'),
    Nome varchar(150) not null,
    Sexo char(1) not null,
    TemperaturaMediaCorpo decimal not null,
    Peso decimal not null,
    Altura decimal not null
);

create table PistaCorrida (
    id int primary key default nextval('id_pista'),
    Descricao varchar(50) not null
);

create table HistoricoCorrida (
    id int primary key default nextval('id_historico'),
    CompetidorId int not null  references Competidores(id),
    PistaCorridaId int not null  references PistaCorrida(id),
    DataCorrida timestamp not null,
    TempoGasto decimal not null
);
