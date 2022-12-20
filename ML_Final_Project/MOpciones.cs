using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MOpciones
{

    public class Ops
    {

        public static void Gitbranch()
        {
            ProcessStartInfo r = new ProcessStartInfo();
            r.Arguments = @"/c git branch";
            r.FileName = "cmd.exe";
            r.RedirectStandardOutput = false;
            r.UseShellExecute = false;
            r.WindowStyle = ProcessWindowStyle.Normal;

            Process z = new Process();
            z.StartInfo = r;
            z.Start();
            //z.Close();
        }

        public static void GitSbranch(string rama)
        {
            ProcessStartInfo r = new ProcessStartInfo();
            r.Arguments = @"/c git switch " + rama;
            r.FileName = "cmd.exe";
            r.RedirectStandardOutput = false;
            r.UseShellExecute = false;
            r.WindowStyle = ProcessWindowStyle.Normal;

            Process z = new Process();
            z.StartInfo = r;
            z.Start();
            //z.Close();
        }


        public static void Gitlog()
        {
            ProcessStartInfo r = new ProcessStartInfo();
            r.Arguments = @"/c git log";
            r.FileName = "cmd.exe";
            r.RedirectStandardOutput = false;
            r.UseShellExecute = false;
            r.WindowStyle = ProcessWindowStyle.Normal;

            Process z = new Process();
            z.StartInfo = r;
            z.Start();
            //z.Close();
        }


        public static void Gitadd()
        {

            ProcessStartInfo r = new ProcessStartInfo();
            r.Arguments = "/c git add iris.data";
            r.FileName = "cmd.exe";
            r.RedirectStandardOutput = false;
            r.UseShellExecute = false;
            r.WindowStyle = ProcessWindowStyle.Normal;

            Process z = new Process();
            z.StartInfo = r;
            z.Start();
            //z.Close();


        }


        public static void Gitcommit(string Nombre)
        {

            ProcessStartInfo r = new ProcessStartInfo();
            r.Arguments = "/c git commit -m " + Nombre;
            r.FileName = "cmd.exe";
            r.RedirectStandardOutput = false;
            r.UseShellExecute = false;
            r.WindowStyle = ProcessWindowStyle.Normal;

            Process z = new Process();
            z.StartInfo = r;
            z.Start();
            //z.Close();

        }

        public static void GitdeleteBranch(string rama)
        {

            ProcessStartInfo r = new ProcessStartInfo();
            r.Arguments = "/c git branch -D " + rama;
            r.FileName = "cmd.exe";
            r.RedirectStandardOutput = false;
            r.UseShellExecute = false;
            r.WindowStyle = ProcessWindowStyle.Normal;

            Process z = new Process();
            z.StartInfo = r;
            z.Start();
            //z.Close();


        }

        public static void Gitrestore(string commit)
        {

            ProcessStartInfo r = new ProcessStartInfo();
            r.Arguments = "/c git checkout  " + commit;
            r.FileName = "cmd.exe";
            r.RedirectStandardOutput = false;
            r.UseShellExecute = false;
            r.WindowStyle = ProcessWindowStyle.Normal;

            Process z = new Process();
            z.StartInfo = r;
            z.Start();
            //z.Close();



        }


        public static void GitSNewBranch(string nombre)
        {

            ProcessStartInfo r = new ProcessStartInfo();
            r.Arguments = "/c git switch -c " + nombre;
            r.FileName = "cmd.exe";
            r.RedirectStandardOutput = false;
            r.UseShellExecute = false;
            r.WindowStyle = ProcessWindowStyle.Normal;

            Process z = new Process();
            z.StartInfo = r;
            z.Start();
            //z.Close();

        }



        public static void GitNewBranch(string nombre)
        {

            ProcessStartInfo r = new ProcessStartInfo();
            r.Arguments = "/c git branch -c " + nombre;
            r.FileName = "cmd.exe";
            r.RedirectStandardOutput = false;
            r.UseShellExecute = false;
            r.WindowStyle = ProcessWindowStyle.Normal;

            Process z = new Process();
            z.StartInfo = r;
            z.Start();

            //z.Close();
        }


        public static void Gitdiff()
        {

            ProcessStartInfo r = new ProcessStartInfo();
            r.Arguments = "/c git diff";
            r.FileName = "cmd.exe";
            r.RedirectStandardOutput = false;
            r.UseShellExecute = false;
            r.WindowStyle = ProcessWindowStyle.Normal;

            Process z = new Process();
            z.StartInfo = r;
            z.Start();

            //z.Close();




        }



    }


}