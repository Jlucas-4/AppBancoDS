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