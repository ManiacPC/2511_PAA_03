using AppSocket1.Comunicaciones;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AppSocket1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Obtenemos y convertimos a número el puerto en App.config
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            string ip = ConfigurationManager.AppSettings["ip"];

            // Levantamos un servidor en puerto indicado en App.config
            ServerSocket servidor = new ServerSocket(puerto);

            if (servidor.Iniciar())
            {
                Console.WriteLine($"Escuchando clientes en el puerto {puerto}");
                Socket socketCliente = servidor.ObtenerCliente();
                Console.WriteLine("Nuevo cliente conectado");
                ClienteSocket clienteSocket = new ClienteSocket(socketCliente);


                // Todo OK al iniciar
                while (true)
                {                   
                    clienteSocket.Escribir("Hola mundo");
                    string mensaje = clienteSocket.Leer();


                    if (mensaje.ToLower().Equals("q"))  //mensaje == "q")
                    {
                        clienteSocket.DesconectarCliente();
                        System.Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine($"Respuesta: {mensaje}");
                    }
                }
            }
            else
            {
                // Falló al iniciar
                Console.WriteLine("Falló al iniciar el servidor socket");
            }
        }
    }
}
