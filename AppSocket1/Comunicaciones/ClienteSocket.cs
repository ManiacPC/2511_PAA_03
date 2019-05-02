using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AppSocket1.Comunicaciones
{
    public class ClienteSocket
    {
        private Socket cliente;
        //enviar datos al socket
        private StreamWriter writer;
        //recibir datos desde el socket
        private StreamReader reader;

        public ClienteSocket(Socket cliente)
        {
            this.cliente = cliente;
            Stream stream = new NetworkStream(this.cliente);
            this.writer = new StreamWriter(stream);
            this.reader = new StreamReader(stream);
        }

        public string Leer()
        {
            try
            {
                return reader.ReadLine().Trim();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void Escribir(string mensaje)
        {
            try
            {
                this.writer.WriteLine(mensaje);
                this.writer.Flush();
            }
            catch (Exception ex)
            {

            }
        }

        public void DesconectarCliente()
        {
            try
            {
                this.cliente.Close();
            }
            catch (Exception ex)
            {

            }
        }

    }
}
