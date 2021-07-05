using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.IO;
using System.Net.NetworkInformation;

namespace WinUtil
{
    public class clsCaracteristicas
    {
        public string GPU()
        {
            string Gpu;
            Gpu = "Caracteristicas de la GPU" + Environment.NewLine;
            Gpu += "" + Environment.NewLine;

            ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_VideoController");

            foreach (ManagementObject obj in myVideoObject.Get())
            {
                Gpu += "Nombre  -  " + obj["Name"] + Environment.NewLine;
                Gpu += "Estado  -  " + obj["Status"] + Environment.NewLine;
                Gpu += "Título  -  " + obj["Caption"] + Environment.NewLine;
                Gpu += "ID del dispositivo  -  " + obj["DeviceID"] + Environment.NewLine;
                Gpu += "Adaptador de RAM  -  " + obj["AdapterRAM"] + Environment.NewLine;
                Gpu += "Tipo de adaptador DAC  -  " + obj["AdapterDACType"] + Environment.NewLine;
                Gpu += "Monocromo  -  " + obj["Monochrome"] + Environment.NewLine;
                Gpu += "Controladores de pantalla instalados  -  " + obj["InstalledDisplayDrivers"] + Environment.NewLine;
                Gpu += "Versión del controlador  -  " + obj["DriverVersion"] + Environment.NewLine;
                Gpu += "Procesador de video  -  " + obj["VideoProcessor"] + Environment.NewLine;
                Gpu += "Arquitectura de video  -  " + obj["VideoArchitecture"] + Environment.NewLine;
                Gpu += "Tipo de memoria de video  -  " + obj["VideoMemoryType"] + Environment.NewLine;
            }
            Gpu += "" + Environment.NewLine;
            return (Gpu);
        }

        static readonly string[] SizeSuffixes = { " bytes", " KB", " MB", " GB", " TB", " PB", " EB", " ZB", " YB" };

        static string SizeSuffix(Int64 value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return "0.0 bytes"; }

            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            return string.Format("{0:n1} {1}", adjustedSize, SizeSuffixes[mag]);
        }

        public string Disco_Duro()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            string DDrive;



            DDrive = "Caracteristicas del disco duro" + Environment.NewLine;
            DDrive += "" + Environment.NewLine;

            foreach (DriveInfo d in allDrives)
            {
                DDrive += "Unidad " + d.Name + Environment.NewLine;
                DDrive += "  Tipo de unidad: " + d.DriveType + Environment.NewLine;
                if (d.IsReady == true)
                {
                    DDrive += "  Etiqueta de volumen: " + d.VolumeLabel + Environment.NewLine;
                    DDrive += "  Archivo de sistema: " + d.DriveFormat + Environment.NewLine;
                    DDrive += "  Espacio disponible para el usuario actual: " + SizeSuffix(d.AvailableFreeSpace)  + Environment.NewLine;

                    DDrive += "  Espacio total disponible:                " + SizeSuffix(d.TotalFreeSpace) +  Environment.NewLine;

                    DDrive += "  Tamaño total de la unidad:                      " + SizeSuffix(d.TotalSize) + Environment.NewLine;
                    DDrive += "  Directorio raíz:            " + d.RootDirectory + Environment.NewLine;
                }
            }

            DDrive += "" + Environment.NewLine;

