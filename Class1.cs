using System;

namespace Progra3
{
	public partial class Class1 : Class
	{
		public void jalaInformacion()
		{
			// socket
			int Socket_Servidor;
			int Socket_Cliente;
			Socket_Servidor = Abre_Socket_Inet("cpp_java");
			Socket_Cliente = Acepta_Conexion_Cliente(Socket_Servidor);

			int Socket_Con_Servidor;
			Socket_Con_Servidor = Abre_Conexion_Inet("localhost", "cpp_java");

			/*	
			
			struct sockaddr_in Direccion; 
			Direccion.sin_port = htons(25557);

			int Longitud_Cadena;
			int Aux;
			Longitud_Cadena = 6; 
			Aux = htonl(Longitud_Cadena); //Se mete en Aux el entero en formato red 
			// Se envía Aux, que ya tiene los bytes en el orden de red 
			Escribe_Socket(Socket_Con_Servidor, (char*)&Aux, sizeof(Longitud_Cadena));
			char Cadena[100];
			strcpy(Cadena, "Adios");
			Escribe_Socket(Socket_Con_Servidor, Cadena, Longitud_Cadena);

			int Longitud_Cadena; 
			int Aux; 
			Lee_Socket (Socket_Con_Servidor, (char *)&Aux, sizeof(int)); // La función nos devuelve en Aux el entero leido en formato red
			Longitud_Cadena = ntohl(Aux); // Guardamos el entero en formato propio en Longitud_Cadena 
			//Ya podemos leer la cadena 
			char Cadena[100];
			Lee_Socket(Socket_Con_Servidor, Cadena, Longitud_Cadena);
			
			 */
		}

		public void insertarCentroAtencion()
		{
			SqlCommand cmd = new SqlCommand("dbo.insertaCentroAtencion", conexion);
			cmd.CommandType = CommandType.StoredProcedure;

			var param1 = new SqlParameter("@IDCentro", SqlDbType.Int);
			param1.Direction = ParameterDirection.Input;
			param1.Value = textBoxIDCentro.Text;
			cmd.Parameters.Add(param1);

			var param2 = new SqlParameter("@Nombre", SqlDbType.VarChar);
			param2.Direction = ParameterDirection.Input;
			param2.Value = textBoxNombre.Text;
			param2.Size = 50;
			cmd.Parameters.Add(param2);

			var param3 = new SqlParameter("@Ubicacion", SqlDbType.VarChar);
			param3.Direction = ParameterDirection.Input;
			param3.Value = textBoxUbicacion.Text;
			param3.Size = 50;
			cmd.Parameters.Add(param3);

			var param4 = new SqlParameter("@CapacidadMaxima", SqlDbType.Int);
			param4.Direction = ParameterDirection.Input;
			param4.Value = textBoxCapacidadMaxima.Text;
			cmd.Parameters.Add(param4);

			var param5 = new SqlParameter("@Tipo", SqlDbType.VarChar);
			param5.Direction = ParameterDirection.Input;
			param5.Value = textBoxTipo.Text;
			param5.Size = 50;
			cmd.Parameters.Add(param5);

			cmd.ExecuteNonQuery();
			conexion.Close();
			MessageBox.Show("Centro Academico creado correctamente");
		}

		public void ConsultarCentroAcdemico()
		{
			/*System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();
			conexion.ConnectionString = "Data Source=WIN-1SDP8NVLN2A\\SA;Initial Catalog=Progra 3;Persist Security Info=True;User ID=;Password=";
			conexion.Open();*/

			String consulta = "Select * from CentroAcademico where IDCentroAcademico=" + textBoxIDCentro.Text;
			SqlCommand consultaEnBD = new SqlCommand(consulta, conexion);

			SqlDataReader leerDatos = consultaEnBD.ExecuteReader();
			if (leerDatos.Read() == true)
			{
				textBoxIDCentro.Text = leerDatos["IDCentro"].ToString();
				textBoxNombre.Text = leerDatos["Nombre"].ToString();
				textBoxUbicacion.Text = leerDatos["Ubicacion"].ToString();
				textBoxCapacidadMaxima.Text = leerDatos["CapacidadMaxima"].ToString();
				textBoxTipo.Text = leerDatos["Tipo"].ToString();

			}
			else
			{
				MessageBox.Show("No existe el Centro");
			}

		}

