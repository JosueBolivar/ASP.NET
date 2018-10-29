using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WebLiga.Business
{
    public class GeneralBusiness
    {
        public string key = "1j7ed58de46l20cW";

        public string Encriptar(string cadena)
        {
            //arreglo de bytes donde guardaremos la llave
            byte[] keyArray;
            //arreglo de bytes donde guardaremos el texto
            //que vamos a encriptar
            byte[] Arreglo_a_Cifrar = UTF8Encoding.UTF8.GetBytes(cadena);

            //byte[] keyArray;
            byte[] resultArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(cadena);

            //se utilizan las clases de encriptación
            //provistas por el Framework
            //Algoritmo MD5

            using (var md5Serv = System.Security.Cryptography.MD5.Create())
            {
                keyArray = md5Serv.ComputeHash(UTF8Encoding.Unicode.GetBytes(key));
                if (keyArray.Length == 16) {
                    byte[] tmp = new byte[24];
                    Buffer.BlockCopy(keyArray, 0, tmp, 0, keyArray.Length);
                    Buffer.BlockCopy(keyArray, 0, tmp, keyArray.Length, 8);
                    keyArray = tmp;
                }
            }

            //Algoritmo 3DAS
            using (var tdes = System.Security.Cryptography.TripleDES.Create())
            {
                //set the secret key for the tripleDES algorithm
                tdes.Key = keyArray;
                //mode of operation. there are other 4 modes.
                //We choose ECB(Electronic code Book)
                tdes.Mode = CipherMode.ECB;
                //padding mode(if any extra byte added)

                tdes.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tdes.CreateEncryptor();
                //transform the specified region of bytes array to resultArray
                resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            }

            //Return the encrypted data into unreadable string format
            string claver = Convert.ToBase64String(resultArray, 0, resultArray.Length);
            string primera = GeneraClaves();
            string segunda = GeneraClaves();
            string final = primera + claver + segunda;
            return final;
        }

        public string DesEncriptar(string clave)
        {
            try
            {
                if (clave.Length >= 16) {

                    string desc1 = clave.Substring(16, clave.Length - 16);
                    clave = desc1.Substring(0, desc1.Length - 16);

                    byte[] keyArray;
                    byte[] Array_a_Descifrar = Convert.FromBase64String(clave);
                    byte[] resultArray;

                    //se llama a las clases que tienen los algoritmos
                    //de encriptación se le aplica hashing
                    //algoritmo MD5
                    using (var md5Serv = System.Security.Cryptography.MD5.Create())
                    {
                        keyArray = md5Serv.ComputeHash(UTF8Encoding.Unicode.GetBytes(key));
                        if (keyArray.Length == 16) {
                            byte[] tmp = new byte[24];
                            Buffer.BlockCopy(keyArray, 0, tmp, 0, keyArray.Length);
                            Buffer.BlockCopy(keyArray, 0, tmp, keyArray.Length, 8);
                            keyArray = tmp;
                        }
                    }

                    using (var tdes = System.Security.Cryptography.TripleDES.Create())
                    {
                        //set the secret key for the tripleDES algorithm
                        tdes.Key = keyArray;
                        //mode of operation. there are other 4 modes.
                        //We choose ECB(Electronic code Book)
                        tdes.Mode = CipherMode.ECB;
                        //padding mode(if any extra byte added)

                        tdes.Padding = PaddingMode.PKCS7;

                        ICryptoTransform cTransform = tdes.CreateDecryptor();
                        //transform the specified region of bytes array to resultArray
                        resultArray = cTransform.TransformFinalBlock(Array_a_Descifrar, 0, Array_a_Descifrar.Length);
                    }
                    return UTF8Encoding.UTF8.GetString(resultArray);
                } else {
                    return null;
                }
            }
            catch (Exception e)
            {
                //Util.Error(DateTime.Now + "<br />" + e.Message.ToString() + "<br />" + e.Source.ToString() + "<br />" + e.StackTrace.ToString());
                return null;
            }
        }

        private Random _random = new Random(Environment.TickCount);
        public string GeneraClaves()
        {
            int length = 16;
            string chars = "0123456789abcdefghijklmnopqrstuvwxyz/*-%$#{}[]";
            StringBuilder builder = new StringBuilder(length);

            for (int i = 0; i < length; ++i)
                builder.Append(chars[_random.Next(chars.Length)]);

            return builder.ToString();
        }

        public bool IsDate(string cadenaFecha)
        {
            bool isDate = true;
            try
            {
                DateTime fecha = DateTime.Parse(cadenaFecha);
            }
            catch
            {
                isDate = false;
            }
            return isDate;

        }

        public bool IsNull(object Expresion)
        {
            return object.Equals(Expresion, null);
        }

        public bool IsNumeric(object Expresion)
        {
            bool isNum = false;
            double retNum = 0;

            isNum = double.TryParse(Convert.ToString(Expresion), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        public string Mid(string cadena, int desde, int largoCadena)
        {
            string temp = cadena.Substring(desde - 1, largoCadena);
            return temp;
        }

        public string QuitaAcentos(string pTexto)
        {
            string consignos = "áàäéèëíìïóòöúùüñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜÑçÇ- #,´`¨'&\";<>¿?/\\|~‘%*:¡!{}[]$()°¬";
            string sinsignos = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUNcC____________________________________";

            for (int v = 0; v < consignos.Length; v++)
            {
                string i = consignos.Substring(v, 1);
                string j = sinsignos.Substring(v, 1);
                pTexto = pTexto.Replace(i, j);
            }

            return pTexto;
        }

        public bool IsAjaxRequest(HttpRequest request)
        {
            return string.Equals(request.Query["X-Requested-With"], "XMLHttpRequest", StringComparison.Ordinal) ||
                string.Equals(request.Headers["X-Requested-With"], "XMLHttpRequest", StringComparison.Ordinal) ||
                string.Equals(request.Headers["X-Requested-With"], "Fetch", StringComparison.Ordinal);
        }

        public bool validarRut(string rut)
        {
            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }

                if (dv == (char)(s != 0 ? s + 47 : 75)) {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }
    }
}
