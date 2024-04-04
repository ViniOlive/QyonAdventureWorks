create sequence id_corredor start 1 increment 1;

create table Competidores (
    Id_Competidor INTEGER PRIMARY KEY DEFAULT NEXTVAL('id_corredor'),
    Nome varchar(150) not null,
    Sexo char(1) not null,
    TemperaturaMediaCorpo decimal not null,
    Peso decimal not null,
    Altura decimal not null
);

ALTER TABLE Competidores
ADD CONSTRAINT Id_Competidor
PRIMARY KEY (Id_Competidor);

create sequence id_pista start 1 increment 1;

create table PistaCorrida (
    Id_Pista int default nextval('id_pista'),
    Descricao varchar(50) not null
);

ALTER TABLE PistaCorrida
ADD CONSTRAINT Id_Pista
PRIMARY KEY (Id_Pista);

create sequence id_historico start 1 increment 1;

create table HistoricoCorrida (
    Id_Historico int default nextval('id_historico'),
    CompetidorId int not null  references Competidores(Id_Competidor),
    PistaCorridaId int not null  references PistaCorrida(Id_Pista),
    DataCorrida timestamp not null,
    TempoGasto decimal not null
);

ALTER TABLE HistoricoCorrida
ADD CONSTRAINT Id_Historico
PRIMARY KEY (Id_Historico);