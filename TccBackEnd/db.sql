Create table Cliente(
  Id serial,
  Nome varchar(50) not null,
  Email varchar(20) not null,
  Telefone varchar(20) not null,
  Nif varchar(15) null,
  Senha text not null
);