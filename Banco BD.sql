create database dbBancoApp;
use dbBancoApp;

create table tbusuario(
IdUsu int primary key auto_increment,
nomeUsua varchar(50) not null,
Cargo varchar(50) not null,
DataNasc datetime
);

insert into tbusuario(nomeUsua, Cargo, DataNasc)
				values('Nilson', 'Gerente', '1917-05-01'),
					('Bruno', 'Colaborador', '2000-10-12');
select * from tbusuario;

create table tbcliente(
IdCli int primary key auto_increment,
nomeCli varchar(50) not null,
Email varchar(100) not null,
DataNasc datetime not null,
Sexo char(1) not null
);

insert into tbcliente(nomeCli, Email, DataNasc, Sexo)
				values('Teste', 'teste.decoisa@gmail.com', '1917-05-01', '4');
select * from tbcliente;
delete from tbcliente where IdCli = 2