using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using MOpciones;


namespace Menu
{

    public class DVC
    {

        public static void OpenMenu()
        {
            
            string x = "0";

            while (x != "14")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string y;
                Console.WriteLine("Menu DVC:");
                Console.WriteLine("6- Verificar las ramas de trabajo existentes"); ////git branch
                Console.WriteLine("7- Cambiar de rama de trabajo"); ////git swtitch
                Console.WriteLine("8- Mostrar registro de versiones del conjunto de datos en la rama de trabajo actual"); ////git log
                Console.WriteLine("9- Eliminar rama de trabajo"); ////git branch -D
                Console.WriteLine("10- Crear nueva rama de trabajo"); ////git branch -c
                Console.WriteLine("11- Restaurar a una version anterior del conjunto de datos"); ////git checkout y git switch -c
                Console.WriteLine("12- Agregar cambios realizados en el conjunto de datos a la rama de trabajo"); //git add y git commit -m
                Console.WriteLine("13- Verificar diferencias entre el conjunto de datos actual y"); //git diff
                Console.WriteLine("la Última modificacion registrada del mismo");
                Console.WriteLine("14- Salir del Menu DVC");
                x = Console.ReadLine();

                switch (x)
                {

                    case "6":
                        Console.WriteLine("Ramas de trabajo (Se esta trabajando en la rama indicada con *):");
                        Ops.Gitbranch();
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Precione Enter para continuar");
                        break;

                    case "7":
                        Console.WriteLine("Escriba el nombre de la rama a la que dea cambiar:");
                        y = Console.ReadLine();
                        Ops.GitSbranch(y);
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Presione Enter para continuar");
                        break;

                    case "8":
                        Console.WriteLine("A continuacion se mostrara el historial de modificaciones del conjunto de datos:");
                        Console.WriteLine("El formato sera el siguiente:");
                        Console.WriteLine("");
                        Console.WriteLine("Commit: (codigo de confirmacion de la modificacion)");
                        Console.WriteLine("Author: (Nombre y correo del usuario que modifico el conjunto de datos)");
                        Console.WriteLine("Date: (Fecha en la que se realizo esta modificacion)");
                        Console.WriteLine("");
                        Console.WriteLine("(Nombre conferido a la modificacion del conjunto de datos)");
                        Console.WriteLine("Precione Enter para continuar");
                        Console.ReadLine();

                        Ops.Gitlog();

                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Presione Enter para continuar");
                        break;

                    case "9":
                        Console.WriteLine("Escriba el nombre de la rama que desea eliminar:");
                        y = Console.ReadLine();
                        Ops.GitdeleteBranch(y);
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Presione Enter para continuar");
                        break;

                    case "10":
                        Console.WriteLine("Escriba el nombre de la nueva rama a crear:");
                        y = Console.ReadLine();
                        Ops.GitNewBranch(y);
                        Console.WriteLine("La nueva rama creada toma como primera modificacion a");
                        Console.WriteLine("la ultima modificacion registrada en la rama actual");
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Presione Enter para continuar");
                        break;

                    case "11":
                        Console.WriteLine("A continuacion se mostrara el historial de modificaciones del conjunto de datos:");
                        Console.WriteLine("El formato sera el siguiente:");
                        Console.WriteLine("");
                        Console.WriteLine("Commit: (codigo de confirmacion de la modificacion)");
                        Console.WriteLine("Author: (Nombre y correo del usuario que modifico el conjunto de datos)");
                        Console.WriteLine("Date: (Fecha en la que se realizo esta modificacion)");
                        Console.WriteLine("");
                        Console.WriteLine("(Nombre conferido a la modificacion del conjunto de datos)");
                        Console.ReadLine();
                        Ops.Gitlog();
                        Console.ReadLine();
                        Console.WriteLine("Escriba el codigo de confirmacion de la modificacion a la que desea volver:");
                        y = Console.ReadLine();
                        Ops.Gitrestore(y);
                        Console.ReadLine();
                        Console.WriteLine("Escriba el nombre de la nueva rama que se creara a partir de este retroceso:");
                        y = Console.ReadLine();
                        Ops.GitSNewBranch(y);
                        Console.ReadLine();
                        Console.Clear();


                        Console.WriteLine("Presione Enter para continuar");
                        break;


                    case "12":
                        Ops.Gitadd();
                        Console.WriteLine("Escriba el nombre que se le conferira a la modificacion (entre comillas):");
                        y = Console.ReadLine();
                        Ops.Gitcommit(y);
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Presione Enter para continuar");
                        break;


                    case "13":
                        Console.WriteLine("A continuacion se mostrara un mensaje del sistema");
                        Console.WriteLine("A partir de la quinta linea se mostrara el conjunto de datos");
                        Console.WriteLine("Los cambios se mostraran de la siguente manera:");
                        Console.ReadLine();
                        Console.WriteLine("-(lineas eliminadas, en color rojo)");
                        Console.WriteLine("+(lineas añadidas, en color verde)");
                        Console.ReadLine();
                        Ops.Gitdiff();
                        Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine("Presione Enter para continuar");
                        break;

                    case "14":
                        Console.WriteLine("Adios!");
                        break;

                    default:
                        Console.WriteLine("Comando equivocado!!!!!");
                        Console.WriteLine("Presione Enter para volver al menu:");
                        break;

                }

                Console.ReadLine();

            }



        }


    }



}
