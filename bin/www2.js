var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);

app.get('/', function(req, res){
});

http.listen(3000, function(){
    console.log('listening on *:3000');
});

io.on('connection', function(socket){
    console.log('a user connected');
    socket.on('jump', function(msg){
        console.log(msg["magnitude"]);
        io.emit('jump', msg);
    });
    socket.on('left', function(msg){
        console.log(msg["action"]);
        io.emit('left', msg);
    });
    socket.on('right', function(msg){
        console.log(msg["action"]);
        io.emit('right', msg);
    });
    socket.on('run', function(msg){
        console.log(msg["action"]);
        io.emit('run', msg);
    });
    socket.on('pong', function(data){
        console.log("Pong received from client");
    });

    setTimeout(sendHeartbeat, 25000);
    function sendHeartbeat(){
        setTimeout(sendHeartbeat, 25000);
        io.sockets.emit('ping', { beat : 1 });
    }
    socket.on('disconnect', function(){
        console.log('user disconnected');
    });
});




