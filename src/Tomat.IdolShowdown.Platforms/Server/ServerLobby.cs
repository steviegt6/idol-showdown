using System;
using System.Net;
using IdolShowdown.Platforms;

namespace Tomat.IdolShowdown.Platforms.Server;

public sealed class ServerLobby : PlatformLobbyBase {
    private readonly IPAddress address;
    private readonly int port;
    
    public ServerLobby(IPAddress address, int port) {
        this.address = address;
        this.port = port;
    }

    public ServerLobby(Uri host) : this(Dns.GetHostAddresses(host.Host)[0], host.Port) { }
}
