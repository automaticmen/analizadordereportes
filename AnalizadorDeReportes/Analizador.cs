using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.OleDb;
using System.Data;
namespace AnalizadorDeReportes
{
    /// <summary>
    /// Esta clase la voy a utilizar para analizar todos los ficheros de base de datos que hay en un directorio especifico. 
    /// Como se utiliza la clase. Debes hacerle saber a la clase en que directorio vas a trabajar. Esto lo puedes hacer pasandole el paramtero de la URL al constructor de la clase o utilizando la fincion setDirectorio.
    /// Tanto el constructor como setDirectorio se encargan de revisar el directorio en busca de ficheros que sirvan para el analisis. de no encontrar ninguno pues te lo harán saber.
    /// Luego de tener un directorio valido con ficheros validos para trbajar pues comienza la acción.
    /// </summary>
    public class Analizador
    {
        /// <summary>
        /// Constructor de la clase, recibe la direccion del directorio que queremos analizar.
        /// </summary>
        /// <param name="directorio">La direccion de donde queremos que se analice la existencia de ficheros o no.</param>
        public Analizador(string directorio)
        {
            //Primero comprobar que el directorio existe antes de hacer nada.
            if (Directory.Exists(directorio))
            {
                //Una variable temporal para alacenar los URLs de los ficheros contenidos en directorio
                List<String> TempFicheros = new List<string>();
                //Leer los ficheros del directorio en forma d elista para despues iterar en buca de los ficheros que necesito
                TempFicheros = Directory.GetFiles(directorio).ToList();
                //Iterando en cada uno de los ficheros y quedandome solo con los ficheros con extension .mdb
                foreach (var item in TempFicheros)
                {
                    if (item.Contains(".mdb"))
                    {
                        Ficheros.Add(item);
                    }
                }
                //Si la lista no está vacia queire decir que puedes trabajar con los ficheros que existen en su interior.
                if (Ficheros.Count != 0)
                {
                    //Inicializar el valor del directorio de trabajo ya que despues lo utilizarás.
                    DirectorioDeTrabajo = directorio;
                }
                else // La lista vacia significa que no hay ficheros con los cuales puedes trabajar.
                {
                    DirectorioDeTrabajo = "NO_VALIDO";
                    //Lanzar un mensaje o excepcion diciendo que que no se han encontrado ficheros que cumplan con la extension que se necesita.
                }
            }
            else
            {
                DirectorioDeTrabajo = "NO_VALIDO";
                throw new AnalizadorException("El directorio no existe");
                //Daras el berro para que sepan que ese directorio no existe tirando una excepcion o algo asi
            }
        }



        /// <summary>
        /// Esta funcion está encargada de establecer un directorio para el trabajo con los reportes. 
        /// verifica si el directorio existe y ademas si hay ficheros con los cuales se puede trabajar. 
        /// Ya de paso incializa la lista de ficheros con los cuales se puede trabajar. IMPORTANTE! Esta fucnion borra los valores de la lista de ficheros. 
        /// </summary>
        /// <param name="directorio">La direccion en la cual estan los ficheros que se queiren analizar</param>
        /// <returns>Verdadero si el fichero existe y ademas tiene ficheros con los cuales se puede trabajar.</returns>
        public bool SetDirectorio(string directorio)
        {
            //Primero comprobar que el directorio existe antes de hacer nada.
            if (Directory.Exists(directorio))
            {
                Ficheros.Clear();//Limpiar la lista de ficheros.
                //Una variable temporal para alacenar los URLs de los ficheros contenidos en directorio
                List<String> TempFicheros = new List<string>();
                //Leer los ficheros del directorio en forma d elista para despues iterar en buca de los ficheros que necesito
                TempFicheros = Directory.GetFiles(directorio).ToList();
                //Iterando en cada uno de los ficheros y quedandome solo con los ficheros con extension .mdb
                foreach (var item in TempFicheros)
                {
                    if (item.Contains(".mdb"))
                    {
                        Ficheros.Add(item);
                    }
                }
                //Si la lista no está vacia queire decir que puedes trabajar con los ficheros que existen en su interior.
                if (Ficheros.Count != 0)
                {
                    //Inicializar el valor del directorio de trabajo ya que despues lo utilizarás.
                    DirectorioDeTrabajo = directorio;
                    return true;
                }
                else // La lista vacia significa que no hay ficheros con los cuales puedes trabajar.
                {
                    DirectorioDeTrabajo = "NO_VALIDO";
                    throw new AnalizadorException("No hay ficheros mdb en este directorio");
                    //Lanzar un mensaje o excepcion diciendo que que no se han encontrado ficheros que cumplan con la extension que se necesita.
                    return false;
                }
            }
            else
            {
                DirectorioDeTrabajo = "NO_VALIDO";
                //Daras el berro para que sepan que ese directorio no existe tirando una excepcion o algo asi
                return false;
            }
        }


