function createHub(url) {
    const hubConnection = new signalR.HubConnectionBuilder()
        .withUrl(url)
        .build();
    return hubConnection;
}