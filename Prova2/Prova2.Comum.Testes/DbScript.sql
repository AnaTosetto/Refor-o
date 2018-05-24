create database DBProva2

use DBProva2

create table Livro(
Id int primary key identity(1,1) not null,
Titulo varchar(50) not null,
Tema varchar(50) not null,
Autor varchar(50) not null,
Volume int not null,
DataPublicacao datetime not null,
Disponibilidade bit not null,
)

create table Emprestimo(
Id int primary key identity(1,1) not null,
NomeCliente varchar(50) not null,
LivroId int not null,
DataDevolucao datetime not null,
CONSTRAINT [FK_Emprestimo_Livro] FOREIGN KEY ([LivroId]) REFERENCES [dbo].[Livro] ([Id])
)