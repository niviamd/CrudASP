create database bdcrud;
use bdcrud;
create table produto(
Prodid int auto_increment primary key,
Prodnome varchar(50) not null,
Proddescr varchar(100) not null
);