create database LabPastelería_Miskila
go
USE master
go
create login usrpasteleria with password = N'1234567',
	default_database =  LabPastelería_Miskila,
	check_expiration = off,
	check_policy = on
go
use LabPastelería_Miskila
go
create user usrpasteleria for login usrpasteleria
go
alter role [db_owner] add member usrpasteleria
go

DROP TABLE IF EXISTS Clientes;
DROP TABLE IF EXISTS Productos;
DROP TABLE IF EXISTS Inventario;
DROP TABLE IF EXISTS Administradores;
DROP TABLE IF EXISTS Pedidos;
DROP TABLE IF EXISTS DetallePedido;
DROP TABLE IF EXISTS Personalizacion;
DROP TABLE IF EXISTS Pagos;
DROP TABLE IF EXISTS Entregas;

--1. Clientes
CREATE TABLE Clientes (
    id_cliente INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    celular VARCHAR(20) NOT NULL UNIQUE,
    contrasena_hash VARCHAR(255) NOT NULL
);

-- 2. Productos
CREATE TABLE Productos (
    id_producto INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    descripcion VARCHAR(MAX),
    precio DECIMAL(18,2) NOT NULL,
    imagen VARCHAR(255),
    disponible BIT NOT NULL
);

-- 3. Inventario
CREATE TABLE Inventario (
    id_producto INT NOT NULL PRIMARY KEY,
    cantidad_disponible INT NOT NULL,
    stock_minimo INT NOT NULL,
    fecha_actualizacion DATETIME NOT NULL,
    CONSTRAINT fk_Inventario_Productos FOREIGN KEY (id_producto) REFERENCES Productos(id_producto) ON DELETE CASCADE
);

-- 4. Administradores
CREATE TABLE Administradores (
    id_administrador INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    nombre_usuario VARCHAR(50) NOT NULL UNIQUE,
    contrasena_hash VARCHAR(255) NOT NULL,
    rol VARCHAR(50) NOT NULL
);

-- 5. Pedidos
CREATE TABLE Pedidos (
    id_pedido INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_cliente INT NULL,
    fecha_pedido DATETIME NOT NULL,
    fecha_entrega DATETIME NULL,
    tipo_pedido VARCHAR(50) NOT NULL, -- En línea / Presencial
    total DECIMAL(18,2) NOT NULL,
    estado VARCHAR(50) NOT NULL,
    observaciones VARCHAR(MAX),
    CONSTRAINT fk_Pedidos_Clientes FOREIGN KEY (id_cliente) REFERENCES Clientes(id_cliente) ON DELETE SET NULL
);

-- 6. DetallePedido
CREATE TABLE DetallePedido (
    id_detalle INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_pedido INT NOT NULL,
    id_producto INT NOT NULL,
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(18,2) NOT NULL,
    subtotal DECIMAL(18,2) NOT NULL,
    CONSTRAINT fk_DetallePedido_Pedidos FOREIGN KEY (id_pedido) REFERENCES Pedidos(id_pedido) ON DELETE CASCADE,
    CONSTRAINT fk_DetallePedido_Productos FOREIGN KEY (id_producto) REFERENCES Productos(id_producto)
);

-- 7. Personalizacion
CREATE TABLE Personalizacion (
    id_personalizacion INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_detalle INT NOT NULL UNIQUE,
    tamaño VARCHAR(50),
    sabor VARCHAR(50),
    decoracion VARCHAR(255),
    instrucciones VARCHAR(MAX),
    costo_adicional DECIMAL(18,2) NOT NULL,
    CONSTRAINT fk_Personalizacion_DetallePedido FOREIGN KEY (id_detalle) REFERENCES DetallePedido(id_detalle) ON DELETE CASCADE
);

-- 8. Pagos
CREATE TABLE Pagos (
    id_pago INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_pedido INT NOT NULL,
    metodo_pago VARCHAR(50) NOT NULL, -- QR / Efectivo
    monto DECIMAL(18,2) NOT NULL,
    fecha_pago DATETIME NOT NULL,
    estado_pago VARCHAR(50) NOT NULL,
    CONSTRAINT fk_Pagos_Pedidos FOREIGN KEY (id_pedido) REFERENCES Pedidos(id_pedido) ON DELETE CASCADE
);

