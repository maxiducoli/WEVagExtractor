using PS2VagTool;
using System.Diagnostics;
using System.Text;

namespace VagExtractor
{
    public  class UtilesVags
    {
        public bool ExtraerArchivosVAG(string pathRA, string vag, string ruta)
        {
            List<long> tempList;
            bool result = false;
            try
            {
                tempList = FindTextOffsets(pathRA, vag); // Offset del archivo
                                                         //uint fileSizeLBA = FileSizeLBA(pathISO, archivo);  // Tamaño del archivo en LBA
                int indice = 1;
                foreach (var item in tempList)
                {
                    try
                    {
                        using (FileStream file = new FileStream(pathRA, FileMode.Open, FileAccess.Read))
                        {
                            // Busco el VAG
                            file.Seek(item + 12, SeekOrigin.Begin);

                            // Leer tamaño del VAG
                            byte[] fileSizeData = new byte[4];
                            file.Read(fileSizeData, 0, 4);
                            Array.Reverse(fileSizeData);
                            int fileSize = (BitConverter.ToInt32(fileSizeData, 0)) ;

                            file.Position = item + 32;
                            byte[] name = new byte[16];
                            file.Read(name, 0, name.Length);

                            
                            // Leer datos del VAG
                            byte[] vagData = new byte[fileSize + 48 ];
                            file.Seek(item, SeekOrigin.Begin);
                            file.Read(vagData, 0, fileSize);

                            // Escribir datos en nuevo archivo VAG
                            string nombre = Encoding.UTF8.GetString(name, 0, name.Length).Trim();
                            nombre = "_" + nombre.Replace("\0","");
                            string archivo = Path.Combine(ruta, nombreContador(indice) + nombre.Trim() + ".vag");
                            File.WriteAllBytes(archivo, vagData);
                            //using (FileStream vagFile = new FileStream(archivo, FileMode.Create, FileAccess.Write))
                            //{
                            //    vagFile.Write(vagData, 0, vagData.Length);
                            //}
                        }
                        indice++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al extraer archivo VAG: " + ex.Message);
                    }
                    result = true;  
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar offsets en el archivo: " + ex.Message);
            }
            return result;
        }
        public List<long> FindTextOffsets(string filePath, string searchText)
        {
            List<long> offsets = new List<long>();

            byte[] searchBytes = Encoding.UTF8.GetBytes(searchText);

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                int bufferSize = 1024;
                byte[] buffer = new byte[bufferSize];
                int bytesRead;
                long position = 0;

                while ((bytesRead = fs.Read(buffer, 0, bufferSize)) > 0)
                {
                    for (int i = 0; i < bytesRead; i++)
                    {
                        if (buffer[i] == searchBytes[0])
                        {
                            bool found = true;
                            for (int j = 1; j < searchBytes.Length; j++)
                            {
                                if (i + j >= bytesRead || buffer[i + j] != searchBytes[j])
                                {
                                    found = false;
                                    break;
                                }
                            }
                            if (found)
                            {
                                offsets.Add(position + i);
                            }
                        }
                    }
                    position += bytesRead;
                }
            }

            return offsets;
        }
        private string nombreContador(int indice)
        {
            string result = string.Empty;
            if (indice.ToString().Length == 1)
                result = "000" + indice.ToString();
            if (indice.ToString().Length == 2)
                result = "00" + indice.ToString();
            if (indice.ToString().Length == 3)
                result = "0" + indice.ToString();

            return result;
        }
        public bool Wav2Vag(string iso,string archivo,string programa,string output,string sali) 
        {
        bool result    = false;
            string error = string.Empty;
            byte[] tempFile;            
            string salida = string.Empty;
            int cantidadFicheros = 0;
            try
            {
                tempFile = ExtraerArchivo(iso, archivo);

                using (FileStream fs = new FileStream(Path.GetTempPath() + archivo, FileMode.Create, FileAccess.Write))
                {
                    fs.Seek(0, SeekOrigin.Begin);
                    fs.Write(tempFile, 0, tempFile.Length);
                }

                if (File.Exists(Path.GetTempPath() + archivo))
                {
                    ExtraerArchivosVAG(Path.GetTempPath() + archivo, "VAGp", output);
                }

                DirectoryInfo fi = new DirectoryInfo(output);
                cantidadFicheros = fi.GetFiles("*.vag").Length;
             
                foreach (FileInfo fileInfo in fi.GetFiles("*.vag"))
                {
                    
                    //ProcessStartInfo processStartInfo = new ProcessStartInfo();
                    salida = sali + "\\" + Path.GetFileNameWithoutExtension(fileInfo.FullName) + ".wav";
                    //processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    //processStartInfo.UseShellExecute = false;
                    //processStartInfo.RedirectStandardOutput = true;
                    //processStartInfo.RedirectStandardError = true;
                    //processStartInfo.RedirectStandardInput = true;
                    //processStartInfo.RedirectStandardOutput = true;
                    //processStartInfo.FileName = "\"" + programa + "\"";
                    //processStartInfo.Arguments = $"{"\"" + fileInfo.FullName + "\""} {"\"" + salida + "\""}";

                    //Process.Start(processStartInfo);
                    ProgramFunctions.ExecuteEncoder("\"" + fileInfo.FullName,salida,false, false);
                }

                if (cantidadFicheros > 0) result = true;
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }

        public long BuscaStringsEnFichero(string archivo, string cadena)
        {
            byte[] array = new byte[8192];
            int length = cadena.Length;
            int num = length - 1;
            long num2 = 0L;
            long result = -1L;
            using (FileStream fileStream = new FileStream(archivo, FileMode.Open, FileAccess.Read))
            {
                int num3;
                while ((num3 = fileStream.Read(array, 0, 8192)) > 0)
                {
                    for (int i = 0; i < num3; i++)
                    {
                        if (array[i] != cadena[0])
                        {
                            continue;
                        }

                        bool flag = true;
                        for (int j = 1; j < length; j++)
                        {
                            if (i + j >= num3 || array[i + j] != cadena[j])
                            {
                                flag = false;
                                break;
                            }
                        }

                        if (flag)
                        {
                            result = num2 + i;
                            return result;
                        }
                    }

                    fileStream.Seek(-num, SeekOrigin.Current);
                    num2 += num3 - num;
                }
            }

            return result;
        }

        private uint StartLBA(string pathISO, string nombreArchivo)
        {
            uint result = 0u;
            using (FileStream fileStream = new FileStream(pathISO, FileMode.Open, FileAccess.Read))
            {
                long num = BuscaStringsEnFichero(pathISO, nombreArchivo);
                byte[] array = new byte[8];
                fileStream.Position = num - 31;
                fileStream.Read(array, 0, array.Length);
                result = BitConverter.ToUInt32(array);
            }

            return result;
        }

        public uint FileSizeBytes(string pathISO, string nombreArchivo)
        {
            uint result = 0u;
            using (FileStream fileStream = new FileStream(pathISO, FileMode.Open, FileAccess.Read))
            {
                long num = BuscaStringsEnFichero(pathISO, nombreArchivo);
                byte[] array = new byte[8];
                fileStream.Position = num - 23;
                fileStream.Read(array, 0, array.Length);
                result = BitConverter.ToUInt32(array);
            }

            return result;
        }

        private uint FileSizeLBA(string pathISO, string nombreArchivo)
        {
            uint num = 0u;
            uint num2 = 0u;
            num = FileSizeBytes(pathISO, nombreArchivo);
            return (num % 2048 == 0) ? (num / 2048) : (num / 2048 + 1);
        }

        public byte[] ExtraerArchivo(string pathISO, string archivo)
        {
            byte[] array3;
            try
            {
                long num = BuscaStringsEnFichero(pathISO, archivo);
                uint num2 = FileSizeBytes(pathISO, archivo);
                uint num3 = StartLBA(pathISO, archivo);
                uint num4 = FileSizeLBA(pathISO, archivo);
                using FileStream fileStream = new FileStream(pathISO, FileMode.Open, FileAccess.Read);
                byte[] array = new byte[2048];
                byte[] array2 = new byte[num4 * 2048];
                int num5 = (int)(num3 * 2352 + 24);
                fileStream.Position = num5;
                for (int i = 0; i < num4; i++)
                {
                    fileStream.Read(array, 0, 2048);
                    num5 += 2352;
                    fileStream.Position = num5;
                    Array.Copy(array, 0, array2, array.Length * i, array.Length);
                }

                array3 = new byte[num2];
                Array.Copy(array2, array3, array3.Length);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return array3;
        }

        public void InsertarArchivo(string pathISO, string archivoEnIso, string archivo, bool esGrande)
        {
            try
            {
                long num = BuscaStringsEnFichero(pathISO, archivoEnIso);
                uint num2 = FileSizeBytes(pathISO, archivoEnIso);
                uint num3 = StartLBA(pathISO, archivoEnIso);
                uint num4 = FileSizeLBA(pathISO, archivoEnIso);
                int num5 = 0;
                uint num6 = 0u;
                using (FileStream fileStream = File.OpenRead(archivo))
                {
                    long length = fileStream.Length;
                    num5 = (int)length;
                }

                using FileStream fileStream2 = new FileStream(pathISO, FileMode.Open, FileAccess.ReadWrite);
                byte[] array = new byte[2048];
                byte[] array2;
                if (esGrande)
                {
                    array2 = new byte[num5];
                    num6 = (uint)((num5 % 2048 != 0) ? (num5 / 2048 + 1) : (num5 / 2048));
                }
                else
                {
                    array2 = new byte[num4 * 2048];
                    num6 = num4;
                }

                byte[] array3 = File.ReadAllBytes(archivo);
                Array.Copy(array3, array2, array3.Length);
                int num7 = (int)(num3 * 2352 + 24);
                fileStream2.Position = num7;
                for (int i = 0; i < num6; i++)
                {
                    if (num5 >= 2048)
                    {
                        Array.Copy(array2, 2048 * i, array, 0, array.Length);
                    }
                    else
                    {
                        Array.Copy(array2, 2048 * i, array, 0, num5);
                    }

                    fileStream2.Write(array, 0, array.Length);
                    num7 += 2352;
                    fileStream2.Position = num7;
                    array = new byte[2048];
                    num5 -= 2048;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
