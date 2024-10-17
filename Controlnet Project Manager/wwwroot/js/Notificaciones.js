
//SCript para realizar la conexion y que se envie la notifacion
var connection;
//Funcion que se llama cada vez que se refresca la pantalla
function initialize(dotnetInstance) {
    //Se establece la conexion con el hub
    connection = new signalR.HubConnectionBuilder().withUrl("/notificacionesHub").build();
    //Se inicia la conexion
    connection.start().then(function () {
    }).catch(function (err) {
        return console.error(err.toString());
    });

    //Se establece el codigo que se ejecutará al llamar a la funcion RecibirNotificacion 
    connection.on("RecibirNotificacion", function () {
        //Lamamos al metodo Notifunc, el cual recibirá un mensaje, que será el cuerpo de la notificacion
        //Llamamos a la instancia pasada por parametros del objeto dotnet
        dotnetInstance.invokeMethodAsync("Notifunc").then(result => { document.getElementById('sound').play(); }).catch(error => {
                console.log("Error al invocar el metodo");
            })       
      }
    );
}

    