-- 9. Entregas
CREATE TABLE Entregas (
    id_entrega INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_pedido INT NOT NULL UNIQUE,
    direccion VARCHAR(255) NOT NULL,
    referencia VARCHAR(255),
    costo_entrega DECIMAL(18,2) NOT NULL,
    estado_entrega VARCHAR(50) NOT NULL,
    CONSTRAINT fk_Entregas_Pedidos FOREIGN KEY (id_pedido) REFERENCES Pedidos(id_pedido) ON DELETE CASCADE
);
GO


ALTER TABLE Clientes ADD estado SMALLINT NOT NULL DEFAULT 1; -- -1: Eliminado, 0: Inactivo, 1: Activo
ALTER TABLE Productos ADD estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Inventario ADD estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Administradores ADD estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Pedidos ADD estado_reg SMALLINT NOT NULL DEFAULT 1; -- (estado_reg para no chocar con el VARCHAR 'estado' que ya tiene Pedidos)
ALTER TABLE DetallePedido ADD estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Personalizacion ADD estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Pagos ADD estado SMALLINT NOT NULL DEFAULT 1;
ALTER TABLE Entregas ADD estado SMALLINT NOT NULL DEFAULT 1;
GO

-- 1. Clientes
INSERT INTO Clientes (nombre, celular, contrasena_hash) VALUES 
('Ana Pérez', '70123456', 'hash_pwd_cliente1'),
('Luis Gómez', '71234567', 'hash_pwd_cliente2');
GO

-- 2. Productos
INSERT INTO Productos (nombre, descripcion, precio, imagen, disponible) VALUES 
('Torta de Chocolate', 'Bizcocho húmedo de chocolate con relleno de manjar', 90.00, 'torta_choco.jpg', 1),
('Queque Seco', 'Queque tradicional de vainilla', 35.00, 'queque_seco.jpg', 1);
GO

-- 3. Inventario (Relacionado 1 a 1 con Productos)
INSERT INTO Inventario (id_producto, cantidad_disponible, stock_minimo, fecha_actualizacion) VALUES 
(1, 10, 2, GETDATE()),
(2, 15, 3, GETDATE());
GO

-- 4. Administradores
INSERT INTO Administradores (nombre, nombre_usuario, contrasena_hash, rol) VALUES 
('Carla Admin', 'admin_carla', 'hash_admin_1', 'Gerente'),
('Pedro Ventas', 'ventas_pedro', 'hash_admin_2', 'Cajero');
GO

-- 5. Pedidos
INSERT INTO Pedidos (id_cliente, fecha_pedido, fecha_entrega, tipo_pedido, total, estado, observaciones) VALUES 
(1, GETDATE(), DATEADD(day, 1, GETDATE()), 'En línea', 90.00, 'Pendiente', 'Entregar por la tarde por favor'),
(2, GETDATE(), NULL, 'Presencial', 35.00, 'Completado', 'Ninguna');
GO

-- 6. DetallePedido
INSERT INTO DetallePedido (id_pedido, id_producto, cantidad, precio_unitario, subtotal) VALUES 
(1, 1, 1, 90.00, 90.00),
(2, 2, 1, 35.00, 35.00);
GO

-- 7. Personalizacion (Asociado al id_detalle 1 del pedido en línea)
INSERT INTO Personalizacion (id_detalle, tamaño, sabor, decoracion, instrucciones, costo_adicional) VALUES 
(1, 'Mediano', 'Chocolate extra', 'Frutas y chocolate', 'Escribir "Feliz Cumpleaños Ana" con letras blancas', 10.00);
GO

-- 8. Pagos
INSERT INTO Pagos (id_pedido, metodo_pago, monto, fecha_pago, estado_pago) VALUES 
(1, 'QR', 90.00, GETDATE(), 'Completado'),
(2, 'Efectivo', 35.00, GETDATE(), 'Completado');
GO

-- 9. Entregas (Solo para pedidos a domicilio, en este caso el id_pedido 1)
INSERT INTO Entregas (id_pedido, direccion, referencia, costo_entrega, estado_entrega) VALUES 
(1, 'Av. 6 de Agosto #123', 'Cerca de la plaza principal, portón negro', 15.00, 'Pendiente');
GO

-- Consultas de verificación general
SELECT * FROM Clientes;
SELECT * FROM Productos;
SELECT * FROM Inventario;
SELECT * FROM Administradores;
SELECT * FROM Pedidos;
SELECT * FROM DetallePedido;
SELECT * FROM Personalizacion;
SELECT * FROM Pagos;
SELECT * FROM Entregas;