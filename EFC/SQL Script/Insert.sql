SELECT * FROM usuariosBox

INSERT INTO usuariosBox(Nombre,Pass,Activo,UsuarioBloqueado,IdSucursal)
VALUES('DARIO','123456',1,0,1),
('JOSE','123456',1,0,2),
('JUAN','123456',1,0,1),
('ARIEL','123456',1,0,1)

SELECT * FROM sucursalesBox
INSERT INTO sucursalesBox(Nombre)
VALUES('NORTE'),
('SUR'),
('ESTE'),
('OESTE')


SELECT * FROM rolesBox
INSERT INTO rolesBox(Nombre)
VALUES('ADMINISTRADOR'),
('PROGRAMADOR'),
('SUPERVISOR'),
('VENDEDOR')