		public void ActualizarCentroAcademico()
		{
			/*System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();
			conexion.ConnectionString = "Data Source=WIN-1SDP8NVLN2A\\SA;Initial Catalog=Progra 3;Persist Security Info=True;User ID=;Password=";
			conexion.Open();*/

			SqlCommand cmd = new SqlCommand("dbo.actualizaCentroAcademico", conexion);
			cmd.CommandType = CommandType.StoredProcedure;

			var param1 = new SqlParameter("@IDCentro", SqlDbType.Int);
			param1.Direction = ParameterDirection.Input;
			param1.Value = textBoxIDCentro.Text;
			cmd.Parameters.Add(param1);

			var param2 = new SqlParameter("@Nombre", SqlDbType.VarChar);
			param2.Direction = ParameterDirection.Input;
			param2.Value = textBoxNombre.Text;
			param2.Size = 50;
			cmd.Parameters.Add(param2);

			var param3 = new SqlParameter("@Ubicacion", SqlDbType.VarChar);
			param3.Direction = ParameterDirection.Input;
			param3.Value = textBoxUbicacion.Text;
			param3.Size = 50;
			cmd.Parameters.Add(param3);

			var param4 = new SqlParameter("@CapacidadMaxima", SqlDbType.Int);
			param4.Direction = ParameterDirection.Input;
			param4.Value = textBoxCapacidadMaxima.Text;
			cmd.Parameters.Add(param4);

			var param5 = new SqlParameter("@Tipo", SqlDbType.VarChar);
			param5.Direction = ParameterDirection.Input;
			param5.Value = textBoxTipo.Text;
			param5.Size = 50;
			cmd.Parameters.Add(param5);

			cmd.ExecuteNonQuery();
			conexion.Close();

			MessageBox.Show("Centro Academico actualizado correctamente");
		}
	}

