create database DBSalaDeReuniao

use DBSalaDeReuniao

create table Funcionario(
Id int primary key identity(1,1) not null,
Nome varchar(50) not null,
Cargo varchar(50) not null,
Ramal varchar(50) not null,
)

create table Sala(
Id int primary key identity(1,1) not null,
Nome varchar(50) not null,
Lugar int not null,
Disponibilidade bit not null,
)

create table Agendamento(
Id int primary key identity(1,1) not null,
HoraInicial datetime not null,
HoraFinal datetime not null,
FuncionarioId int not null,
SalaId int not null
CONSTRAINT [FK_Agendamento_Funcionario] FOREIGN KEY ([FuncionarioId]) REFERENCES [dbo].[Funcionario] ([Id]),
CONSTRAINT [FK_Agendamento_Sala] FOREIGN KEY ([SalaId]) REFERENCES [dbo].[Sala] ([Id])
)