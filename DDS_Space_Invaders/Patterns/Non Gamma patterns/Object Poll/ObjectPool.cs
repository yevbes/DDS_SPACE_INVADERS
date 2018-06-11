using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Invaders.Patterns.Non_Gamma_patterns.Object_Poll
{
    /// <summary>
    /// Implementar un conjunto de objetos que usan enlaces "suaves"
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectPool<T> where T : class
    {
        /// <summary>
        /// Objeto de sincronizacion 
        /// </summary>
        private Semaphore semaphore;

        /// <summary>
        /// La colección contiene objetos administrados
        /// </summary>
        private ArrayList pool;

        /// <summary>
        /// Una referencia a un objeto al que se delega la responsabilidad de 
        /// crear objetos de grupo
        /// </summary>
        private ICreation<T> creator;

        /// <summary>
        /// La cantidad de objetos que existen en este momento
        /// </summary>
        private Int32 instanceCount;

        /// <summary>
        /// Número máximo de objetos administrados por el grupo
        /// </summary>
        private Int32 maxInstances;

        /// <summary>
        /// Creando un grupo de objetos
        /// </summary>
        /// <param name="creator">Un objeto al que el grupo delegará 
        /// la responsabilidad de crear objetos que los administre</param>
        public ObjectPool(ICreation<T> creator)
            : this(creator, Int32.MaxValue)
        {
        }

        /// <summary>
        /// Creando un grupo de objetos
        /// </summary>
        /// <param name="creator">Un objeto al que el grupo delegará 
        /// la responsabilidad de crear objetos que los administre</param>
        /// <param name="maxInstances">El número máximo de instancias de clases 
        /// que el grupo permite que existan al mismo tiempo
        /// </param>
        public ObjectPool(ICreation<T> creator, Int32 maxInstances)
        {
            this.creator = creator;
            this.instanceCount = 0;
            this.maxInstances = maxInstances;
            this.pool = new ArrayList();
            this.semaphore = new Semaphore(0, this.maxInstances);
        }

        /// <summary>
        /// Devuelve la cantidad de objetos en el grupo que están esperando ser reutilizados. 
        /// El número real puede ser menor que este valor, 
        /// ya que el valor de retorno es el número de enlaces "suaves" en el grupo.
        /// </summary>
        public Int32 Size
        {
            get
            {
                lock (pool)
                {
                    return pool.Count;
                }
            }
        }

        /// <summary>
        /// Devuelve la cantidad de objetos administrados 
        /// actualmente por el grupo
        /// </summary>
        public Int32 InstanceCount { get { return instanceCount; } }

        /// <summary>
        /// Obtener o establezer el número máximo de objetos 
        /// agrupados que el grupo permite que existan al mismo tiempo.
        /// </summary>
        public Int32 MaxInstances
        {
            get { return maxInstances; }
            set { maxInstances = value; }
        }

        /// <summary>
        /// Devuelve un objeto del grupo. Con un grupo vacío, se creará un objeto 
        /// si el número de objetos administrados por el 
        /// grupo no es mayor o igual que el valor devuelto por el método
        /// <see cref="ObjectPool{T}.MaxInstances"/>. Si el número de objetos administrados por el grupo excede este valor,
        /// este método devuelve un valor nulo
        /// </summary>
        /// <returns></returns>
        public T GetObject()
        {
            lock (pool)
            {
                T thisObject = RemoveObject();
                if (thisObject != null)
                    return thisObject;

                if (InstanceCount < MaxInstances)
                    return CreateObject();

                return null;
            }
        }

        /// <summary>
        /// Devuelve un objeto del grupo. Con un grupo vacío, 
        /// se creará un objeto si el número de objetos administrados 
        /// por el grupo no es mayor o igual que el valor devuelto por el método
        /// <see cref="ObjectPool{T}.MaxInstances"/>. Si el número de objetos administrados 
        /// por el grupo excede este valor, este método esperará 
        /// hasta que algún objeto esté disponible para su reutilización.
        /// </summary>
        /// <returns></returns>
        public T WaitForObject()
        {
            lock (pool)
            {
                T thisObject = RemoveObject();
                if (thisObject != null)
                    return thisObject;

                if (InstanceCount < MaxInstances)
                    return CreateObject();
            }
            semaphore.WaitOne();
            return WaitForObject();
        }

        /// <summary>
        /// Quita un objeto de la colección de grupo y lo devuelve
        /// </summary>
        /// <returns></returns>
        private T RemoveObject()
        {
            while (pool.Count > 0)
            {
                var refThis = (WeakReference)pool[pool.Count - 1];
                pool.RemoveAt(pool.Count - 1);
                var thisObject = (T)refThis.Target;
                if (thisObject != null)
                    return thisObject;
                instanceCount--;
            }
            return null;
        }

        /// <summary>
        /// Crear un objeto administrado por este grupo
        /// </summary>
        /// <returns></returns>
        private T CreateObject()
        {
            T newObject = creator.Create();
            instanceCount++;
            return newObject;
        }

        /// <summary>
        /// Libera un objeto colocándolo en un grupo para su reutilización
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NullReferenceException"></exception>
        public void Release(T obj)
        {
            if (obj == null)
                throw new NullReferenceException();
            lock (pool)
            {
                var refThis = new WeakReference(obj);
                pool.Add(refThis);
                semaphore.Release();
            }
        }
    }
}
