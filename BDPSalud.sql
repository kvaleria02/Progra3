BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Funcionario
	(
	IDFuncionario int NOT NULL,
	Nombre varchar(20) NOT NULL,
	Apellido1 varchar(20) NOT NULL,
	Apellido2 varchar(20) NOT NULL,
	Tipo varchar(30) NOT NULL,
	FechaIngreso date NOT NULL,
	Area varchar(30) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Funcionario ADD CONSTRAINT
	PK_Funcionario PRIMARY KEY CLUSTERED 
	(
	IDFuncionario
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Funcionario SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Pacientes
	(
	Cedula int NOT NULL,
	Nombre varchar(20) NOT NULL,
	Apellido1 varchar(20) NOT NULL,
	Apellido2 varchar(20) NOT NULL,
	FechaNacimiento date NOT NULL,
	TipoSangre varchar(10) NOT NULL,
	Nacionalidad varchar(20) NOT NULL,
	Residencia varchar(20) NOT NULL,
	Telefono int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Pacientes ADD CONSTRAINT
	PK_Pacientes PRIMARY KEY CLUSTERED 
	(
	Cedula
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Pacientes SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tratamientos
	(
	Nombre varchar(20) NOT NULL,
	Dosis varchar(20) NOT NULL,
	Tipo varchar(30) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tratamientos ADD CONSTRAINT
	PK_Tratamientos PRIMARY KEY CLUSTERED 
	(
	Nombre
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Tratamientos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Diagnosticos
	(
	Nombre varchar(30) NOT NULL,
	Nivel varchar(10) NOT NULL,
	Observaciones varchar(150) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Diagnosticos ADD CONSTRAINT
	PK_Diagnosticos PRIMARY KEY CLUSTERED 
	(
	Nombre
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Diagnosticos SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.intermediaDiagnosticosTratamiento
	(
	Nombre varchar(30) NOT NULL,
	NombreT varchar(20) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.intermediaDiagnosticosTratamiento ADD CONSTRAINT
	FK_intermediaDiagnosticosTratamiento_Tratamientos FOREIGN KEY
	(
	NombreT
	) REFERENCES dbo.Tratamientos
	(
	Nombre
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.intermediaDiagnosticosTratamiento ADD CONSTRAINT
	FK_intermediaDiagnosticosTratamiento_Diagnosticos FOREIGN KEY
	(
	Nombre
	) REFERENCES dbo.Diagnosticos
	(
	Nombre
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.intermediaDiagnosticosTratamiento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Citas
	(
	IDCitas int NOT NULL,
	AreaEspecialidad varchar(30) NOT NULL,
	Fecha date NOT NULL,
	Hora time(7) NOT NULL,
	Observaciones varchar(100) NOT NULL,
	Estado nchar(20) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Citas ADD CONSTRAINT
	PK_Citas PRIMARY KEY CLUSTERED 
	(
	IDCitas
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Citas SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.intermediaCitaFuncionario
	(
	IDCita int NOT NULL,
	IDFuncionario int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.intermediaCitaFuncionario ADD CONSTRAINT
	FK_intermediaCitaFuncionario_Citas FOREIGN KEY
	(
	IDCita
	) REFERENCES dbo.Citas
	(
	IDCitas
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.intermediaCitaFuncionario ADD CONSTRAINT
	FK_intermediaCitaFuncionario_Funcionario FOREIGN KEY
	(
	IDFuncionario
	) REFERENCES dbo.Funcionario
	(
	IDFuncionario
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.intermediaCitaFuncionario SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.intermediaCitaDiagnosticoPaciente
	(
	IDCita int NOT NULL,
	Nombre varchar(30) NOT NULL,
	Cedula int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.intermediaCitaDiagnosticoPaciente ADD CONSTRAINT
	FK_intermediaCitaDiagnosticoPaciente_Citas FOREIGN KEY
	(
	IDCita
	) REFERENCES dbo.Citas
	(
	IDCitas
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.intermediaCitaDiagnosticoPaciente ADD CONSTRAINT
	FK_intermediaCitaDiagnosticoPaciente_Diagnosticos FOREIGN KEY
	(
	Nombre
	) REFERENCES dbo.Diagnosticos
	(
	Nombre
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.intermediaCitaDiagnosticoPaciente ADD CONSTRAINT
	FK_intermediaCitaDiagnosticoPaciente_Pacientes FOREIGN KEY
	(
	Cedula
	) REFERENCES dbo.Pacientes
	(
	Cedula
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.intermediaCitaDiagnosticoPaciente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.intermediaCitaPaciente
	(
	IDCitas int NOT NULL,
	Cedula int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.intermediaCitaPaciente ADD CONSTRAINT
	FK_intermediaCitaPaciente_Citas FOREIGN KEY
	(
	IDCitas
	) REFERENCES dbo.Citas
	(
	IDCitas
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.intermediaCitaPaciente ADD CONSTRAINT
	FK_intermediaCitaPaciente_Pacientes FOREIGN KEY
	(
	Cedula
	) REFERENCES dbo.Pacientes
	(
	Cedula
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.intermediaCitaPaciente SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.CentroAtencion
	(
	IDCentro int NOT NULL,
	Nombre varchar(20) NOT NULL,
	Ubicacion varchar(20) NOT NULL,
	CapacidadMaxima int NOT NULL,
	Tipo varchar(20) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.CentroAtencion ADD CONSTRAINT
	PK_CentroAtencion PRIMARY KEY CLUSTERED 
	(
	IDCentro
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.CentroAtencion SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.intermediaCentroPacienteFuncionario
	(
	IDCentro int NOT NULL,
	Cedula int NOT NULL,
	IDFuncionario int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.intermediaCentroPacienteFuncionario ADD CONSTRAINT
	FK_intermediaCentroPacienteFuncionario_Pacientes FOREIGN KEY
	(
	Cedula
	) REFERENCES dbo.Pacientes
	(
	Cedula
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.intermediaCentroPacienteFuncionario ADD CONSTRAINT
	FK_intermediaCentroPacienteFuncionario_CentroAtencion FOREIGN KEY
	(
	IDCentro
	) REFERENCES dbo.CentroAtencion
	(
	IDCentro
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.intermediaCentroPacienteFuncionario ADD CONSTRAINT
	FK_intermediaCentroPacienteFuncionario_Funcionario FOREIGN KEY
	(
	IDFuncionario
	) REFERENCES dbo.Funcionario
	(
	IDFuncionario
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.intermediaCentroPacienteFuncionario SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
