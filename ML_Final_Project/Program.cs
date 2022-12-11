using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML;
using Microsoft.ML.Data;
using System.Windows.Forms;

namespace ML_Final_Project
{
     class Program
    {
        static readonly string _dataPath = Path.Combine(Environment.CurrentDirectory, "Data", "iris.data");
        static readonly string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "IrisClusteringModel.zip");
        static void Main(string[] args)
        {
            


            try
            {
                var mlContext = new MLContext(seed: 0);

                IDataView dataView = mlContext.Data.LoadFromTextFile<IrisData>(_dataPath, hasHeader: false, separatorChar: ',');
                dataView.Preview();
                var dataList = mlContext.Data.CreateEnumerable<IrisData>(dataView, false);
                var list = dataList.ToList();
                var oneSample = list.ElementAt(1);



                double eps = 0.8;
                int minPts = 3;


                List<List<IrisData>> clusters = DBSCAN.GetClusters(list, eps, minPts);

                Console.Clear();

                
                string op = "0"; //creando variable de seleccion del switch
                while (op != "4")
                {
                    Console.WriteLine("Presione la tecla de la opcion deseada:");
                    Console.WriteLine("1-Mostrar el conjunto de datos");
                    Console.WriteLine("2-Mostrar clusteres");
                    Console.WriteLine("3-Ingresar nuevas caracteristicas");
                    Console.WriteLine("4-Salir");
                    op = Console.ReadLine();


                    switch (op)
                    {
                        case "1": // print points to console
                                  Console.WriteLine("The {0} points are :\n", list.Count);
                                  foreach (IrisData p in list) Console.Write(" {0} \n", p);
                                  Console.WriteLine();
                                  break;
                       
                        case "4":break;
                        
                        default: Console.WriteLine("Opcion incorrecta");
                                 break;




                    }
                }

                // print clusters to console
                int total = 0;
                for (int i = 0; i < clusters.Count; i++)
                {
                    int count = clusters[i].Count;
                    total += count;
                    string plural = (count != 1) ? "s" : "";
                    Console.WriteLine($"\nCluster {i+1} consists of the following {count} point{plural} :\n");
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
                        if (p.ClusterId == IrisData.NOISE) Console.Write(" {0} ", p);
                    }
                    Console.WriteLine();
                }

                else
                {
                    Console.WriteLine("\nNo points are NOISE");
                }
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
                

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
