using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Business.Helpers
{
    class SimplyAssemblyLoader : MarshalByRefObject
    {
        private Assembly _assembly;

        public void Load(string path)
        {
            Assembly.Load(path);
        }

        public void LoadFrom(string path)
        {
            ValidatePath(path);

            _assembly = Assembly.LoadFrom(path);
        }

        public void LoadFromStream(Stream stream)
        {
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);

            _assembly = Assembly.Load(data);
        }

        public void LoadFromByteArray(byte[] stream)
        {
            _assembly = Assembly.Load(stream);
        }

        public object LoadFromAndExecute(string path, Type type, string methodName, object[] parameters)
        {
            ValidatePath(path);
            var assembly = Assembly.LoadFrom(path);
            foreach (Type item in assembly.GetTypes())
            {
                if (!item.IsClass) continue;
                if (item.GetInterfaces().Contains(type))
                {
                    var objectLoaded = Activator.CreateInstance(item);
                    var method = type.GetMethod(methodName);
                    return method.Invoke(objectLoaded, parameters);
                    break;
                }
            }
            throw new ArgumentException(String.Format("path \"{0}\" does not exist", path));

        }

        public object Execute(Type type, string methodName, object[] parameters)
        {

            foreach (Type item in _assembly.GetTypes())
            {
                if (!item.IsClass) continue;
                if (item.GetInterfaces().Contains(type))
                {
                    var objectLoaded = Activator.CreateInstance(item);

                    var method = type.GetMethod(methodName);
                    return method.Invoke(objectLoaded, parameters);
                    break;
                }
            }
            throw new ArgumentException(String.Format("Method Error does not exist"));

        }

        public object ExecuteWithConstructor(Type type, Type ctorType, string methodName, object[] ctorParameters,
            object[] parameters)
        {

            foreach (Type item in _assembly.GetTypes())
            {
                if (!item.IsClass) continue;
                if (item.GetInterfaces().Contains(type))
                {
                    var ctor = item.GetConstructor(new[] { ctorType });

                    var objectLoaded = ctor.Invoke(ctorParameters);

                    var method = type.GetMethod(methodName);
                    return method.Invoke(objectLoaded, parameters);
                    break;
                }
            }
            throw new ArgumentException(String.Format("Method Error does not exist"));

        }

        private void ValidatePath(string path)
        {
            if (path == null) throw new ArgumentNullException("path");
            if (!System.IO.File.Exists(path))
                throw new ArgumentException(String.Format("path \"{0}\" does not exist", path));
        }
    }
}