            return (DDrive);
        }

        public string Procesadores()
        {
            ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Processor");

            string Processor;
            Processor = "Caracteristicas del procesador " + Environment.NewLine;
            Processor += "" + Environment.NewLine;

            foreach (ManagementObject obj in myProcessorObject.Get())
            {
                Processor += "Nombre  -  " + obj["Name"] + Environment.NewLine;
                Processor += "ID del dispositivo  -  " + obj["DeviceID"] + Environment.NewLine;
                Processor += "Fabricante  -  " + obj["Manufacturer"] + Environment.NewLine;
                Processor += "Velocidad actual del reloj  -  " + obj["CurrentClockSpeed"] + Environment.NewLine;
                Processor += "Título  -  " + obj["Caption"];
                Processor += "Numero de nucleos  -  " + obj["NumberOfCores"] + Environment.NewLine;
                Processor += "Número de núcleos habilitados  -  " + obj["NumberOfEnabledCore"] + Environment.NewLine;
                Processor += "Numero de procesadores lógicos  -  " + obj["NumberOfLogicalProcessors"] + Environment.NewLine;
                Processor += "Arquitectura  -  " + obj["Architecture"] + Environment.NewLine;
                Processor += "Familia  -  " + obj["Family"] + Environment.NewLine;
                Processor += "Tipo de procesador  -  " + obj["ProcessorType"] + Environment.NewLine;
                Processor += "Características  -  " + obj["Characteristics"] + Environment.NewLine;
                Processor += "Ancho de dirección  -  " + obj["AddressWidth"] + Environment.NewLine;
            }

            Processor += "" + Environment.NewLine;

            return (Processor);
        }

        public string SO()
        {
            ManagementObjectSearcher myOperativeSystemObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

            string SisOP;
            SisOP = "Caracteristicas del sistema operativo" + Environment.NewLine;
            SisOP += "" + Environment.NewLine;

            foreach (ManagementObject obj in myOperativeSystemObject.Get())
            {
                SisOP += "Nombre  -  " + obj["Caption"] + Environment.NewLine;
                SisOP += "Dirección de Windows  -  " + obj["WindowsDirectory"] + Environment.NewLine;
                SisOP += "Tipo de producto  -  " + obj["ProductType"] + Environment.NewLine;
                SisOP += "Numero de serie  -  " + obj["SerialNumber"] + Environment.NewLine;
                SisOP += "Dirección  -  " + obj["SystemDirectory"] + Environment.NewLine;
                SisOP += "Código de país  -  " + obj["CountryCode"] + Environment.NewLine;
                SisOP += "Zona horaria actual  -  " + obj["CurrentTimeZone"] + Environment.NewLine;
                SisOP += "Nivel de encriptación  -  " + obj["EncryptionLevel"] + Environment.NewLine;
                SisOP += "Tipo de SO  -  " + obj["OSType"] + Environment.NewLine;
                SisOP += "Versión  -  " + obj["Version"] + Environment.NewLine;
            }

            SisOP += "" + Environment.NewLine;

            return (SisOP);
        }

        public string Interfaz_Red()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            string IntNet;
            IntNet = "Caracteristicas de la Interfaz de red" + Environment.NewLine;
            IntNet += "" + Environment.NewLine;

            if (nics == null || nics.Length < 1)
            {
                IntNet += "  No se encontraron interfaces de red " + Environment.NewLine;
            }
            else
            {
                foreach (NetworkInterface adapter in nics)
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    IntNet += "" + Environment.NewLine;
                    IntNet += adapter.Description + Environment.NewLine;
                    IntNet += String.Empty.PadLeft(adapter.Description.Length, '=') + Environment.NewLine;
                    IntNet += "  Tipo de interfaz .......................... : " + adapter.NetworkInterfaceType + Environment.NewLine;
                    IntNet += "  Dirección física ........................ : " + adapter.GetPhysicalAddress().ToString() + Environment.NewLine;
                    IntNet += "  Estado operativo ...................... : " + adapter.OperationalStatus + Environment.NewLine;
                }
            }

            IntNet += "" + Environment.NewLine;

            return (IntNet);
        }

        public string ShowNetworkInterfaces()
        {
            string IPGlobal;
            string IPGlobalNotFound;
            IPGlobal = "Información de las interfaces" + Environment.NewLine;
            IPGlobal += "" + Environment.NewLine;

            IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            IPGlobal += "Información de interfaz para " + computerProperties.HostName + "." + computerProperties.DomainName;
            if (nics == null || nics.Length < 1)
            {
                IPGlobalNotFound = "  Interfaces de red no encontradas." + Environment.NewLine;
                return(IPGlobalNotFound);
            }

            IPGlobal += "  Numero de interfaces .................... : " + nics.Length + Environment.NewLine;

            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                IPGlobal += "" + Environment.NewLine;
                IPGlobal += adapter.Description + Environment.NewLine;
                IPGlobal += String.Empty.PadLeft(adapter.Description.Length, '=');
                IPGlobal += "  Tipo de interfaz .......................... : " + adapter.NetworkInterfaceType + Environment.NewLine;
                IPGlobal += "  Dirección física ........................ : " + adapter.GetPhysicalAddress().ToString() + Environment.NewLine;
                IPGlobal += "  Estado operativo ...................... : " + adapter.OperationalStatus + Environment.NewLine;
                IPGlobal += "" + Environment.NewLine;
                string versions = "";

                // Create a display string for the supported IP versions.
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    versions = "IPv4";
                    IPGlobal += "IPv4" + Environment.NewLine;
                }
                if (adapter.Supports(NetworkInterfaceComponent.IPv6))
                {
                    if (versions.Length > 0)
                    {
                        versions += " ";
                        IPGlobal += " " + Environment.NewLine;
                    }
                    IPGlobal += "IPv6" + Environment.NewLine;
                    versions += "IPv6";
                }
                IPGlobal += "  Version IP .............................. : " + versions + Environment.NewLine;
                //ShowIPAddresses(properties);

                // The following information is not useful for loopback adapters.
                if (adapter.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                {
                    continue;
                }
                IPGlobal += "  Sufijo DNS .............................. : " + properties.DnsSuffix + Environment.NewLine;

                string label = "";
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    IPv4InterfaceProperties ipv4 = properties.GetIPv4Properties();
                    IPGlobal += "  MTU...................................... : " + ipv4.Mtu + Environment.NewLine;
                    if (ipv4.UsesWins)
                    {

                        IPAddressCollection winsServers = properties.WinsServersAddresses;
                        if (winsServers.Count > 0)
                        {
                            label += "  Servidores WINS ............................ :";
                            //ShowIPAddresses(label, winsServers);
                        }
                    }
                }

                IPGlobal += "  DNS habilitado ............................. : " + properties.IsDnsEnabled +  Environment.NewLine;
                IPGlobal += "  DNS configurado dinámicamente .............. : " + properties.IsDynamicDnsEnabled + Environment.NewLine;
                IPGlobal += "  Reciba sólo ............................ : " + adapter.IsReceiveOnly + Environment.NewLine;
                IPGlobal += "  Multidifusión ............................... : " + adapter.SupportsMulticast + Environment.NewLine;
            }

            IPGlobal += "" + Environment.NewLine;

            return (IPGlobal);
        }

        public string Tarjeta_Sonido()
        {
            ManagementObjectSearcher myAudioObject = new ManagementObjectSearcher("select * from Win32_SoundDevice");

            string CardSound;
            CardSound = "Características de la tarjeta de sonido" + Environment.NewLine;
            CardSound += "" + Environment.NewLine;

            foreach (ManagementObject obj in myAudioObject.Get())
            {
                CardSound += "Nombre  -  " + obj["Name"] + Environment.NewLine;
                CardSound += "Nombre del producto  -  " + obj["ProductName"] + Environment.NewLine;
                CardSound += "Disponibilidad  -  " + obj["Availability"] + Environment.NewLine;
                CardSound += "ID del dispositivo  -  " + obj["DeviceID"] + Environment.NewLine;
                CardSound += "Administración de energía compatible  -  " + obj["PowerManagementSupported"] + Environment.NewLine;
                CardSound += "Estado  -  " + obj["Status"] + Environment.NewLine;
                CardSound += "Información de estado  -  " + obj["StatusInfo"] + Environment.NewLine;
                CardSound += String.Empty.PadLeft(obj["ProductName"].ToString().Length, '=') + Environment.NewLine;
            }

            CardSound += "" + Environment.NewLine;

            return (CardSound);
        }

        public string Impresoras()
        {
            ManagementObjectSearcher myPrinterObject = new ManagementObjectSearcher("select * from Win32_Printer");

            string Printer;
            Printer = "Características de la impresora" + Environment.NewLine;
            Printer += "" + Environment.NewLine;

            foreach (ManagementObject obj in myPrinterObject.Get())
            {
                Printer += "Name  -  " + obj["Name"] + Environment.NewLine;
                Printer += "Network  -  " + obj["Network"] + Environment.NewLine;
                Printer += "Availability  -  " + obj["Availability"] + Environment.NewLine;
                Printer += "Is default printer  -  " + obj["Default"] + Environment.NewLine;
                Printer += "DeviceID  -  " + obj["DeviceID"] + Environment.NewLine;
                Printer += "Status  -  " + obj["Status"] + Environment.NewLine;

                Printer += String.Empty.PadLeft(obj["Name"].ToString().Length, '=') + Environment.NewLine;
            }

            Printer += "" + Environment.NewLine;

            return (Printer);
        }
    }

}
