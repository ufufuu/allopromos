@section scripts
$(function () {
    var = chat = $.connection.chatHub;
    chat.client.addNewMessageToPage = function (name, message) {
        $('#discussion').append('<ul style="list-style-type:square"><li>+'
            '<strong style="color:red;font-' +
            'size:medium;text-tansform:uppercase">' + htmlEncode(name) + ' ' + '<strong style="color:black;font-
            style: normal; font - size: medium; text - transform: uppercase">');};
        $('#displayName').val(prompt('Your Name :', ''));
        $('#message').focus();
        $.connection.hub.start().done(function () {
            $('#sendMessage').click(function () {
                chat.server.send($('#displayName').val(), $('#message').val());
                $('#message').val('').focus();
            })
        });
    }

});
function htmlEncode(value) {
    var encodedValue = $('<div />').text(value).html();
    return encodedValue;
}

var connection = $.hubconnection("/signalr", { useDefaultpath: false });


//Drivers Connection Pool
//1 CLient sends Request to Server for PickUp or Transport 
//2 Server receives message and Forwards Message to Connection Clients in Drivers Pool
//3 Clients in the Driver Pools Receive message and One Send the Message back to Server
//4 Server then Forward back the Message to 1st CLietn

//Multiple or Single Hub Class 


//Client Side Library JS in Visual Studio or NUget ?
// or Nuget ?



//Owun - Microsoft.Owin - aspnet SignalCore (3)--

// c-sharpcorner:
// SignalR Message conversation App 
//Using asp.Net MVC 5 in Real Time Scenario