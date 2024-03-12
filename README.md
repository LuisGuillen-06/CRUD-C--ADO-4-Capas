# CRUD en 4 Capas con C# .NET Framework y SQL Server

Este proyecto es un CRUD (Create, Read, Update, Delete) desarrollado en C# utilizando el framework .NET y SQL Server para la gestión de una base de datos.

## Descripción

El proyecto implementa un CRUD con una arquitectura de cuatro capas:

1. Capa de Presentación
2. Capa de Dominio
3. Capa de Acceso a Datos
4. Capa de Base de Datos

Cada capa tiene una responsabilidad específica en la aplicación, lo que facilita la escalabilidad y el mantenimiento del código.

## Configuración de la conexión a la base de datos y Ejecucion del Proyecto

La conexión a la base de datos está configurada dentro del código en la clase `Connection_DB` en el espacio de nombres `DataAccess.Connection`. Para modificar la configuración de conexión, sigue estos pasos:

1. Abre el proyecto en Visual Studio.
2. Navega hasta la clase `Connection_DB` dentro del directorio `DataAccess/Connection`.
3. Busca la cadena de conexión en el constructor de la clase.
4. Modifica la cadena de conexión según tu entorno de base de datos.
5. Compila y ejecuta la aplicación desde Visual Studio.

    Ahora estás listo para comenzar a utilizar el CRUD en tu entorno de desarrollo.

```csharp
private SqlConnection c = new SqlConnection("Data Source=.\\sql2022;Initial Catalog=CRUD_N_CAPAS;Integrated Security=True");
