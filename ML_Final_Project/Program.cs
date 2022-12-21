using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Data;
using System.Windows.Forms;
using Menu;

namespace ML_Final_Project
{ 
     class Program
    {
        static readonly string _dataPath = Path.Combine(Environment.CurrentDirectory,"iris.data");
       // static readonly string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "IrisClusteringModel.zip");

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            try
            {
                var mlContext = new MLContext(seed: 0);

                IDataView dataView = mlContext.Data.LoadFromTextFile<IrisData>(_dataPath, hasHeader: false, separatorChar: ',');
                dataView.Preview();
                var dataList = mlContext.Data.CreateEnumerable<IrisData>(dataView, false);
                var list = dataList.ToList();
                

                double eps = 1;
                int minPts = 14;


                List<List<IrisData>> clusters = DBSCAN.GetClusters(list, eps, minPts);              
                
                string op = "0"; //creando variable de seleccion del switch
                while (op != "5")
                {
                    Console.WriteLine("Presione la tecla de la opcion deseada:");
                    Console.WriteLine("1-Mostrar el conjunto de datos");
                    Console.WriteLine("2-Mostrar clusteres");
                    Console.WriteLine("3-Ingresar nuevas caracteristicas");
                    Console.WriteLine("4-Menu DVC");
                    Console.WriteLine("5-Salir");
                    op = Console.ReadLine();


                    switch (op)
                    {
                        case "1": // print points to console
                            Console.WriteLine("The {0} data are :\n", list.Count);
                            foreach (IrisData p in list) Console.Write(" {0} \n", p);
                            Console.WriteLine();
                            Console.WriteLine("Presione una tecla para continuar");
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case "2": // print clusters to console
                            int total = 0;
                            for (int i = 0; i < clusters.Count; i++)
                            {
                                int count = clusters[i].Count;
                                total += count;
                                string plural = (count != 1) ? "s" : "";
                                Console.WriteLine($"\nCluster {i + 1} consists of the following {count} point{plural} :");
                                if (i == 0)
                                    Console.WriteLine("Iris Setosa\n");

                                else if (i == 1)
                                    Console.WriteLine("Iris Versicolor-Iris Virginica\n");

                                else
                                {
                                    Console.WriteLine("Teclee el nombre del cluster");
                                    string cad=Console.ReadLine();
                                }
                                
                                foreach (IrisData p in clusters[i]) Console.Write($" {p} \n");
                                Console.WriteLine();
                            }

                            // print any points which are NOISE
                            total = list.Count - total;
                            if (total > 0)
                            {
                                string plural = (total != 1) ? "s" : "";
                                string verb = (total != 1) ? "are" : "is";
                                Console.WriteLine("\nThe following {0} point{1} {2} NOISE :\n", total, plural, verb);
                                foreach (IrisData p in list)
                                {
                                    if (p.ClusterId == IrisData.NOISE) Console.Write(" {0} \n", p);
                                }
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("\nNo points are NOISE");
                            }
                            Console.WriteLine("Presione una tecla para continuar");
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case "3":   IrisData newIris =new IrisData();
                                    Console.WriteLine("Ingrese el SepalLength: ");
                                    newIris.SepalLength = float.Parse(Console.ReadLine());
                                    Console.WriteLine("Ingrese el SepalWidth: ");
                                    newIris.SepalWidth = float.Parse(Console.ReadLine());
                                    Console.WriteLine("Ingrese el PetalLength: ");
                                    newIris.PetalLength = float.Parse(Console.ReadLine());
                                    Console.WriteLine("Ingrese el PetalWidth: ");
                                    newIris.PetalWidth = float.Parse(Console.ReadLine());
                                    list.Add(newIris);
                               
                                    string archivo = @"C:\Users\raide\source\repos\ML_final_project\ML_Final_Project\bin\x64\Debug\iris.data"; //escribiendo los datos ingresados en el txt 
                                    string newflower = newIris.ToString();
                                    StreamWriter sw = new StreamWriter(archivo, true);
                                    sw.WriteLine(newflower);
                                    sw.Close();
                                    List<List<IrisData>> clusters2 = DBSCAN.GetClusters(list, eps, minPts);


                            Console.WriteLine("Presione una tecla para continuar");
                                  Console.ReadLine();
                                  Console.Clear();
                                  break;

                        case "4": DVC.OpenMenu();
                                  break;

                        case "5": break;

                        default:
                            Console.WriteLine("Opcion incorrecta");
                            Console.ReadLine();
                            Console.Clear();
                            break;

                    }
                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
                Console.WriteLine("presione una tecla");
                Console.ReadKey();
            }
            

    }

    }
}
