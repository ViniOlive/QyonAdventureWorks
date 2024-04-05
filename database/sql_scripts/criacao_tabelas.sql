create sequence id_corredor start 1 increment 1;

create table Competidores (
    Id_Competidor INTEGER PRIMARY KEY DEFAULT NEXTVAL('id_corredor'),
    Nome varchar(150) not null,
    Sexo char(1) not null,
    TemperaturaMediaCorpo decimal not null,
    Peso decimal not null,
    Altura decimal not null
);

create sequence id_pista start 1 increment 1;

create table PistaCorrida (
    Id_Pista INTEGER PRIMARY KEY DEFAULT NEXTVAL('id_pista'),
    Descricao varchar(50) not null
);

create sequence id_historico start 1 increment 1;

create table HistoricoCorrida (
    Id_Historico INTEGER PRIMARY KEY DEFAULT NEXTVAL('id_historico'),
    CompetidorId int not null  references Competidores(Id_Competidor),
    PistaCorridaId int not null  references PistaCorrida(Id_Pista),
    DataCorrida timestamp not null,
    TempoGasto decimal not null
);
