namespace Patterns.Creational.CacheSingleton
{
    void Main()
    {
        int size = 10;
        Task[] tasks = new Task[size];
        for (int i = 0; i < size; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                var c = MemoryCache.Create();
                if (c.AquireKey("key", "value"))
                {
                    "Save".Dump();
                }
            });
        }
        Task.WaitAll(tasks);
    }

    public class MemoryCache
    {
        private static int i = 0;
        private static MemoryCache _instance;

        private readonly Dictionary<string, string> _registry;

        private static object _lock = new object();

        private MemoryCache()
        {
            _registry = new Dictionary<string, string>();
        }

        public static MemoryCache Create()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        return _instance = new MemoryCache();
                    }
                }
            }

            return _instance;
        }

        public bool Contains(string key, string value)
        {
            return _registry.Contains(KeyValuePair.Create(key, value));
        }

        public void Write(string key, string value)
        {
            _registry[key] = value;
        }

        public bool AquireKey(string key, string value)
        {
            lock (_lock)
            {
                if (Contains(key, value))
                {
                    return false;
                }
                Write(key, value);

                return true;
            }
        }
    }
}
