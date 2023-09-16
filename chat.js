// JavaScript source code

" use connection";

var connection = new signalR.HubConntectionBuilder().withUrl("chatHub").build();

//Disable Send Button until connection is established

var sendBtn = document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement();

    document.getElementById("messageList").appendChild(li);

    li.textContent = `${user} says {message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = true;
}).catch(function (err) {
    return console.error(err.toString())
});
document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value

    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});