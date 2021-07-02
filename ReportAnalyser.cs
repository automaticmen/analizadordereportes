using System;
using System.IO;
using System.Linq;
// Esta clase va a recibir la direccion del lugar donde se encuentran almacenados los ficheros que se desean analizar. Entonces voy a ir poniendo aqui los pasos logicos que creo se deben de seguir:
// 1 - Revisar si en la direccion que ha recibido existen ficheros del tipo base de datos. De no existir pues comnunicarlo al upper level
// 2 - Guardar en un arreglo los nombres de los fichero que se han encontrado.
public class ReportAnalyser
{
    /// <summary>
    /// Miembros privados de la clase
    /// </summary>
    /// 
    private Array pepe;
	public ReportAnalyser()
	{
        Directory.GetFiles("C:/Users/Jorge Aguilera Perez/Desktop/Borrar");
	}
}
