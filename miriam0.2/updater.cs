using riku.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace riku
{
    class updater
    {
        public double currentVersion = riku.Properties.Settings.Default.currentVersion;
        public double localVersion = riku.Properties.Settings.Default.localVersion;
        public bool searchOnLoad = riku.Properties.Settings.Default.searchUpdatesonLoad;
        private string url = riku.Properties.Settings.Default.url1;

        public string procesar(string comando)
        {
            try
            {
                string str1 = comando;
                if (!(str1 == "buscar"))
                {
                    if (str1 == "descargar")
                    {
                        this.procesar("buscar");
                        if (this.currentVersion > this.localVersion)
                        {
                            string verxion = this.currentVersion.ToString().Replace(",", ".");
                            string str2 = this.url + "/riku/updates/" + verxion;
                            string targetRoute = System.IO.Directory.GetCurrentDirectory() + "Riku V" + verxion + "\\";
                            string filename = "Riku-v" + verxion + ".exe";
                            if (this.descargar(str2 + "/" + filename, targetRoute, filename))
                                return "-- EL PROGRAMA FUE DESCARGADO CON EXITO, SE ENCUENTRA EN " + targetRoute + " --";
                        }
                    }
                  }
                else if (this.descargar(this.url + "/riku/updates/Versions.txt", Directory.GetCurrentDirectory(), "Versions.txt"))
                {
                    string v2 = ((IEnumerable<string>)this.leer("Versions.txt").Split('|')).Max<string>();
                    string v1 = v2.Replace(".", ",");
                    this.currentVersion = Convert.ToDouble(v2);
                    this.borrar("Versions.txt");
                    if (this.currentVersion <= this.localVersion)
                    {
                        riku.Properties.Settings.Default.currentVersion = this.currentVersion;
                        riku.Properties.Settings.Default.Save();
                        return "-- TIENES LA VERSION MAS ACTUALIZADA --";
                    }
                    else
                    {
                        riku.Properties.Settings.Default.currentVersion = this.currentVersion;
                        riku.Properties.Settings.Default.Save();
                        Console.WriteLine("-- VERSION " + (object)this.currentVersion.ToString() + " DISPONIBLE --");
                        return "-- VERSION " + (object)this.currentVersion + " DISPONIBLE --";
                    }                       
                    
                }
                return "Ups, ha pasado algo inesperado en el proceso de actualizacion.";
               
            }
            catch (Exception)
            {
                return "Ups, ha pasado algo inesperado en el proceso de actualizacion.";
            }
            finally
            {

            }
        }

        public string leer(string textFile)
        {
            return File.ReadAllText(textFile);
        }

        public DateTime getLastUpdateRequest()
        {
            return riku.Properties.Settings.Default.lastRequest;
        }

        public bool setLastUpdateRequest(DateTime fecha)
        {
            try
            {
                riku.Properties.Settings.Default.lastRequest = fecha;
                riku.Properties.Settings.Default.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool autoSearch(bool data)
        {
            try
            {
                riku.Properties.Settings.Default.searchUpdatesonLoad = data;
                riku.Properties.Settings.Default.Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string getReleaseNotes(double version)
        {
            string str = this.url + "/riku/updates/" + (object)version;
            string targetRoute = System.IO.Directory.GetCurrentDirectory() + "Riku V" + (object)version + "\\";
            string filename = "versionInfo.txt";
            if (!this.descargar(str + "/" + filename, targetRoute, filename));
            return "Sin datos extra.";
        }

        public bool descargar(string urlFile, string targetRoute, string filename)
        {
            try
            {
                if (!Directory.Exists(targetRoute))
                    Directory.CreateDirectory(targetRoute);
                Console.WriteLine("-- DESCARGANDO DATOS --");
                new WebClient().DownloadFile(urlFile, targetRoute +"/"+ filename);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("-- ERROR DESCARGANDO DATOS --");
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool borrar(string target)
        {
            try
            {
                System.IO.File.Delete(target);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("-- ERROR ELIMINANDO EL ARCHIVO " + target.ToUpper() + " --");
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
