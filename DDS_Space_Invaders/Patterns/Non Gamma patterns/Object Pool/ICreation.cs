using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Invaders.Patterns.Non_Gamma_patterns.Object_Poll
{
    /// <summary>
    /// Interfaz para usar el pattern "Object Pool" 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICreation<T>
    {
        /// <summary>
        /// Devuelve de nuevo el objeto creado
        /// </summary>
        /// <returns></returns>
        T Create();
    }
}