        public bool Analisis()
        {
            if (DirectorioDeTrabajo != "NO_VALIDO")// Se puede trabajar con el directorio porque hay al menos un fichero de los qu equeremos analizar
            {
                foreach (var item in Ficheros)
                {
                    //El nombre de la tabla de la cual voy a sacar la informacion es "RegistroFiltro_USER" entonces necesito obtener cual es el user en cada iteracion. Esta informacion la tengo el path del fichero.
                    // si le doy split utilizando "_" pues es el tercer elemenot del arreglo obtenido.
                    string[] parsed = item.Split('_');
                    //Debo tener un listado de los modos de trabajo de cada usario a analizar.
                    List<string> modosTrabajo = new List<string>();

                    //Para cada uno de los ficheros hay que iterar organizando los datos y escribiendolos  a un fichero excel. Entonces el primer paso logico es crear el fichero excel en el cual voy a escribir :)
                    string strDSN = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = " + item;
                    string strSQL = "SELECT Modo,COUNT(Modo) as Modos FROM RegistroFiltro_" + parsed[2]+" GROUP BY Modo";//Lo primero que necesito saber es cuales son los modos de trabajo que ha realizado la persona que estoy analizando.
                    OleDbConnection myConn = new OleDbConnection(strDSN);
                    OleDbDataAdapter myCmd = new OleDbDataAdapter(strSQL, myConn);
                    myConn.Open();
                    DataSet dtSet = new DataSet();
                    myCmd.Fill(dtSet);
                    //Lo primero es tener un listado de todos los modos de trabajo en ls cuales ha trabajado el usuario para despues hacer el resumen correspondiente.
                    foreach (DataRow fila in dtSet.Tables[0].Rows)
                    {
                        modosTrabajo.Add(fila[0].ToString());
                    }

                    //Luego de que tengo los modos de trabajo en los cuales ha trabajado este usuario pues entonces debo realizar la consulta correspondiente para resumir el trabajo.
                    // La consulta se encarga de sumar los modos de trabajo par aun mismo dia.
                    foreach (string modoTrabajo in modosTrabajo)
                    {
                        //Ahora por cada modo de trabajo encontrado para cada usuario haremos una conculta para resumir el trabajo hecho por tipo de trabajo por dia.
                        strSQL = "SELECT RegistroFiltro_"+parsed[2]+ ".Fecha, Sum(RegistroFiltro_" + parsed[2] + ".[Tiempo Trabajado]) AS TOTALDIARIO,RegistroFiltro_" + parsed[2] + ".[Info Extra] FROM RegistroFiltro_" + parsed[2] + " WHERE ((RegistroFiltro_" + parsed[2] + ".Modo)='"+modoTrabajo+"') GROUP BY RegistroFiltro_" + parsed[2] + ".Fecha, RegistroFiltro_" + parsed[2] + ".[Info Extra] ORDER BY RegistroFiltro_" + parsed[2] + ".Fecha;";
                        OleDbDataAdapter miConsulta = new OleDbDataAdapter(strSQL, myConn);
                        DataSet localDataSet = new DataSet();
                        miConsulta.Fill(localDataSet);
                        DataTable dTable = localDataSet.Tables[0];
                        GuardarComoXLS(dTable, DirectorioDeTrabajo + @"\" + parsed[2]+ "_" + modoTrabajo+ ".xls");

                    }                    
                }
            }
            else
            {
                throw new AnalizadorException("El directorio que ha seleccionado no contiene ficheros mdb");
                //aQUI DAR EL BERRO TIRAR UNA EXCEPCION QUE SE YO :)
            }
            return true;
        }
        
        
        private void GuardarComoXLS(DataTable tabla, string nombreFichero)
        {
            StreamWriter sw = new StreamWriter(nombreFichero, false);
            //Primero los encabezados de la tabla
            for (int i = 0; i < tabla.Columns.Count; i++)
            {
                sw.Write(tabla.Columns[i]);
                if (i < tabla.Columns.Count - 1)
                {
                    sw.Write("\t");//los formatos antiguos de excel interpretan ficheros de texto separados por tabas coo tablas. por esto separamos los elementos utilizano el TAB
                }
            }
            sw.Write(sw.NewLine);//Cambiamos d elinea para escribi los datos de la tabla como tal.
            //Recorriendo cada una de las filas de la tabla
            foreach (DataRow dr in tabla.Rows)
            {

                for (int i = 0; i < tabla.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains('\t'))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < tabla.Columns.Count - 1)
                    {
                        sw.Write("\t");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        //Miembros Privados de la clase aqui
        List<String> Ficheros = new List<string>();
        string DirectorioDeTrabajo = "NO_VALIDO";
    }
}


public class AnalizadorException : Exception
{
    public AnalizadorException(string message)
       : base(message)
    {
    }
}