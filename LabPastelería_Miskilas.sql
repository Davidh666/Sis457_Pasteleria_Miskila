create database LabPastelería_Miskila
go
USE master
go
create login usrpasteleria with password = N'1234567',
    default_database = LabPastelería_Miskila,
    check_expiration = off,
    check_policy = on
go
use LabPastelería_Miskila
go
create user usrpasteleria for login usrpasteleria
go
alter role [db_owner] add member usrpasteleria
go

DROP TABLE IF EXISTS Entregas;
DROP TABLE IF EXISTS Pagos;
DROP TABLE IF EXISTS Personalizacion;
DROP TABLE IF EXISTS DetallePedido;
DROP TABLE IF EXISTS Pedidos;
DROP TABLE IF EXISTS Inventario;
DROP TABLE IF EXISTS Productos;
DROP TABLE IF EXISTS Usuarios;
GO

-- 1. Usuarios (Unifica Clientes y Administradores para el Login y Roles)
CREATE TABLE Usuarios (
    id_usuario INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    identificador VARCHAR(100) NOT NULL UNIQUE, -- Celular (clientes) o usuario (admin)
    contrasena_hash VARCHAR(255) NOT NULL,
    rol VARCHAR(30) NOT NULL,                   -- 'Administrador' o 'Cliente'
    estado SMALLINT NOT NULL DEFAULT 1          -- -1: Eliminado, 0: Inactivo, 1: Activo
);
GO

-- 2. Productos (CRUD 1: Gestionado por Administrador)
CREATE TABLE Productos (
    id_producto INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    nombre VARCHAR(100) NOT NULL,
    descripcion VARCHAR(MAX),
    precio DECIMAL(18,2) NOT NULL,
    imagen VARCHAR(255),
    disponible BIT NOT NULL,
    estado SMALLINT NOT NULL DEFAULT 1
);
GO

-- 3. Inventario (Control de stock)
CREATE TABLE Inventario (
    id_producto INT NOT NULL PRIMARY KEY,
    cantidad_disponible INT NOT NULL,
    stock_minimo INT NOT NULL,
    fecha_actualizacion DATETIME NOT NULL,
    estado SMALLINT NOT NULL DEFAULT 1,
    CONSTRAINT fk_Inventario_Productos FOREIGN KEY (id_producto) REFERENCES Productos(id_producto) ON DELETE CASCADE
);
GO

-- 4. Pedidos (CRUD 2: Creado por Clientes, gestionado por Admins)
CREATE TABLE Pedidos (
    id_pedido INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_usuario INT NULL,
    fecha_pedido DATETIME NOT NULL,
    fecha_entrega DATETIME NULL,
    tipo_pedido VARCHAR(50) NOT NULL, -- 'En línea' / 'Presencial'
    total DECIMAL(18,2) NOT NULL,
    estado VARCHAR(50) NOT NULL,      -- 'Pendiente', 'En Proceso', 'Completado'
    observaciones VARCHAR(MAX),
    estado_reg SMALLINT NOT NULL DEFAULT 1,
    CONSTRAINT fk_Pedidos_Usuarios FOREIGN KEY (id_usuario) REFERENCES Usuarios(id_usuario) ON DELETE SET NULL
);
GO

-- 5. DetallePedido
CREATE TABLE DetallePedido (
    id_detalle INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_pedido INT NOT NULL,
    id_producto INT NOT NULL,
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(18,2) NOT NULL,
    subtotal DECIMAL(18,2) NOT NULL,
    estado SMALLINT NOT NULL DEFAULT 1,
    CONSTRAINT fk_DetallePedido_Pedidos FOREIGN KEY (id_pedido) REFERENCES Pedidos(id_pedido) ON DELETE CASCADE,
    CONSTRAINT fk_DetallePedido_Productos FOREIGN KEY (id_producto) REFERENCES Productos(id_producto)
);
GO

-- 6. Personalizacion (Detalles a medida de los pasteles)
CREATE TABLE Personalizacion (
    id_personalizacion INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_detalle INT NOT NULL UNIQUE,
    tamaño VARCHAR(50),
    sabor VARCHAR(50),
    decoracion VARCHAR(255),
    instrucciones VARCHAR(MAX),
    costo_adicional DECIMAL(18,2) NOT NULL,
    estado SMALLINT NOT NULL DEFAULT 1,
    CONSTRAINT fk_Personalizacion_DetallePedido FOREIGN KEY (id_detalle) REFERENCES DetallePedido(id_detalle) ON DELETE CASCADE
);
GO

-- 7. Pagos
CREATE TABLE Pagos (
    id_pago INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_pedido INT NOT NULL,
    metodo_pago VARCHAR(50) NOT NULL, -- 'QR' / 'Efectivo'
    monto DECIMAL(18,2) NOT NULL,
    fecha_pago DATETIME NOT NULL,
    estado_pago VARCHAR(50) NOT NULL,
    estado SMALLINT NOT NULL DEFAULT 1,
    CONSTRAINT fk_Pagos_Pedidos FOREIGN KEY (id_pedido) REFERENCES Pedidos(id_pedido) ON DELETE CASCADE
);
GO

-- 8. Entregas (Para envíos a domicilio)
CREATE TABLE Entregas (
    id_entrega INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    id_pedido INT NOT NULL UNIQUE,
    direccion VARCHAR(255) NOT NULL,
    referencia VARCHAR(255),
    costo_entrega DECIMAL(18,2) NOT NULL,
    estado_entrega VARCHAR(50) NOT NULL,
    estado SMALLINT NOT NULL DEFAULT 1,
    CONSTRAINT fk_Entregas_Pedidos FOREIGN KEY (id_pedido) REFERENCES Pedidos(id_pedido) ON DELETE CASCADE
);
GO

-- DATOS DE PRUEBA INICIALES
INSERT INTO Usuarios (nombre, identificador, contrasena_hash, rol) VALUES 
('Carla Admin', 'admin_carla', 'hash_admin_1', 'Administrador'),
('Ana Pérez', '70123456', 'hash_pwd_cliente1', 'Cliente');
GO

INSERT INTO Productos (nombre, descripcion, precio, imagen, disponible) VALUES 
('Torta de Chocolate', 'Bizcocho húmedo de chocolate con relleno de manjar', 90.00, 'torta_choco.jpg', 1),
('Queque Seco', 'Queque tradicional de vainilla', 35.00, 'queque_seco.jpg', 1);
GO

INSERT INTO Inventario (id_producto, cantidad_disponible, stock_minimo, fecha_actualizacion) VALUES 
(1, 10, 2, GETDATE()),
(2, 15, 3, GETDATE());
GO