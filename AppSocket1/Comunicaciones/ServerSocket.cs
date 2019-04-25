using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AppSocket1.Comunicaciones
{
    class ServerSocket
    {
        private int puerto;
        private Socket servidor;

        public ServerSocket(int puerto)
        {
            this.puerto = puerto;
        }

        public bool Iniciar()
        {
            try
            {
                //1. Construir el Servidor
                this.servidor = new Socket(AddressFamily.InterNetwork
                    , SocketType.Stream, ProtocolType.Tcp);

                //2. Definir donde escucha y a quien escucha
                this.servidor.Bind(new IPEndPoint(IPAddress.Any, this.puerto));
                //3. Determinar cuanto es su capacidad límite de Clientes
                this.servidor.Listen(10);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Socket ObtenerCliente()
        {
            try
            {
                return this.servidor.Accept();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Detener()
        {
            try
            {
                this.servidor.Close();
            }
            catch (Exception ex)
            {

            }
        }

    }
}
