# Proyecto Motos

## Instrucciones para descargar el código

Si deseas descargar el código fuente de este repositorio sin usar Git, sigue estos sencillos pasos:

1. Ve a la página principal del repositorio en GitHub.
2. Haz clic en el botón verde que dice **"Code"**.
3. Selecciona la opción **"Download ZIP"**.
4. Extrae el archivo ZIP descargado en tu equipo local.

¡Y listo! Ya tendrás el código disponible en tu computadora.

---

## Modificación de la cadena de conexión

Para configurar correctamente la conexión a la base de datos en el módulo **Motos**, sigue las siguientes instrucciones:

1. Navega al archivo `web.config` en la raíz del módulo **Motos**.
2. Modifica la sección de las **connectionStrings** con la información de tu servidor de base de datos.

```xml
<connectionStrings>
  <add name="cadena" 
       providerName="System.Data.ProviderName" 
       connectionString="Data source=MSI_LAPTOP\MSSERVERLUIS;Initial Catalog=Motos; Integrated Security=true" />
</connectionStrings>
