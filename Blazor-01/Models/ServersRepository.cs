namespace Blazor_01.Models
{
    public static class ServersRepository
    {
        private static List<Server> servers = new List<Server>()
        {
            new Server {  ServerID = 1, Name = "Server1", City = "Toronto" },
            new Server {  ServerID = 2, Name = "Server2", City = "Toronto" },
            new Server {  ServerID = 3, Name = "Server3", City = "Toronto" },
            new Server {  ServerID = 4, Name = "Server4", City = "Toronto" },
            new Server {  ServerID = 5, Name = "Server5", City = "Montreal" },
            new Server {  ServerID = 6, Name = "Server6", City = "Montreal" },
            new Server {  ServerID = 7, Name = "Server7", City = "Montreal" },
            new Server {  ServerID = 8, Name = "Server8", City = "Ottawa" },
            new Server {  ServerID = 9, Name = "Server9", City = "Ottawa" },
            new Server {  ServerID = 10, Name = "Server10", City = "Calgary" },
            new Server {  ServerID = 11, Name = "Server11", City = "Calgary" },
            new Server {  ServerID = 12, Name = "Server12", City = "Halifax" },
            new Server {  ServerID = 13, Name = "Server13", City = "Halifax" },
            new Server {  ServerID = 14, Name = "Server14", City = "Halifax" },
            new Server {  ServerID = 15, Name = "Server15", City = "Halifax" },
        };

        public static void AddServer(Server server)
        {
            var maxId = servers.Max(s => s.ServerID);
            server.ServerID = maxId + 1;
            servers.Add(server);
        }

        public static List<Server> GetServers() => servers;

        public static List<Server> GetServersByCity(string cityName)
        {
            return servers.Where(s => s.City.Equals(cityName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static Server? GetServerById(int id)
        {
            var server = servers.FirstOrDefault(s => s.ServerID == id);
            if (server != null)
            {
                return new Server
                {
                    ServerID = server.ServerID,
                    Name = server.Name,
                    City = server.City,
                    IsOnline = server.IsOnline
                };
            }

            return null;
        }

        public static void UpdateServer(int serverId, Server server)
        {
            if (serverId != server.ServerID) return;

            var serverToUpdate = servers.FirstOrDefault(s => s.ServerID == serverId);
            if (serverToUpdate != null)
            {
                serverToUpdate.IsOnline = server.IsOnline;
                serverToUpdate.Name = server.Name;
                serverToUpdate.City = server.City;
            }
        }

        public static void DeleteServer(int serverId)
        {
            var server = servers.FirstOrDefault(s => s.ServerID == serverId);
            if (server != null)
            {
                servers.Remove(server);
            }
        }

        public static List<Server> SearchServers(string serverFilter)
        {
            return servers.Where(s => s.Name.Contains(serverFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