	public void BorrarCentroAcademico()
	{
		try
		{
			/*System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();
			conexion.ConnectionString = "Data Source=WIN-1SDP8NVLN2A\\SA;Initial Catalog=Progra 3;Persist Security Info=True;User ID=;Password=";
			conexion.Open();*/

			SqlCommand cmd = new SqlCommand("dbo.eliminaCentroAcademico", conexion);
			cmd.CommandType = CommandType.StoredProcedure;

			var param1 = new SqlParameter("@IDCentro", SqlDbType.Int);
			param1.Direction = ParameterDirection.Input;
			param1.Value = textBoxIDCentro.Text;
			cmd.Parameters.Add(param1);

			cmd.ExecuteNonQuery();

			conexion.Close();

			MessageBox.Show("Se ha borrado el Centro");
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());

		}
	}

	public void insertarCita()
	{
		SqlCommand cmd = new SqlCommand("dbo.insertaCita", conexion);
		cmd.CommandType = CommandType.StoredProcedure;

		var param1 = new SqlParameter("@IDCita", SqlDbType.Int);
		param1.Direction = ParameterDirection.Input;
		param1.Value = textBoxIDCentro.Text;
		cmd.Parameters.Add(param1);

		var param2 = new SqlParameter("@AreaEspecialidad", SqlDbType.VarChar);
		param2.Direction = ParameterDirection.Input;
		param2.Value = textBoxAreaEspecialidad.Text;
		param2.Size = 50;
		cmd.Parameters.Add(param2);

		var param3 = new SqlParameter("@Fecha", SqlDbType.Date);
		param3.Direction = ParameterDirection.Input;
		param3.Value = textBoxFecha.Text;
		cmd.Parameters.Add(param3);

		var param4 = new SqlParameter("@Hora", SqlDbType.Time);
		param4.Direction = ParameterDirection.Input;
		param4.Value = textBoxHora.Text;
		cmd.Parameters.Add(param4);

		var param5 = new SqlParameter("@Observaciones", SqlDbType.VarChar);
		param5.Direction = ParameterDirection.Input;
		param5.Value = textBoxObservaciones.Text;
		param5.Size = 50;
		cmd.Parameters.Add(param5);

		var param6 = new SqlParameter("@Estado", SqlDbType.VarChar);
		param6.Direction = ParameterDirection.Input;
		param6.Value = textBoxEstado.Text;
		param6.Size = 50;
		cmd.Parameters.Add(param6);

		cmd.ExecuteNonQuery();
		conexion.Close();
		MessageBox.Show("Cita creada correctamente");
	}

	public void ConsultarCita()
	{
		/*System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();
		conexion.ConnectionString = "Data Source=WIN-1SDP8NVLN2A\\SA;Initial Catalog=Progra 3;Persist Security Info=True;User ID=;Password=";
		conexion.Open();*/

		String consulta = "Select * from Cita where IDCita=" + textBoxIDCita.Text;
		SqlCommand consultaEnBD = new SqlCommand(consulta, conexion);

		SqlDataReader leerDatos = consultaEnBD.ExecuteReader();
		if (leerDatos.Read() == true)
		{
			textBoxIDCita.Text = leerDatos["IDCita"].ToString();
			textBoxAreaEspecialidad.Text = leerDatos["AreaEspecialidad"].ToString();
			textBoxFecha.Text = leerDatos["Fecha"].ToString();
			textBoxHora.Text = leerDatos["Hora"].ToString();
			textBoxObservaciones.Text = leerDatos["Observaciones"].ToString();
			textBoxEstado.Text = leerDatos["Estado"].ToString();

		}
		else
		{
			MessageBox.Show("No existe la Cita");
		}

	}

	public void ActualizarCita()
	{
		/*System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();
		conexion.ConnectionString = "Data Source=WIN-1SDP8NVLN2A\\SA;Initial Catalog=Progra 3;Persist Security Info=True;User ID=;Password=";
		conexion.Open();*/

		SqlCommand cmd = new SqlCommand("dbo.actualizaCentroAcademico", conexion);
		cmd.CommandType = CommandType.StoredProcedure;

		var param1 = new SqlParameter("@IDCita", SqlDbType.Int);
		param1.Direction = ParameterDirection.Input;
		param1.Value = textBoxIDCentro.Text;
		cmd.Parameters.Add(param1);

		var param2 = new SqlParameter("@AreaEspecialidad", SqlDbType.VarChar);
		param2.Direction = ParameterDirection.Input;
		param2.Value = textBoxAreaEspecialidad.Text;
		param2.Size = 50;
		cmd.Parameters.Add(param2);

		var param3 = new SqlParameter("@Fecha", SqlDbType.Date);
		param3.Direction = ParameterDirection.Input;
		param3.Value = textBoxFecha.Text;
		cmd.Parameters.Add(param3);

		var param4 = new SqlParameter("@Hora", SqlDbType.Time);
		param4.Direction = ParameterDirection.Input;
		param4.Value = textBoxHora.Text;
		cmd.Parameters.Add(param4);

		var param5 = new SqlParameter("@Observaciones", SqlDbType.VarChar);
		param5.Direction = ParameterDirection.Input;
		param5.Value = textBoxObservaciones.Text;
		param5.Size = 50;
		cmd.Parameters.Add(param5);

		var param6 = new SqlParameter("@Estado", SqlDbType.VarChar);
		param6.Direction = ParameterDirection.Input;
		param6.Value = textBoxEstado.Text;
		param6.Size = 50;
		cmd.Parameters.Add(param6);

		cmd.ExecuteNonQuery();
		conexion.Close();

		MessageBox.Show("Cita actualizada correctamente");
		
	}

	public void BorrarCita()
	{
		try
		{
			/*System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();
			conexion.ConnectionString = "Data Source=WIN-1SDP8NVLN2A\\SA;Initial Catalog=Progra 3;Persist Security Info=True;User ID=;Password=";
			conexion.Open();*/

			SqlCommand cmd = new SqlCommand("dbo.eliminaCita", conexion);
			cmd.CommandType = CommandType.StoredProcedure;

			var param1 = new SqlParameter("@IDCita", SqlDbType.Int);
			param1.Direction = ParameterDirection.Input;
			param1.Value = textBoxIDCita.Text;
			cmd.Parameters.Add(param1);

			cmd.ExecuteNonQuery();

			conexion.Close();

			MessageBox.Show("Se ha borrado la Cita");
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());

		}
	}

	public void insertarDiagnostico()
	{
		SqlCommand cmd = new SqlCommand("dbo.insertaDiagnostico", conexion);
		cmd.CommandType = CommandType.StoredProcedure;

		var param1 = new SqlParameter("@Nombre", SqlDbType.VarChar);
		param1.Direction = ParameterDirection.Input;
		param1.Value = textBoxNombre.Text;
		param1.Size = 50;
		cmd.Parameters.Add(param1);

		var param2 = new SqlParameter("@Nivel1", SqlDbType.VarChar);
		param2.Direction = ParameterDirection.Input;
		param2.Value = textBoxNivel1.Text;
		param2.Size = 50;
		cmd.Parameters.Add(param2);

		var param3 = new SqlParameter("@Observaciones", SqlDbType.VarChar);
		param3.Direction = ParameterDirection.Input;
		param3.Value = textBoxObservaciones.Text;
		param3.Size = 50;
		cmd.Parameters.Add(param3);

		cmd.ExecuteNonQuery();
		conexion.Close();
		MessageBox.Show("Diagnostico creado correctamente");
	}

	public void ConsultarDiagnostico()
	{
		/*System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();
		conexion.ConnectionString = "Data Source=WIN-1SDP8NVLN2A\\SA;Initial Catalog=Progra 3;Persist Security Info=True;User ID=;Password=";
		conexion.Open();*/

		String consulta = "Select * from Diagnostico where Nombre=" + textBoxNombre.Text;
		SqlCommand consultaEnBD = new SqlCommand(consulta, conexion);

		SqlDataReader leerDatos = consultaEnBD.ExecuteReader();
		if (leerDatos.Read() == true)
		{
			textBoxNombre.Text = leerDatos["Nombre"].ToString();
			textBoxNivel.Text = leerDatos["Nivel"].ToString();
			textBoxObservaciones.Text = leerDatos["Observaciones"].ToString();
			
		}
		else
		{
			MessageBox.Show("No existe el Diagnostico");
		}

	}

	public void ActualizarDiagnostico()
	{
		/*System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();
		conexion.ConnectionString = "Data Source=WIN-1SDP8NVLN2A\\SA;Initial Catalog=Progra 3;Persist Security Info=True;User ID=;Password=";
		conexion.Open();*/

		SqlCommand cmd = new SqlCommand("dbo.actualizaDiagnostico", conexion);
		cmd.CommandType = CommandType.StoredProcedure;

		var param1 = new SqlParameter("@Nombre", SqlDbType.VarChar);
		param1.Direction = ParameterDirection.Input;
		param1.Value = textBoxNombre.Text;
		param1.Size = 50;
		cmd.Parameters.Add(param1);

		var param2 = new SqlParameter("@Nivel1", SqlDbType.VarChar);
		param2.Direction = ParameterDirection.Input;
		param2.Value = textBoxNivel1.Text;
		param2.Size = 50;
		cmd.Parameters.Add(param2);

		var param3 = new SqlParameter("@Observaciones", SqlDbType.VarChar);
		param3.Direction = ParameterDirection.Input;
		param3.Value = textBoxObservaciones.Text;
		param3.Size = 50;
		cmd.Parameters.Add(param3);

		cmd.ExecuteNonQuery();
		conexion.Close();

		MessageBox.Show("Diagnostico actualizado correctamente");

	}

	public void BorrarDiagnostico()
	{
		try
		{
			/*System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();
			conexion.ConnectionString = "Data Source=WIN-1SDP8NVLN2A\\SA;Initial Catalog=Progra 3;Persist Security Info=True;User ID=;Password=";
			conexion.Open();*/

			SqlCommand cmd = new SqlCommand("dbo.eliminaDiagnostico", conexion);
			cmd.CommandType = CommandType.StoredProcedure;

			var param1 = new SqlParameter("@Nombre", SqlDbType.VarChar);
			param1.Direction = ParameterDirection.Input;
			param1.Value = textBoxNombre.Text;
			cmd.Parameters.Add(param1);

			cmd.ExecuteNonQuery();

			conexion.Close();

			MessageBox.Show("Se ha borrado el Diagnostico");
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());

		}
	}

	public void insertarTratamiento()
	{
		SqlCommand cmd = new SqlCommand("dbo.insertaTratamiento", conexion);
		cmd.CommandType = CommandType.StoredProcedure;

		var param1 = new SqlParameter("@Nombre", SqlDbType.VarChar);
		param1.Direction = ParameterDirection.Input;
		param1.Value = textBoxNombre.Text;
		param1.Size = 50;
		cmd.Parameters.Add(param1);

		var param2 = new SqlParameter("@Dosis", SqlDbType.VarChar);
		param2.Direction = ParameterDirection.Input;
		param2.Value = textBoxDosis.Text;
		param2.Size = 50;
		cmd.Parameters.Add(param2);

		var param3 = new SqlParameter("@Tipo", SqlDbType.Date);
		param3.Direction = ParameterDirection.Input;
		param3.Value = textBoxTipo.Text;
		cmd.Parameters.Add(param3);

		cmd.ExecuteNonQuery();
		conexion.Close();
		MessageBox.Show("Tratamiento creado correctamente");
	}

	public void ConsultarTratamiento()
	{
		/*System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();
		conexion.ConnectionString = "Data Source=WIN-1SDP8NVLN2A\\SA;Initial Catalog=Progra 3;Persist Security Info=True;User ID=;Password=";
		conexion.Open();*/

		String consulta = "Select * from Tratamiento where Nombre=" + textBoxNombre.Text;
		SqlCommand consultaEnBD = new SqlCommand(consulta, conexion);

		SqlDataReader leerDatos = consultaEnBD.ExecuteReader();
		if (leerDatos.Read() == true)
		{
			textBoxNombre.Text = leerDatos["Nombre"].ToString();
			textBoxDosis.Text = leerDatos["Dosis"].ToString();
			textBoxTipo.Text = leerDatos["Tipo"].ToString();
		}
		else
		{
			MessageBox.Show("No existe el Tratamiento");
		}

	}

	public void ActualizarTratamiento()
	{
		/*System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();
		conexion.ConnectionString = "Data Source=WIN-1SDP8NVLN2A\\SA;Initial Catalog=Progra 3;Persist Security Info=True;User ID=;Password=";
		conexion.Open();*/

		SqlCommand cmd = new SqlCommand("dbo.actualizaTratamiento", conexion);
		cmd.CommandType = CommandType.StoredProcedure;

		var param1 = new SqlParameter("@Nombre", SqlDbType.VarChar);
		param1.Direction = ParameterDirection.Input;
		param1.Value = textBoxNombre.Text;
		param1.Size = 50;
		cmd.Parameters.Add(param1);

		var param2 = new SqlParameter("@Dosis", SqlDbType.VarChar);
		param2.Direction = ParameterDirection.Input;
		param2.Value = textBoxDosis.Text;
		param2.Size = 50;
		cmd.Parameters.Add(param2);

		var param3 = new SqlParameter("@Tipo", SqlDbType.Date);
		param3.Direction = ParameterDirection.Input;
		param3.Value = textBoxTipo.Text;
		cmd.Parameters.Add(param3);

		cmd.ExecuteNonQuery();
		conexion.Close();

		MessageBox.Show("Tratamiento actualizado correctamente");

	}

	public void BorrarTratamiento()
	{
		try
		{
			/*System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();
			conexion.ConnectionString = "Data Source=WIN-1SDP8NVLN2A\\SA;Initial Catalog=Progra 3;Persist Security Info=True;User ID=;Password=";
			conexion.Open();*/

			SqlCommand cmd = new SqlCommand("dbo.eliminaTratamiento", conexion);
			cmd.CommandType = CommandType.StoredProcedure;

			var param1 = new SqlParameter("@Nombre", SqlDbType.VarChar);
			param1.Direction = ParameterDirection.Input;
			param1.Value = textBoxNombre.Text;
			cmd.Parameters.Add(param1);

			cmd.ExecuteNonQuery();

			conexion.Close();

			MessageBox.Show("Se ha borrado el Tratamiento");
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());

		}
	}

	public void insertarPaciente()
	{
		SqlCommand cmd = new SqlCommand("dbo.insertaPaciente", conexion);
		cmd.CommandType = CommandType.StoredProcedure;

		var param1 = new SqlParameter("@Cedula", SqlDbType.Int);
		param1.Direction = ParameterDirection.Input;
		param1.Value = textBoxCedula.Text;
		cmd.Parameters.Add(param1);

		var param2 = new SqlParameter("@Nombre", SqlDbType.VarChar);
		param2.Direction = ParameterDirection.Input;
		param2.Value = textBoxNombre.Text;
		param2.Size = 50;
		cmd.Parameters.Add(param2);

		var param3 = new SqlParameter("@Apellido1", SqlDbType.VarChar);
		param3.Direction = ParameterDirection.Input;
		param3.Value = textBoxApellido1.Text;
		param3.Size = 50;
		cmd.Parameters.Add(param3);

		var param4 = new SqlParameter("@Apellido2", SqlDbType.VarChar);
		param4.Direction = ParameterDirection.Input;
		param4.Value = textApellido2.Text;
		param4.Size = 50;
		cmd.Parameters.Add(param4);

		var param5 = new SqlParameter("@FechaNacimiento", SqlDbType.Date);
		param5.Direction = ParameterDirection.Input;
		param5.Value = textBoxFechaNacimiento.Text;
		cmd.Parameters.Add(param5);

		var param6 = new SqlParameter("@TipoSangre", SqlDbType.VarChar);
		param6.Direction = ParameterDirection.Input;
		param6.Value = textBoxTipoSangre.Text;
		param6.Size = 50;
		cmd.Parameters.Add(param6);

		var param7 = new SqlParameter("@Nacionalidad", SqlDbType.VarChar);
		param7.Direction = ParameterDirection.Input;
		param7.Value = textBoxNacionalidad.Text;
		param7.Size = 50;
		cmd.Parameters.Add(param7);

		var param8 = new SqlParameter("@Telefono", SqlDbType.Int);
		param8.Direction = ParameterDirection.Input;
		param8.Value = textBoxTelefono.Text;
		cmd.Parameters.Add(param8);

		cmd.ExecuteNonQuery();
		conexion.Close();
		MessageBox.Show("Paciente creado correctamente");
	}

	public void ConsultarPaciente()
	{
		/*System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();
		conexion.ConnectionString = "Data Source=WIN-1SDP8NVLN2A\\SA;Initial Catalog=Progra 3;Persist Security Info=True;User ID=;Password=";
		conexion.Open();*/

		String consulta = "Select * from ConsultarPaciente where Cedula=" + textBoxCedula.Text;
		SqlCommand consultaEnBD = new SqlCommand(consulta, conexion);

		SqlDataReader leerDatos = consultaEnBD.ExecuteReader();
		if (leerDatos.Read() == true)
		{
			textBoxCedula.Text = leerDatos["Cedula"].ToString();
			textBoxNombre.Text = leerDatos["Nombre"].ToString();
			textBoxApellido1.Text = leerDatos["Apellido1"].ToString();
			textBoxApellido2.Text = leerDatos["Apellido2"].ToString();
			textBoxFechaNacimiento.Text = leerDatos["FechaNacimiento"].ToString();
			textBoxTipoSangre.Text = leerDatos["TipoSangre"].ToString();
			textBoxNacionalidad.Text = leerDatos["Nacionalidad"].ToString();
			textBoxTelefono.Text = leerDatos["Telefono"].ToString();

		}
		else
		{
			MessageBox.Show("No existe el Paciente");
		}

	}

	public void ActualizarPaciente()
	{
		/*System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();
		conexion.ConnectionString = "Data Source=WIN-1SDP8NVLN2A\\SA;Initial Catalog=Progra 3;Persist Security Info=True;User ID=;Password=";
		conexion.Open();*/

		SqlCommand cmd = new SqlCommand("dbo.actualizaPaciente", conexion);
		cmd.CommandType = CommandType.StoredProcedure;

		var param1 = new SqlParameter("@Cedula", SqlDbType.Int);
		param1.Direction = ParameterDirection.Input;
		param1.Value = textBoxCedula.Text;
		cmd.Parameters.Add(param1);

		var param2 = new SqlParameter("@Nombre", SqlDbType.VarChar);
		param2.Direction = ParameterDirection.Input;
		param2.Value = textBoxNombre.Text;
		param2.Size = 50;
		cmd.Parameters.Add(param2);

		var param3 = new SqlParameter("@Apellido1", SqlDbType.VarChar);
		param3.Direction = ParameterDirection.Input;
		param3.Value = textBoxApellido1.Text;
		param3.Size = 50;
		cmd.Parameters.Add(param3);

		var param4 = new SqlParameter("@Apellido2", SqlDbType.VarChar);
		param4.Direction = ParameterDirection.Input;
		param4.Value = textApellido2.Text;
		param4.Size = 50;
		cmd.Parameters.Add(param4);

		var param5 = new SqlParameter("@FechaNacimiento", SqlDbType.Date);
		param5.Direction = ParameterDirection.Input;
		param5.Value = textBoxFechaNacimiento.Text;
		cmd.Parameters.Add(param5);

		var param6 = new SqlParameter("@TipoSangre", SqlDbType.VarChar);
		param6.Direction = ParameterDirection.Input;
		param6.Value = textBoxTipoSangre.Text;
		param6.Size = 50;
		cmd.Parameters.Add(param6);

		var param7 = new SqlParameter("@Nacionalidad", SqlDbType.VarChar);
		param7.Direction = ParameterDirection.Input;
		param7.Value = textBoxNacionalidad.Text;
		param7.Size = 50;
		cmd.Parameters.Add(param7);

		var param8 = new SqlParameter("@Telefono", SqlDbType.Int);
		param8.Direction = ParameterDirection.Input;
		param8.Value = textBoxTelefono.Text;
		cmd.Parameters.Add(param8);

		cmd.ExecuteNonQuery();
		conexion.Close();

		MessageBox.Show("Paciente actualizada correctamente");

	}

	public void BorrarPaciente()
	{
		try
		{
			/*System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();
			conexion.ConnectionString = "Data Source=WIN-1SDP8NVLN2A\\SA;Initial Catalog=Progra 3;Persist Security Info=True;User ID=;Password=";
			conexion.Open();*/

			SqlCommand cmd = new SqlCommand("dbo.eliminaPaciente", conexion);
			cmd.CommandType = CommandType.StoredProcedure;

			var param1 = new SqlParameter("@Cedula", SqlDbType.Int);
			param1.Direction = ParameterDirection.Input;
			param1.Value = textBoxCedula.Text;
			cmd.Parameters.Add(param1);

			cmd.ExecuteNonQuery();

			conexion.Close();

			MessageBox.Show("Se ha borrado el Paciente");
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());

		}
	}

	public void insertarFuncionario()
	{
		SqlCommand cmd = new SqlCommand("dbo.insertaFuncionario", conexion);
		cmd.CommandType = CommandType.StoredProcedure;

		var param1 = new SqlParameter("@IDFuncionario", SqlDbType.Int);
		param1.Direction = ParameterDirection.Input;
		param1.Value = textBoxIDFuncionario.Text;
		cmd.Parameters.Add(param1);

		var param2 = new SqlParameter("@Nombre", SqlDbType.VarChar);
		param2.Direction = ParameterDirection.Input;
		param2.Value = textBoxNombre.Text;
		param2.Size = 50;
		cmd.Parameters.Add(param2);

		var param3 = new SqlParameter("@Apellido1", SqlDbType.VarChar);
		param3.Direction = ParameterDirection.Input;
		param3.Value = textBoxApellido1.Text;
		param3.Size = 50;
		cmd.Parameters.Add(param3);

		var param4 = new SqlParameter("@Apellido2", SqlDbType.VarChar);
		param4.Direction = ParameterDirection.Input;
		param4.Value = textBoxApellido2.Text;
		param4.Size = 50;
		cmd.Parameters.Add(param4);

		var param5 = new SqlParameter("@Tipo", SqlDbType.VarChar);
		param5.Direction = ParameterDirection.Input;
		param5.Value = textBoxTipo.Text;
		param5.Size = 50;
		cmd.Parameters.Add(param5);

		var param6 = new SqlParameter("@FechaIngreso", SqlDbType.Date);
		param6.Direction = ParameterDirection.Input;
		param6.Value = textBoxFechaIngreso.Text;
		cmd.Parameters.Add(param6);

		var param7 = new SqlParameter("@Area", SqlDbType.VarChar);
		param7.Direction = ParameterDirection.Input;
		param7.Value = textBoxArea.Text;
		param7.Size = 50;
		cmd.Parameters.Add(param7);

		cmd.ExecuteNonQuery();
		conexion.Close();
		MessageBox.Show("Funcionario creada correctamente");
	}

	public void ConsultarFuncionario()
	{
		/*System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();
		conexion.ConnectionString = "Data Source=WIN-1SDP8NVLN2A\\SA;Initial Catalog=Progra 3;Persist Security Info=True;User ID=;Password=";
		conexion.Open();*/

		String consulta = "Select * from Funcionario where IDFuncionario=" + textBoxIDFuncionario.Text;
		SqlCommand consultaEnBD = new SqlCommand(consulta, conexion);

		SqlDataReader leerDatos = consultaEnBD.ExecuteReader();
		if (leerDatos.Read() == true)
		{
			textBoxIDFuncionario.Text = leerDatos["IDFuncionario"].ToString();
			textBoxNombre.Text = leerDatos["Nombre"].ToString();
			textBoxApellido1.Text = leerDatos["Apellido1"].ToString();
			textBoxApellido2.Text = leerDatos["Apellido2"].ToString();
			textBoxTipo.Text = leerDatos["Tipo"].ToString();
			textBoxFechaIngreso.Text = leerDatos["FechaIngreso"].ToString();
			textBoxArea.Text = leerDatos["Area"].ToString();
		}
		else
		{
			MessageBox.Show("No existe el Funcionario");
		}

	}

	public void ActualizarFuncionario()
	{
		/*System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();
		conexion.ConnectionString = "Data Source=WIN-1SDP8NVLN2A\\SA;Initial Catalog=Progra 3;Persist Security Info=True;User ID=;Password=";
		conexion.Open();*/

		SqlCommand cmd = new SqlCommand("dbo.actualizaFuncionario", conexion);
		cmd.CommandType = CommandType.StoredProcedure;

		var param1 = new SqlParameter("@IDFuncionario", SqlDbType.Int);
		param1.Direction = ParameterDirection.Input;
		param1.Value = textBoxIDFuncionario.Text;
		cmd.Parameters.Add(param1);

		var param2 = new SqlParameter("@Nombre", SqlDbType.VarChar);
		param2.Direction = ParameterDirection.Input;
		param2.Value = textBoxNombre.Text;
		param2.Size = 50;
		cmd.Parameters.Add(param2);

		var param3 = new SqlParameter("@Apellido1", SqlDbType.VarChar);
		param3.Direction = ParameterDirection.Input;
		param3.Value = textBoxApellido1.Text;
		param3.Size = 50;
		cmd.Parameters.Add(param3);

		var param4 = new SqlParameter("@Apellido2", SqlDbType.VarChar);
		param4.Direction = ParameterDirection.Input;
		param4.Value = textBoxApellido2.Text;
		param4.Size = 50;
		cmd.Parameters.Add(param4);

		var param5 = new SqlParameter("@Tipo", SqlDbType.VarChar);
		param5.Direction = ParameterDirection.Input;
		param5.Value = textBoxTipo.Text;
		param5.Size = 50;
		cmd.Parameters.Add(param5);

		var param6 = new SqlParameter("@FechaIngreso", SqlDbType.Date);
		param6.Direction = ParameterDirection.Input;
		param6.Value = textBoxFechaIngreso.Text;
		cmd.Parameters.Add(param6);

		var param7 = new SqlParameter("@Area", SqlDbType.VarChar);
		param7.Direction = ParameterDirection.Input;
		param7.Value = textBoxArea.Text;
		param7.Size = 50;
		cmd.Parameters.Add(param7);

		cmd.ExecuteNonQuery();
		conexion.Close();

		MessageBox.Show("Funcionario actualizado correctamente");

	}

	public void BorrarFuncionario()
	{
		try
		{
			/*System.Data.SqlClient.SqlConnection conexion = new System.Data.SqlClient.SqlConnection();
			conexion.ConnectionString = "Data Source=WIN-1SDP8NVLN2A\\SA;Initial Catalog=Progra 3;Persist Security Info=True;User ID=;Password=";
			conexion.Open();*/

			SqlCommand cmd = new SqlCommand("dbo.eliminaFuncionario", conexion);
			cmd.CommandType = CommandType.StoredProcedure;

			var param1 = new SqlParameter("@IDFuncionario", SqlDbType.Int);
			param1.Direction = ParameterDirection.Input;
			param1.Value = textBoxIDFuncionario.Text;
			cmd.Parameters.Add(param1);

			cmd.ExecuteNonQuery();

			conexion.Close();

			MessageBox.Show("Se ha borrado el Funcionario");
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());

		}
	}
}

