--Procedures para realizar diferentes operaciones en la BD
--insertar CentroAtencion
create procedure insertarCentroAtencion
	@IDCentro int,
	@Nombre varchar(20),
	@Ubicacion varchar(20),
	@CapacidadMaxima int,
	@Tipo varchar (20)
	
	as
	begin
		insert into CentroAtencion values(@IDCentro, @Nombre, @Ubicacion, @CapacidadMaxima, @Tipo)
	end


--Actualizar datos CentroAtencion
create procedure actualizarCentroAtencion
	@IDCentro int,
	@Nombre varchar(20),
	@Ubicacion varchar(20),
	@CapacidadMaxima int,
	@Tipo varchar (20)
	AS
	BEGIN 
      SET NOCOUNT ON 
      UPDATE CentroAtencion
      SET 
			IDCentro = @IDCentro,
			Nombre = @Nombre,
			Ubicacion = @Ubicacion,
			CapacidadMaxima = @CapacidadMaxima,
			Tipo = @Tipo
			FROM CentroAtencion
			where
			IDCentro = @IDCentro
	END

--Eliminar CentroAtencion
create procedure eliminaCentroAtencion
	@CódigoCentro int
	as
	begin
		delete CentroAtencion
		from CentroAtencion
		where IDCentro = @IDCentro
	end

--insertar Cita
create procedure insertarCita
	@IDCita int,
	@AreaEspecialidad varchar(30),
	@Fecha date,
	@Hora time(7),
	@Observaciones varchar (100),
	Estado varchar(20)
	
	as
	begin
		insert into Cita values(@IDCita, @AreaEspecialidad, @Fecha, @Hora, @Observaciones, @Estado)
	end


--Actualizar datos Cita
create procedure actualizarCita
	@IDCita int,
	@AreaEspecialidad varchar(30),
	@Fecha date,
	@Hora time(7),
	@Observaciones varchar (100),
	@Estado varchar(20)
	AS
	BEGIN 
      SET NOCOUNT ON 
      UPDATE Cita
      SET 
			IDCita = @IDCita,
			AreaEspecialidad = @AreaEspecialidad,
			Fecha = @Fecha,
			Hora = @Hora,
			Observaciones = @Observaciones,
			Estado = @Estado
			FROM Cita
			where
			Cita = @Cita
	END

--Eliminar Cita
create procedure eliminarCita
	@IDCita int
	as
	begin
		delete Cita
		from Cita
		where IDCita = @IDCita
	end

--insertar Diagnosticos
create procedure insertarDiagnostico
	@Nombre varchar(30),
	@Nivel varchar(10),
	@Observaciones varchar(150)
	
	as
	begin
		insert into Diagnosticos values(@Nombre, @Nivel, @Observaciones)
	end


--Actualizar datos Diagnosticos
create procedure actualizarDiagnosticos
	@Nombre varchar(30),
	@Nivel varchar(10),
	@Observaciones varchar(150)
	AS
	BEGIN 
      SET NOCOUNT ON 
      UPDATE Diagnosticos
      SET 
			Nombre = @Nombre,
			Nivel = @Nivel,
			Observaciones = @Observaciones
			FROM Diagnosticos
			where
			Nombre = @Nombre
	END

--Eliminar Diagnosticos
create procedure eliminarDiagnosticos
	@Nombre varchar(30)
	as
	begin
		delete Diagnosticos
		from Diagnosticos
		where Nombre = @Nombre
	end

--insertar Tratamientos
create procedure insertarTratamientos
	@Nombre varchar(20),
	@Dosis varchar(20),
	@Tipo varchar(30)
	
	as
	begin
		insert into Tratamientos values(@Nombre, @Dosis, @Tipo)
	end


--Actualizar datos Tratamientos
create procedure actualizarTratamientos
	@Nombre varchar(20),
	@Dosis varchar(20),
	@Tipo varchar(30)
	AS
	BEGIN 
      SET NOCOUNT ON 
      UPDATE Tratamientos
      SET 
			Nombre = @Nombre,
			Dosis = @Dosis,
			Tipo = @Tipo
			FROM Tratamientos
			where
			Nombre = @Nombre
	END

--Eliminar Tratamientos
create procedure eliminarTratamientos
	@Nombre varchar(20)
	as
	begin
		delete Tratamientos
		from Tratamientos
		where Nombre = @Nombre
	end

--insertar Paciente
create procedure insertarPaciente
	@Cedula int,
	@Nombre varchar(20),
	@Apellido1 varchar(20),
	@Apellido2 varchar(20),
	@FechaNacimiento date,
	@TipoSangre varchar(10),
	@Nacionalidad varchar(20),
	@Telefono int

	
	as
	begin
		insert into Pacientes values(@Cedula, @Nombre, @Apellido1, @Apellido2, @FechaNacimiento, @TipoSangre, @Nacionalidad, @Telefono)
	end


