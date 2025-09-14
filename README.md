[Script de base de datos.txt](https://github.com/user-attachments/files/22318135/Script.de.base.de.datos.txt)
CREATE DATABASE RL201130Desafio2;
GO

USE RL201130Desafio2;
GO

CREATE TABLE Instructor (
    IdInstructor INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Especialidad VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL
);

CREATE TABLE Estudiante (
    IdEstudiante INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    FechaNacimiento DATE NOT NULL
);

CREATE TABLE Curso (
    IdCurso INT PRIMARY KEY IDENTITY(1,1),
    Titulo VARCHAR(150) NOT NULL,
    Descripcion VARCHAR(300) NOT NULL,
    Nivel VARCHAR(50) NOT NULL CHECK (Nivel IN ('Básico', 'Intermedio', 'Avanzado')),
    IdInstructor INT NOT NULL FOREIGN KEY REFERENCES Instructor(IdInstructor)
);

CREATE TABLE Inscripcion (
    IdInscripcion INT PRIMARY KEY IDENTITY(1,1),
    FechaInscripcion DATE NOT NULL DEFAULT GETDATE(),
    IdEstudiante INT NOT NULL FOREIGN KEY REFERENCES Estudiante(IdEstudiante),
    IdCurso INT NOT NULL FOREIGN KEY REFERENCES Curso(IdCurso),
    CONSTRAINT UC_Inscripcion UNIQUE (IdEstudiante, IdCurso)
);
