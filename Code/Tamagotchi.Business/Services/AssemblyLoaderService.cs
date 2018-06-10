using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Tamagotchi.Business.Services
{
    public class AssemblyLoaderService : MarshalByRefObject
    {
        private Assembly _assembly;

        public void Load(string path)
        {


            Assembly.Load(path);
        }

        public void LoadFrom(string path)
        {
            ValidatePath(path);
            //AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);

            _assembly = Assembly.LoadFrom(path);
        }

        public void LoadFromStream(Stream stream)
        {
            var data = new byte[stream.Length];
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
            foreach (var item in assembly.GetTypes())
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

            foreach (var item in _assembly.GetTypes())
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
            throw new ArgumentException("Method Error does not exist");

        }

        public object ExecuteWithConstructor(Type type, Type ctorType, string methodName, object[] ctorParameters,
            object[] parameters)
        {

            foreach (var item in _assembly.GetTypes())
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
            throw new ArgumentException("Method Error does not exist");

        }

        private void ValidatePath(string path)
        {
            if (path == null) throw new ArgumentNullException("path");
            if (!File.Exists(path))
                throw new ArgumentException(String.Format("path \"{0}\" does not exist", path));
        }
    }
}