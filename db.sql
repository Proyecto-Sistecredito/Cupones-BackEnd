
-- Tabla: Campañas
CREATE TABLE Campañas (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255) NOT NULL,
    FechaInicio DATETIME NOT NULL,
    FechaFin DATETIME NOT NULL,
    IdEmpresa INT NOT NULL,
    FOREIGN KEY (IdEmpresa) REFERENCES Empresas(Id)
);

-- Tabla: Compras
CREATE TABLE Compras (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    ValorCompra DOUBLE NOT NULL,
    FechaCompra DATETIME NOT NULL,
    IdUsuario INT NOT NULL,
    IdCupon INT NOT NULL,
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id),
    FOREIGN KEY (IdCupon) REFERENCES Cupones(Id)
);

-- Tabla: Cupones
CREATE TABLE Cupones (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255) NOT NULL,
    FechaInicio DATETIME NOT NULL,
    FechaFin DATETIME NOT NULL,
    Valor VARCHAR(55) NOT NULL,
    Usabilidad INT NOT NULL,
    UsosDisponibles INT NOT NULL,
    Codigo VARCHAR(255) NOT NULL,
    IdUsuarioMarketing INT NOT NULL,
    IdTipoCupon INT NOT NULL,
    IdRedimido INT NOT NULL,
    IdUsuario INT NOT NULL,
    IdTipoUso INT NOT NULL,
    IdCampaña INT NOT NULL,
    FOREIGN KEY (IdUsuarioMarketing) REFERENCES UsuariosMarketing(Id),
    FOREIGN KEY (IdTipoCupon) REFERENCES TiposCupones(Id),
    FOREIGN KEY (IdRedimido) REFERENCES Redimido(Id),
    FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id),
    FOREIGN KEY (IdTipoUso) REFERENCES TiposUsos(Id),
    FOREIGN KEY (IdCampaña) REFERENCES Campañas(Id)
);

-- Tabla: Empresas
CREATE TABLE Empresas (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Logo VARCHAR(100) NOT NULL,
    Nit VARCHAR(25) NOT NULL UNIQUE
);

-- Tabla: Redimido
CREATE TABLE Redimido (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Estado VARCHAR(5) NOT NULL
);

-- Datos en la tabla Redimido
INSERT INTO Redimido (Estado) VALUES ('si'), ('no');

-- Tabla: Roles
CREATE TABLE Roles (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Tipo VARCHAR(55) NOT NULL
);

-- Datos en la tabla Roles
INSERT INTO Roles (Tipo) VALUES ('Administrador'), ('UsuarioMarketing');

-- Tabla: TiposCupones
CREATE TABLE TiposCupones (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Tipo VARCHAR(100) NOT NULL
);

-- Datos en la tabla TiposCupones
INSERT INTO TiposCupones (Tipo) VALUES ('valorvariable'), ('valorfijo'), ('porcentajevariable'), ('procentajefijo');

-- Tabla: TiposDocumentos
CREATE TABLE TiposDocumentos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Tipo VARCHAR(55) NOT NULL
);

-- Datos en la tabla TiposDocumentos
INSERT INTO TiposDocumentos (Tipo) VALUES ('cedula'), ('tarjeta identidad'), ('cedula extranjera'), ('otro');

-- Tabla: TiposUsos
CREATE TABLE TiposUsos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Tipo VARCHAR(100) NOT NULL
);

-- Datos en la tabla TiposUsos
INSERT INTO TiposUsos (Tipo) VALUES ('varios usos'), ('uno por usuario');

-- Tabla: Usuarios
CREATE TABLE Usuarios (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Documento VARCHAR(25) NOT NULL UNIQUE,
    TipoDocumento VARCHAR(50) NOT NULL
);

-- Tabla: UsuariosMarketing
CREATE TABLE UsuariosMarketing (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
    Contraseña VARCHAR(255) NOT NULL,
    Documento INT NOT NULL UNIQUE,
    IdTipoDocumento INT NOT NULL,
    IdRol INT NOT NULL,
    FOREIGN KEY (IdTipoDocumento) REFERENCES TiposDocumentos(Id),
    FOREIGN KEY (IdRol) REFERENCES Roles(Id)
);


-- Insertar registros de administradores en la tabla UsuariosMarketing
INSERT INTO UsuariosMarketing (Nombre, Apellido, Email, Contraseña, Documento, IdTipoDocumento, IdRol)
VALUES 
('Anthony', 'Apellido1', 'anthony@example.com', 'contraseña1', 124123213, 1,1),
('Juanky', 'Apellido2', 'juanky@example.com', 'contraseña2',1241245, 1,1),
('Maicol', 'Apellido3', 'maicol@example.com', 'contraseña3', 1231245, 1,1),
('Juanda', 'Apellido4', 'juanda@example.com', 'contraseña4', 12315123, 1,1);