--Actualizar datos Pacientes
create procedure actualizarPaciente
	@Cedula int,
	@Nombre varchar(20),
	@Apellido1 varchar(20),
	@Apellido2 varchar(20),
	@FechaNacimiento date,
	@TipoSangre varchar(10),
	@Nacionalidad varchar(20),
	@Telefono int
	AS
	BEGIN 
      SET NOCOUNT ON 
      UPDATE Pacientes
      SET 
			Cedula = @Cedula,
			Nombre = @Nombre,
			Apellido1 = @Apellido1,
			Apellido2 = @Apellido2,
			FechaNacimiento = @FechaNacimiento,
			TipoSangre = @TipoSangre,
			Nacionalidad = @Nacionalidad,
			Telefono = @Telefono
			FROM Pacientes
			where
			Cedula = @Cedula
	END

--Eliminar Paciente
create procedure eliminarPaciente
	@Cedula int
	as
	begin
		delete Pacientes
		from Pacientes
		where Cedula = @Cedula
	end

--insertar Funcionario
create procedure insertarFuncionario
	@IDFuncionario int,
	@Nombre varchar(20),
	@Apellido1 varchar(20),
	@Apellido2 varchar(20),
	@Tipo varchar (30),
	@FechaIngreso date,
	@Area varchar (30)

	
	as
	begin
		insert into Funcionario values(@IDFuncionario, @Nombre, @Apellido1, @Apellido2, @Tipo, @FechaIngreso, @Area)
	end


--Actualizar datos Funcionario
create procedure actualizarFuncionario
	@IDFuncionario int,
	@Nombre varchar(20),
	@Apellido1 varchar(20),
	@Apellido2 varchar(20),
	@Tipo varchar (30),
	@FechaIngreso date,
	@Area varchar (30)
	AS
	BEGIN 
      SET NOCOUNT ON 
      UPDATE Funcionario
      SET 
			IDFuncionario = @IDFuncionario,
			Nombre = @Nombre,
			Apellido1 = @Apellido1,
			Apellido2 = @Apellido2,
			Tipo = @Tipo,
			FechaIngreso = @FechaIngreso,
			Area = @Area
			FROM Funcionario
			where
			IDFuncionario = @IDFuncionario
	END

--Eliminar Funcionario
create procedure eliminarFuncionario
	@IDFuncioanrio int
	as
	begin
		delete Funcionario
		from Funcionario
		where IDFuncionario = @IDFuncionario
	end



--insertar IntermediaDiagnosticosTratamiento
create procedure insertarTratamientoaDiagnostico
	@Nombre varchar(30),
	@NombreT varchar(20)
	
	as
	begin
		insert into intermediaDiagnosticosTratamiento values(@Nombre, @NombreT)
	end


--Eliminar intermediaDiagnosticosTratamiento
create procedure eliminarTratamientoaDiagnostico
	@Nombre varchar(30),
	@NombreT varchar(20)
	as
	begin
		delete intermediaDiagnosticosTratamiento
		from intermediaDiagnosticosTratamiento
		where Nombre = @Nombre and Nombre = @NombreT 
	end

--insertar IntermediaCitaDiagnosticoPaciente
create procedure insertarCitaDiagnosticoPaciente
	@IDCita int,
	@Nombre varchar(30),
	@Cedula int
	
	as
	begin
		insert into intermediaCitaDiagnosticoPaciente values(@IDCita,@Nombre, @Cedula)
	end


--Eliminar IntermediaCitaDiagnosticoPaciente
create procedure eliminarCitaDiagnosticoPaciente
	@IDCita int,
	@Nombre varchar(30),
	@Cedula int
	as
	begin
		delete intermediaCitaDiagnosticoPaciente
		from intermediaCitaDiagnosticoPaciente
		where IDCita = @IDCita and Nombre = @Nombre and Cedula = @Cedula
	end

--insertar IntermediaCitaFuncionario
create procedure insertarCitaFuncionario
	@IDCita int,
	@IDFuncionario int
	
	as
	begin
		insert into intermediaCitaFuncionario values(@IDCita,@IDFuncionario)
	end


--Eliminar IntermediaCitaFuncionario
create procedure eliminarCitaFuncionario
	@IDCita int,
	@IDFuncionario int
	as
	begin
		delete intermediaCitaFuncionario
		from intermediaCitaFuncionario
		where IDCita = @IDCita and IDFuncionario = @IDFuncionario
	end

--insertar IntermediaCitaPaciente
create procedure insertarCitaPaciente
	@IDCitas int,
	@Cedula int
	
	as
	begin
		insert into intermediaCitaPaciente values(@IDCitas,@Cedula)
	end


--Eliminar IntermediaCitaFuncionario
create procedure eliminarCitaPaciente
	@IDCita int,
	@Cedula int
	as
	begin
		delete intermediaCitaPaciente
		from intermediaCitaPaciente
		where IDCitas = @IDCitas and Cedula = @Cedula
	end

--insertar IntermediaCentroPacienteFuncionario
create procedure insertarCentroPacienteFuncionario
	@IDCentro int,
	@Cedula int,
	@IDFuncionario
	
	as
	begin
		insert into intermediaCentroPacienteFuncionario values(@IDCentro,@Cedula, @IDFuncionario)
	end


--Eliminar IntermediaCentroPacienteCita
create procedure eliminarCentroPacienteFuncionario
	@IDCentro int,
	@Cedula int,
	@IDFuncionario
	as
	begin
		delete IntermediaCentroPacienteFuncionario
		from IntermediaCentroPacienteFuncionario
		where IDCentro = @IDCentro and Cedula = @Cedula and IDFuncionario = @IDFuncionario
	end


