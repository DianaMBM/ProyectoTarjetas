using System.Security.Cryptography;

namespace WebApi.Helpers
{
    public class RandomGen
    {
        private static RNGCryptoServiceProvider _global = new RNGCryptoServiceProvider();
        [ThreadStatic] // Permite una copia en particular por hilo en una variable
        private static Random _local;

        public static double NextDouble() // Método para obtener un número de manera aleatoria
        {
            Random inst = _local;
            if (inst == null)
            {
                byte[] buffer = new byte[4];
                _global.GetBytes(buffer);
                _local = inst = new Random(BitConverter.ToInt32(buffer, 0));
            }

            // Nos devuelve un valor entre 0 y 1
            return inst.NextDouble();
        }
    }
}
