using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnalizadorDeReportes
{
    /// <summary>
    /// Esta clase la voy a utilizar para analizar todos los ficheros de base de datos que hay en un directorio especifico. 
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
                    //Lanzar un mensaje o excepcion diciendo que que no se han encontrado ficheros que cumplan con la extension que se necesita.
                }
            }
            else
            {
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
                    //Lanzar un mensaje o excepcion diciendo que que no se han encontrado ficheros que cumplan con la extension que se necesita.
                    return false;
                }
            }
            else
            {
                //Daras el berro para que sepan que ese directorio no existe tirando una excepcion o algo asi
                return false;
            }
        }



        //Miembros Privados de la clase aqui
        private List<String> Ficheros = new List<string>();
        private string DirectorioDeTrabajo;
    }
}
