using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace serialRoleAcmaKapama
{
    public class serialRoleAcKapa
    {


        public SerialPort serialPort;
        public bool portDurum = false;
        public string[] portNames;

        public serialRoleAcKapa()
        {
        }
        public serialRoleAcKapa(string portName)
        {
            serialPort = new SerialPort(portName, 9600);
            serialPort.Open();

        }
        public void serialPortAc(string portName)
        {
            serialPort = new SerialPort(portName, 9600);
            serialPort.Open();
        }

        public void serialPortKapat()
        {
            serialPort.Close();
        }

        public bool serialPortAcikMi(SerialPort serialPort)
        {
            bool portDurum = false;

            if (serialPort.IsOpen)
            {
                portDurum = true;
            }
            else
            {
                portDurum = false;
            }

            return portDurum;
        }

        public string[] acikPortlariGetir()
        {
            portNames = SerialPort.GetPortNames();
            return portNames;
        }

        public void roleAc(string roleHarf)
        {
            serialPort.Write(roleHarf);
        }

        public void roleKapa(string roleNo)
        {
            serialPort.Write(roleNo);
        }

        public void roleHepsiKapan()
        {
            serialPort.Write("0");
        }

        public void roleAcKapa(string roleNo)
        {
            if (portDurum == false)
            {
                acKapa(roleNo, true);
                portDurum = true;
            }
            else
            {
                acKapa(roleNo, false);
                portDurum = false;
            }
        }
        public void acKapa(string roleNo, bool acKapa)
        {
            if (roleNo == "1" && acKapa == true)
            {
                serialPort.Write("a");
            }
            else if (roleNo == "1" && acKapa == false)
            {
                serialPort.Write("1");
            }
            else if (roleNo == "2" && acKapa == true)
            {
                serialPort.Write("b");
            }
            else if (roleNo == "2" && acKapa == false)
            {
                serialPort.Write("2");
            }
            else if (roleNo == "3" && acKapa == true)
            {
                serialPort.Write("c");
            }
            else if (roleNo == "3" && acKapa == false)
            {
                serialPort.Write("3");
            }
            else if (roleNo == "4" && acKapa == true)
            {
                serialPort.Write("d");
            }
            else if (roleNo == "4" && acKapa == false)
            {
                serialPort.Write("4");
            }
            else if (roleNo == "5" && acKapa == true)
            {
                serialPort.Write("e");
            }
            else if (roleNo == "5" && acKapa == false)
            {
                serialPort.Write("5");
            }
            else if (roleNo == "6" && acKapa == true)
            {
                serialPort.Write("f");
            }
            else if (roleNo == "6" && acKapa == false)
            {
                serialPort.Write("6");
            }
            else if (roleNo == "7" && acKapa == true)
            {
                serialPort.Write("g");
            }
            else if (roleNo == "7" && acKapa == false)
            {
                serialPort.Write("7");
            }
            else if (roleNo == "8" && acKapa == true)
            {
                serialPort.Write("h");
            }
            else if (roleNo == "8" && acKapa == false)
            {
                serialPort.Write("8");
            }

        }

    }
}