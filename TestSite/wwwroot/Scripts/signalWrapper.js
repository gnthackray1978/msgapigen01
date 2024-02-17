function SignalWrapper() {
    
}

SignalWrapper.prototype = {
    run: function (signalR, fOutput) {


        const connection = new signalR.HubConnectionBuilder()
            .withUrl("https://msgapiinput01.azurewebsites.net/hub/msgnotificationhub",
                { withCredentials: false })
            .configureLogging(signalR.LogLevel.Information)
            .build();

        async function start() {
            try {
                await connection.start();
                console.log("SignalR Connected.");


            } catch (err) {
                console.log(err);
                setTimeout(start, 5000);
            }
        };

        connection.on("fred", function (user, message) {

            console.log(user + ' ' + message);

        });
        connection.on("Notify", function (user, message) {

            console.log("Notify" + user + ' ' + message);

            if (fOutput) {
                fOutput(user);
            }
            
        });

        connection.on("Update", function (user, message) {

            console.log('update');

            var listItem = $("ul").first();

            if (listItem) {
                listItem.html(user + '<br />');
            } else {
                $('#header').append(user + '<br />');
            }

        });

        connection.onclose(start);

        // Start the connection.
        start();

 
        return true;
    }
}