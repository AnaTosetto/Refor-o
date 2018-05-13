create database DBDonaLaura

use DBDonaLaura

create table Produto(
Id int primary key identity(1,1) not null,
Nome varchar(50) not null,
Disponibilidade bit not null,
PrecoVenda numeric(7,2) not null,
PrecoCusto numeric(7,2) not null,
DataFabricacao datetime not null,
DataValidade datetime not null,
)

create table Venda(
Id int primary key identity(1,1) not null,
NomeCliente varchar(50) not null,
Quantidade int not null,
Lucro numeric(7,2) not null,
ProdutoId int not null,
CONSTRAINT [FK_Venda_Produto] FOREIGN KEY ([ProdutoId]) REFERENCES [dbo].[Produto] ([Id])
)